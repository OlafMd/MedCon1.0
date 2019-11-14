(function () {
    'use strict';
    angular.module('mainModule').controller('ordersController', ['$scope', '$rootScope', '$filter', 'ordersService', 'alertService', 'commonServices', 'validationService', 'ngDialog', 'doctorsService', 'pharmacyService', 'practiceSettingsService',
        function ($scope, $rootScope, $filter, ordersService, alertService, commonServices, validationService, ngDialog, doctorsService, pharmacyService, practiceSettingsService) {
            var ascending = false;
            var sort_by = 'treatment_date';
            $scope.today = $filter('date')(new Date(), 'MM.dd.yyyy');
            $scope.scroll_down_params = {};
            $scope.scroll_down_params.infiniteScrollStep = 100;
            $scope.scroll_down_params.infiniteScrollStartIndex = 0;
            $scope.orders = [];
            $scope.search_data = new Object();
            $scope.search_data.filter_by = new Object();
            $scope.search_data.filter_by.filter_status = [];
            $scope.search_data.filter_by.filter_type = [];
            $scope.search_data.filter_by.filter_current = false;
            $scope.search_data.filter_by.ordered_drugs = true;
            $scope.practiceCanOrderLabelOnly = false;
            var practiceSettings = {};

            $scope.order_period = 'today';
            var custom_date_clicked = false;

            var emptyGuid = '00000000-0000-0000-0000-000000000000';
            var nonePharmacy = { 'display_name': "LABEL_NON_COOPERATTING_PHARMACY", 'id': emptyGuid };
            $scope.pharmacies = [];

            // ------------------------------------------------------------------ INIT -------------------------------------------------------------------
            $scope.orderOpen = orderOpen;
            $scope.canShowEditButton = canShowEditButton;
            $scope.loadOrders = loadOrders;
            getDoctors();
            loadOrders();
            getPracticeSettings();
            // ------------------------------------------------------------- DATA RETRIEVAL --------------------------------------------------------------

            function getSortParameter() {
                var orders_from_date = null;
                var orders_to_date = null;
                var today = new Date();

                switch ($scope.order_period) {
                    case 'today':
                        orders_from_date = today;
                        orders_to_date = today;
                        break;

                    case 'tomorrow':
                        var tomorrow = new Date(today.getFullYear(), today.getMonth(), today.getDate() + 1)
                        orders_from_date = tomorrow;
                        orders_to_date = tomorrow;
                        break;

                    case 'future':
                        orders_from_date = today;
                        orders_to_date = null;
                        break;

                    default:
                        orders_from_date = $scope.orders_from_date;
                        orders_to_date = $scope.orders_to_date;
                        break;
                }

                var sort_parameter = {
                    page_size: 100,
                    start_row_index: $scope.scroll_down_params.infiniteScrollStartIndex,
                    isAsc: ascending,
                    sort_by: sort_by,
                    orders_from_date: orders_from_date,
                    orders_to_date: orders_to_date
                };

                if ($scope.search_data) {
                    sort_parameter.search_params = $scope.search_data.text_search;
                    sort_parameter.filter_by = $scope.search_data.filter_by;
                    sort_parameter.hip_name = $scope.search_data.filter_by.hip_name;
                }

                return sort_parameter;
            }

            function loadOrders() {
                if ($scope.execute_scroll) return;
                $scope.execute_scroll = true;
                var sort_parameter = getSortParameter();

                ordersService.getAllOrders(sort_parameter, function (response) {
                    $scope.execute_scroll = false;
                    $scope.orders = $scope.orders.concat(response.orders);
                    $scope.scroll_down_params.infiniteScrollStartIndex += $scope.scroll_down_params.infiniteScrollStep;
                    $scope.isScrollDisabled = response.orders.length < $scope.scroll_down_params.infiniteScrollStep;

                    $scope.order_stats = response.order_stats;

                    commonServices.focusSearch();
                }, errorFunction);

                if ($scope.should_download) {
                    commonServices.download($scope.should_download);
                    $scope.should_download = undefined;
                };
            };

            $scope.$on('GlobalSearch', function (event, data) {
                $scope.search_data = data;
                reloadOrders();
            });

            function reloadOrders() {
                $scope.scroll_down_params.infiniteScrollStartIndex = 0;
                $scope.orders = [];
                $scope.isScrollDisabled = true;
                $rootScope.$broadcast("StickyReset");
                loadOrders();
                commonServices.focusSearch();
                $scope.show_edit_case_form = false;
            }

            $scope.orderPeriodCustomDateDisabled = function () {
                return $scope.order_period !== 'custom';
            };

            function getDoctors() {
                doctorsService.getDoctorsInPractice().then(function (response) {
                    $scope.doctors = response;
                });
            }

            function getPharmacies() {
                pharmacyService.getPharmacies().then(getPharmaciesComplete);
            }

            function getPharmaciesComplete(response) {
                $scope.pharmacies = response.map(function (x) {
                    return {
                        'display_name': x.pharmacyName, 'id': x.pharmacyID
                    };
                });

                $scope.pharmacies.push(nonePharmacy);

                if ($scope.default_pharmacy_id != null) {
                    var pharmacyFound = false;
                    angular.forEach($scope.pharmacies, function (item) {
                        if (item.id == $scope.default_pharmacy_id) {
                            $scope.order_to_submit.default_pharmacy = item.id;
                            pharmacyFound = true;
                        }
                    })

                    if (!pharmacyFound)
                        $scope.order_to_submit.default_pharmacy = emptyGuid;
                } else {
                    $scope.order_to_submit.default_pharmacy = $scope.pharmacies[0].id;
                }
            }

            // --------------------------------------------------------- EDIT -----------------------------------------------------------------

            function orderOpen(order) {
                return order.status_drug_order === 'MO0' || order.status_drug_order === 'MO8';
            };

            function canShowEditButton(order) {
                if (order.is_treatment_submitted || order.status_drug_order === 'MO9' || order.status_drug_order === 'MO6')
                    return false;
                else
                    return true;
            }

            $scope.editOrder = function (order) {
                if (order.status_drug_order === "MO0" || order.status_drug_order === "MO8") {
                    $scope.show_edit_order_form_id = order.id;
                    $scope.show_edit_case_form = false;
                } else {
                    $scope.show_edit_case_form = true;
                    $scope.edit_case_id = order.case_id;
                    $scope.show_edit_order_form_id = false;
                }
            };

            $scope.$on('CloseForm', function () {
                $scope.edit_case_id = undefined;
                $scope.show_edit_order_form_id = undefined;
                reloadOrders();
            });


            // -------------------------------------------------------- CANCEL -----------------------------------------------------------------

            $scope.cancelOrder = function (order) {
                if (orderOpen(order)) {
                    alertService.RenderConfirmationDialog('LABEL_WARNING', { message: 'LABEL_DELETE_DRUG_ORDER_POPUP' }, 'BUTTON_YES', 'BUTTON_NO', function () {
                        ordersService.cancelOrder(order.id, function () {
                            alertService.RenderSuccessMessage('LABEL_ORDER_DELETED');
                            reloadOrders();
                        }, errorFunction);
                    }, function () {
                    });
                } else {
                    if (order.doctor_id === '00000000-0000-0000-0000-000000000000') {
                        order.doctor_id = null;
                    }

                    alertService.ConfirmPassword($scope, function () {
                        ordersService.cancelCase({
                            case_id: order.case_id,
                            cancel_drug_order: true
                        }, function () {
                            alertService.RenderSuccessMessage('LABEL_ORDER_CANCELLED');
                            reloadOrders();
                        }, errorFunction);

                    }, null, 'LABEL_PLEASE_ENTER_PASSWORD_TO_CANCEL_ORDER', order.doctor_id || $rootScope.id);
                }
            };

            // -------------------------------------------------------- REPORT --------------------------------------------------------

            function downloadReportComplete(response) {
                commonServices.download(response);
            }

            $scope.downloadReport = function (order) {
                ordersService.getOrderReportURL(order.id, downloadReportComplete, errorFunction)
            }
            // -------------------------------------------------------- SUBMIT -------------------------------------------------------------------

            $scope.submitOrder = function (order) {
                submit([order.id]);
            };

            function submit(ids) {
                $scope.order_to_submit = {};

                if (ids.length === 1) {
                    ordersService.getOrderComment({ order_id: ids[0] }, function (response) {
                        $scope.order_to_submit.comment = response;
                    }, errorFunction);
                }

                getPharmacies();
                if (practiceSettings) {
                    $scope.order_to_submit.street = practiceSettings.address;
                    $scope.order_to_submit.city = practiceSettings.town;
                    $scope.order_to_submit.number = practiceSettings.No;
                    $scope.order_to_submit.zip = practiceSettings.Zip;
                    $scope.order_to_submit.order_ids = ids;
                    $scope.order_to_submit.receiver = practiceSettings.name;
                    $scope.default_pharmacy_id = practiceSettings.DefaultPharmacy;
                }

                $scope.order_to_submit.delivery_date_from = practiceSettings.DeliveryDateFrom;
                $scope.order_to_submit.delivery_date_to = practiceSettings.DeliveryDateTo;

                for (var i = 0; i < $scope.doctors.length; i++) {
                    var doctor = $scope.doctors[i];
                    if (doctor.id === $rootScope.id) {
                        $scope.order_to_submit.doctor_id = doctor.id;
                        break;
                    }
                }

                ngDialog.open({
                    template: 'scripts/src/app/shoppingCart/view/confirmOrderPopup.html',
                    scope: $scope,
                    closeByDocument: false,
                    closeByEscape: false
                });

                commonServices.focusElement('#dpDeliveryDate');
            }

            $scope.passwordConfirmationCancel = function () {
                resetOrderToSubmit();
                ngDialog.close();
            };

            function confirmOrderSubmit() {
                ordersService.submitOrder($scope.order_to_submit, function (response) {
                    commonServices.download(response);
                    resetOrderToSubmit();
                    alertService.RenderSuccessMessage('LABEL_ORDERS_SUBMITTED');
                    reloadOrders()
                }, errorFunction);
            }

            function resetOrderToSubmit() {
                $scope.order_to_submit = undefined;
            }

            $scope.verifyPassword = function () {
                $scope.submitClicked = true;
                $scope.deliveryDateInvalid = false;
                if (!validationService.isValidDate($scope.order_to_submit.delivery_date)) {
                    $scope.deliveryDateInvalid = true;
                    commonServices.focusElement('#dpDeliveryDate');
                    return;
                }

                ordersService.verifyPassword({
                    doctor: { id: $scope.order_to_submit.doctor_id },
                    password: $scope.order_to_submit.password
                }, function (response) {
                    $scope.credentials_not_verified = false;
                    ngDialog.close();
                    confirmOrderSubmit();
                }, function () {
                    $scope.credentials_not_verified = true;
                });
            };

            // -------------------------------------------------------- FILTER -----------------------------------------------------------------

            $scope.updateOrderPeriod = function () {
                if ($scope.orderPeriodCustomDateDisabled()) {
                    custom_date_clicked = false;
                    $scope.orders_from_date = null;
                    $scope.orders_to_date = null;
                } else {
                    if (!custom_date_clicked) {
                        if (!$scope.orders_from_date) {
                            $scope.orders_from_date = new Date();
                        }

                        if (!$scope.orders_to_date) {
                            var today = new Date();
                            var first = today.getDate() - today.getDay();
                            var last = first + 7;

                            $scope.orders_to_date = new Date(today.setDate(last));
                        }
                    }

                    custom_date_clicked = true;
                }

                if (($scope.orders_from_date && $scope.orders_to_date) || $scope.orderPeriodCustomDateDisabled()) {
                    reloadOrders();
                }
            };

            // --------------------------------------------------------- UTIL ------------------------------------------------------------------

            function getPracticeSettings() {
                practiceSettingsService.getPracticeSettings().then(function (settings) {
                    practiceSettings = settings;
                    $scope.practiceCanOrderLabelOnly = practiceSettings.IsOnlyLabelRequired;
                }, errorFunction);
            }

            function errorFunction(response) {
                $scope.execute_scroll = false;
                console.log(response);
                alertService.RenderErrorMessage('LABEL_SOMETHING_WENT_WRONG');
            }

            $scope.getBorderClassName = function (item) {
                switch (item.status) {
                    case ('FS1'): return '';
                    case ('FS2'): return 'yellow-border';
                    case ('FS4'): return 'yellow-border';
                    case ('FS6'): return 'red-border';
                    case ('FS7'): return 'green-border';
                    case ('FS8'): return 'gray-border';
                    case ('FS9'): return 'red-border';
                    case ('FS12'): return 'green-item';
                };
            };

            $scope.getTextClassName = function (item) {
                switch (item.status) {
                    case ('FS1'): return '';
                    case ('FS2'): return 'ordered-text';
                    case ('FS4'): return 'ordered-text';
                    case ('FS6'): return 'rejected-text';
                    case ('FS7'): return 'shipped-text';
                    case ('FS8'): return 'gray-text';
                    case ('FS9'): return 'rejected-text';
                    case ('FS12'): return 'shipped-text';
                    case ('FS12'): return 'shipped-border';
                };
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

                $rootScope.$broadcast("StickyReset");
                reloadOrders();
            };

            $scope.loadMore = function () {
                if ($scope.execute_scroll) {
                    return;
                }

                loadOrders();
            };

            // ------------------------------------------------------------------ CONTROLLER END ------------------------------------------------------------------
        }]);
})();
