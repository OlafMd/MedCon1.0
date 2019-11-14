"use strict";
define(['application-configuration', 'validationService', 'alertsServices', 'treatmentService', 'commonServices'], function (app) {
    app.register.controller('treatmentController', ['$scope', '$rootScope', '$translate', 'validationService', 'ngDialog', '$timeout', '$location', '$filter', 'alertsServices', 'treatmentService', '$routeParams', 'commonServices', '$interval',
        function ($scope, $rootScope, $translate, validationService, ngDialog, $timeout, $location, $filter, alertsServices, treatmentService, $routeParams, commonServices, $interval) {

            // --------------------------------------------------- VARIABLES ----------------------------------------------------------------------------------------------

            var ascending = false;
            var sort_by = 'treatment_date';
            var selected_action_ids = [];
            var deselected_action_ids = [];
            $scope.case = new Object();
            // $scope.case_statuses = $rootScope.isMaster ?
            $scope.case_statuses =
                [{ id: 1, display_value: 'FS1' },
                 { id: 2, display_value: 'FS2' },
                 { id: 3, display_value: 'FS3' },
                 { id: 0, display_value: 'LABEL_NOT_ON_HOLD' },
                 { id: 4, display_value: 'FS4' },
                 { id: 5, display_value: 'FS5' },
                 { id: 6, display_value: 'FS6' },
                 { id: 7, display_value: 'FS7' },
                 { id: 8, display_value: 'FS8' },
                 { id: 9, display_value: 'FS9' },
                 { id: 10, display_value: 'FS10' }];

            /*:
           [{ id: 3, display_value: 'FS3' },
            { id: 0, display_value: 'LABEL_NOT_ON_HOLD' }];*/
            $scope.selected_count = 0;
            var filterByError = undefined;

            $scope.scroll_down_params = new Object();
            $scope.scroll_down_params.infiniteScrollStep = 100;
            $scope.scroll_down_params.infiniteScrollStartIndex = 0;
            $scope.isScrollDisabled = false;
            $scope.cases = [];
            $scope.showData = false;
            $scope.execute_scroll = false;
            $scope.is_scroll = false;
            $rootScope.$broadcast("StickyReset");

            // ----------------------------------------------------------- INIT ------------------------------------------------------------------------------------------

            if ($routeParams.status) {
                filterByError = true;
                $rootScope.$broadcast('SetFilter', { status: $routeParams.status });
            };

            $scope.initializeController = function () {
                treatmentService.authenicateUser($location.path(), $scope.authenicateUserComplete, $scope.authenicateUserError);
            };

            $scope.authenicateUserComplete = function (response) {
                $scope.showData = true;
            };

            function getSubmittedCases() {
                if ($scope.execute_scroll) return;
                $scope.execute_scroll = true;

                var sort_parameter = new Object();
                sort_parameter.sort_by = sort_by;
                sort_parameter.isAsc = ascending;
                sort_parameter.start_row_index = $scope.scroll_down_params.infiniteScrollStartIndex;

                if ($scope.search_data === undefined) {
                    sort_parameter.filter_by = filterByError === undefined ? { filter_status: [], filter_type: [] } :  { filter_status: [$routeParams.status], filter_type: ["ac", "op", "oct"] };
                    sort_parameter.search_params = '';
                    sort_parameter.date_from = "1-1-1";
                    sort_parameter.date_to = '';
                } else {
                    sort_parameter.search_params = $scope.search_data.text_search;
                    sort_parameter.filter_by = $scope.search_data.filter_by;
                    sort_parameter.date_from = $scope.search_data.date_from;
                    sort_parameter.date_to = $scope.search_data.date_to;
                };

                treatmentService.getSubmittedCases(sort_parameter, getSubmittedCasesComplete, getSubmittedCasesError);
            };

            function getSubmittedCasesComplete(response) {
                $scope.execute_scroll = false;
                $scope.scroll_down_params.infiniteScrollStartIndex = $scope.scroll_down_params.infiniteScrollStartIndex + $scope.scroll_down_params.infiniteScrollStep;
                $scope.isScrollDisabled = response.length < $scope.scroll_down_params.infiniteScrollStep;

                if ($scope.is_scroll) {
                    $scope.cases = $scope.cases.concat(response);
                } else {
                    $rootScope.$broadcast("StickyReset");
                    $scope.cases = response;
                }

                $scope.selectAll();
            };

            $scope.$on('GlobalSearch', function (event, data) {
                $scope.search_data = data;
                $scope.selected_count = $scope.all_selected ? $scope.selected_count : 0;
                deselected_action_ids = $scope.search_data.all_selected ? deselected_action_ids : [];
                selected_action_ids = $scope.search_data.all_selected ? selected_action_ids : [];
                $scope.scroll_down_params.infiniteScrollStartIndex = 0;
                $scope.isScrollDisabled = true;
                $scope.is_scroll = false;
                getSubmittedCases();
            });

            $scope.loadMore = function () {
                $scope.is_scroll = true;
                getSubmittedCases();
            };

            // ----------------------------------- SUBMIT CASE FOR ERROR CORRECTION -----------------------------------------

            $scope.showEditForm = function (item) {
                var param = new Object();
                param.id = item.case_id;
                param.secondary_id = item.id;
                $scope.id = item.id;
                treatmentService.getResponseFromHIP(param, getResponseFromHIPComplete, getResponseFromHIPError);
            };

            function getResponseFromHIPComplete(response) {
                $scope.case.response_from_hip = response;
                $scope.show_edit_form = !$scope.show_edit_form;
                $scope.case.comment = response;
                $scope.id = $scope.show_edit_form ? $scope.id : undefined;
            };

            function getResponseFromHIPError(response) {
                $scope.id = undefined;
                $scope.show_edit_form = false;
                alertsServices.ErrorMessage('LABEL_SOMETHING_WENT_WRONG');
            };

            $scope.closeEditForm = function () {
                $scope.id = undefined;
                $scope.show_edit_form = false;
            };

            $scope.submitCaseForErrorCorrection = function (item) {
                var param = new Object();
                param.id = item.case_id;
                param.text = $scope.case.comment;
                param.action_type = item.type;
                param.secondary_id = item.id;

                treatmentService.submitCaseForErrorCorrection(param, submitCaseForErrorCorrectionComplete, errorFunction);
            };

            function submitCaseForErrorCorrectionComplete(response) {
                $scope.id = undefined;
                $scope.show_edit_form = false;
                alertsServices.SuccessMessage('LABEL_CASE_SUBMITTED_FOR_ERROR_CORRECTION');
                $scope.scroll_down_params.infiniteScrollStartIndex = 0;
                $scope.isScrollDisabled = true;
                $scope.is_scroll = false;
                getSubmittedCases();
            };

            // ------------------------------------- SELECTION FUNCTIONS -----------------------------------------------------

            function getSubmittedCasesCountComplete(response) {
                $scope.selected_count = response;

                if ($scope.selected_count !== 0) {
                    $timeout(function () { angular.element('#btnEditStatus')[0].focus(); }, 0, false);
                };
            };

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
                        if ($routeParams.status === undefined)
                            parameter.filter_by = { filter_status: [], filter_type: [] };
                        else
                            parameter.filter_by = { filter_status: [$routeParams.status], filter_type: [] };
                        parameter.search_params = '';
                    } else {
                        parameter.search_params = $scope.search_data.text_search;
                        parameter.filter_by = $scope.search_data.filter_by;
                        parameter.date_from = $scope.search_data.date_from;
                        parameter.date_to = $scope.search_data.date_to;
                    };

                    treatmentService.getSubmittedCasesCount(parameter, getSubmittedCasesCountComplete, getSubmittedCasesCountError);
                };

                angular.forEach($scope.cases, function (item) {
                    item.is_selected = $scope.all_selected;
                });

                $scope.any_selected = $scope.all_selected && $scope.cases.length !== 0;
            };

            $scope.checkSelected = function (item) {
                $scope.any_selected = false;

                if ($scope.all_checked_previously) {
                    if (!item.is_selected) {
                        deselected_action_ids.push(item.id);
                    } else {
                        var index = deselected_action_ids.indexOf(item.id);
                        deselected_action_ids.splice(index, 1);
                    };

                    $scope.any_selected = deselected_action_ids.length !== $scope.cases.length;
                    $scope.all_selected = deselected_action_ids.length === 0;
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
                    $timeout(function () { angular.element('#btnEditStatus')[0].focus(); }, 0, false);
                };
            };

            $scope.deselectAll = function () {
                $scope.all_selected = false;
                $scope.all_checked_previously = false;
                $scope.selectAll();
            };

            // ------------------------------------------------------------ CHANGE CASE STATUS -------------------------------------------------------------------

            $scope.changeStatus = function () {
                commonServices.getEmployeesForRightID({ isMaster: true }, getEmployeesForRightIDComplete, errorFunction);
            };

            function getEmployeesForRightIDComplete(response) {
                $scope.users = response.employees;
                $scope.status = new Object();
                $scope.status.user_login_email = response.logged_in_user_email;
                $scope.credentials_not_verified = false;
                $scope.edit_management_fee = false;
                $scope.edit_status = false;

                ngDialog.open({
                    template: 'scripts/src/app/treatment/view/changeStatusPopupTemplate.html',
                    scope: $scope,
                    plain: false,
                    closeByDocument: false
                });

                $timeout(function () { angular.element('#cbWaiveManagementFee')[0].focus(); }, 400, false);
            };

            $scope.changeStatusCancel = function () {
                ngDialog.close();
            };

            $scope.changeStatusConfirm = function () {
                var param = new Object();
                param.password = $scope.status.password;
                param.user_login_email = $scope.status.user_login_email;

                treatmentService.verifyPassword(param, passwordVerified, passwordNotVerified);
            };

            function passwordVerified(response) {
                $scope.param = new Object();
                $scope.param.selected_action_ids = selected_action_ids;
                $scope.param.deselected_action_ids = deselected_action_ids;
                $scope.param.is_management_fee_waived = $scope.edit_management_fee ? !!$scope.status.is_management_fee_waived : null;
                $scope.param.case_status = $scope.edit_status ? $scope.status.case_status.id : null;
                $scope.param.case_status_ground = $scope.edit_status ? $scope.status.ground : "";
                $scope.param.password = $scope.status.password;
                $scope.param.all_selected = $scope.all_selected;
                $scope.param.filter_by = new Object();
                $scope.param.filter_by.date_from = $scope.search_data !== undefined ? $scope.search_data.date_from : '1-1-1';
                $scope.param.filter_by.date_to = $scope.search_data !== undefined ? $scope.search_data.date_to : '';
                $scope.param.filter_by.search_params = $scope.search_data !== undefined ? $scope.search_data.text_search : '';
                $scope.param.filter_by.filter_by = new Object();
                $scope.param.filter_by.filter_by.filter_type = $scope.search_data !== undefined ? $scope.search_data.filter_by.filter_type : [];
                $scope.param.filter_by.filter_by.filter_status = $scope.search_data !== undefined ? $scope.search_data.filter_by.filter_status : $routeParams.status === undefined ? [] : [$routeParams.status];

                treatmentService.getEligibleCases($scope.param, getEligibleCasesComplete, errorFunction);
                ngDialog.close();
            };

            function getEligibleCasesComplete(response) {
                $scope.param.eligible_cases_for_status_edit = response;

                if (response.length !== 0) {
                    if ($scope.selected_count - response.length !== 0) {
                        var message = new Object();
                        message.message = 'LABEL_MULTI_CHANGE_STATUS_ELGIBILITY';
                        message.eligible = $scope.selected_count - response.length;
                        message.total = $scope.selected_count;
                        alertsServices.RenderConfirmationDialog('LABEL_WARNING', message, 'BUTTON_YES', 'BUTTON_NO', confirmCaseStatusEdit, cancelCaseStatusEdit);
                    } else {
                        confirmCaseStatusEdit();
                    };
                } else {
                    alertsServices.RenderNotificationMessageRedHeader([{ message: 'LABEL_NO_CASES_ELIGIBLE_FOR_STATUS_CHANGE' }], $scope);
                };
            };

            function confirmCaseStatusEdit() {
                treatmentService.changeCaseStatus($scope.param, changeCaseStatusComplete, errorFunction);
            };

            function cancelCaseStatusEdit() { };

            function changeCaseStatusComplete(response) {
                if (response) {
                    ngDialog.close();
                    alertsServices.SuccessMessage('LABEL_CHANGES_SAVED');
                };

                $scope.all_selected = false;
                $scope.selectAll();

                selected_action_ids = [];
                deselected_action_ids = [];
                $scope.all_checked_previously = false;
                $scope.scroll_down_params.infiniteScrollStartIndex = 0;
                $scope.isScrollDisabled = true;
                $scope.is_scroll = false;
                getSubmittedCases();

                $scope.fakeusername = undefined;
                $scope.fakepassword = undefined;
            };

            // ---------------------------------------------------------- ERROR FUNCTIONS -------------------------------------------------------------------------

            function passwordNotVerified(response) {
                $scope.credentials_not_verified = !response;
                if (response) {
                    ngDialog.close();
                    alertsServices.ErrorMessage('LABEL_SOMETHING_WENT_WRONG');
                };
            };

            function getSubmittedCasesCountError(response) {
                console.log(response);
            };

            $scope.authenicateUserError = function (response) {
                $rootScope.activeMenuItem = null;
                $window.location.replace(response.logoutUrl);
            };

            function getSubmittedCasesError(response) {
                $scope.execute_scroll = false;
                console.log(response.Message);
            };

            function errorFunction(response) {
                console.log(response);
                alertsServices.ErrorMessage('LABEL_SOMETHING_WENT_WRONG');
            };

            // ------------------------------------------------------------------------- UTIL ------------------------------------------------------------------------

            $scope.checboxesEmpty = function () {
                return !$scope.edit_status && !$scope.edit_management_fee;
            };

            $scope.getBorderClassName = function (item) {
                switch (item.status) {
                    case 'FS1': return '';
                    case 'FS2': return '';
                    case 'FS3': return 'rejected-border';
                    case 'FS4': return '';
                    case 'FS5': return 'rejected-border';
                    case 'FS6': return 'ordered-border';
                    case 'FS7': return '';
                    case 'FS8': return '';
                    case 'FS9': return 'rejected-border';
                    case 'FS10': return 'rejected-border';
                };
            };

            $scope.getTextClassName = function (item) {
                switch (item.status) {
                    case 'FS1': return '';
                    case 'FS2': return '';
                    case 'FS3': return 'rejected-text';
                    case 'FS4': return '';
                    case 'FS5': return 'rejected-text';
                    case 'FS6': return 'ordered-text';
                    case 'FS7': return '';
                    case 'FS8': return 'gray-font-color';
                    case 'FS9': return 'rejected-text';
                    case 'FS10': return 'rejected-text';
                };
            };

            $scope.SortFunction = function (sort_value) {
                if (sort_by == sort_value) {
                    ascending = !ascending;
                }

                sort_by = sort_value;
                $scope.cases.length = 0;
                $scope.scroll_down_params.infiniteScrollStartIndex = 0;
                $scope.isScrollDisabled = true;
                $scope.is_scroll = false;
                $rootScope.$broadcast("StickyReset");
                getSubmittedCases();
            };

            $scope.setTableHeaderClass = function (order_value) {
                if (ascending && sort_by == order_value)
                    return 'sorted_asc';
                else if (!ascending && sort_by == order_value)
                    return 'sorted_dsc'
                else
                    return 'unsorted';
            };

            $scope.isEditButtonVisible = function (item) {
                return $scope.id !== item.id && item.status === 'FS5';
            };

            $scope.redTextColor = function (item) {
                return item.status === 'FS5' || item.status === 'FS3' || item.status === 'FS9';
            };


            var interval = $interval(function () {
                var element = angular.element('#globalSearchInput')[0];
                if (element) {
                    $interval.cancel(interval);
                    element.focus();
                }
            }, 20, 100, false);

            // -------------------------------- CONTROLLER END -------------------------------------------
        }]);
});
