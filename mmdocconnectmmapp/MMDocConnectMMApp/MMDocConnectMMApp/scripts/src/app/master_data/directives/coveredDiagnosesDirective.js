define(['angularAMD'], function (angularAMD) {

    angularAMD.directive('coveredDiagnosesDirective', function () {

        return {

            templateUrl: 'scripts/src/app/master_data/view/contract_templates/coveredDiagnosesTemplate.html',
            scope: {
                mode: '='
            },
            replace: true,
            restrict: 'E',
            controller: coveredDiagnosesController
        };
        function coveredDiagnosesController($scope, $rootScope, $translate, contractService, validationService, ngDialog, $timeout, $routeParams, $location, alertsServices, $filter) {

            // --------------------------------------------------------- VARIABLES --------------------------------------------------------

            var ascending = true;
            var sort_by = 'name';
            $scope.diagnoses = [];

            // ----------------------------------------------------------- INIT -----------------------------------------------------------

            $scope.initializeController = function () {
                contractService.authenicateUser($location.path(), $scope.authenicateUserComplete, $scope.authenicateUserError);
            };

            $scope.authenicateUserComplete = function (response) {
                if (!contractService.isNotUndefined(contractService.getContract().covered_diagnoses))
                    contractService.getContract().covered_diagnoses = [];

                $scope.diagnoses = contractService.getContract().covered_diagnoses;
            };

            // ---------------------------------------------------------- SAVE  -----------------------------------------------------------

            $scope.addDiagnose = function (selectedObject) {
                $scope.diagnose_to_add = selectedObject.originalObject;
                if ($scope.diagnose_to_add === undefined) {
                    $scope.showErrorMessageContainer = undefined;
                };
            };

            $scope.addDiagnoseToList = addDiagnoseToList;

            function addDiagnoseToList() {
                if ($scope.diagnose_to_add !== undefined && $scope.diagnoses.map(function (diagnose) { return diagnose.id; }).indexOf($scope.diagnose_to_add.id) === -1) {
                    $scope.diagnoses.push($scope.diagnose_to_add);
                    $scope.diagnoses = $filter('orderBy')($scope.diagnoses, sort_by, !ascending);
                    contractService.getContract().covered_diagnoses = $scope.diagnoses;
                    $scope.diagnose_to_add = undefined;
                    $rootScope.$broadcast('angucomplete-alt:clearInput');
                } else {
                    if ($scope.diagnose_to_add !== undefined) {
                        $scope.showErrorMessageContainer = true;
                    } else {
                        $scope.showErrorMessageContainer = undefined;
                    };
                };

                $scope.$digest();
            };

            // ---------------------------------------------------------- REMOVE ----------------------------------------------------------

            $scope.removeDiagnose = function (item) {
                $scope.id_to_remove = item.id;
                alertsServices.RenderConfirmationDialog('LABEL_REMOVE_DIAGNOSE_TITLE', { message: 'LABEL_REMOVE_DATA_FROM_CONTRACT_CONTENT', eligible: item.expanded_name }, 'BUTTON_YES', 'BUTTON_NO', removeDiagnose, cancelRemoveDiagnose);
            };

            function removeDiagnose() {
                var index = -1;
                for (var i = 0; i < $scope.diagnoses.length; i++) {
                    if ($scope.diagnoses[i].id === $scope.id_to_remove) {
                        index = i;
                        break;
                    };
                };

                $scope.diagnoses.splice(index, 1);
                contractService.getContract().covered_diagnoses = $scope.diagnoses;
            };

            function cancelRemoveDiagnose() { };

            // ------------------------------------------------------ ERROR FUNCTIONS -----------------------------------------------------

            $scope.authenicateUserError = function (response) {
                $rootScope.activeMenuItem = null;
                $window.location.replace(response.logoutUrl);
            };

            function errorFunction(response) {
                console.log(response);
                alertsServices.ErrorMessage('LABEL_SOMETHING_WENT_WRONG');
            };

            // ----------------------------------------------------------- UTIL -----------------------------------------------------------

            $scope.setTableHeaderClass = function (order_value) {
                if (ascending && sort_by == order_value)
                    return 'sorted_asc';
                else if (!ascending && sort_by == order_value)
                    return 'sorted_dsc'
                else
                    return 'unsorted';
            };

            $scope.SortFunction = function (sort_value) {
                if (sort_by == sort_value) {
                    ascending = !ascending;
                };

                sort_by = sort_value;

                $scope.diagnoses = $filter('orderBy')($scope.diagnoses, sort_value, !ascending);
            };

            $scope.remoteUrlRequestFn = function (str) {
                return { search_criteria: str };
            };

            $timeout(function () {
                var elem = angular.element('#inDiagnoseName_value');
                elem.bind('keydown', function (event) {
                    if (event.which === 13) {
                        addDiagnoseToList();
                    };
                });

                elem[0].focus();
            }, 200, false);

            // ----------------------------------------------------------- WATCHERS -------------------------------------------------------

            $scope.$on('contractUpdated', function () {
                $scope.diagnoses = contractService.getContract().covered_diagnoses;
            });

            // ----------------------------------------------------------- END ------------------------------------------------------------
        };
    });
});