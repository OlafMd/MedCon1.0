define(['angularAMD'], function (angularAMD) {
    angularAMD.directive('addContractDirective', function () {
        return {
            templateUrl:
                'scripts/src/app/doctor/view/addContractTemplate.html',

            scope: {
                assignmentId: '='
            },
            replace: true,
            restrict: 'E',
            controller: addContractController
        };


        function addContractController($scope, $rootScope, $translate, doctorService, ajaxService, validationService, ngDialog, $timeout, $routeParams, $filter, alertsServices, $interval) {

            // ------------------------------------------------ VARIABLES ------------------------------------------
            $scope.contractDatesInvalidList = [];
            $scope.divContainer = false;
            $scope.contracts = [];
            $scope.contract = new Object();
            $scope.contract.doctorID = $routeParams.doctor_id;

            // ------------------------------------------------ DATA RETRIEVAL -------------------------------------

            doctorService.getContractsForDropDown(getContractsForDropDownComplete, errorFunction);

            function getContractsForDropDownComplete(response) {
                $scope.contracts = response;
            };

            if ($scope.assignmentId !== undefined) {
                $scope.contractsDisabled = true;
                doctorService.getDoctorsConsentDetails({ assignmentID: $scope.assignmentId }, getDoctorsConsentDetailsComplete, errorFunction);
            };

            function getDoctorsConsentDetailsComplete(response) {
                $scope.contract = response;
                $scope.selectedContract();
            };

            // ------------------------------------------------ ERROR FUNCTIONS ------------------------------------

            function errorFunction(response) {
                console.log(response);
                alertsServices.ErrorMessage('LABEL_SOMETHING_WENT_WRONG');
            };

            // ------------------------------------------------ SAVE CONTRACT --------------------------------------

            $scope.saveContract = function () {
                if (consentDatesValid()) {
                    doctorService.validateContractOverlaps($scope.contract, validateContractOverlapsComplete, errorFunction);
                };
            };

            function validateContractOverlapsComplete(response) {
                if (response.length !== 0) {
                    $scope.divContainer = true;
                    $scope.overlaps = response;
                } else {
                    doctorService.saveDoctorsConsent($scope.contract, saveDoctorsConsentComplete, errorFunction);
                };
            };

            function saveDoctorsConsentComplete(response) {
                $rootScope.$broadcast('CloseForm', ['CloseContract']);
                alertsServices.SuccessMessage('LABEL_OPERATION_SUCCESSFUL');
            };

            // ------------------------------------------------ VALIDATION -----------------------------------------

            function isConsentStartDateValid() {
                var consentStartDate = getDateFromString($scope.contract.consentStartDate, 'de');
                var isConsentStartDateAfterContractStartDate = consentStartDate >= getDateFromString($scope.contractValidFrom, 'en');
                var isConsentStartDateBeforeContractEndDate = $scope.isContractValidIndefinitely ? true : consentStartDate < getDateFromString($scope.contractValidThrough, 'en');

                return isConsentStartDateAfterContractStartDate && isConsentStartDateBeforeContractEndDate;
            };

            function isConsentEndDateValid() {
                var consentEndDate = getDateFromString($scope.contract.consentEndDate, 'de');
                var isConsentEndDateAfterContractStartDate = consentEndDate >= getDateFromString($scope.contractValidFrom, 'en');
                var isConsentEndDateBeforeContractEndDate = $scope.isContractValidIndefinitely ? true : consentEndDate <= getDateFromString($scope.contractValidThrough, 'en');

                return isConsentEndDateAfterContractStartDate && isConsentEndDateBeforeContractEndDate;
            };

            function isConsentEndDateAfterConsentStartDate() {
                return getDateFromString($scope.contract.consentEndDate, 'de') > getDateFromString($scope.contract.consentStartDate, 'de');
            };

            function consentDatesValid() {
                var allValid = true;

                if (!validationService.isValidDate($scope.contract.consentStartDate)) {
                    allValid = false;
                    $scope.contractStartDateInvalid = true;
                    $scope.contractStartDateNotInContractValidityTimespan = false;

                    $timeout(function () { angular.element('#startdatecontract')[0].focus(); }, 0, false);
                } else {
                    $scope.contractStartDateInvalid = false;

                    if (!isConsentStartDateValid()) {
                        allValid = false;
                        $scope.contractStartDateNotInContractValidityTimespan = true;

                        $timeout(function () { angular.element('#startdatecontract')[0].focus(); }, 0, false);
                    } else {
                        $scope.contractStartDateNotInContractValidityTimespan = false;
                    };
                };

                if (validationService.isNotUndefinedOrNull($scope.contract.consentEndDate) && $scope.contract.consentEndDate !== '∞') {
                    if (!validationService.isValidDate($scope.contract.consentEndDate)) {
                        allValid = false;
                        $scope.contractEndDateInvalid = true;
                        $scope.consentEndDateBeforeConsentStartDate = false;

                        $timeout(function () { angular.element('#endDateContract')[0].focus(); }, 0, false);
                    } else {
                        $scope.contractEndDateInvalid = false;
                        if (!isConsentEndDateValid()) {
                            allValid = false;
                            $scope.contractEndDateNotInContractValidityTimespan = true;

                            $timeout(function () { angular.element('#endDateContract')[0].focus(); }, 0, false);
                        } else {
                            $scope.contractEndDateNotInContractValidityTimespan = false
                            ;
                            if (validationService.isNotUndefinedOrNull($scope.contract.consentStartDate)) {
                                if (!isConsentEndDateAfterConsentStartDate()) {
                                    allValid = false;
                                    $scope.consentEndDateBeforeConsentStartDate = true;

                                    $timeout(function () { angular.element('#endDateContract')[0].focus(); }, 0, false);
                                } else {
                                    $scope.consentEndDateBeforeConsentStartDate = false;
                                };
                            };
                        };
                    };
                };

                $scope.divContainer = !allValid;
                return allValid;
            };

            // ------------------------------------------------ UTIL -----------------------------------------------

            $scope.closeContractForm = function () {
                $scope.contract = undefined;
                $rootScope.$broadcast('CloseForm', ["CloseContract"]);
            };

            $scope.selectedContract = function () {
                if (validationService.isNotUndefinedOrNull($scope.contract.Contract)) {
                    $scope.contractValidFrom = $filter('date')($scope.contract.Contract.ValidFrom, 'MM.dd.yyyy');
                    $scope.contractValidThroughDate = new Date($scope.contract.Contract.ValidThrough);
                    $scope.isContractValidIndefinitely = $scope.contractValidThroughDate.getFullYear() === 1;
                    $scope.contractValidThrough = $scope.isContractValidIndefinitely ? undefined : $filter('date')($scope.contractValidThroughDate, 'MM.dd.yyyy');

                    var contractValidThrough = $scope.isContractValidIndefinitely ? '∞' : $filter('date')($scope.contract.Contract.ValidThrough, 'dd.MM.yyyy');
                    $scope.contractValidityTimespan = $filter('date')($scope.contract.Contract.ValidFrom, 'dd.MM.yyyy') + ' - ' + contractValidThrough;
                };
            };

            $scope.selectedFromDate = function () {
                $scope.consentFromDate = $filter('date')($scope.contract.consentStartDate, 'MM.dd.yyyy')
            };

            function getDateFromString(dateString, format) {
                var dayOrdinal = format === 'de' ? 0 : 1;
                var monthOrdinal = format === 'de' ? 1 : 0;
                var parts = dateString.split('.');
                return new Date(parseInt(parts[2]), parseInt(parts[monthOrdinal]), parseInt(parts[dayOrdinal]), 0, 0, 0, 0);
            };

            $scope.SetClass = function () {
                $('.gray-content-holder').css("overflow", "visible");
            };


            var interval = $interval(function () {
                var element = angular.element('#Contract_value')[0];
                if (element) {
                    $interval.cancel(interval);
                    element.focus();
                }
            }, 20, 100, false);

            // ------------------------------------------------ END ------------------------------------------------
        };
    });
});