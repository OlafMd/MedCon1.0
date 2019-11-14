(function () {
    'use strict';
    angular.module('mainModule').controller('octController', ['$scope', '$timeout', '$filter', '$rootScope', 'commonServices', 'validationService', 'octService', 'alertService', 'ngDialog', 'documentationOnlyService', 'doctorsService',
        function ($scope, $timeout, $filter, $rootScope, commonServices, validationService, octService, alertService, ngDialog, documentationOnlyService, doctorsService) {

            $scope.octs = [];
            $scope.today = $filter('date')(new Date(), 'MM.dd.yyyy');
            $scope.show_datepicker_id = null;
            var sort_by = "oct_date";
            var ascending = true;
            $scope.scroll_down_params = new Object();
            $scope.scroll_down_params.infiniteScrollStep = 100;
            $scope.scroll_down_params.infiniteScrollStartIndex = 0;
            $scope.search_data = new Object();
            $scope.search_data.filter_by = new Object();
            $scope.search_data.filter_by.filter_status = [];
            $scope.search_data.filter_by.filter_type = [];
            $scope.search_data.filter_by.filter_current = true;
            $scope.parameter = new Object();

            var selected_action_ids = [];
            var deselected_action_ids = [];
            $scope.all_selected = false;
            $scope.selected_count = 0;
            $scope.execute_scroll = false;
            loadOCT();
            getDoctors();

            $rootScope.$broadcast("StickyReset");

            function loadOCT() {
                if ($scope.execute_scroll) return;
                $scope.execute_scroll = true;
                var sort_parameter = new Object();
                sort_parameter.sort_by = sort_by;
                sort_parameter.isAsc = ascending;
                sort_parameter.start_row_index = $scope.scroll_down_params.infiniteScrollStartIndex;
                if ($scope.search_data) {
                    sort_parameter.search_params = $scope.search_data.text_search;
                    sort_parameter.filter_by = $scope.search_data.filter_by;
                    sort_parameter.hip_name = $scope.search_data.filter_by.hip_name;
                }

                octService.getAllOCT(sort_parameter, errorFunction).then(function (result) {
                    $scope.execute_scroll = false;
                    $scope.octs = $scope.octs.concat(result);
                    $scope.scroll_down_params.infiniteScrollStartIndex = $scope.scroll_down_params.infiniteScrollStartIndex + $scope.scroll_down_params.infiniteScrollStep;
                    $scope.isScrollDisabled = result.length < $scope.scroll_down_params.infiniteScrollStep;
                    $scope.checkAll();
                    commonServices.focusSearch();
                });

                if ($scope.should_download) {
                    commonServices.download($scope.should_download.reportUrl);
                    $scope.should_download = undefined;
                };
            };

            $scope.loadMore = function () {
                if ($scope.execute_scroll) return;
                $scope.is_scroll = true;
                loadOCT();
            };

            function getDoctors() {
                doctorsService.getDoctorsInPractice().then(function (response) {
                    $scope.oct_doctors = response;
                    $scope.oct_doctors.unshift({ id: '00000000-0000-0000-0000-000000000000', display_name: ' ' });
                    $scope.parameter.oct_doctor_id = $scope.oct_doctors[0].id;
                });
            }

            $scope.$on('GlobalSearch', function (event, data) {
                $scope.scroll_down_params.infiniteScrollStartIndex = 0;
                $scope.octs = [];
                $scope.isScrollDisabled = true;
                $scope.search_data = data;
                $scope.is_scroll = false;
                $rootScope.$broadcast("StickyReset");
                loadOCT();
                commonServices.focusSearch();
            });

            $scope.checkAll = function () {
                deselected_action_ids = [];
                selected_action_ids = [];
                $scope.all_checked_previously = $scope.all_selected;
                $scope.selectAll();
            };

            $scope.cancelMultiEdit = function () {
                $scope.all_selected = false;
                $scope.all_checked_previously = false;
                $scope.selectAll();
                deselected_action_ids = [];
                selected_action_ids = [];
                $scope.parameter = new Object();
            };

            $scope.selectAll = function () {
                $scope.selected_count = 0;

                if ($scope.all_selected) {
                    var parameter = new Object();

                    if ($scope.search_data === undefined) {
                        parameter.filter_by = { filter_status: ["oct1"], filter_type: [] };
                        parameter.search_params = '';
                    } else {
                        parameter.search_params = $scope.search_data.text_search;
                        parameter.filter_by = $scope.search_data.filter_by;
                        parameter.date_from = $scope.search_data.date_from;
                        parameter.date_to = $scope.search_data.date_to;
                        parameter.hip_name = $scope.search_data.filter_by.hip_name;
                    };

                    octService.getOctCount(parameter, errorFunction).then(function (result) {
                        $scope.selected_count = result;
                    });
                };

                angular.forEach($scope.octs, function (item) {
                    item.is_selected = $scope.all_selected && item.status !== 'OCT4' && item.status !== 'OCT6';
                });

                $scope.any_selected = $scope.all_selected && $scope.octs.length !== 0;
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

                    $scope.any_selected = deselected_action_ids.length !== $scope.octs.length;
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
            };

            $scope.getOctStatusClassName = function (item) {
                switch (item.status) {
                    case 'OCT3': return 'red-border';
                }
            };
            // -------------------------------------------------------------------------------------------- SUBMIT CASE --------------------------------------------------------------------------------------------

            $scope.submitOct = function (item) {
                $scope.oct_to_submit_patient_id = item.patient_id;
                if (validationService.isValidDate(item.oct_performed_date) && item.oct_performed_date.length === 10) {
                    $scope.oct_to_submit = item;

                    var param = {
                        id: $scope.oct_to_submit.id,
                        secondary_id: $scope.oct_to_submit.case_id,
                        date: $filter('date')($scope.oct_to_submit.oct_performed_date, 'dd.MM.yyyy')
                    };

                    octService.validateConsents(param, validateConsentsComplete, errorFunction);
                };
            };

            function validateConsentsComplete(response) {
                if (response.length === 0) {
                    checkExistingOCTs();
                } else {
                    if (!response[0].is_warning_message) {
                        if (response[0].message != 'LABEL_CANT_SUBMIT_OCT_SINCE_IVOM_AUTO_GENERATED') {
                            alertService.RenderNotificationMessage(response, $scope);
                        } else {
                            documentationOnlyService.showExistingAutoGeneratedIvomMessage($scope.oct_to_submit_patient_id, $scope);
                        }
                    } else {
                        alertService.RenderConfirmationDialog('LABEL_WARNING', response[0], 'BUTTON_SUBMIT', 'LABEL_CANCEL', checkExistingOCTs, cancelSubmitOctWithouitConsent);
                    }
                };
            };

            function checkExistingOCTs() {
                var consent_validation_parameter = {
                    oct_ids: [$scope.oct_to_submit.id],
                    date_of_performed_action: $scope.oct_to_submit.oct_performed_date
                };

                octService.checkIfAlreadyExistOCT(consent_validation_parameter, function (response) {
                    if (response.number_of_invalid_cases == 0) {
                        alertService.ConfirmPassword($scope, $scope.confirmSubmitOct, $scope.cancelSubmitOct, 'LABEL_PLEASE_ENTER_PASSWORD_TO_SUBMIT_OCT', $scope.oct_to_submit.oct_doctor_id, true);
                    } else {
                        alertService.RenderNotificationMessage([{ message: 'LABEL_OCT_ALREADY_EXIST' }], $scope, function () {
                            ngDialog.close();
                        });
                    }
                }, errorFunction)
            }

            function cancelSubmitOctWithouitConsent(response) {
                ngDialog.close();
            }


            $scope.confirmSubmitOct = function (doctor_id) {
                var oct_param = {
                    oct_ids: [$scope.oct_to_submit.id],
                    date_of_performed_action: $scope.oct_to_submit.oct_performed_date,
                    authorizing_doctor_id: doctor_id
                };

                octService.SubmitOct(oct_param, SubmitOctComplete, errorFunction);
            };

            $scope.cancelSubmitOct = function () {
                $scope.case_id = undefined;
            };

            function SubmitOctComplete(response) {
                if (response.reportUrl === undefined) {
                    $scope.should_download = {
                        reportUrl: response
                    };
                } else {
                    $scope.should_download = response;
                }
                
                alertService.RenderSuccessMessage('LABEL_OCT_SUBMITTED');
                $scope.scroll_down_params.infiniteScrollStartIndex = 0;
                $scope.isScrollDisabled = true;
                $scope.is_scroll = false;
                $scope.octs = [];
                $rootScope.$broadcast("StickyReset");
                loadOCT();               
            };

            $scope.isSubmitVisible = function (item) {
                return item.status !== 'OCT4' && item.status !== 'OCT6';
            };

            // --------------------------------- REJECTION -------------------------------
            $scope.rejectOct = function (oct) {
                $scope.oct_to_reject = oct;
                alertService.ConfirmPassword($scope, $scope.confirmOctReject, $scope.cancelSubmitOct, 'LABEL_PLEASE_ENTER_PASSWORD_TO_REJECT_OCT', $scope.oct_to_reject.oct_doctor_id);
            };

            $scope.confirmOctReject = function () {
                octService.rejectOct({ id: $scope.oct_to_reject.id }, rejectionSuccessful, errorFunction);
            };

            function rejectionSuccessful() {
                alertService.RenderSuccessMessage('LABEL_OCT_REJECTION_SUCCESSFUL');
                $scope.oct_to_reject = undefined;
                reloadOcts();
            }

            // -------------------------------------------------------------------------- UTIL ------------------------------------------------------------------------------------
            $scope.renderDatepicker = function (index) {
                $scope.show_datepicker_id = index;
                $timeout(function () {
                    angular.element('#octPerformedDate_' + index)[0].focus()
                }, 0, false);
            };

            $scope.setClass = function () {
                $('.aftercare-list-item').css("overflow", "visible");
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
                $scope.scroll_down_params.infiniteScrollStartIndex = 0;
                $scope.octs = [];
                $scope.isScrollDisabled = false;
                if (sort_by == sort_value) {
                    ascending = !ascending;
                }

                sort_by = sort_value;
                $scope.is_scroll = false;
                $scope.isScrollDisabled = true;

                $rootScope.$broadcast("StickyReset");
                loadOCT();
            };

            function errorFunction(response) {
                $scope.execute_scroll = false;
                console.log(response);
                alertService.RenderErrorMessage('LABEL_SOMETHING_WENT_WRONG');
            };

            commonServices.focusSearch();

            // ------------------------------------------------------- MULTI EDIT/SUBMIT ------------------------------------------------------------------

            $scope.cancelMultiEdit = function () {
                $scope.all_selected = false;
                $scope.all_checked_previously = false;
                $scope.selectAll();
                deselected_action_ids = [];
                selected_action_ids = [];
                $scope.parameter = new Object();
            };

            $scope.multiEditSubmitOct = function (should_submit) {
                if (validationService.isValidDate($scope.parameter.oct_performed_date) || !$scope.parameter.oct_performed_date) {
                    if (should_submit && !$scope.parameter.oct_performed_date) {
                        return false;
                    };

                    $scope.submitted = should_submit;
                    $scope.multi_popup = true;
                    $scope.multi_popup_index = 0;
                    var multiSubmitParameter = new Object();
                    multiSubmitParameter.selected_ids = selected_action_ids;
                    multiSubmitParameter.deselected_ids = deselected_action_ids;
                    multiSubmitParameter.all_selected = $scope.all_selected;
                    multiSubmitParameter.search_params = $scope.search_data.text_search;
                    multiSubmitParameter.filter_by = $scope.search_data.filter_by;
                    multiSubmitParameter.submission_date = $scope.parameter.oct_performed_date;
                    multiSubmitParameter.oct_doctor_id = $scope.parameter.oct_doctor_id;

                    octService.initiateMultiEditSubmit(multiSubmitParameter, errorFunction).then(function initiateMultiSubmitComplete(response) {
                        $scope.popup_doctors = response;
                        $scope.param = new Object();
                        $scope.param.date_of_performed_action = $scope.parameter.oct_performed_date;

                        $scope.param.oct_ids = $scope.popup_doctors[$scope.multi_popup_index].oct_ids;

                        if (!response.length) {
                            alertService.RenderNotificationMessage([{ message: 'LABEL_NO_CASE_CAN_BE_SUBMITTED' }], $scope);
                        } else {
                            if ($scope.parameter.oct_doctor_id && $scope.parameter.oct_doctor_id !== $scope.oct_doctors[0].id) {
                                $scope.param.oct_doctor_id = $scope.parameter.oct_doctor_id;
                                submitOctMultiEdit();
                            } else {
                                nextPopup();
                            }
                        }
                    });
                } else {
                    $scope.parameter.oct_performed_date = '';
                };
            };

            function validateOctDateComplete(response) {
                $scope.param.ids_to_edit = response;
                if (response) {
                    confirmMultiSubmit();
                } else {
                    alertService.RenderNotificationMessage([{ message: 'LABEL_CANT_SUBMIT_OCT_IN_FUTURE' }], $scope, $scope.multi_popup ? cancelCurrentPopup_helperFunction : undefined);
                };
            };

            $scope.isEditButtonDisabled = function () {
                return !$scope.parameter.oct_doctor_id || $scope.parameter.oct_doctor_id === $scope.oct_doctors[0].id;
            };

            function cancelCurrentPopup_helperFunction() {
                ngDialog.close();
                cancelCurrentPopup();
            };

            function verifyDate(doctor_id) {
                $scope.auth_doc_id = doctor_id;
                $scope.param = new Object();
                $scope.param.date_of_performed_action = $scope.parameter.oct_performed_date;
                $scope.param.oct_doctor_id = $scope.parameter.oct_doctor_id;
                $scope.param.oct_ids = $scope.popup_doctors[$scope.multi_popup_index].oct_ids;

                if ($scope.parameter.oct_performed_date) {
                    octService.validateOctDate($scope.param, validateOctDateComplete, errorFunction);
                }
            };

            function nextPopup() {
                alertService.ConfirmPassword($scope, verifyDate, cancelCurrentPopup, 'LABEL_PLEASE_ENTER_PASSWORD_TO_SUBMIT_OCT', $scope.popup_doctors[$scope.multi_popup_index].doctor_id, true);
            };

            function cancelCurrentPopup() {
                $scope.multi_popup_index++;
                if ($scope.multi_popup_index !== $scope.popup_doctors.length) {
                    nextPopup();
                } else {
                    if ($scope.any_submitted) {
                        alertService.RenderSuccessMessage('LABEL_OCT_SUBMITTED');
                        reloadOcts();
                    }
                };
            };

            function submitOctMultiEdit() {
                octService.multiEditOct($scope.param, multiEditOctComplete, errorFunction);
            };

            function multiEditOctComplete() {
                if (!$scope.submitted) {
                    alertService.RenderSuccessMessage('LABEL_CHANGES_SAVED');
                    reloadOcts();
                } else {
                    nextPopup();
                };
            };

            function confirmMultiSubmit() {
                var consent_validation_parameter = {
                    oct_ids: $scope.popup_doctors[$scope.multi_popup_index].oct_ids,
                    date_of_performed_action: $scope.parameter.oct_performed_date
                };

                octService.validateConsentsMulti(consent_validation_parameter, validateConsentsMultiComplete, errorFunction);
            };

            function validateConsentsMultiComplete(responseConsent) {
                $scope.param = {
                    oct_ids: responseConsent,
                    date_of_performed_action: $scope.parameter.oct_performed_date,
                    authorizing_doctor_id: $scope.auth_doc_id
                };

                if (responseConsent.length !== 0) {

                    octService.checkIfAlreadyExistOCT($scope.param, function (responseDuplicate) {
                        $scope.param.oct_ids = responseDuplicate.valid_case_ids;

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
                octService.SubmitOct($scope.param, confirmMultiSubmitAfterMultiEditComplete, errorFunction);
            };

            function confirmMultiSubmitAfterMultiEditComplete(response) {
                $scope.should_download = response;
                if ($scope.multi_popup) {
                    $scope.any_submitted = true;
                    $scope.multi_popup_index++;
                    if ($scope.multi_popup_index !== $scope.popup_doctors.length) {
                        nextPopup();
                    } else {
                        alertService.RenderSuccessMessage('LABEL_OCT_SUBMITTED');
                        reloadOcts();
                    };
                } else {
                    alertService.RenderSuccessMessage('LABEL_OCT_SUBMITTED');
                    reloadOcts();
                };
            };

            function cancelMultiSubmit(response) {
                if ($scope.multi_popup) {
                    $scope.multi_popup_index++;
                    if ($scope.multi_popup_index !== $scope.popup_doctors.length) {
                        nextPopup();
                    } else {
                        if ($scope.any_submitted)
                            alertService.RenderSuccessMessage('LABEL_OCT_SUBMITTED');
                        reloadOcts();
                    };
                } else {
                    reloadOcts();
                };
            };

            function reloadOcts() {
                $rootScope.$broadcast("StickyReset");
                $scope.scroll_down_params.infiniteScrollStartIndex = 0;
                $scope.octs = [];
                $scope.isScrollDisabled = false;
                $scope.multi_popup_index = 0;
                $scope.is_scroll = false;
                $scope.isScrollDisabled = true;
                $scope.any_submitted = false;
                loadOCT();
                $scope.parameter = new Object();
                deselected_action_ids = [];
                selected_action_ids = [];
                $scope.all_checked_previously = false;
                $scope.all_selected = false;
                $scope.selectAll();
            };

            function cancelMultiSubmitAfterMultiEdit() {
                if ($scope.multi_popup) {
                    $scope.multi_popup_index++;
                    if ($scope.multi_popup_index !== $scope.popup_doctors.length) {
                        nextPopup();
                    } else {
                        if ($scope.any_submitted) {
                            if ($scope.multi_popup_index !== 0)
                                alertService.RenderSuccessMessage('LABEL_OCT_SUBMITTED');

                            reloadOcts();
                        }
                    };
                } else {
                    if ($scope.any_submitted) {
                        reloadOcts();
                    }
                };
            };

            $scope.cancelOctMultiEdit = function () {
                return;
            };

            commonServices.focusSearch();
        }
    ]);
})();