(function () {
    "use strict";
    angular.module('mainModule').controller('aftercareController', ['$scope', '$rootScope', 'alertService', 'ngDialog', 'validationService', 'aftercareService', '$filter', '$timeout', 'commonServices', 'doctorsService',
        function ($scope, $rootScope, alertService, ngDialog, validationService, aftercareService, $filter, $timeout, commonServices, doctorsService) {
            var sort_by = "treatment_date";
            var ascending = false;
            $scope.today = $filter('date')(new Date(), 'MM.dd.yyyy');
            var selected_action_ids = [];
            var deselected_action_ids = [];
            $scope.aftercares = [];
            $scope.selected_count = 0;
            $scope.parameter = new Object();
            $scope.search_data = new Object();
            $scope.search_data.filter_by = new Object();
            $scope.search_data.filter_by.filter_status = [];
            $scope.search_data.filter_by.filter_type = [];
            $scope.search_data.filter_by.filter_current = true;
            $scope.show_datepicker_id = undefined;
            $scope.ac_doctors = [];
            $scope.scroll_down_params = new Object();
            $scope.scroll_down_params.infiniteScrollStep = 100;
            $scope.scroll_down_params.infiniteScrollStartIndex = 0;
            $scope.isScrollDisabled = false;
            $scope.any_submitted = false;
            $scope.is_scroll = false;
            $scope.execute_scroll = false;
            $rootScope.$broadcast("StickyReset");
            getAftercares();

            // ------------------------------------------------------------- INIT --------------------------------------------------------------           
            function getAftercares() {
                if ($scope.execute_scroll) return;
                $scope.execute_scroll = true;

                var sort_parameter = new Object();
                sort_parameter.sort_by = sort_by;
                sort_parameter.isAsc = ascending;
                sort_parameter.start_row_index = $scope.scroll_down_params.infiniteScrollStartIndex;
                sort_parameter.search_params = $scope.search_data.text_search;
                sort_parameter.filter_by = $scope.search_data.filter_by;
                sort_parameter.hip_name = $scope.search_data.filter_by.hip_name;

                aftercareService.getAftercares(sort_parameter, getAftercaresComplete, getAftercaresError);
            };

            $scope.$on('GlobalSearch', function (event, data) {
                $scope.scroll_down_params.infiniteScrollStartIndex = 0;
                $scope.aftercares = [];
                $scope.isScrollDisabled = true;
                $scope.search_data = data;
                $scope.is_scroll = false;
                getAftercares();
            });

            function getAftercaresComplete(response) {
                $scope.execute_scroll = false;
                angular.forEach(response, function (item) {
                    item.had_aftercare_performed_date_saved = item.aftercare_date_string !== '' && item.aftercare_date_string !== null && item.aftercare_date_string !== undefined;
                });

                if ($scope.is_scroll)
                    $scope.aftercares = $scope.aftercares.concat(response);
                else {
                    $rootScope.$broadcast("StickyReset");
                    $scope.aftercares = response;
                };

                $scope.selectAll();
                $scope.scroll_down_params.infiniteScrollStartIndex = $scope.scroll_down_params.infiniteScrollStartIndex + $scope.scroll_down_params.infiniteScrollStep;

                $scope.isScrollDisabled = response.length < $scope.scroll_down_params.infiniteScrollStep;

                if ($scope.should_download) {
                    commonServices.download($scope.should_download);
                    $scope.should_download = undefined;
                };

                commonServices.focusSearch();
            };

            $scope.submitAftercare = function (aftercare) {
                if (validationService.isValidDate(aftercare.aftercare_date_string) && aftercare.aftercare_date_string.length === 10) {
                    $scope.aftercare = aftercare;

                    var param = new Object();
                    param.id = aftercare.treatment_doctor_id;
                    param.secondary_id = aftercare.aftercare_doctor_practice_id;
                    param.tertiary_id = aftercare.patient_id;
                    param.date_string = $filter('date')(aftercare.aftercare_date_string, 'dd.MM.yyyy');
                    param.diagnose_id = aftercare.diagnose_id;
                    param.drug_id = aftercare.drug_id;
                    param.date = $filter('date')(aftercare.treatment_date, 'dd.MM.yyyy');
                    param.case_id = aftercare.case_id;

                    aftercareService.validateConsents(param, validateConsentsComplete, errorFunction);
                } else {
                    aftercare.aftercare_date_string = '';
                };
            };

            function validateConsentsComplete(response) {
                if (response.length === 0) {

                    $scope.param = new Object();
                    $scope.param.ids_to_submit = [$scope.aftercare.case_id];
                    $scope.param.date_string = $scope.aftercare.aftercare_date_string;

                    aftercareService.checkIfAlreadyExistAftercare($scope.param, function (response) {
                        if (response.number_of_invalid_cases == 0) {
                            alertService.ConfirmPassword($scope, $scope.confirmSubmitAftercare, $scope.cancelSubmitAftercare, 'LABEL_PLEASE_ENTER_PASSWORD_TO_SUBMIT_CASE', $scope.aftercare.aftercare_doctor_practice_id);
                        } else {
                            alertService.RenderNotificationMessage([{ message: 'LABEL_AFTERCARE_ALREADY_EXIST' }], $scope, function () {
                                ngDialog.close();
                            });
                        }
                    }, errorFunction);

                } else {
                    alertService.RenderNotificationMessage(response, $scope);
                };
            };


            $scope.confirmSubmitAftercare = function (doctor_id) {
                var aftercare_param = new Object();
                aftercare_param.case_id = $scope.aftercare.case_id;
                aftercare_param.date_of_performed_action = $scope.aftercare.aftercare_date_string;
                aftercare_param.authorizing_doctor_id = doctor_id;

                aftercareService.submitAftercare(aftercare_param, submitAftercareComplete, errorFunction);
            };

            $scope.cancelSubmitAftercare = function () {
                $scope.aftercare_id = undefined;
                $scope.aftercare.aftercare_date_string = '';
            };

            function submitAftercareComplete(response) {
                $scope.should_download = response;
                $scope.scroll_down_params.infiniteScrollStartIndex = 0;
                alertService.RenderSuccessMessage('LABEL_CASE_SUBMITTED');
                $scope.is_scroll = false;
                $scope.isScrollDisabled = true;
                getAftercares();
            };

            doctorsService.getDoctorsInPractice().then(getACDoctorsForPracticeIDComplete);

            function getACDoctorsForPracticeIDComplete(response) {
                $scope.ac_doctors = response;
                $scope.ac_doctors.unshift({ id: '00000000-0000-0000-0000-000000000000', display_name: ' ' });
                $scope.parameter.aftercare_doctor_practice_id = $scope.ac_doctors[0].id;
            };


            $scope.loadMore = function () {
                if ($scope.execute_scroll) return;
                $scope.is_scroll = true;
                getAftercares();
            };

            // ---------------------------- SELECTION FUNCTIONS ----------------------------------------------

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
                        parameter.filter_by = { filter_status: ["ac1"], filter_type: [] };
                        parameter.search_params = '';
                    } else {
                        parameter.search_params = $scope.search_data.text_search;
                        parameter.filter_by = $scope.search_data.filter_by;
                        parameter.date_from = $scope.search_data.date_from;
                        parameter.date_to = $scope.search_data.date_to;
                        parameter.hip_name = $scope.search_data.filter_by.hip_name;
                    };

                    aftercareService.getAftercaresCount(parameter, getAftercaresCountComplete, errorFunction);
                };

                angular.forEach($scope.aftercares, function (item) {
                    item.is_selected = $scope.all_selected && item.status !== 'AC4';
                });

                $scope.any_selected = $scope.all_selected && $scope.aftercares.length !== 0;

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

                    $scope.any_selected = deselected_action_ids.length !== $scope.aftercares.length;
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
                    $timeout(function () { angular.element('#selACDoctor_value')[0].focus() }, 0, false);
                };
            };

            function getAftercaresCountComplete(response) {
                $scope.selected_count = response;

                if ($scope.selected_count !== 0) {
                    $timeout(function () { angular.element('#selACDoctor_value')[0].focus(); }, 0, false);
                };
            };

            // ---------------------------- MULTI EDIT/SUBMIT FUNCTIONS ------------------------------------------------------

            $scope.cancelMultiEdit = function () {
                $scope.all_selected = false;
                $scope.all_checked_previously = false;
                $scope.selectAll();
                deselected_action_ids = [];
                selected_action_ids = [];
                $scope.parameter = new Object();
            };

            $scope.multiEditAftercare = function (should_submit) {
                var date_not_defined = $scope.parameter.aftercare_performed_date === undefined || $scope.parameter.aftercare_performed_date === '' && $scope.parameter.aftercare_performed_date === null;

                if (validationService.isValidDate($scope.parameter.aftercare_performed_date) || date_not_defined) {
                    if (should_submit && $scope.isMultiEditSubmitButtonDisabled()) {
                        return false;
                    };

                    $scope.submitted = should_submit;

                    if (should_submit) {
                        if ($scope.parameter.aftercare_doctor_practice_id === $scope.ac_doctors[0].id || $scope.parameter.aftercare_doctor_practice_id === undefined) {
                            $scope.multi_popup = true;
                            $scope.multi_popup_index = 0;
                            var multiSubmitParameter = new Object();
                            multiSubmitParameter.ids_to_submit = selected_action_ids;
                            multiSubmitParameter.ids_to_deselect = deselected_action_ids;
                            multiSubmitParameter.all_selected = $scope.all_selected;
                            multiSubmitParameter.filter_by = new Object();
                            multiSubmitParameter.filter_by.filter_by = $scope.search_data.filter_by;
                            multiSubmitParameter.filter_by.date_from = $scope.search_data !== undefined ? $scope.search_data.date_from : '1-1-1';
                            multiSubmitParameter.filter_by.date_to = $scope.search_data !== undefined ? $scope.search_data.date_to : '';
                            multiSubmitParameter.filter_by.search_params = $scope.search_data !== undefined ? $scope.search_data.text_search : '';
                            multiSubmitParameter.sort_by = sort_by;
                            multiSubmitParameter.isAsc = ascending;

                            aftercareService.initiateMultiSubmit(multiSubmitParameter, initiateMultiSubmitComplete, errorFunction);
                        } else {
                            alertService.ConfirmPassword($scope, verifyDate, cancelMultiSubmit, 'LABEL_PLEASE_ENTER_PASSWORD_TO_SUBMIT_CASE', $scope.parameter.aftercare_doctor_practice_id);
                        };
                    } else {
                        verifyDate();
                    };
                } else {
                    $scope.parameter.aftercare_performed_date = '';
                };
            };

            function validateAftercareDateComplete(response) {
                $scope.param.ids_to_edit = response;
                if (response.length !== 0) {
                    if ($scope.selected_count - response.length !== 0 && !$scope.submitted) {
                        var message = new Object();
                        message.message = 'LABEL_AFTERCARE_MULTI_EDIT_ELIGIBILITY';
                        message.eligible_cases = $scope.selected_count - response.length;
                        message.total_cases = $scope.selected_count;
                        alertService.RenderConfirmationDialog('LABEL_WARNING', message, 'BUTTON_YES', 'BUTTON_NO', initiateMultiEdit, $scope.cancelAftercareMultiEdit);
                    } else {
                        initiateMultiEdit();
                    };
                } else {
                    alertService.RenderNotificationMessage([{ message: 'LABEL_NO_CASE_CAN_BE_SUBMITTED' }], $scope, $scope.multi_popup ? cancelCurrentPopup_helperFunction : undefined);
                };
            };

            function cancelCurrentPopup_helperFunction() {
                ngDialog.close();
                cancelCurrentPopup();
            };

            function verifyDate(doctor_id) {
                $scope.auth_doc_id = doctor_id;

                $scope.param = new Object();
                $scope.param.ids_to_edit = selected_action_ids;
                $scope.param.ids_to_deselect = deselected_action_ids;
                $scope.param.secondary_id = $scope.parameter.aftercare_doctor_practice_id;
                $scope.param.flag = false;
                $scope.param.all_selected = $scope.all_selected;
                $scope.param.date_string = $scope.parameter.aftercare_performed_date;
                $scope.param.filter_by = new Object();
                $scope.param.filter_by.filter_by = $scope.search_data.filter_by;
                $scope.param.filter_by.date_from = $scope.search_data !== undefined ? $scope.search_data.date_from : '1-1-1';
                $scope.param.filter_by.date_to = $scope.search_data !== undefined ? $scope.search_data.date_to : '';
                $scope.param.filter_by.search_params = $scope.search_data !== undefined ? $scope.search_data.text_search : '';
                $scope.param.authorizing_doctor_id = doctor_id;

                if ($scope.parameter.aftercare_performed_date !== '' && $scope.parameter.aftercare_performed_date !== undefined && $scope.parameter.aftercare_performed_date !== null) {
                    aftercareService.validateAftercareDate($scope.param, validateAftercareDateComplete, errorFunction);
                } else {
                    initiateMultiEdit();
                };
            };

            function initiateMultiSubmitComplete(response) {
                $scope.popup_doctors = response;
                nextPopup();
            };

            function nextPopup() {
                alertService.ConfirmPassword($scope, verifyDate, cancelCurrentPopup, 'LABEL_PLEASE_ENTER_PASSWORD_TO_SUBMIT_CASE', $scope.popup_doctors[$scope.multi_popup_index].id);
            };

            function cancelCurrentPopup() {
                $scope.multi_popup_index++;
                if ($scope.multi_popup_index !== $scope.popup_doctors.length) {
                    nextPopup();
                } else {
                    if ($scope.any_submitted)
                        alertService.RenderSuccessMessage('LABEL_CASE_SUBMITTED');
                    reloadAftercares();
                };
            };

            function initiateMultiEdit() {
                submitAftercareMultiEdit();
            };

            function submitAftercareMultiEdit() {
                aftercareService.multiEditAftercare($scope.param, multiEditAftercareComplete, errorFunction);
            };

            function multiEditAftercareComplete() {
                if (!$scope.submitted) {
                    alertService.RenderSuccessMessage('LABEL_CHANGES_SAVED');
                    reloadAftercares();
                } else {
                    confirmMultiSubmit();
                };
            };

            function confirmMultiSubmit() {
                $scope.consent_validation_parameter = new Object();
                $scope.consent_validation_parameter.type = "aftercare";
                $scope.consent_validation_parameter.flag = true;
                $scope.consent_validation_parameter.multi_ids = selected_action_ids;
                $scope.consent_validation_parameter.deselected_ids = deselected_action_ids;
                $scope.consent_validation_parameter.secondary_flag = $scope.all_selected;
                $scope.consent_validation_parameter.secondary_id = $scope.parameter.aftercare_doctor_practice_id;
                $scope.consent_validation_parameter.date_string = $scope.parameter.aftercare_performed_date;
                $scope.consent_validation_parameter.filter_by = new Object();
                $scope.consent_validation_parameter.filter_by.filter_by = $scope.search_data.filter_by;
                $scope.consent_validation_parameter.filter_by.date_from = $scope.search_data !== undefined ? $scope.search_data.date_from : '1-1-1';
                $scope.consent_validation_parameter.filter_by.date_to = $scope.search_data !== undefined ? $scope.search_data.date_to : '';
                $scope.consent_validation_parameter.filter_by.search_params = $scope.search_data !== undefined ? $scope.search_data.text_search : '';
                $scope.consent_validation_parameter.authorizing_doctor_id = $scope.auth_doc_id;
                $scope.param.authorizing_doctor_id = $scope.auth_doc_id;

                aftercareService.validateConsentsMulti($scope.consent_validation_parameter, validateConsentsMultiComplete, errorFunction);
            };

            function validateConsentsMultiComplete(responseConsent) {
                $scope.param.ids_to_submit = responseConsent;
                $scope.param.flag = true;

                if (responseConsent.length !== 0) {
                    var parameters = new Object();
                    parameters.ids_to_submit = responseConsent;
                    parameters.date_string = $scope.parameter.aftercare_performed_date;

                    aftercareService.checkIfAlreadyExistAftercare(parameters, function (responseDuplicate) {
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
                            alertService.RenderNotificationMessage([{ message: 'LABEL_NO_CASE_CAN_BE_SUBMITTED' }], $scope);
                            if ($scope.any_submitted) {
                                reloadAftercares();
                            }
                        }
                    }, errorFunction);                   
                } else {
                    alertService.RenderNotificationMessage([{ message: 'LABEL_NO_CASE_CAN_BE_SUBMITTED' }], $scope);
                    if ($scope.any_submitted) {
                        reloadAftercares();
                    }
                };
            };

            function confirmMultiSubmitAfterMultiEdit() {
                aftercareService.multiEditAftercare($scope.param, confirmMultiSubmitAfterMultiEditComplete, errorFunction);
            };

            function confirmMultiSubmitAfterMultiEditComplete(response) {
                if (response.length && response != "") {
                    commonServices.download(response);
                }

                if ($scope.multi_popup) {
                    $scope.any_submitted = true;
                    $scope.multi_popup_index++;
                    if ($scope.multi_popup_index !== $scope.popup_doctors.length) {
                        nextPopup();
                    } else {
                        alertService.RenderSuccessMessage('LABEL_CASE_SUBMITTED');
                        reloadAftercares();
                    };
                } else {
                    alertService.RenderSuccessMessage('LABEL_CASE_SUBMITTED');
                    reloadAftercares();
                };
            };

            function cancelMultiSubmit(response) {
                if ($scope.multi_popup) {
                    $scope.multi_popup_index++;
                    if ($scope.multi_popup_index !== $scope.popup_doctors.length) {
                        nextPopup();
                    } else {
                        if ($scope.any_submitted)
                            alertService.RenderSuccessMessage('LABEL_CASE_SUBMITTED');
                        reloadAftercares();
                    };
                } else {
                    reloadAftercares();
                };
            };

            function reloadAftercares() {
                $scope.scroll_down_params.infiniteScrollStartIndex = 0;
                $scope.aftercares = [];
                $scope.isScrollDisabled = false;
                $scope.multi_popup_index = 0;
                $scope.is_scroll = false;
                $scope.isScrollDisabled = true;
                $scope.any_submitted = false;
                getAftercares();
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
                                alertService.RenderSuccessMessage('LABEL_CASE_SUBMITTED');

                            reloadAftercares();
                        }
                    };
                } else {
                    reloadAftercares();
                };

                $scope.multi_popup_index = 0;
            };

            $scope.cancelAftercareMultiEdit = function () {
                return;
            };


            // ------------------------------------------- ERROR FUNCTIONS ---------------------------------------------
            function getAftercaresError(response) {
                $scope.execute_scroll = false;
                console.log(response);
                alertService.RenderErrorMessage('LABEL_SOMETHING_WENT_WRONG');
            };

            function errorFunction(response) {
                console.log(response);
                alertService.RenderErrorMessage('LABEL_SOMETHING_WENT_WRONG');
            };
            // ------------------------------------- UTIL ---------------------------------------------------

            $scope.isEditButtonDisabled = function () {
                return ($scope.parameter.aftercare_doctor_practice_id === undefined || $scope.parameter.aftercare_doctor_practice_id === $scope.ac_doctors[0].id) && ($scope.parameter.aftercare_performed_date === '' || $scope.parameter.aftercare_performed_date === undefined || $scope.parameter.aftercare_performed_date === null);
            };

            $scope.isMultiEditSubmitButtonDisabled = function () {
                return $scope.parameter.aftercare_performed_date === '' || $scope.parameter.aftercare_performed_date === undefined || $scope.parameter.aftercare_performed_date === null;
            };

            $scope.remoteUrlRequestFn = function (str) {
                return { search_criteria: str };
            };

            $scope.renderDatepicker = function (index, item) {
                $scope.datePickerLoading = true;
                $scope.show_datepicker_id = index;
                $timeout(function () {
                    item.aftercare_date_string = $filter('date')(item.treatment_date, 'dd.MM.yyyy');
                    angular.element('#aftercarePerformedDate_' + index)[0].focus();
                    item.aftercare_date_string = '';
                    $scope.datePickerLoading = false;
                }, 0, true);
            };

            $scope.formatDate = function (date) {
                var yyyy = date.substr(0, 4);
                var mm = date.substr(5, 2);
                var dd = date.substr(8, 2);
                var new_date = new Date(parseInt(yyyy), parseInt(mm) - 1, parseInt(dd));

                return $filter('date')(new_date, 'MM.dd.yyyy');
            };

            $scope.purgeDate = function ($event, item) {
                var relatedTarget = $event.relatedTarget || $event.originalEvent.explicitOriginalTarget || document.activeElement;

                if (relatedTarget === null || relatedTarget.id !== 'btnSubmitCase') {
                    if (relatedTarget !== null && relatedTarget.className.indexOf('_720') > -1) {
                        var el = angular.element('.aftercare-datepicker_' + item.id);
                        angular.element('.aftercare-datepicker_' + item.id).focus();
                    } else {
                        if (!item.had_aftercare_performed_date_saved)
                            item.aftercare_date_string = '';
                    };
                }
            };

            $scope.setClass = function () {
                $('.aftercare-list-item').css("overflow", "visible");
            };

            $scope.getAftercareStatusClassName = function (item) {
                switch (item.status) {
                    case 'AC1':
                        return 'normal-height-font margin-top-3'
                    case 'AC3':
                        return 'rejected-text';
                    default:
                        return 'normal-height-font margin-top-3 gray-font-color';
                }
            };

            $scope.getBorderClassName = function (item) {
                switch (item.status) {
                    case 'AC3':
                        return 'red-border';
                    default:
                        return '';
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
                $scope.scroll_down_params.infiniteScrollStartIndex = 0;
                $scope.aftercares = [];
                $scope.isScrollDisabled = false;
                if (sort_by == sort_value) {
                    ascending = !ascending;
                }

                sort_by = sort_value;
                $scope.is_scroll = false;
                $scope.isScrollDisabled = true;

                $rootScope.$broadcast("StickyReset");
                getAftercares();
            };

            commonServices.focusSearch();

            // ---------------------------- CONTROLLER END ------------------------------------------------
        }]);
})();