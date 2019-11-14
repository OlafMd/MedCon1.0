(function () {
    'use strict';
    angular.module('mainModule').controller('settlementController', ['$scope', '$rootScope', 'alertService', 'ngDialog', 'settlementServices', '$filter', '$timeout',
        'octService', 'commonServices', 'doctorsService', 'practiceSettingsService',
        function ($scope, $rootScope, alertService, ngDialog, settlementServices, $filter, $timeout, octService, commonServices, doctorsService, practiceSettingsService) {
            $scope.settlement = new Object();
            var sort_by = "surgery_date";
            var ascending = false;
            $scope.doctorList = [];
            var items_for_multiedit = [];
            $scope.settlement = [];
            $scope.selected_count = 0;
            $scope.SaveButtonDisabled = true;
            $scope.selected_caseId = null;
            $scope.disable_doctor_select = null;
            $scope.credentials_not_verified = false;
            $scope.scroll_down_params = new Object();
            $scope.scroll_down_params.infiniteScrollStep = 100;
            $scope.scroll_down_params.infiniteScrollStartIndex = 0;
            $scope.isScrollDisabled = false;
            $scope.is_scroll = false;
            $scope.execute_scroll = false;
            $rootScope.$broadcast("StickyReset");
            getSettlement();

            practiceSettingsService.getPracticeSettings().then(function (settings) {
                $scope.isDownloadAllNonDownloadedReportsVisible = !settings.ShouldDownloadReportUponSubmission;
            });

            //user authentication

            $scope.downloadAllNonDowloadedReports = function () {
                settlementServices.downloadAllNonDowloadedReports(downloadAllNonDownloadedReportsSuccess, errorFunction);
            };

            $scope.showItemStatus = function (item) {
                if (new Date(item.status_date).getFullYear() === 1) {
                    return false;
                }

                return item.status === 'FS7' || item.status === 'FS12';
            };

            function downloadAllNonDownloadedReportsSuccess(response) {
                if (response === null) {
                    alertService.RenderNotificationMessage([{ message: 'LABEL_NO_ELIGIBLE_REPORTS' }], $scope);
                } else {
                    commonServices.download(response);
                    $scope.scroll_down_params.infiniteScrollStartIndex = 0;
                    $scope.isScrollDisabled = false;
                    $scope.is_scroll = false;
                    $rootScope.$broadcast("StickyReset");
                    getSettlement();
                }
            }

            $scope.$on('GlobalSearch', function (event, data) {
                $scope.search_params = data.text_search;
                $scope.scroll_down_params.infiniteScrollStartIndex = 0;
                $scope.is_scroll = false;
                $scope.isScrollDisabled = false;
                $scope.search_data = data;
                $rootScope.$broadcast("StickyReset");
                getSettlement();
            });

            function getSettlement() {
                if ($scope.execute_scroll) return;
                $scope.execute_scroll = true;
                $scope.selected_count = 0;

                var sort_parameter = new Object();
                sort_parameter.sort_by = sort_by;
                sort_parameter.isAsc = ascending;
                sort_parameter.start_row_index = $scope.scroll_down_params.infiniteScrollStartIndex;

                if ($scope.search_data === undefined) {
                    sort_parameter.search_params = '';
                    sort_parameter.filter_by = { filter_status: [], filter_type: [] };
                } else {
                    sort_parameter.search_params = $scope.search_data.text_search;
                    sort_parameter.filter_by = $scope.search_data.filter_by;
                    sort_parameter.hip_name = $scope.search_data.filter_by.hip_name;
                };

                settlementServices.getSettlementitems(sort_parameter, successFunction, errorFunction);

                if ($scope.all_selected) {
                    GetItemsForCheckAll();
                }
            };

            function successFunction(response) {
                $scope.execute_scroll = false;
                $scope.scroll_down_params.infiniteScrollStartIndex = $scope.scroll_down_params.infiniteScrollStartIndex + $scope.scroll_down_params.infiniteScrollStep;

                $scope.isScrollDisabled = response.settlement.length < $scope.scroll_down_params.infiniteScrollStep;

                if ($scope.is_scroll) {
                    $scope.settlement = $scope.settlement.concat(response.settlement);
                } else {
                    $scope.settlement.length = 0;
                    $scope.settlement = response.settlement;
                };

                if ($scope.should_download) {
                    commonServices.download($scope.should_download);
                    $scope.should_download = undefined;
                };

                commonServices.focusSearch();
            };

            $scope.openCaseEditForm = function (id) {
                $scope.show_edit_case_form = !$scope.show_edit_case_form;
                $scope.edit_case_id = id;
            };

            // ------------------------------------------------------------------ SUBMIT CASE ------------------------------------------------------------------

            $scope.submitCase = function (item) {
                $scope.item_to_submit = item;
                $scope.is_oct = item.case_type === 'oct';
                $scope.treatment_doctor_id = item.case_type !== 'ac' ? item.treatment_doctor_id : item.aftercare_doctor_practice_id;

                if ($scope.is_oct) {
                    var param = {
                        id: item.id,
                        secondary_id: item.case_id,
                        date: $filter('date')(item.surgery_date, 'dd.MM.yyyy'),
                        flag: true
                    };

                    octService.validateConsents(param, validateConsentsComplete, errorFunction);
                } else {
                    $scope.id_to_submit = item.case_id;
                    $scope.planned_action_id_to_submit = item.id;

                    if (!$scope.isSubmitButtonDisabled(item)) {
                        $scope.date_of_performed_action = item.surgery_date;
                        var param = new Object();
                        param.id = item.treatment_doctor_id;
                        param.secondary_id = item.aftercare_doctor_practice_id;
                        param.tertiary_id = item.patient_id;
                        param.date_string = $filter('date')(item.surgery_date, 'dd.MM.yyyy');
                        param.date = $filter('date')(item.surgery_date, 'dd.MM.yyyy');
                        param.diagnose_id = item.diagnose_id;
                        param.drug_id = item.drug_id;
                        param.case_id = item.case_id;
                        param.flag = item.case_type === 'op';
                        $scope.is_treatment = param.flag;

                        settlementServices.validateConsents(param, validateConsentsComplete, errorFunction);
                    };
                };
            };

            function validateConsentsComplete(response) {
                if (response.length === 0) {
                    $scope.showCaseDirective = false;
                    if ($scope.show_edit_case_form) {
                        $scope.show_edit_case_form = false;
                        $scope.edit_case_id = 0;
                    };
                    $scope.case_id = $scope.id_to_submit;
                    var label = !$scope.is_oct ? 'LABEL_PLEASE_ENTER_PASSWORD_TO_SUBMIT_CASE' : 'LABEL_PLEASE_ENTER_PASSWORD_TO_SUBMIT_OCT';
                    alertService.ConfirmPassword($scope, $scope.confirmSubmitCase, $scope.cancelSubmitCase, label, $scope.treatment_doctor_id, $scope.is_oct);
                } else {
                    alertService.RenderNotificationMessage(response, $scope);
                };
            };


            $scope.confirmSubmitCase = function (doctor_id) {
                if (!$scope.is_oct) {
                    var case_param = new Object();
                    case_param.case_id = $scope.case_id;
                    case_param.authorizing_doctor_id = doctor_id;
                    case_param.datetime_of_performed_action = $scope.date_of_performed_action;
                    case_param.is_treatment = $scope.is_treatment;
                    case_param.planned_action_id = $scope.planned_action_id_to_submit;

                    settlementServices.submitCase(case_param, submitCaseComplete, errorFunction);
                } else {
                    var oct_param = {
                        oct_ids: [$scope.item_to_submit.id],
                        date_of_performed_action: $filter('date')($scope.item_to_submit.surgery_date, 'dd.MM.yyyy'),
                        authorizing_doctor_id: doctor_id,
                        is_resubmit: true
                    };

                    octService.SubmitOct(oct_param, submitCaseComplete, errorFunction);
                };
            };

            $scope.cancelSubmitCase = function () {
                $scope.case_id = undefined;
                $scope.preexaminationToSubmit = undefined;
            };

            function submitCaseComplete(response) {
                $scope.should_download = response === undefined || response === null ? false : response.downloadUrl === undefined ? response : response.downloadUrl;
                $scope.scroll_down_params.infiniteScrollStartIndex = 0;
                $scope.isScrollDisabled = false;
                $scope.is_scroll = false;

                $rootScope.$broadcast("StickyReset");
                alertService.RenderSuccessMessage('LABEL_CASE_SUBMITTED');
                getSettlement();
            };

            // ------------------------------------------------------------------ ERROR FUNCTIONS ------------------------------------------------------------------

            function errorFunction(response) {
                console.log(response);
                $scope.execute_scroll = false;
                alertService.RenderErrorMessage('LABEL_SOMETHING_WENT_WRONG');
            };

            function errorChangedMultiEditSaveFunction(response) {
                $scope.cancelMultiEdit();
                items_for_multiedit = [];
                alertService.RenderErrorMessage('LABEL_SOMETHING_WENT_WRONG');

            };

            function errorMultiEditSaveFunction(response) {
                $scope.cancelMultiEdit();
                items_for_multiedit = [];
                alertService.RenderErrorMessage('LABEL_SOMETHING_WENT_WRONG');
            };

            // ------------------------------------------------------------------ UTIL ------------------------------------------------------------------

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

            $scope.SortFunction = function (sort_value) {
                if (sort_by == sort_value) {
                    ascending = !ascending;
                }
                sort_by = sort_value;
                $scope.scroll_down_params.infiniteScrollStartIndex = 0;
                $scope.isScrollDisabled = true;
                $scope.is_scroll = false;
                $scope.settlement.length = 0;

                $rootScope.$broadcast("StickyReset");
                getSettlement();
            };

            $scope.isSubmitButtonDisabled = function (item) {
                return item.status !== 'FS6';
            };

            $scope.isDownloadVisible = function (status) {
                return status !== 'FS8' && status !== 'FS6';
            };

            $scope.isAcEditable = function (item) {
                return item.status !== 'FS6' ? item.is_edit_button_visible : !item.is_aftercare_performed;
            };

            $scope.setTableHeaderClass = function (settlement_value) {
                if (ascending && sort_by == settlement_value)
                    return 'sorted_asc';
                else if (!ascending && sort_by == settlement_value)
                    return 'sorted_dsc'
                else
                    return 'unsorted';
            };

            $scope.$on('CloseForm', function (event, data) {
                if (data.form === 'CloseCase' || data.form === 'ClosePreexamination') {
                    if ($scope.show_edit_case_form) {
                        $scope.show_edit_case_form = false;
                        $scope.edit_case_id = 0;
                    };
                    $scope.scroll_down_params.infiniteScrollStartIndex = 0;
                    $scope.isScrollDisabled = true;
                    $scope.is_scroll = false;
                    $rootScope.$broadcast("StickyReset");
                    getSettlement();
                };
            });

            $scope.showEditTreatmentForm = function (item) {
                return $scope.show_edit_case_form && item.id === $scope.edit_case_id && $rootScope.isOpRole && item.case_type === 'op';
            };

            $scope.showAftercareForm = function (item) {
                return $scope.show_edit_case_form && item.id === $scope.edit_case_id && item.case_type === 'ac';
            };

            $scope.showOctForm = function (item) {
                return $scope.show_edit_case_form && item.id === $scope.edit_case_id && item.case_type === 'oct';
            };

            $scope.loadMore = function () {
                if ($scope.execute_scroll) return;
                $scope.is_scroll = true;
                $rootScope.$broadcast("StickyReset");
                getSettlement();
            };

            function cleanScope() {
                delete $scope.credentials_not_verified;
                delete $scope.doctors;
                delete $scope.confirmation;

            };

            $scope.statuses = [{ name: 'FS7', id: 8 },
                            { name: 'OP9', id: 9 }
            ];

            $scope.$on('ngDialog.opened', function (event, data) {
                var input = angular.element('#reasonForCancelation')[0];
                if (input !== undefined)
                    input.focus();
            });

            // ------------------------------------------------------------------ CANCEL CASE ------------------------------------------------------------------

            $scope.setCancelButton = function (status) {
                if (status == "FS8" || status == "FS11" || status === "FS13")
                    return false;
                else
                    return true;
            };

            $scope.cancelCase = function (item) {
                $scope.selected_caseId = item.case_id;
                $scope.selected_actionId = item.id;
                $scope.selected_type = item.case_type;
                if (item.case_type == "ac") {
                    $scope.disable_doctor_select = item.aftercare_doctor_practice_id;
                } else {
                    $scope.disable_doctor_select = item.treatment_doctor_id;
                }

                doctorsService.getDoctorsInPractice().then(function (response) {
                    $scope.doctors = response;
                    $scope.confirmation = new Object();
                    $scope.confirmation.doctor = new Object();
                    $scope.confirmation.doctor.id = $scope.disable_doctor_select;

                    ngDialog.open({
                        template: 'scripts/src/app/settlement/view/cancelCasePopup.html',
                        scope: $scope,
                        closeByDocument: false
                    });
                });
            };

            $scope.cancelCaseCancel = function () {
                cleanScope();
                ngDialog.close();
            };

            $scope.CancelCaseSuccess = function (response) {
                alertService.RenderSuccessMessage($scope.selected_type === 'op' ? 'LABEL_TREATMENT_CASE_CANCELLED' : $scope.selected_type === 'ac' ? 'LABEL_AFTERCARE_CASE_CANCELLED' : 'LABEL_OCT_CASE_CANCELLED');
                cleanScope();
                $scope.scroll_down_params.infiniteScrollStartIndex = 0;
                $scope.isScrollDisabled = true;
                $scope.is_scroll = false;
                $rootScope.$broadcast("StickyReset");
                getSettlement();

            };
            $scope.CancelCaseError = function (response) {
                console.log(response);
                alertService.RenderErrorMessage('LABEL_SOMETHING_WENT_WRONG');
            };
            $scope.passwordVerified = function (response) {
                $scope.credentials_not_verified = false;
                ngDialog.close();
                var case_param = new Object();
                case_param.case_id = $scope.selected_caseId;
                case_param.authorizing_doctor_id = $scope.confirmation.doctor.id;
                case_param.reasonForCancelation = $scope.confirmation.reasonForCancelation;
                case_param.caseType = $scope.selected_type;
                case_param.planned_action_id = $scope.selected_actionId;

                settlementServices.CancelCase(case_param, $scope.CancelCaseSuccess, $scope.CancelCaseError);
                cleanScope();
            };
            $scope.passwordNotVerified = function (response) {
                $scope.credentials_not_verified = true;
            };
            $scope.verifyPasswordSettlement = function () {
                settlementServices.verifyPassword($scope.confirmation, $scope.passwordVerified, $scope.passwordNotVerified);
            };

            // ------------------------------------------------------------------ SELECTION FUNCTIONS ------------------------------------------------------------------

            $scope.checkAll = function () {
                if ($scope.all_selected) {
                    $scope.status = 0;
                    GetItemsForCheckAll();
                }
                else {
                    $scope.cancelMultiEdit();
                }
            }
            function GetItemsForCheckAll() {
                var sort_parameter = new Object();
                sort_parameter.sort_by = sort_by;
                sort_parameter.isAsc = ascending;
                sort_parameter.start_row_index = 0;

                if ($scope.search_data === undefined) {
                    sort_parameter.search_params = '';
                    sort_parameter.filter_by = { filter_status: [], filter_type: [] };
                } else {
                    sort_parameter.search_params = $scope.search_data.text_search;
                    sort_parameter.filter_by = $scope.search_data.filter_by;
                    sort_parameter.hip_name = $scope.search_data.filter_by.hip_name;
                }

                settlementServices.getSettlementitemsForMultiSelect(sort_parameter, successFunctionMultiCount, errorFunction);

            }
            function successFunctionMultiCount(response) {
                items_for_multiedit = [];
                $scope.selected_count = response.settlement.length;
                angular.forEach($scope.settlement, function (item) {
                    item.is_selected = true;
                })
                angular.forEach(response.settlement, function (item) {
                    items_for_multiedit.push(item.id);
                });

                if ($scope.selected_count !== 0) {
                    $timeout(function () { angular.element('#selStatus_value')[0].focus(); }, 0, false);
                };
            };

            $scope.checkSelected = function (item) {
                $scope.status = 0;
                if (item.is_selected) {
                    $scope.selected_count++;
                    items_for_multiedit.push(item.id);
                } else {
                    $scope.selected_count--;
                    var index = items_for_multiedit.indexOf(item.id);
                    items_for_multiedit.splice(index, 1);
                };

                if ($scope.selected_count !== 0) {
                    $timeout(function () { angular.element('#selStatus_value')[0].focus(); }, 0, false);
                };
            };

            // ------------------------------------------------------------------ MULTI EDIT ------------------------------------------------------------------

            $scope.cancelMultiEdit = function () {
                $scope.SaveButtonDisabled = true;
                $scope.all_selected = false;
                $scope.selected_count = 0;

                angular.forEach($scope.settlement, function (item) {
                    item.is_selected = false;
                });
                items_for_multiedit = [];
            };

            $scope.selectedStatus = function (status) {
                if (!angular.isUndefined(status) && status !== null) {
                    $scope.status = status;
                    $scope.SaveButtonDisabled = false;
                };
            };

            $scope.multiEditSaveCase = function () {

                parameter = new Object();
                parameter.status = $scope.status;
                parameter.items_for_multiedit = items_for_multiedit;
                settlementServices.multiEditSaveCase(parameter, successMultiEditSaveFunction, errorMultiEditSaveFunction);
            };

            function successMultiEditSaveFunction(response) {
                if (response.settlementChanged.ids_changed == response.settlementChanged.ids_to_change) {
                    parameter = new Object();
                    parameter.status = response.settlementChanged.status;
                    parameter.items_for_multiedit = response.settlementChanged.ids_to_change_list;
                    settlementServices.multiEditConfirmSaveCase(parameter, successChangedMultiEditSaveFunction, errorChangedMultiEditSaveFunction);
                }
                else if (response.settlementChanged.ids_changed != 0) {
                    $scope.status = response.settlementChanged.status;
                    items_for_multiedit = response.settlementChanged.ids_to_change_list;
                    var message = new Object();
                    message.message = 'LABEL_MULTI_SETTLEMENT_ELIGIBILITY';
                    message.eligible_cases = response.settlementChanged.ids_to_change - response.settlementChanged.ids_changed;
                    message.total_cases = response.settlementChanged.ids_to_change;
                    alertService.RenderConfirmationDialog('LABEL_WARNING', message, 'BUTTON_YES', 'BUTTON_NO', confirmMultiSubmitAfterMultiEdit, cancelMultiSubmitAfterMultiEdit);
                }
                else {
                    $scope.cancelMultiEdit();
                    alertService.RenderNotificationMessage([{ message: 'LABEL_NO_ITEMS_FOR_EDIT' }], $scope);
                };
            };

            function confirmMultiSubmitAfterMultiEdit() {
                parameter = new Object();
                parameter.status = $scope.status;
                parameter.items_for_multiedit = items_for_multiedit;
                settlementServices.multiEditConfirmSaveCase(parameter, successChangedMultiEditSaveFunction, errorChangedMultiEditSaveFunction);
            };

            function cancelMultiSubmitAfterMultiEdit() { };

            function successChangedMultiEditSaveFunction(response) {
                $scope.cancelMultiEdit();
                var message = response.settlementChanged.ids_changed + "{{'LABEL_MULTI_EDIT_SETTLEMENT'|translate}}";
                alertService.RenderSuccessMessage(message);
                $scope.scroll_down_params.infiniteScrollStartIndex = 0;
                $scope.isScrollDisabled = true;
                $scope.is_scroll = false;
                $rootScope.$broadcast("StickyReset");
                getSettlement();
            };

            // ------------------------------------------------------------------ DOWNLOAD REPORT ------------------------------------------------------------------

            $scope.downloadReport = function (caseData) {
                $scope.reportDownloadedForSettlement = undefined;

                var parameter = { CaseParameters: [] };
                if (caseData) {
                    $scope.reportDownloadedForSettlement = caseData;
                    parameter.CaseParameters.push({ CaseID: caseData.id, IsTreatment: caseData.case_type === 'op' || caseData.case_type === 'preexamination' });
                } else {
                    if ($scope.all_selected) {
                        parameter.IsAllSelected = true;
                    } else {
                        for (var i = 0; i < items_for_multiedit.length; i++) {
                            parameter.CaseParameters.push({ CaseID: items_for_multiedit[i] });
                        };
                    };
                };

                settlementServices.downloadSubmissionReport(parameter, downloadSubmissionReportComplete, errorFunction);
            };

            function downloadSubmissionReportComplete(response) {
                if ($scope.reportDownloadedForSettlement) {
                    $scope.reportDownloadedForSettlement.is_report_downloaded = true;
                } else {
                    $scope.scroll_down_params.infiniteScrollStartIndex = 0;
                    $scope.isScrollDisabled = true;
                    $scope.is_scroll = false;
                    $rootScope.$broadcast("StickyReset");
                    getSettlement();
                }

                $scope.all_selected = false;
                $scope.checkAll();
                items_for_multiedit = [];
                commonServices.download(response);
            };

            commonServices.focusSearch();

            // ------------------------------------------------------------------ CONTROLLER END ------------------------------------------------------------------
        }]);
})();
