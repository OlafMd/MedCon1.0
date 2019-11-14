"use strict";

define(['application-configuration', 'validationService', 'alertsServices', 'orderService', 'commonServices'], function (app) {

    app.register.controller('orderController', ['$scope', '$rootScope', '$translate', 'validationService', 'ngDialog', '$timeout', '$location', '$filter', 'alertsServices', 'orderService', 'commonServices', '$interval',
        function ($scope, $rootScope, $translate, validationService, ngDialog, $timeout, $location, $filter, alertsServices, orderService, commonServices, $interval) {

            var sort_by = "treatment_date";
            var ascending = false;
            var orderClicked = {};

            $scope.scroll_down_params = new Object();
            $scope.scroll_down_params.infiniteScrollStep = 100;
            $scope.scroll_down_params.infiniteScrollStartIndex = 0;
            $scope.isScrollDisabled = false;
            $scope.orders = [];
            $scope.showData = false;
            $scope.is_scroll = false;
            $scope.execute_scroll = false;
            $rootScope.$broadcast("StickyReset");

            function succesFunction(response) {
                $scope.execute_scroll = false;
                $scope.scroll_down_params.infiniteScrollStartIndex = $scope.scroll_down_params.infiniteScrollStartIndex + $scope.scroll_down_params.infiniteScrollStep;

                $scope.isScrollDisabled = response.OrderData.length < $scope.scroll_down_params.infiniteScrollStep;
                if ($scope.is_scroll)
                    $scope.orders = $scope.orders.concat(response.OrderData);
                else {
                    $rootScope.$broadcast("StickyReset");
                    $scope.orders = response.OrderData;
                };
            };
            function errorFunction(response) {
                $scope.execute_scroll = false;
                console.log(response);
            };

            function errorFunction(response) {
                $scope.execute_scroll = false;
                console.log(response);
            };

            $scope.initializeController = function () {
                orderService.authenicateUser($location.path(), $scope.authenicateUserComplete, $scope.authenicateUserError);
            };


            $scope.initializeController = function () {
                orderService.authenicateUser($location.path(), $scope.authenicateUserComplete, $scope.authenicateUserError);
            };

            $scope.authenicateUserComplete = function (response) {
                $scope.showData = true;
            };

            $scope.authenicateUserError = function (response) {
                $rootScope.activeMenuItem = null;
                $window.location.replace(response.logoutUrl);
            };

            function getOrders() {
                if ($scope.execute_scroll) return;
                $scope.execute_scroll = true;
                var sort_parameter = new Object();
                sort_parameter.sort_by = sort_by;
                sort_parameter.isAsc = ascending;
                sort_parameter.start_row_index = $scope.scroll_down_params.infiniteScrollStartIndex;

                if ($scope.search_data === undefined) {


                    sort_parameter.search_params = '';
                    sort_parameter.date_from = "1-1-1";
                    sort_parameter.date_to = '';

                }
                else {
                    sort_parameter.search_params = $scope.search_data.text_search;
                    sort_parameter.filter_by = $scope.search_data.filter_by;
                    sort_parameter.date_from = $scope.search_data.date_from;
                    sort_parameter.date_to = $scope.search_data.date_to;
                }


                orderService.getOrderData(sort_parameter, succesFunction, errorFunction);
            }

            $scope.$on('GlobalSearch', function (event, data) {
                $scope.search_data = data;
                $scope.scroll_down_params.infiniteScrollStartIndex = 0;
                $scope.is_scroll = false;
                $scope.isScrollDisabled = true;
                getOrders();
            });

            $scope.getBorderClassName = function (item) {
                switch (item.status_drug_order) {
                    case 'MO1':
                        return 'yellow-border';
                    case 'MO2':
                        return 'green-border';
                    case 'MO3':
                        return '';
                    case 'MO4':
                        return 'red-border';
                    case 'MO6':
                        return 'red-border';
                    default:
                        return 'black-border';
                }
            };
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
                }
                sort_by = sort_value;
                $scope.orders.length = 0;
                $scope.scroll_down_params.infiniteScrollStartIndex = 0;
                $scope.is_scroll = false;
                $scope.isScrollDisabled = true;
                $rootScope.$broadcast("StickyReset");
                getOrders();
            };

            function succesFunctionRejectOrder(response) {
                var message = "LABEL_REJECT_ORDER";
                alertsServices.SuccessMessage(message);
                $scope.scroll_down_params.infiniteScrollStartIndex = 0;
                $scope.is_scroll = false;
                $scope.isScrollDisabled = true;
                getOrders();
            };
            function errorFunctionRejectOrder(response) {
                console.log(response);
                var message = "LABEL_SOMETHING_WENT_WRONG";
                alertsServices.ErrorMessage(message);
            };

            function confirmFunction() {
                orderService.rejectOrderStatus(orderClicked, succesFunctionRejectOrder, errorFunctionRejectOrder);

            }
            function cancelFunction() {
                alertsServices.PopupClose();
            };

            $scope.RejectOrder = function (item) {
                orderClicked = item;
                commonServices.getEmployeesForRightID({ isMaster: true }, RejectOrder, errorFunction);
            };

            function RejectOrder(response) {
                var message = "LABEL_CONFIRM_REJECT_ORDER";
                alertsServices.ConfirmPassword(response.employees, response.logged_in_user_email, confirmFunction, cancelFunction, message);
            };

            $scope.loadMore = function () {
                $scope.is_scroll = true;
                getOrders();
            };


            var interval = $interval(function () {
                var element = angular.element('#globalSearchInput')[0];
                if (element) {
                    $interval.cancel(interval);
                    element.focus();
                }
            }, 20, 100, false);
        }]);
});
