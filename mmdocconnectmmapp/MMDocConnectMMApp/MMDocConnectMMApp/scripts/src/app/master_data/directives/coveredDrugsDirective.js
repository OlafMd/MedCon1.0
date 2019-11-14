﻿define(['angularAMD'], function (angularAMD) {

    angularAMD.directive('coveredDrugsDirective', function () {

        return {

            templateUrl: 'scripts/src/app/master_data/view/contract_templates/coveredDrugsTemplate.html',
            scope: {
                mode: '='
            },
            replace: true,
            restrict: 'E',
            controller: coveredDrugsController
        };
        function coveredDrugsController($scope, $rootScope, $translate, contractService, validationService, ngDialog, $timeout, $routeParams, $location, alertsServices, $filter) {

            // --------------------------------------------------------- VARIABLES --------------------------------------------------------

            var ascending = true;
            var sort_by = 'name';
            $scope.drugs = [];

            // ----------------------------------------------------------- INIT -----------------------------------------------------------

            $scope.initializeController = function () {
                contractService.authenicateUser($location.path(), $scope.authenicateUserComplete, $scope.authenicateUserError);
            };

            $scope.authenicateUserComplete = function (response) {
                if (!contractService.isNotUndefined(contractService.getContract().covered_drugs))
                    contractService.getContract().covered_drugs = [];

                $scope.drugs = contractService.getContract().covered_drugs;
            };

            // ---------------------------------------------------------- SAVE  -----------------------------------------------------------

            $scope.addDrug = function (selectedObject) {
                $scope.drug_to_add = selectedObject.originalObject;
                if ($scope.drug_to_add === undefined) {
                    $scope.showErrorMessageContainer = undefined;
                };
            };

            $scope.addDrugToList = addDrugToList;

            function addDrugToList() {
                if ($scope.drug_to_add !== undefined && $scope.drugs.map(function (drug) { return drug.id; }).indexOf($scope.drug_to_add.id) === -1) {
                    $scope.drugs.push($scope.drug_to_add);
                    $scope.drugs = $filter('orderBy')($scope.drugs, sort_by, !ascending);
                    contractService.getContract().covered_drugs = $scope.drugs;
                    $scope.drug_to_add = undefined;
                    $rootScope.$broadcast('angucomplete-alt:clearInput');
                } else {
                    if ($scope.drug_to_add !== undefined) {
                        $scope.showErrorMessageContainer = true;
                    } else {
                        $scope.showErrorMessageContainer = undefined;
                    };
                };

                $scope.$digest();
            };

            // ---------------------------------------------------------- REMOVE ----------------------------------------------------------

            $scope.removeDrug = function (item) {
                $scope.id_to_remove = item.id;
                alertsServices.RenderConfirmationDialog('LABEL_REMOVE_DRUG_TITLE', { message: 'LABEL_REMOVE_DATA_FROM_CONTRACT_CONTENT', eligible: item.expanded_name }, 'BUTTON_YES', 'BUTTON_NO', removeDrug, cancelRemoveDrug);
            };

            function removeDrug() {
                var index = -1;
                for (var i = 0; i < $scope.drugs.length; i++) {
                    if ($scope.drugs[i].id === $scope.id_to_remove) {
                        index = i;
                        break;
                    };
                };

                $scope.drugs.splice(index, 1);
                contractService.getContract().covered_drugs = $scope.drugs;
            };

            function cancelRemoveDrug() { };

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

            $scope.setTableHeaderClass = function () {
                return ascending ? 'sorted_asc' : 'sorted_dsc';
            };

            $scope.SortFunction = function () {
                ascending = !ascending;
                $scope.drugs = $filter('orderBy')($scope.drugs, sort_by, !ascending);
            };

            $scope.remoteUrlRequestFn = function (str) {
                return { search_criteria: str };
            };

            $timeout(function () {
                var elem = angular.element('#inDrugName_value');
                elem.bind('keydown', function (event) {
                    if (event.which === 13) {
                        addDrugToList();
                    };
                });

                elem[0].focus();
            }, 200, false);

            // ----------------------------------------------------------- WATCHERS -------------------------------------------------------

            $scope.$on('contractUpdated', function () {
                $scope.drugs = contractService.getContract().covered_drugs;
            });

            // ----------------------------------------------------------- END ------------------------------------------------------------
        };
    });
});