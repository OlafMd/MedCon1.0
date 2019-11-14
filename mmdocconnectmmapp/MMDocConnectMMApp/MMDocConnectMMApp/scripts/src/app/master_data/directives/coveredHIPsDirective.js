define(['angularAMD'], function (angularAMD) {

    angularAMD.directive('coveredHipsDirective', function () {

        return {

            templateUrl: 'scripts/src/app/master_data/view/contract_templates/coveredHIPsTemplate.html',
            scope: {
                mode: '='
            },
            replace: true,
            restrict: 'E',
            controller: coveredHIPsController
        };
        function coveredHIPsController($scope, $rootScope, $translate, contractService, validationService, ngDialog, $timeout, $routeParams, $location, alertsServices, $filter) {

            // --------------------------------------------------------- VARIABLES --------------------------------------------------------

            var ascending = true;
            var sort_by = 'name';
            $scope.hips = [];

            // ----------------------------------------------------------- INIT -----------------------------------------------------------

            $scope.initializeController = function () {
                contractService.authenicateUser($location.path(), $scope.authenicateUserComplete, $scope.authenicateUserError);
            };

            $scope.authenicateUserComplete = function (response) {
                if (!contractService.isNotUndefined(contractService.getContract().covered_insurance_companies))
                    contractService.getContract().covered_insurance_companies = [];

                $scope.hips = contractService.getContract().covered_insurance_companies;
            };

            // ---------------------------------------------------------- SAVE  -----------------------------------------------------------

            $scope.addHip = function (selectedObject) {
                $scope.Hip_to_add = selectedObject.originalObject;

                if ($scope.Hip_to_add === undefined) {
                    $scope.showErrorMessageContainer = undefined;
                };
            };

            $scope.addHipToList = addHipToList;

            function addHipToList() {
                if ($scope.Hip_to_add !== undefined && $scope.hips.map(function (Hip) { return Hip.additional_info; }).indexOf($scope.Hip_to_add.additional_info) === -1) {
                    $scope.hips.push($scope.Hip_to_add);
                    $scope.hips = $filter('orderBy')($scope.hips, sort_by, !ascending);
                    contractService.getContract().covered_insurance_companies = $scope.hips;
                    $scope.Hip_to_add = undefined;
                    $rootScope.$broadcast('angucomplete-alt:clearInput');
                    $rootScope.$broadcast('update-ik-number-list');
                } else {
                    if ($scope.Hip_to_add !== undefined) {
                        $scope.showErrorMessageContainer = true;
                    } else {
                        $scope.showErrorMessageContainer = undefined;
                    };
                };

                $scope.$digest();
            };

            // ---------------------------------------------------------- REMOVE ----------------------------------------------------------

            $scope.removeHip = function (item) {
                $scope.id_to_remove = item.id;
                alertsServices.RenderConfirmationDialog('LABEL_REMOVE_HIP_TITLE', { message: 'LABEL_REMOVE_DATA_FROM_CONTRACT_CONTENT', eligible: item.expanded_name }, 'BUTTON_YES', 'BUTTON_NO', removeHip, cancelRemoveHip);
            };

            function removeHip() {
                var index = -1;
                for (var i = 0; i < $scope.hips.length; i++) {
                    if ($scope.hips[i].id === $scope.id_to_remove) {
                        index = i;
                        break;
                    };
                };

                $scope.hips.splice(index, 1);
                contractService.getContract().covered_insurance_companies = $scope.hips;
                $rootScope.$broadcast('update-ik-number-list');
            };

            function cancelRemoveHip() { };

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

                $scope.hips = $filter('orderBy')($scope.hips, sort_value, !ascending);
            };

            $scope.remoteUrlRequestFn = function (str) {
                return { search_criteria: str };
            };

            $timeout(function () {
                var elem = angular.element('#inHipName_value');
                elem.bind('keydown', function (event) {
                    if (event.which === 13) {
                        addHipToList();
                    };
                });

                elem[0].focus();
            }, 200, false);

            // ----------------------------------------------------------- WATCHERS -------------------------------------------------------
            
            $scope.$on('contractUpdated', function () {
                $scope.hips = contractService.getContract().covered_insurance_companies;
            });

            // ----------------------------------------------------------- END ------------------------------------------------------------
        };
    });
});