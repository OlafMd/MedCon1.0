define(['angularAMD'], function (angularAMD) {
    angularAMD.directive('addGposDirective', function () {
        return {
            templateUrl: 'scripts/src/app/master_data/view/contract_templates/addGposDirectiveTemplate.html',
            scope: {
                onSubmit: '=',
                ngModel: '=',
                gposId: '='
            },
            replace: true,
            restrict: 'E',
            controller: gposDetailController
        };
        function gposDetailController($scope, $rootScope, $translate, contractService, validationService, ngDialog, $timeout, $routeParams, $location, alertsServices, $filter, $interval) {

            // --------------------------------------------------------- VARIABLES --------------------------------------------------------

            var ascending = true;
            var sort_by = "gpos_number";
            $scope.ngModel.waive_with_order = true;
            var previous_state = new Object();
            $scope.isMaster = $rootScope.isMaster;

            $scope.case_types = [
				{ 'display_name': 'LABEL_OP_CASE_TYPE', 'id': 'mm.docconnect.gpos.catalog.operation' },
				{ 'display_name': 'LABEL_AC_CASE_TYPE', 'id': 'mm.docconnect.gpos.catalog.nachsorge' },
				{ 'display_name': 'LABEL_PRE_EXAMINATION_CASE_TYPE', 'id': 'mm.docconnect.gpos.catalog.voruntersuchung' }
            ];

            // ----------------------------------------------------------- INIT -----------------------------------------------------------

            $scope.initializeController = function () {
                contractService.authenicateUser($location.path(), $scope.authenicateUserComplete, $scope.authenicateUserError);
            };

            $scope.authenicateUserComplete = function (response) {
                angular.copy($scope.ngModel, previous_state);
            };

            // ------------------------------------------------------ ERROR FUNCTIONS -----------------------------------------------------

            $scope.authenicateUserError = function (response) {
                $rootScope.activeMenuItem = null;
                $window.location.replace(response.logoutUrl);
            };

            function errorFunction(response) {
                console.log(response);
                alertsServices.ErrorMessage('LABEL_SOMETHING_WENT_WRONG');
            };

            // ------------------------------------------------------- DATA RETRIEVAL ------------------------------------------------------

            $scope.getDrugs = function () {
                return contractService.getContract().covered_drugs;
            };

            $scope.getDiagnoses = function () {
                return contractService.getContract().covered_diagnoses;
            };

            // ------------------------------------------------------------ SAVE -----------------------------------------------------------

            $scope.saveGpos = function () {
                var allValid = true;
                $scope.validationObj = new Object();

                var decimalRegExp = /^\d+\.?\d*$/;
                var intRegExp = /\D/;

                if (!decimalRegExp.test($scope.ngModel.fee_value)) {
                    $scope.feeValueError = true;
                    if (allValid)
                        angular.element('#inFeeInEur')[0].focus();
                    allValid = false;
                } else {
                    $scope.feeValueError = false;
                };

                if (!decimalRegExp.test($scope.ngModel.management_fee_value)) {
                    $scope.managementFeeValueError = true;
                    if (allValid)
                        angular.element('#inManagementFee')[0].focus();
                    allValid = false;
                } else {
                    $scope.managementFeeValueError = false;
                };

                if (contractService.isNotUndefined($scope.ngModel.from_injection) && intRegExp.test($scope.ngModel.from_injection)) {
                    if (allValid)
                        angular.element('#inInjectionsFrom')[0].focus();
                    allValid = false;
                    $scope.fromInjectionError = true;
                } else {
                    $scope.fromInjectionError = false;
                };

                var index = -1;
                for (var i = 0; i < contractService.getContract().gpos_data.length; i++) {
                    var current_gpos = contractService.getContract().gpos_data[i];
                    if (current_gpos.gpos_number === $scope.ngModel.gpos_number && current_gpos.gpos_id !== $scope.ngModel.gpos_id) {
                        index = i;
                        break;
                    };
                };

                if (index !== -1) {
                    $scope.gposNumberExists = true;
                    if (allValid)
                        angular.element('#inGposNumber')[0].focus();

                    allValid = false;
                    $scope.non_unique_gpos_number = new Object();
                    angular.copy($scope.ngModel, $scope.validationObj);
                } else {
                    $scope.gposNumberExists = false;
                };

                index = -1;
                for (var i = 0; i < contractService.getContract().gpos_data.length; i++) {
                    var current_gpos = contractService.getContract().gpos_data[i];

                    var from_inj = $scope.ngModel.from_injection === undefined ? '' : $scope.ngModel.from_injection;

                    if (current_gpos.from_injection == from_inj && current_gpos.gpos_id !== $scope.ngModel.gpos_id &&
                        current_gpos.gpos_type === $scope.ngModel.gpos_type) {

                        // both missing
                        if (!isNotUndefinedNullOrZeroLength($scope.ngModel.drugs) && !isNotUndefinedNullOrZeroLength($scope.ngModel.diagnoses)) {
                            continue;

                            // no diagnoses
                        } else if (!isNotUndefinedNullOrZeroLength($scope.ngModel.diagnoses) && isNotUndefinedNullOrZeroLength($scope.ngModel.drugs)) {
                            if (isNotUndefinedNullOrZeroLength(current_gpos.diagnoses) || !isNotUndefinedNullOrZeroLength(current_gpos.drugs))
                                continue;

                            index = getIndexOfArrayItemInAnotherArray($scope.ngModel.drugs, current_gpos.drugs);
                            if (index !== -1)
                                break;

                            // no drugs
                        } else if (!isNotUndefinedNullOrZeroLength($scope.ngModel.drugs) && isNotUndefinedNullOrZeroLength($scope.ngModel.diagnoses)) {
                            if (isNotUndefinedNullOrZeroLength(current_gpos.drugs) || !isNotUndefinedNullOrZeroLength(current_gpos.diagnoses))
                                continue;

                            index = getIndexOfArrayItemInAnotherArray($scope.ngModel.diagnoses, current_gpos.diagnoses);
                            if (index !== -1)
                                break;

                            //both exist
                        } else if (isNotUndefinedNullOrZeroLength($scope.ngModel.drugs) && isNotUndefinedNullOrZeroLength($scope.ngModel.diagnoses)) {
                            if (!isNotUndefinedNullOrZeroLength(current_gpos.drugs) || !isNotUndefinedNullOrZeroLength(current_gpos.diagnoses))
                                continue;

                            var drugsIndex = getIndexOfArrayItemInAnotherArray($scope.ngModel.drugs, current_gpos.drugs);

                            if (drugsIndex !== -1) {
                                index = getIndexOfArrayItemInAnotherArray($scope.ngModel.diagnoses, current_gpos.diagnoses);
                                if (index !== -1)
                                    break;
                            };
                        };
                    };
                };

                if (index !== -1) {
                    $scope.fromInjectionExists = true;
                    if (allValid)
                        angular.element('#inInjectionsFrom')[0].focus();

                    allValid = false;

                    angular.copy($scope.ngModel, $scope.validationObj);
                } else {
                    $scope.fromInjectionExists = false;
                };

                if (!allValid) {
                    $scope.divContainer = true;
                    return false;
                };

                if (contractService.isNotUndefined($scope.ngModel.drugs) && $scope.ngModel.drugs.length !== 0) {
                    $scope.ngModel.drug_names = $scope.ngModel.drugs.map(function (drug) {
                        return drug.name;
                    }).join(', ');
                } else {
                    $scope.ngModel.drug_names = "-";
                };

                if (contractService.isNotUndefined($scope.ngModel.diagnoses) && $scope.ngModel.diagnoses.length !== 0) {
                    $scope.ngModel.diagnose_names = $scope.ngModel.diagnoses.map(function (diagnose) {
                        return diagnose.expanded_name;
                    }).join(', ');
                } else {
                    $scope.ngModel.diagnose_names = "-";
                };

                $scope.$eval($scope.onSubmit);
            };

            // ------------------------------------------------------------ UTIL -----------------------------------------------------------
            var interval = $interval(function () {
                var element = angular.element('#inGposName')[0];
                if (element) {
                    $interval.cancel(interval);
                    element.focus();
                }
            }, 20, 100, false);

            $scope.closeGposForm = function () {
                $rootScope.$broadcast('CloseForm', {
                    'form': 'gpos',
                    'previous_state': previous_state
                });
            };

            function isNotUndefinedNullOrZeroLength(array) {
                return array !== undefined && array !== null && array.length !== 0;
            };

            function getIndexOfArrayItemInAnotherArray(source_array, queried_array) {
                var index = -1;
                for (var j = 0; j < queried_array.length; j++) {
                    if (source_array.map(function (item) { return item.id }).indexOf(queried_array[j].id) > -1) {
                        index = j;
                        break;
                    };
                };

                return index;
            };

            $scope.isPreexaminationGPOS = function () {
                return $scope.ngModel.gpos_type === 'mm.docconnect.gpos.catalog.voruntersuchung';
            };

            $scope.gposTypeChanged = function () {
                if ($scope.isPreexaminationGPOS()) {
                    $scope.ngModel.drugs = undefined;
                    $scope.ngModel.diagnoses = undefined;
                    $scope.ngModel.waive_with_order = undefined;
                    $scope.ngModel.from_injection = undefined;
                };
            };

            // ----------------------------------------------------------- END ------------------------------------------------------------
        };
    });
});