"use strict";
define(['application-configuration', 'patientService'], function (app) {
    app.register.controller('patientDetailViewController', ['$scope', '$filter', '$routeParams', 'patientService', 'alertsServices', '$timeout', '$rootScope', function ($scope, $filter, $routeParams, patientService, alertsServices, $timeout, $rootScope) {


        $scope.patient_detail = [];

        $scope.contractList = {};
        $scope.participation_consent = {};
        $scope.ValidFrom = $filter('date')(new Date(), 'dd.MM.yyyy');
        $scope.showMessageContainer = false;

        //#patient detail view data
        $scope.sort_by = "date";
        $scope.ascending = false;
        $scope.patientDetailViewList = [];
        $scope.scroll_down_params = new Object();
        $scope.scroll_down_params.infiniteScrollStep = 100;
        $scope.scroll_down_params.infiniteScrollStartIndex = 0;
        $scope.isScrollDisabled = false;
        $scope.is_scroll = false;
        $scope.execute_scroll = false;
        $rootScope.$broadcast("StickyReset");

        $scope.patientDetailsComplete = function (response) {
            $scope.patient_detail = response.patient;
            $scope.patient_data = new Object();
            $scope.patient_data.display_name = response.patient.name + ' (' + response.patient.birthday + ')';
            $scope.patient_data.id = $routeParams.patient_id;

            $scope.execute_scroll = false;
            $scope.scroll_down_params.infiniteScrollStartIndex = $scope.scroll_down_params.infiniteScrollStartIndex + $scope.scroll_down_params.infiniteScrollStep;
            if (response.patient_details_list.length < $scope.scroll_down_params.infiniteScrollStep)
                $scope.isScrollDisabled = true;
            if ($scope.is_scroll)
                $scope.patientDetailViewList = $scope.patientDetailViewList.concat(response.patient_details_list);
            else {
                $rootScope.$broadcast("StickyReset");
                $scope.patientDetailViewList.length = 0;
                $scope.patientDetailViewList = response.patient_details_list;
            };
        };

        $scope.getItemStatus = function (item) {
            if (item.detail_type === 'order') {
                return item.order_status;
            } else {
                return item.status;
            }
        }

        $scope.patientDetailsError = function (response) {
            $scope.execute_scroll = false;
            console.log(response);
            alertsServices.ErrorMessage('LABEL_SOMETHING_WENT_WRONG');
        };

        $scope.getPatientDetails = function () {
            if ($scope.execute_scroll) return;
            $scope.execute_scroll = true;

            var patient = new Object();
            patient.ID = $routeParams.patient_id;
            patient.isAsc = $scope.ascending;
            patient.start_row_index = $scope.scroll_down_params.infiniteScrollStartIndex;
            patient.sort_by = $scope.sort_by;
            patientService.getPatientDetails(patient, $scope.patientDetailsComplete, $scope.patientDetailsError);
        };
        $scope.getPatientDetails();
        $scope.redirectBackOnePage = function () {
            window.history.back();
        };



        $scope.getPatientID = function () {
            return $routeParams.patient_id;
        };

        $scope.setTableHeaderClass = function (order_value) {
            if ($scope.ascending && $scope.sort_by == order_value)
                return 'sorted_asc';
            else if (!$scope.ascending && $scope.sort_by == order_value)
                return 'sorted_dsc'
            else
                return 'unsorted';
        };

        $scope.orderTable = function (order_value) {
            $scope.isScrollDisabled = false;
            $scope.scroll_down_params.infiniteScrollStartIndex = 0;
            $scope.patientDetailViewList.length = 0;
            $scope.sort_by = order_value;
            $scope.ascending = !$scope.ascending;
            $rootScope.$broadcast("StickyReset");
            $scope.getPatientDetails();
        };

        $scope.loadMore = function () {
            if ($scope.execute_scroll) return;
            $scope.is_scroll = true;
            $scope.getPatientDetails();
        };

        $scope.getBorderClassName = function (item) {
            if (item.detail_type != 'order') {
                switch (item.status) {
                    case ('FS0'): return '';
                    case ('FS1'): return '';
                    case ('FS2'): return 'ordered-border';
                    case ('FS4'): return 'ordered-border';
                    case ('FS6'): return 'rejected-border';
                    case ('FS7'): return 'shipped-border';
                    case ('FS8'): return 'gray-border';
                    case ('FS9'): return 'rejected-border';
                    case ('FS12'): return 'shipped-border';
                    case ('LABEL_PARTICIPATION_ACTIVE'): return 'shipped-border';
                    case ('LABEL_PARTICIPATION_NOT_ACTIVE'): return 'rejected-border';
                    case ('LABEL_PARTICIPATION_NOT_YET_ACTIVE'): return 'rejected-border';
                    case 'MO1': return 'ordered-border ordered-text';
                    case 'MO2': return 'shipped-border shipped-text';
                    case 'MO3': return '';
                    case 'MO4': return 'rejected-border rejected-text';
                    case 'MO5': return 'scheduled-border';
                    case 'MO6': return 'rejected-border rejected-text';
                    case 'AC3': return 'rejected-border rejected-text';
                    case 'AC4': return 'gray-border gray-text';
                };
            } else {
                switch (item.order_status) {
                    case 'MO1': return 'ordered-border ordered-text';
                    case 'MO2': return 'shipped-border shipped-text';
                    case 'MO3': return '';
                    case 'MO4': return 'rejected-border rejected-text';
                    case 'MO5': return 'scheduled-border';
                    case 'MO6': return 'rejected-border rejected-text';
                }
            }
        };

        $scope.getTextClassName = function (item) {
            if (item.detail_type != 'order') {
                switch (item.status) {
                    case ('FS0'): return '';
                    case ('FS1'): return '';
                    case ('FS2'): return 'ordered-text';
                    case ('FS4'): return 'ordered-text';
                    case ('FS6'): return 'rejected-text';
                    case ('FS7'): return 'shipped-text';
                    case ('FS8'): return 'gray-text';
                    case ('FS9'): return 'rejected-text';
                    case ('FS12'): return 'shipped-text';
                    case ('LABEL_PARTICIPATION_ACTIVE'): return 'shipped-text';
                    case ('LABEL_PARTICIPATION_NOT_ACTIVE'): return 'rejected-text';
                    case ('LABEL_PARTICIPATION_NOT_YET_ACTIVE'): return 'rejected-text';
                };
            } else {
                switch (item.order_status) {
                    case ('MO2'): return 'shipped-text';
                }
            }
        };
        
        $scope.getOrderStatus = function (item) {
            if (item.detail_type === 'order') {
                return "";
            } else if (item.detail_type === "op") {
                if (item.order_status === "") {
                    return "LABEL_NOT_ORDERED";
                } else if (item.order_status !== 'MO0') {
                    return item.order_status;
                }
            }            else {
                return item.order_status;
            }

        };

        getCanShowOctInformation();
        function getCanShowOctInformation() {
            patientService.getIsPatientHipOnAnOctContract($routeParams.patient_id, function (response) {
                $scope.can_show_oct_info = response;
            }, function () {
                $scope.can_show_oct_info = false;
            });
        }
    }]);
});
