(function () {
    'use strict';
    angular.module('mainModule').directive('editOrderDirective', function () {

        return {
            templateUrl: 'scripts/src/app/shoppingCart/view/editOrder.html',
            scope: {
                orderId: '='
            },
            replace: true,
            restrict: 'E',
            controller: ['$scope', '$rootScope', 'alertService', '$filter', 'ordersService', 'drugsService', 'practiceSettingsService', '$location', editOrderController]
        };

        function editOrderController($scope, $rootScope, alertService, $filter, ordersService, drugsService, practiceSettingsService, $location) {
            // -- variables
            $scope.today = $filter('date')(new Date(), 'MM.dd.yyyy');
            $scope.closeOrderForm = closeOrderForm;

            function orderDetailsRetrieved(response) {
                $scope.order = response;
            };

            // -- order saving
            $scope.saveOrder = function () {
                ordersService.saveOrder($scope.order, orderSaved, errorFunction);
            };

            function orderSaved() {
                closeOrderForm();
                alertService.RenderSuccessMessage('LABEL_CHANGES_SAVED');
            }

            // -- util
            function closeOrderForm() {
                $rootScope.$broadcast('CloseForm', { form: 'orders' });
            };

            // -- error functions
            function errorFunction(response) {
                console.log(response);
                alertService.RenderErrorMessage('LABEL_SOMETHING_WENT_WRONG');
            };

            // -- init
            ordersService.getOrderDetails($scope.orderId, orderDetailsRetrieved, errorFunction);

            drugsService.getAll().then(function (response) {
                $scope.drugs = response;
            });

            practiceSettingsService.getPracticeSettings().then(function (response) {
                $scope.labelOnlyVisible = response.IsOnlyLabelRequired;
            });
        };
    });
})();