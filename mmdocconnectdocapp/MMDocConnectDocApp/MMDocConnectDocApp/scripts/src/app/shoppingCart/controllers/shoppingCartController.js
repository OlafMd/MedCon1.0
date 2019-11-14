(function () {
    'use strict';
    angular.module('mainModule').controller('shoppingCartController', ['$scope', '$rootScope', '$filter', 'alertService', 'ordersService', 'ngDialog', 'commonServices', 'validationService', 'doctorsService', 'pharmacyService', 'practiceSettingsService',
        function ($scope, $rootScope, $filter, alertService, ordersService, ngDialog, commonServices, validationService, doctorsService, pharmacyService, practiceSettingsService) {

            // --------------------------------------------------------------- VARIABLES ----------------------------------------------------------------

            $scope.selected_count = 0;
            $scope.scroll_down_params = new Object();
            $scope.scroll_down_params.infiniteScrollStep = 100;
            $scope.scroll_down_params.infiniteScrollStartIndex = 0;
            $scope.today = $filter('date')(new Date(), 'MM.dd.yyyy');
            $scope.orders = [];
            $scope.order_period = 'today';
            $scope.submitClicked = false;
            var deselected_action_ids = [];
            var selected_action_ids = [];
            var custom_date_clicked = false;

            var emptyGuid = '00000000-0000-0000-0000-000000000000';
            var nonePharmacy = { 'display_name': "LABEL_NON_COOPERATTING_PHARMACY", 'id': emptyGuid };

            $scope.pharmacies = [];

            // ---------------------------------------------------------- SCOPE METHOD BINDING ----------------------------------------------------------

            $scope.checkAll = checkAll;
            $scope.selectAll = selectAll;
            $scope.checkGroup = checkGroup;

            // ------------------------------------------------------------------ INIT ------------------------------------------------------------------
            getDoctors();
            loadOrders();
            $scope.getGroupItem = getGroupItem;
            $rootScope.$broadcast("StickyReset");

            // ------------------------------------------------------------------ EDIT ------------------------------------------------------------------

            $scope.editOrder = function (order) {
                $scope.show_edit_order_form_id = order.id;
            };

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
                    orders_from_date: orders_from_date,
                    orders_to_date: orders_to_date
                };

                if ($scope.search_data) {
                    sort_parameter.search_params = $scope.search_data.text_search;
                }

                return sort_parameter;
            }

            function loadOrders() {
                if ($scope.execute_scroll) return;
                $scope.execute_scroll = true;
                var sort_parameter = getSortParameter();

                ordersService.getOrders(sort_parameter, function (response) {
                    $scope.execute_scroll = false;
                    $scope.orders = response.orders;
                    $scope.order_stats = response.order_stats;
                    $scope.scroll_down_params.infiniteScrollStartIndex += $scope.scroll_down_params.infiniteScrollStep;
                    $scope.isScrollDisabled = response.length < $scope.scroll_down_params.infiniteScrollStep;
                    checkAll();
                    commonServices.focusSearch();
                }, errorFunction);

                if ($scope.should_download) {
                    commonServices.download($scope.should_download);
                    $scope.should_download = undefined;
                };
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
                    if ($scope.pharmacies.length) {
                        angular.forEach($scope.pharmacies, function (item) {
                            if (item.id == $scope.default_pharmacy_id) {
                                $scope.order_to_submit.default_pharmacy = item.id;
                                pharmacyFound = true;
                            }
                        })
                    }

                    if (!pharmacyFound) {
                        $scope.order_to_submit.default_pharmacy = emptyGuid;
                    }
                } else {
                    $scope.order_to_submit.default_pharmacy = $scope.pharmacies[0].id;
                }

                $scope.order_to_submit.isNewPharmacy = false;
                if ($scope.order_to_submit.default_pharmacy == emptyGuid) {
                    $scope.order_to_submit.isNewPharmacy = true;
                }
            }

            // -------------------------------------------------------------- GLOBAL SEARCH --------------------------------------------------------------

            $scope.$on('GlobalSearch', function (event, data) {
                $scope.search_data = data;
                reloadOrders();
            });

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

            $scope.orderPeriodCustomDateDisabled = function () {
                return $scope.order_period !== 'custom';
            };

            // -------------------------------------------------------------- CANCEL ORDER ----------------------------------------------------------------

            $scope.cancelOrder = function (order) {
                $scope.order_to_cancel = order;
                alertService.RenderConfirmationDialog('LABEL_WARNING', { message: 'LABEL_DELETE_DRUG_ORDER_POPUP' }, 'BUTTON_YES', 'BUTTON_NO', confirmCancelOrder, resetOrderToCancel);
            }

            function confirmCancelOrder() {
                ordersService.cancelOrder($scope.order_to_cancel.id, orderCancelled, errorFunction);
            }

            function orderCancelled() {
                resetOrderToSubmit();
                alertService.RenderSuccessMessage('LABEL_ORDER_DELETED');
                reloadOrders()
            }

            function resetOrderToCancel() {
                $scope.order_to_cancel = undefined;
            }

            // -------------------------------------------------------------- SUBMIT ORDER ----------------------------------------------------------------
            $scope.submitOrder = function (order) {
                submit([order.id]);
            };

            $scope.checkTreatmentDates = checkTreatmentDates;

            function checkTreatmentDates() {
                $scope.number_of_orders_whose_treatment_date_is_before_delivery_date = 0;
                if ($scope.treatmentDates && $scope.order_to_submit.delivery_date && $scope.order_to_submit.delivery_date.length == 10) {
                    var yyyy = $scope.order_to_submit.delivery_date.substr(6, 4);
                    var mm = $scope.order_to_submit.delivery_date.substr(3, 2);
                    var dd = $scope.order_to_submit.delivery_date.substr(0, 2);
                    var delivery_date = new Date(parseInt(yyyy), parseInt(mm) - 1, parseInt(dd));

                    for (var i = 0; i < $scope.treatmentDates.length; i++) {
                        var treatmentDate = new Date($scope.treatmentDates[i]);
                        treatmentDate.setHours(0, 0, 0, 0);
                        if (treatmentDate < delivery_date) {
                            $scope.number_of_orders_whose_treatment_date_is_before_delivery_date++
                        }
                    }
                }
            }

            function submit(ids) {
                $scope.order_to_submit = {};

                if (ids.length === 1) {
                    ordersService.getOrderComment({ order_id: ids[0] }, function (response) {
                        $scope.order_to_submit.comment = response;
                    }, errorFunction);
                }
                ordersService.getTreatmentDates(ids, function (treatmentDates) {
                    checkTreatmentDates();
                    $scope.treatmentDates = treatmentDates;
                    practiceSettingsService.getPracticeSettings().then(function (settings) {
                        getPharmacies();
                        if (settings) {
                            $scope.order_to_submit.street = settings.address;
                            $scope.order_to_submit.city = settings.town;
                            $scope.order_to_submit.number = settings.No;
                            $scope.order_to_submit.zip = settings.Zip;
                            $scope.order_to_submit.order_ids = ids;
                            $scope.order_to_submit.receiver = settings.name;
                            $scope.default_pharmacy_id = settings.DefaultPharmacy;
                        }

                        $scope.order_to_submit.delivery_date_from = settings.DeliveryDateFrom;
                        $scope.order_to_submit.delivery_date_to = settings.DeliveryDateTo;

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
                    }, errorFunction);
                }, errorFunction);
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

                if ($scope.order_to_submit.isNewPharmacy) {
                    $scope.credentials_not_verified = false;
                    ngDialog.close();
                    confirmOrderSubmit();
                } else {
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
                }
            };

            // ---------------------------------------------------------- PHARMACY -------------------------------------------------------------

            $scope.checkSelectedPharmacy = function () {
                $scope.order_to_submit.isNewPharmacy = false;
                if ($scope.order_to_submit.default_pharmacy == undefined || $scope.order_to_submit.default_pharmacy == undefined == null || $scope.order_to_submit.default_pharmacy == emptyGuid) {
                    $scope.order_to_submit.isNewPharmacy = true;
                }
            }
            // ---------------------------------------------------------- SELECTION FUNCTIONS -------------------------------------------------------------

            $scope.$on('sticky:group-checked', function (event, data) {
                var order = getGroupItem(data.group);
                order.is_group_selected = !order.is_group_selected;
                checkGroup(order);
            });

            function checkGroup(item) {
                for (var i = 0; i < $scope.orders.length; i++) {
                    var order = $scope.orders[i];
                    if (order.group_name == item.group_name) {
                        var was_selected = order.is_selected;
                        if (was_selected && item.is_group_selected) {
                            continue;
                        }

                        order.is_selected = item.is_group_selected;
                        $scope.checkSelected(order);

                    }
                }
            }

            function checkAll() {
                deselected_action_ids = [];
                selected_action_ids = [];
                $scope.all_checked_previously = $scope.all_selected;
                selectAll();
            };

            $scope.cancelMultiEdit = function () {
                $scope.all_selected = false;
                $scope.all_checked_previously = false;
                selectAll();
                deselected_action_ids = [];
                selected_action_ids = [];
                $scope.parameter = new Object();
            };

            function selectAll() {
                $scope.selected_count = 0;
                if ($scope.all_selected) {
                    var sort_parameter = getSortParameter();
                    ordersService.getOrderCount(sort_parameter, function (result) {
                        $scope.selected_count = result;
                    }, errorFunction);
                };

                angular.forEach($scope.orders, function (item) {
                    item.is_selected = $scope.all_selected && item.status !== 'OCT4' && item.status !== 'OCT6';
                });

                $scope.any_selected = $scope.all_selected && $scope.orders.length !== 0;
            };

            $scope.checkSelected = function (item) {
                $scope.any_selected = false;

                if ($scope.all_checked_previously) {
                    if (!item.is_selected) {
                        deselected_action_ids.push(item.id);
                        $scope.all_selected = false;
                    } else {
                        $scope.all_selected = deselected_action_ids.length === 0;
                        var index = deselected_action_ids.indexOf(item.id);
                        deselected_action_ids.splice(index, 1);
                    };

                    $scope.any_selected = deselected_action_ids.length !== $scope.orders.length;
                } else {
                    if (item.is_selected && selected_action_ids.indexOf(item.id) === -1) {
                        selected_action_ids.push(item.id);
                    } else {
                        var index = selected_action_ids.indexOf(item.id);
                        selected_action_ids.splice(index, 1);
                        var selected_order_group = getGroupItem(item.group_name);
                        if (selected_order_group.is_group_selected) {
                            selected_order_group.is_group_selected = false;
                            $rootScope.$broadcast('sticky:group-deselected', { group: item.group_name });
                        }
                    };
                    $scope.any_selected = selected_action_ids.length !== 0 || $scope.all_selected;
                };

                $scope.selected_count = !$scope.any_selected ? 0 : item.is_selected ? $scope.selected_count === undefined ? 1 : $scope.selected_count + 1 : $scope.selected_count - 1;
            };

            // ---------------------------------------------------------- DELIVERY TIME ------------------------------------------------------------------

            $scope.$watch('order_to_submit.alternative_delivery_date_from', function () {
                if ($scope.order_to_submit && $scope.order_to_submit.alternative_delivery_date_from)
                    verifyDeliveryTime();
            });

            $scope.$watch('order_to_submit.alternative_delivery_date_to', function () {
                if ($scope.order_to_submit && $scope.order_to_submit.alternative_delivery_date_from)
                    verifyDeliveryTime();
            });

            function verifyDeliveryTime() {
                var from_array = $scope.order_to_submit.alternative_delivery_date_from.split(':');
                var from = new Date(1970, 0, 1, from_array[0], from_array[1], 0);
                var to_array = $scope.order_to_submit.alternative_delivery_date_to.split(':');
                var to = new Date(1970, 0, 1, to_array[0], to_array[1], 0);

                if (from > to)
                    $scope.delivery_time_invalid = true;
                else
                    $scope.delivery_time_invalid = false;
            };

            $scope.fixTime = function (time) {
                if ($scope.order_to_submit[time].length > 0 && $scope.order_to_submit[time].length < 5) {
                    var time_array = $scope.order_to_submit[time].split(':');
                    if (time_array.length > 1) {
                        var zeros = time_array[1] !== '' ? '0' : '00';
                        $scope.order_to_submit[time] = $scope.order_to_submit[time] + zeros;
                    } else {
                        $scope.order_to_submit[time] = time_array[0] < 10 ? '0' + $scope.order_to_submit[time] + ':00' : $scope.order_to_submit[time] + ':00';
                    };
                };
            };

            // ------------------------------------------------------------- MULTI SUBMIT ------------------------------------------------------------------

            $scope.multiSubmitOrders = function () {
                ordersService.getOrderIDsToSubmit({
                    all_selected: $scope.all_selected,
                    selected_ids: selected_action_ids,
                    deselected_ids: deselected_action_ids,
                    search_criteria: $scope.search_data ? $scope.search_data.text_search : ''
                }, function (response) {
                    submit(response);
                }, errorFunction);
            };

            // --------------------------------------------------------------- UTIL ----------------------------------------------------------------------

            function getGroupItem(currentGroupName) {
                return $filter('filter')($scope.orders, function (order) {
                    return order.group_name_CHANGED && order.group_name == currentGroupName;
                })[0];
            };

            $scope.removeSpaces = function (str) {
                return str.replace(/\s+/g, '').replace('.', '');
            };

            function reloadOrders() {
                $scope.scroll_down_params.infiniteScrollStartIndex = 0;
                $scope.isScrollDisabled = true;
                $scope.is_scroll = false;
                $rootScope.$broadcast("StickyReset");
                loadOrders();
                commonServices.focusSearch();
            }

            function errorFunction(response) {
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

            $scope.$on('CloseForm', function (event, data) {
                $scope.show_edit_order_form_id = undefined;
                reloadOrders();
            });

            // ------------------------------------------------------------------ CONTROLLER END ------------------------------------------------------------------
        }]);
})();
