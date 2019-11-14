(function () {
    'use strict';
    angular.module('mainModule').controller('planningController', ['$scope', '$rootScope', 'planningService', 'alertService', 'ngDialog', '$routeParams', '$timeout', 'ordersService', 'validationService',
        '$filter', '$translate', 'commonServices', 'doctorsService',
    function ($scope, $rootScope, planningService, alertService, ngDialog, $routeParams, $timeout, ordersService, validationService, $filter, $translate, commonServices, doctorsService) {
        $scope.showCaseDirective = false;
        var sort_by = "treatment_date";
        var ascending = false;
        var selected_action_ids = [];
        var deselected_action_ids = [];
        $scope.selected_count = 0;
        $scope.parameter = new Object();
        $scope.any_submitted = false;
        $scope.scroll_down_params = new Object();
        $scope.scroll_down_params.infiniteScrollStep = 100;
        $scope.scroll_down_params.infiniteScrollStartIndex = 0;
        $scope.isScrollDisabled = false;
        $scope.cases = [];
        $scope.is_scroll = false;
        $scope.execute_scroll = false;
        $rootScope.$broadcast("StickyReset");
        $scope.loadMore = loadMore;
        var empty_guid = "00000000-0000-0000-0000-000000000000";
        // -------------------------------------------------------------------- INIT --------------------------------------------------------------------
        loadMore();
        doctorsService.getDoctorsInPractice().then(getOPDoctorsComplete);

        // ---------------------------------------------------------------------- DATA RETRIEVAL -----------------------------------------------------------------------

        $scope.$on('GlobalSearch', function (event, data) {
            $scope.search_data = data;
            $scope.selected_count = $scope.all_selected ? $scope.selected_count : 0;
            deselected_action_ids = $scope.search_data.all_selected ? deselected_action_ids : [];
            selected_action_ids = $scope.search_data.all_selected ? selected_action_ids : [];
            $scope.scroll_down_params.infiniteScrollStartIndex = 0;
            $scope.is_scroll = false;
            $scope.isScrollDisabled = true;
            getCases();
        });

        function loadMore() {
            if ($routeParams.filter !== undefined) {
                $rootScope.$broadcast('SetFilter', { patientName: $routeParams.filter.split('_').join(' ') });

            };
            if ($scope.execute_scroll) return;
            $scope.is_scroll = true;
            getCases();
        };

        function getCasesComplete(response) {

            $translate('LABEL_CASE_CANNOT_MULTI_EDIT').then(function (translation) {
                for (var i = 0; i < response.length; i++) {
                    var item = response[i];
                    if (item.localization === '-' || item.status_treatment === 'OP4') {
                        item.tooltip = translation;
                    }
                }

                $scope.execute_scroll = false;
                $scope.scroll_down_params.infiniteScrollStartIndex = $scope.scroll_down_params.infiniteScrollStartIndex + $scope.scroll_down_params.infiniteScrollStep;
                $scope.isScrollDisabled = response.length < $scope.scroll_down_params.infiniteScrollStep;
                if ($scope.is_scroll) {
                    $scope.cases = $scope.cases.concat(response);
                } else {
                    $rootScope.$broadcast("StickyReset");
                    $scope.cases.length = 0;
                    $scope.cases = response;
                };
                $scope.selectAll();

                if ($scope.should_download) {
                    commonServices.download($scope.should_download);
                    $scope.should_download = undefined;
                };

                commonServices.focusSearch();
            });
        };

        function getCases() {
            if ($scope.execute_scroll) return;
            $scope.execute_scroll = true;

            var sort_parameter = new Object();
            sort_parameter.sort_by = sort_by;
            sort_parameter.isAsc = ascending;
            sort_parameter.start_row_index = $scope.scroll_down_params.infiniteScrollStartIndex;

            if ($scope.search_data === undefined) {
                sort_parameter.search_params = $routeParams.filter !== undefined ? $routeParams.filter.split('_').join(' ') : '';
                sort_parameter.date_from = "1-1-1";
                sort_parameter.date_to = '';
                sort_parameter.filter_by = new Object();
                sort_parameter.filter_by.filter_status = [];
                sort_parameter.filter_by.filter_type = [];
                sort_parameter.filter_by.filter_current = true;
                sort_parameter.filter_by.order = null;
            } else {
                sort_parameter.search_params = $scope.search_data.text_search;
                sort_parameter.filter_by = $scope.search_data.filter_by;
                if (sort_parameter.filter_by.localization === undefined && sort_parameter.filter_by.order === undefined && sort_parameter.filter_by.filter_status.length == 0 && sort_parameter.filter_by.filter_type.length == 0) {
                    sort_parameter.filter_by.filter_current = true;
                };

                sort_parameter.date_from = $scope.search_data.date_from;
                sort_parameter.date_to = $scope.search_data.date_to;
                sort_parameter.hip_name = $scope.search_data.filter_by.hip_name;
            };

            planningService.getCases(sort_parameter, getCasesComplete, errorFunction);
        };

        // -------------------------------------------------------------------------------------------- SUBMIT CASE --------------------------------------------------------------------------------------------

        //#region Submit order
        getDoctors();
        function getDoctors() {
            doctorsService.getDoctorsInPractice().then(function (response) {
                $scope.doctors = response;
            }, errorFunction);
        }

        $scope.submitOrder = function (order) {
            submit([order.order_id]);
        };

        function submit(ids) {
            $scope.order_to_submit = {};

            if (ids.length === 1) {
                ordersService.getOrderComment({ order_id: ids[0] }, function (response) {
                    $scope.order_to_submit.comment = response;
                }, errorFunction);
            }

            ordersService.GetPracticeAddressAndBacisInfo(function (address) {
                if (address) {
                    $scope.order_to_submit.street = address.street;
                    $scope.order_to_submit.city = address.city;
                    $scope.order_to_submit.number = address.number;
                    $scope.order_to_submit.zip = address.zip;
                    $scope.order_to_submit.order_ids = ids;
                    $scope.order_to_submit.receiver = address.name;
                }

                $scope.order_to_submit.delivery_date_from = '08:00';
                $scope.order_to_submit.delivery_date_to = '18:00';

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
        }

        function openQuickOrder() {
            ngDialog.open({
                template: 'scripts/src/app/planning/view/quickOrderPopup.html'
            });
        }

        $scope.openQuickOrder = function () {
            openQuickOrder();
        };


        $scope.passwordConfirmationCancel = function () {
            resetOrderToSubmit();
            ngDialog.close();
        };

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

        function confirmOrderSubmit() {
            ordersService.submitOrder($scope.order_to_submit, function (response) {
                commonServices.download(response);
                resetOrderToSubmit();
                alertService.RenderSuccessMessage('LABEL_ORDERS_SUBMITTED');
                $scope.scroll_down_params.infiniteScrollStartIndex = 0;
                $scope.isScrollDisabled = true;
                $scope.is_scroll = false;
                getCases();
            }, errorFunction);
        }

        function resetOrderToSubmit() {
            $scope.order_to_submit = undefined;
        }
        //#endregion

        $scope.submitCase = function (item) {
            $scope.id_to_submit = item.id;
            $scope.treatment_doctor_id = item.treatment_doctor_id;
            $scope.case_to_submit = item;

            var param = new Object();
            param.case_id = item.id;
            param.id = $scope.case_to_submit.treatment_doctor_id;
            param.secondary_id = $scope.case_to_submit.aftercare_doctor_practice_id;
            param.tertiary_id = $scope.case_to_submit.patient_id;
            param.date_string = $filter('date')($scope.case_to_submit.treatment_date, 'dd.MM.yyyy');
            param.diagnose_id = $scope.case_to_submit.diagnose_id;
            param.drug_id = $scope.case_to_submit.drug_id;

            planningService.validateConsents(param, validateConsentsComplete, errorFunction);
        };

        function validateConsentsComplete(response) {
            if (response.length === 0) {
                $scope.showCaseDirective = false;
                if ($scope.show_edit_case_form) {
                    $scope.show_edit_case_form = false;
                    $scope.edit_case_id = 0;
                };
                $scope.case_id = $scope.id_to_submit;

                var parameters = new Object();
                parameters.ids_to_submit = [$scope.case_id];

                planningService.checkIfAlreadyExistAnyTreatment(parameters, function (response) {
                    if (response.number_of_invalid_cases == 0) {
                        alertService.ConfirmPassword($scope, $scope.confirmSubmitCase, $scope.cancelSubmitCase, 'LABEL_PLEASE_ENTER_PASSWORD_TO_SUBMIT_CASE', $scope.treatment_doctor_id);
                    } else {
                        alertService.RenderNotificationMessage([{ message: 'LABEL_TREATMENT_ALREADY_EXIST' }], $scope, function () {
                            ngDialog.close();
                        });
                    }
                }, errorFunction)


            } else {
                alertService.RenderNotificationMessage(response, $scope);
            };
        };


        $scope.confirmSubmitCase = function (doctor_id) {
            var case_param = new Object();
            case_param.case_id = $scope.case_id;
            case_param.authorizing_doctor_id = doctor_id;

            planningService.submitCase(case_param, submitCaseComplete, errorFunction);
        };

        $scope.cancelSubmitCase = function () {
            $scope.case_id = undefined;
        };

        function submitCaseComplete(response) {
            $scope.should_download = response;
            alertService.RenderSuccessMessage('LABEL_CASE_SUBMITTED');
            $scope.scroll_down_params.infiniteScrollStartIndex = 0;
            $scope.isScrollDisabled = true;
            $scope.is_scroll = false;
            getCases();
        };


        /**Cancel case******************************/
        $scope.cancelCase = function (case_id) {
            if ($scope.show_edit_case_form || $scope.showCaseDirective) {
                $scope.show_edit_case_form = false;
                $scope.showCaseDirective = false;
            } else {
                planningService.getCaseHasOctPending({ case_id: case_id }, function (response) {
                    if (response) {
                        alertService.RenderNotificationMessage([{ message: 'LABEL_PENDING_OCT_WONT_BE_AUTOMATICALLY_CANCELLED' }], $scope, function () {
                            ngDialog.close();
                            continueCaseCancellation(case_id);
                        });
                    } else {
                        continueCaseCancellation(case_id);
                    }
                }, errorFunction);
            };
        };

        function continueCaseCancellation(case_id) {
            var case_param = new Object();
            case_param.case_id = case_id;
            planningService.getCaseDetails(case_param, getCaseDetailsComplete, errorFunction);
        }

        $scope.confirmCancelCase = function () {
            if ($scope.is_order_submitted) {
                $scope.credentials_not_verified = false;
                planningService.verifyPassword({
                    doctor: { id: $scope.case_cancellation.doctor_id },
                    password: $scope.case_cancellation.password
                }, function (response) {
                    completeCaseCancellation();
                }, function () {
                    $scope.credentials_not_verified = true;
                });
            } else {
                completeCaseCancellation();
            }
        };

        function completeCaseCancellation() {
            var case_param = new Object();
            case_param.case_id = $scope.case_id;
            if ($scope.case_cancellation.both) {
                case_param.cancel_drug_order = true;
                case_param.cancel_treatment = true;
                $scope.cancel_popup.message = $scope.is_orders_drug && $scope.is_treatment ? 'LABEL_MESSAGE_CANCEL_BOTH' : $scope.is_orders_drug ? 'LABEL_MESSAGE_CANCEL_ORDER' : 'LABEL_MESSAGE_CANCEL_TREATMENT';
            } else {
                case_param.cancel_drug_order = true;
                case_param.cancel_treatment = false;
                $scope.cancel_popup.message = 'LABEL_MESSAGE_CANCEL_ORDER';
            };

            planningService.cancelCase(case_param, cancelCaseComplete, errorFunction);
            ngDialog.close();

        }

        function cancelCaseComplete(response) {
            alertService.RenderSuccessMessage($scope.cancel_popup.message);
            $scope.scroll_down_params.infiniteScrollStartIndex = 0;
            $scope.isScrollDisabled = true;
            $scope.is_scroll = false;
            getCases();
        };

        $scope.cancelCancelCase = function () {
            $scope.case_id = undefined;
            ngDialog.close();
        };

        function getCaseDetailsComplete(response) {
            planningService.getIsOrderSubmitted({ case_id: response.case_id }, function (is_order_submitted) {
                $scope.cancel_popup = new Object();
                $scope.is_orders_drug = response.is_orders_drug;
                $scope.is_treatment = response.is_treatment_form_open;
                $scope.is_order_submitted = is_order_submitted;

                $scope.cancel_popup.title = response.is_orders_drug && response.is_treatment_form_open ? 'LABEL_TITLE_CANCEL_BOTH' : response.is_orders_drug ? 'LABEL_TITLE_CANCEL_ORDER' : 'LABEL_TITLE_CANCEL_TREATMENT';
                $scope.cancel_popup.content = response.is_orders_drug && response.is_treatment_form_open ? 'LABEL_CONTENT_CANCEL_BOTH' : response.is_orders_drug ? 'LABEL_CONTENT_CANCEL_ORDER' : 'LABEL_CONTENT_CANCEL_TREATMENT';
                $scope.cancel_popup.message = 'LABEL_MESSAGE_CANCEL_TREATMENT';
                $scope.cancel_popup.show_radio_buttons = response.is_orders_drug && response.is_treatment_form_open;
                $scope.case_id = response.case_id;

                $scope.case_cancellation = new Object();
                if (response.treatment_doctor_id !== $scope.opDoctors[0].id) {
                    $scope.case_cancellation.doctor_id = response.treatment_doctor_id;
                } else {
                    $scope.case_cancellation.doctor_id = $rootScope.isDoctor ? $rootScope.id : undefined;
                }
                if ($scope.cancel_popup.show_radio_buttons) {
                    $scope.case_cancellation.both = true;
                } else {
                    if (response.is_orders_drug && response.is_treatment_form_open) {
                        $scope.case_cancellation.both = true;
                    } else {
                        $scope.case_cancellation.order_only = response.is_orders_drug;
                        $scope.case_cancellation.both = response.is_treatment_form_open;
                    };
                };

                ngDialog.open({
                    template: 'scripts/src/app/planning/view/cancelCasePopupTemplate.html',
                    scope: $scope,
                    closeByDocument: false
                });
            }, errorFunction);
        };

        $scope.changeMessage = function () {
            $scope.cancel_popup.content = $scope.case_cancellation.both ? 'LABEL_CONTENT_CANCEL_BOTH' : 'LABEL_CONTENT_CANCEL_ORDER';
        };

        // ------------------------------------------------------------------- SELECTION FUNCTIONS -----------------------------------------------------------------

        $scope.checkAll = function () {
            deselected_action_ids = [];
            selected_action_ids = [];
            $scope.all_checked_previously = $scope.all_selected;
            $scope.selectAll();
        };

        $scope.selectAll = function () {
            $scope.selected_count = 0;

            if ($scope.all_selected) {
                var parameter = new Object();

                if ($scope.search_data === undefined) {
                    parameter.search_params = '';
                    parameter.date_from = "1-1-1";
                    parameter.date_to = '';
                    parameter.filter_by = new Object();
                    parameter.filter_by.filter_status = [];
                    parameter.filter_by.filter_type = [];
                    parameter.filter_by.filter_current = true;
                    parameter.filter_by.order = null;
                } else {
                    parameter.search_params = $scope.search_data.text_search;
                    parameter.filter_by = $scope.search_data.filter_by;
                    parameter.date_from = $scope.search_data.date_from;
                    parameter.date_to = $scope.search_data.date_to;
                    parameter.hip_name = $scope.search_data.filter_by.hip_name;
                };

                planningService.getCasesCount(parameter, getCasesCountComplete, errorFunction);
            };

            angular.forEach($scope.cases, function (item) {
                item.is_selected = $scope.all_selected && item.localization !== '-' && item.status_treatment !== 'OP4';
            });

            $scope.any_selected = $scope.all_selected && $scope.cases.length !== 0;
        };

        function getCasesCountComplete(response) {
            $scope.selected_count = response;

            if ($scope.selected_count !== 0) {
                $timeout(function () { angular.element('#selMultiOpDoctor_value')[0].focus(); }, 0, false);
            };
        };

        $scope.checkSelected = function (item) {
            $scope.any_selected = false;

            if ($scope.all_checked_previously) {
                if (!item.is_selected) {
                    deselected_action_ids.push(item.id);
                    $scope.all_selected = false;
                } else {
                    var index = deselected_action_ids.indexOf(item.id);
                    deselected_action_ids.splice(index, 1);
                    $scope.all_selected = deselected_action_ids.length === 0;
                };

                $scope.any_selected = deselected_action_ids.length !== $scope.cases.length;
            } else {
                if (item.is_selected && selected_action_ids.indexOf(item.id) === -1) {
                    selected_action_ids.push(item.id);
                } else {
                    var index = selected_action_ids.indexOf(item.id);
                    selected_action_ids.splice(index, 1);
                };
                $scope.any_selected = selected_action_ids.length !== 0 || $scope.all_selected;
            };

            $scope.selected_count = !$scope.any_selected ? 0 : item.is_selected ? $scope.selected_count === undefined ? 1 : $scope.selected_count + 1 : $scope.selected_count - 1;

            if ($scope.selected_count !== 0) {
                $timeout(function () { angular.element('#selMultiOpDoctor_value')[0].focus(); }, 0, false);
            };
        };


        // ------------------------------------------------------------------------- MULIT EDIT/SUBMIT FUNCTIONS -----------------------------------------------------------------------

        $scope.cancelMultiEdit = function () {
            $scope.all_selected = false;
            $scope.all_checked_previously = false;
            $scope.selectAll();
            deselected_action_ids = [];
            selected_action_ids = [];
        };

        $scope.multiEditCase = function (should_submit) {
            $scope.submitted = should_submit;
            setAftercareDoctorPracticeId();
            if (should_submit) {

                var multiSubmitParameter = new Object();
                multiSubmitParameter.ids_to_submit = selected_action_ids;
                multiSubmitParameter.ids_to_deselect = deselected_action_ids;
                multiSubmitParameter.all_selected = $scope.all_selected;
                multiSubmitParameter.filter_by = new Object();
                multiSubmitParameter.filter_by.filter_by = new Object();
                multiSubmitParameter.filter_by.filter_by = $scope.search_data !== undefined ? $scope.search_data.filter_by : new Object();
                multiSubmitParameter.filter_by.date_from = $scope.search_data !== undefined ? $scope.search_data.date_from : '1-1-1';
                multiSubmitParameter.filter_by.date_to = $scope.search_data !== undefined ? $scope.search_data.date_to : '';
                multiSubmitParameter.filter_by.search_params = $scope.search_data !== undefined ? $scope.search_data.text_search : '';
                multiSubmitParameter.filter_by.filter_by.filter_type = $scope.search_data !== undefined ? $scope.search_data.filter_by.filter_type : [];
                multiSubmitParameter.filter_by.filter_by.filter_status = $scope.search_data !== undefined ? $scope.search_data.filter_by.filter_status : [];
                multiSubmitParameter.filter_by.filter_by.filter_current = $scope.search_data !== undefined ? $scope.search_data.filter_by.filter_current : true;
                multiSubmitParameter.sort_by = sort_by;
                multiSubmitParameter.isAsc = ascending;

                if ($scope.parameter.treatment_doctor_id === $scope.opDoctors[0].id) {
                    $scope.multi_popup = true;
                    $scope.multi_popup_index = 0;

                    planningService.initiateMultiSubmit(multiSubmitParameter, initiateMultiSubmitComplete, errorFunction);
                } else {
                    alertService.ConfirmPassword($scope, initiateMultiEdit, cancelMultiSubmit, 'LABEL_PLEASE_ENTER_PASSWORD_TO_SUBMIT_CASE', $scope.parameter.treatment_doctor_id);
                };

            } else {
                initiateMultiEdit()
            };
        };

        function initiateMultiSubmitComplete(response) {
            if (response.length) {
                $scope.popup_doctors = response;
                nextPopup();
            } else {
                alertService.RenderNotificationMessage([{ message: 'LABEL_NO_CASE_CAN_BE_SUBMITTED' }], $scope);
            }
        };

        function nextPopup() {
            alertService.ConfirmPassword($scope, initiateMultiEdit, cancelCurrentPopup, 'LABEL_PLEASE_ENTER_PASSWORD_TO_SUBMIT_CASE', $scope.popup_doctors[$scope.multi_popup_index].id);
        };

        function cancelCurrentPopup() {
            $scope.multi_popup_index++;
            if ($scope.multi_popup_index !== $scope.popup_doctors.length) {
                nextPopup();
            } else {
                if ($scope.any_submitted) {
                    alertService.RenderSuccessMessage('LABEL_CASE_SUBMITTED');
                    reloadCases();
                };
            };
        };

        function cancelCurrentPopup_helperFunction() {
            ngDialog.close();
            cancelCurrentPopup();
        };

        function initiateMultiEdit(doctor_id) {
            $scope.auth_doc_id = doctor_id;

            $scope.param = new Object();
            $scope.param.authorizing_doctor_id = doctor_id;
            $scope.param.ids_to_edit = selected_action_ids;
            $scope.param.ids_to_deselect = deselected_action_ids;
            $scope.param.primary_id = $scope.parameter.treatment_doctor_id;
            $scope.param.secondary_id = $scope.parameter.aftercare_doctor_practice_id;
            $scope.param.flag = false;
            $scope.param.all_selected = $scope.all_selected;
            $scope.param.filter_by = new Object();
            $scope.param.filter_by.filter_by = new Object();
            $scope.param.filter_by.filter_by = $scope.search_data !== undefined ? $scope.search_data.filter_by : new Object();
            $scope.param.filter_by.date_from = $scope.search_data !== undefined ? $scope.search_data.date_from : '1-1-1';
            $scope.param.filter_by.date_to = $scope.search_data !== undefined ? $scope.search_data.date_to : '';
            $scope.param.filter_by.search_params = $scope.search_data !== undefined ? $scope.search_data.text_search : '';
            $scope.param.filter_by.filter_by.filter_type = $scope.search_data !== undefined ? $scope.search_data.filter_by.filter_type : [];
            $scope.param.filter_by.filter_by.filter_status = $scope.search_data !== undefined ? $scope.search_data.filter_by.filter_status : [];
            $scope.param.filter_by.filter_by.filter_current = $scope.search_data !== undefined ? $scope.search_data.filter_by.filter_current : true;

            planningService.multiEditCase($scope.param, multiEditCaseComplete, multiEditCaseError);
        };

        function multiEditCaseComplete() {
            if (!$scope.submitted) {
                alertService.RenderSuccessMessage('LABEL_CHANGES_SAVED');
                reloadCases();
            } else {
                confirmMultiSubmit();
            };
        };

        function confirmMultiSubmit() {
            $scope.consent_validation_parameter = new Object();
            $scope.consent_validation_parameter.type = "case";
            $scope.consent_validation_parameter.flag = true;
            $scope.consent_validation_parameter.multi_ids = selected_action_ids;
            $scope.consent_validation_parameter.deselected_ids = deselected_action_ids;
            $scope.consent_validation_parameter.secondary_flag = $scope.all_selected;
            $scope.consent_validation_parameter.id = $scope.parameter.treatment_doctor_id;
            $scope.consent_validation_parameter.secondary_id = $scope.parameter.aftercare_doctor_practice_id;
            $scope.consent_validation_parameter.filter_by = new Object();
            $scope.consent_validation_parameter.filter_by.filter_by = new Object();
            $scope.consent_validation_parameter.filter_by.date_from = $scope.search_data !== undefined ? $scope.search_data.date_from : '1-1-1';
            $scope.consent_validation_parameter.filter_by.date_to = $scope.search_data !== undefined ? $scope.search_data.date_to : '';
            $scope.consent_validation_parameter.filter_by.search_params = $scope.search_data !== undefined ? $scope.search_data.text_search : '';
            $scope.consent_validation_parameter.filter_by.filter_by = $scope.search_data !== undefined ? $scope.search_data.filter_by : new Object();
            $scope.consent_validation_parameter.filter_by.filter_by.filter_type = $scope.search_data !== undefined ? $scope.search_data.filter_by.filter_type : [];
            $scope.consent_validation_parameter.filter_by.filter_by.filter_status = $scope.search_data !== undefined ? $scope.search_data.filter_by.filter_status : [];
            $scope.consent_validation_parameter.filter_by.filter_by.filter_current = $scope.search_data !== undefined ? $scope.search_data.filter_by.filter_current : true;
            $scope.consent_validation_parameter.authorizing_doctor_id = $scope.auth_doc_id;
            $scope.param.authorizing_doctor_id = $scope.auth_doc_id;

            planningService.validateConsentsMulti($scope.consent_validation_parameter, validateConsentsMultiComplete, errorFunction);
        };

        function validateConsentsMultiComplete(responseConsent) {
            $scope.param.ids_to_submit = responseConsent;
            $scope.param.flag = true;

            if (responseConsent.length !== 0) {
                planningService.checkIfAlreadyExistAnyTreatment($scope.param, function (responseDuplicate) {
                    $scope.param.ids_to_submit = responseDuplicate.valid_case_ids;
       
                    if (responseDuplicate.valid_case_ids.length !== 0) {
                        var message = new Object();
                        message.message = 'LABEL_MULTI_SUBMIT_ELIGIBILITY';

                        if (responseDuplicate.number_of_invalid_cases == 0) {
                            if (!$scope.multi_popup) {
                                if ($scope.selected_count - responseConsent.length !== 0) {

                                    message.eligible_cases = $scope.selected_count - responseConsent.length;
                                    message.total_cases = $scope.selected_count;
                                    alertService.RenderConfirmationDialog('LABEL_WARNING', message, 'BUTTON_YES', 'BUTTON_NO', confirmMultiSubmitAfterMultiEdit, cancelMultiSubmitAfterMultiEdit);
                                } else {
                                    confirmMultiSubmitAfterMultiEdit();
                                };
                            } else {
                                if ($scope.popup_doctors[$scope.multi_popup_index].count - responseConsent.length !== 0) {
                                    message.eligible_cases = $scope.popup_doctors[$scope.multi_popup_index].count - responseConsent.length;
                                    message.total_cases = $scope.popup_doctors[$scope.multi_popup_index].count;
                                    alertService.RenderConfirmationDialog('LABEL_WARNING', message, 'BUTTON_YES', 'BUTTON_NO', confirmMultiSubmitAfterMultiEdit, cancelMultiSubmitAfterMultiEdit);
                                } else {
                                    confirmMultiSubmitAfterMultiEdit();
                                };
                            };
                        } else {
                            message.total_cases = responseDuplicate.number_of_all_cases;
                            if (!$scope.multi_popup) {
                                if ($scope.selected_count - responseConsent.length !== 0) {
                                    message.eligible_cases = $scope.selected_count - responseConsent.length;
                                    message.total_cases = $scope.selected_count;
                                }
                            } else {
                                if ($scope.popup_doctors[$scope.multi_popup_index].count - responseConsent.length !== 0) {
                                    message.eligible_cases = $scope.popup_doctors[$scope.multi_popup_index].count - responseConsent.length;
                                    message.total_cases = $scope.popup_doctors[$scope.multi_popup_index].count;
                                }
                            };

                            message.eligible_cases += responseDuplicate.number_of_invalid_cases;

                            alertService.RenderConfirmationDialog('LABEL_WARNING', message, 'BUTTON_YES', 'BUTTON_NO', confirmMultiSubmitAfterMultiEdit, cancelMultiSubmitAfterMultiEdit);
                        }
                    } else {
                        alertService.RenderNotificationMessage([{ message: 'LABEL_NO_CASE_CAN_BE_SUBMITTED' }], $scope, $scope.multi_popup ? cancelCurrentPopup_helperFunction : undefined);
                    }
                }, errorFunction)
            } else {
                alertService.RenderNotificationMessage([{ message: 'LABEL_NO_CASE_CAN_BE_SUBMITTED' }], $scope, $scope.multi_popup ? cancelCurrentPopup_helperFunction : undefined);
            };
        };

        function confirmMultiSubmitAfterMultiEdit() {
            planningService.multiEditCase($scope.param, confirmMultiSubmitAfterMultiEditComplete, errorFunction);
        };

        function confirmMultiSubmitAfterMultiEditComplete(response) {
            commonServices.download(response);
            if ($scope.multi_popup) {
                $scope.any_submitted = true;
                $scope.multi_popup_index++;
                if ($scope.multi_popup_index !== $scope.popup_doctors.length) {
                    nextPopup();
                } else {
                    alertService.RenderSuccessMessage('LABEL_CASE_SUBMITTED');
                    reloadCases();

                };
            } else {
                alertService.RenderSuccessMessage('LABEL_CASE_SUBMITTED');
                reloadCases();
            };
        };

        function cancelMultiSubmit(response) {
            reloadCases();
        };

        $scope.cancelCaseMultiEdit = function () {
            $scope.parameter = new Object();
            $scope.parameter.treatment_doctor_id = $scope.opDoctors[0].id;

            return;
        };


        function cancelMultiSubmitAfterMultiEdit() {
            if ($scope.multi_popup) {
                $scope.multi_popup_index++;
                if ($scope.multi_popup_index !== $scope.popup_doctors.length) {
                    nextPopup();
                } else {
                    if ($scope.any_submitted)
                        alertService.RenderSuccessMessage('LABEL_CASE_SUBMITTED');

                    reloadCases();
                };
            } else {
                reloadCases();
            };
        };

        // ---------------------------------------------------- ERROR FUNCTIONS ------------------------------------------------

        function errorFunction(response) {
            console.log(response);
            $scope.execute_scroll = false;
            alertService.RenderErrorMessage('LABEL_SOMETHING_WENT_WRONG');
        };

        function multiEditCaseError(response) {
            $scope.execute_scroll = false;
            alertService.RenderErrorMessage('LABEL_SOMETHING_WENT_WRONG');
            $scope.parameter = new Object();
            $scope.parameter.treatment_doctor_id = $scope.opDoctors[0].id;
        };
        // ------------------------------ UTIL ----------------------------------------

        $scope.checkItemStatus = function (item) {
            if (item.status_treatment === 'OP4') {
                return false;
            } else if (item.status_treatment === '' && item.status_drug_order === 'MO6') {
                return false;
            };

            return true;
        };

        function reloadCases() {
            $scope.cases.length = 0;
            $scope.is_scroll = false;
            $scope.scroll_down_params.infiniteScrollStartIndex = 0;
            $scope.isScrollDisabled = true;
            getCases();
            $scope.parameter = new Object();
            $scope.parameter.treatment_doctor_id = $scope.opDoctors[0].id;
            if (deselected_action_ids)
                deselected_action_ids.length = 0;
            if (selected_action_ids)
                selected_action_ids.length = 0;
            $scope.all_checked_previously = false;
            $scope.all_selected = false;
            $scope.selectAll();
            $scope.multi_popup_index = 0;
            if ($scope.popup_doctors)
                $scope.popup_doctors.length = 0;
        };

        $scope.getTreatmentStatusClassName = function (item) {
            switch (item.status_treatment) {
                case 'OP1':
                    return 'normal-height-font margin-top-3';
                default:
                    return 'normal-height-font margin-top-3 gray-font-color';
            }
        };

        $scope.getBorderClassName = function (item) {
            switch (item.status_drug_order) {
                case 'MO1':
                    return 'yellow-border';
                case 'MO2':
                    return 'yellow-border';
                case 'MO3':
                    return 'green-border';
                case 'MO4':
                    return 'red-border';
                default:
                    return '';
            }
        };

        $scope.getDrugStatusClassName = function (item) {
            switch (item.status_drug_order) {
                case 'MO1':
                    return 'ordered-text';
                case 'MO2':
                    return 'ordered-text';
                case 'MO3':
                    return 'shipped-text';
                case 'MO4':
                    return 'rejected-text';
                case 'MO6':
                case 'MO9':
                    return 'normal-height-font gray-font-color margin-top-3';
                case 'MO8':
                    return 'rejected-text';
                default:
                    return '';
            }
        };

        $scope.getPreviousStatusLabel = function (status) {
            return status !== '' ? status : 'LABEL_NO_DRUGS_ORDERED';
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
            $scope.cases = [];
            $scope.scroll_down_params.infiniteScrollStartIndex = 0;
            $scope.is_scroll = false;
            $scope.isScrollDisabled = true;

            $rootScope.$broadcast("StickyReset");
            getCases();
        };

        $scope.isOrderCancelled = function (item) {
            return item.status_drug_order === 'MO6';
        };

        $scope.showDrugOrderStatus = function (item) {
            return item.status_drug_order !== '' && item.status_treatment !== 'OP3';
        };

        function setAftercareDoctorPracticeId() {
            $scope.parameter.aftercare_doctor_practice_id = $scope.parameter.aftercare_doctor_practice ? $scope.parameter.aftercare_doctor_practice.id : undefined;
        };

        $scope.isEditButtonDisabled = function () {
            return $scope.parameter.aftercare_doctor_practice === undefined && ($scope.parameter.treatment_doctor_id === $scope.opDoctors[0].id || $scope.parameter.treatment_doctor_id === undefined);
        };

        $scope.$on('CloseForm', function (event, data) {
            if (data.form === 'CloseCase') {
                $scope.showCaseDirective = false;
                if ($scope.show_edit_case_form) {
                    $scope.show_edit_case_form = false;
                    $scope.edit_case_id = 0;
                };

                $scope.show_edit_order_form_id = undefined;
                $rootScope.$broadcast("StickyReset");
                $scope.scroll_down_params.infiniteScrollStartIndex = 0;
                $scope.is_scroll = false;
                $scope.isScrollDisabled = true;
                getCases();
                commonServices.focusSearch();
            };
        });

        $scope.openCaseEditForm = function (id) {
            $scope.showCaseDirective = false;
            $scope.show_edit_case_form = !$scope.show_edit_case_form;
            $scope.edit_case_id = id;
        };

        $scope.OpenFormAddCase = function () {
            $scope.showCaseDirective = true;
        };

        function getOPDoctorsComplete(response) {
            $scope.opDoctors = response;
            $scope.opDoctors.unshift({ id: empty_guid, display_name: 'LABEL_EMPTY' });
            $scope.parameter.treatment_doctor_id = $scope.opDoctors[0].id;
        };

        commonServices.focusSearch();

        // ---------------------------- CONTROLLER END ------------------------------------------------
    }]);
})();
