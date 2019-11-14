define(['angularAMD'], function (angularAMD) {

    angularAMD.directive('gposDetailDirective', function () {

        return {

            templateUrl: 'scripts/src/app/master_data/view/contract_templates/gposDetailTemplate.html',
            scope: {
                mode: '='
            },
            replace: true,
            restrict: 'E',
            controller: gposDetailController
        };
        function gposDetailController($scope, $rootScope, $translate, contractService, validationService, ngDialog, $timeout, $routeParams, $location, alertsServices, $filter) {

            // --------------------------------------------------------- VARIABLES --------------------------------------------------------

            var ascending = true;
            var sort_by = "gpos_number";
            $scope.gpos = new Object();
            $scope.showGposForm = false;
            $scope.editMode = false;

            // ----------------------------------------------------------- INIT -----------------------------------------------------------

            $scope.initializeController = function () {
                contractService.authenicateUser($location.path(), $scope.authenicateUserComplete, $scope.authenicateUserError);
            };

            $scope.authenicateUserComplete = function (response) {
                if (!contractService.isNotUndefined(contractService.getContract().gpos_data))
                    contractService.getContract().gpos_data = [];

                $scope.gpos_data = contractService.getContract().gpos_data;
            };

            // ---------------------------------------------------------- SAVE  -----------------------------------------------------------

            $scope.saveGpos = function () {
                if (!$scope.editMode) {
                    var latestID = Math.max.apply(null,
                        $.grep($scope.gpos_data.map(function (gpos) {
                            try {
                                if (gpos.gpos_id.indexOf('-') === -1)
                                    return gpos.gpos_id;
                            } catch (e) {
                                return gpos.gpos_id;
                            };
                        }), function (n) {
                            return n !== undefined
                        }));
                    if (latestID !== -Infinity && !isNaN(latestID)) {
                        $scope.gpos.gpos_id = parseInt(latestID) + 1;
                    } else {
                        $scope.gpos.gpos_id = 1;
                    };

                    $scope.gpos_data.push($scope.gpos);
                };

                var message = $scope.editMode ? 'LABEL_CHANGES_SAVED' : 'LABEL_GPOS_ADDED';
                alertsServices.SuccessMessage(message);
                closeGposForm();
                $scope.gpos_data = $filter('orderBy')($scope.gpos_data, sort_by, !ascending);
                contractService.getContract().gpos_data = $scope.gpos_data;
            };

            // ---------------------------------------------------------- REMOVE ----------------------------------------------------------

            $scope.removeGPOS = function (item) {
                $scope.id_to_remove = item.gpos_id;
                var content = item.gpos_number + ' (' + item.gpos_name + ')';
                alertsServices.RenderConfirmationDialog('LABEL_REMOVE_GPOS_TITLE', { message: 'LABEL_REMOVE_DATA_FROM_CONTRACT_CONTENT', eligible: content }, 'BUTTON_YES', 'BUTTON_NO', removeGpos, cancelRemoveGpos);
            };

            function removeGpos() {
                var index = -1;
                for (var i = 0; i < $scope.gpos_data.length; i++) {
                    if ($scope.gpos_data[i].gpos_id === $scope.id_to_remove) {
                        index = i;
                        break;
                    };
                };

                $scope.gpos_data.splice(index, 1);
                contractService.getContract().gpos_data = $scope.gpos_data;
            };

            function cancelRemoveGpos() { };

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

                $scope.gpos_data = $filter('orderBy')($scope.gpos_data, sort_value, !ascending);
            };

            $scope.openGposForm = function () {
                $scope.showGposForm = true;
            };

            $scope.$on('CloseForm', function (event, data) {
                if (data.form === 'gpos') {
                    if (data.previous_state !== undefined) {
                        var index = -1;
                        for (var i = 0; i < $scope.gpos_data.length; i++) {
                            if ($scope.gpos_data[i].gpos_id === data.previous_state.gpos_id) {
                                index = i;
                                break;
                            };
                        };

                        $scope.gpos_data[index] = data.previous_state;
                    };
                    closeGposForm();
                };
            });

            function closeGposForm() {
                $scope.showGposForm = false;
                $scope.gposToEditID = undefined;
                $scope.editMode = false;
                $scope.gpos = new Object();
            };

            $scope.editGpos = function (id) {
                $scope.gposToEditID = id;
                $scope.editMode = true;
            };
            
            // ----------------------------------------------------------- END ------------------------------------------------------------
        };
    });
});