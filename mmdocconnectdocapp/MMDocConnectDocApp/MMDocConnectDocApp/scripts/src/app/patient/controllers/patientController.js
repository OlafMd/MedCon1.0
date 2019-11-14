(function () {
    'use strict';
    angular.module('mainModule').controller('patientController', ['$scope', '$rootScope', 'patientService', '$location', 'alertService', 'commonServices', 'planningService', 'documentationOnlyService',
        function ($scope, $rootScope, patientService, $location, alertService, commonServices, planningService, documentationOnlyService) {

            $scope.sort_by = "name";
            $scope.ascending = true;
            $scope.showPatientData = false;
            $scope.isScrollDisabled = false;
            $scope.patientList = [];
            $scope.search_data = { filter_by: { all: true }, text_search: '' };
            $scope.scroll_down_params = new Object();
            $scope.scroll_down_params.infiniteScrollStep = 100;
            $scope.scroll_down_params.infiniteScrollStartIndex = 0;
            $scope.isScrollDisabled = false;
            $scope.is_scroll = false;
            $scope.execute_scroll = false;
            $scope.getPatients = getPatients;
            getPatients();

            $scope.$on('CloseForm', function (event, data) {
                if (data == "ClosePatient") {
                    $scope.scroll_down_params.infiniteScrollStartIndex = 0;
                    $scope.is_scroll = false;
                    $scope.isScrollDisabled = true;
                    $scope.showPatientDirective = false;
                    $scope.hidePatientButton = false;
                    $scope.getPatients();
                }
            });

            $scope.$on('GlobalSearch', function (event, data) {
                $scope.search_params = data.text_search;
                $scope.search_data = data;
                $scope.scroll_down_params.infiniteScrollStartIndex = 0;
                $scope.is_scroll = false;
                $scope.isScrollDisabled = true;
                $scope.getPatients();
            });

            $scope.OpenFormAddPatient = function () {
                $scope.showPatientDirective = !$scope.showPatientDirective;
                if ($scope.showPatientDirective)
                    $scope.hidePatientButton = true;
            };

            //#Table functions ################################################
            $scope.setTableHeaderClass = function (order_value) {
                if ($scope.ascending && $scope.sort_by == order_value)
                    return 'sorted_asc';
                else if (!$scope.ascending && $scope.sort_by == order_value)
                    return 'sorted_dsc'
                else
                    return 'unsorted';
            };

            $scope.redirectToDetailView = function (patient) {
                var id = patient.originating_patient_id || patient.id;
                $location.url('/patient/patient_detail/' + id);
            };

            $rootScope.$broadcast("StickyReset");

            function getPatientsSucess(response) {
                $scope.execute_scroll = false;
                $scope.scroll_down_params.infiniteScrollStartIndex = $scope.scroll_down_params.infiniteScrollStartIndex + $scope.scroll_down_params.infiniteScrollStep;

                $scope.isScrollDisabled = response.patient.length < $scope.scroll_down_params.infiniteScrollStep;
                if ($scope.is_scroll) {
                    $scope.patientList = $scope.patientList.concat(response.patient);
                } else {
                    $rootScope.$broadcast("StickyReset");
                    $scope.patientList = response.patient;
                };


                commonServices.focusSearch();
            };

            function getPatientsError(response) {
                $scope.execute_scroll = false;
                alertService.RenderErrorMessage("LABEL_SOMETHING_WENT_WRONG");
            };

            function getPatients() {
                if ($scope.execute_scroll) return;
                $scope.execute_scroll = true;

                var object = new Object();
                object.sort_by = $scope.sort_by;
                object.isAsc = $scope.ascending;
                object.start_row_index = $scope.scroll_down_params.infiniteScrollStartIndex;
                object.search_params = $scope.search_data.text_search;
                object.show_only_with_rejected_octs = $scope.search_data.filter_by.show_only_with_rejected_octs;
                object.hip_name = $scope.search_data.filter_by.hip_name;
                object.this_practice = $scope.search_data.filter_by.this_practice;
                object.different_practice = $scope.search_data.filter_by.different_practice;
                object.invalid_consent = $scope.search_data.filter_by.invalid_consent;

                patientService.getPatients(object, getPatientsSucess, getPatientsError)
            };

            $scope.orderTable = function (order_value) {
                $scope.scroll_down_params.infiniteScrollStartIndex = 0;
                $scope.is_scroll = false;
                $scope.isScrollDisabled = true;
                $scope.patientList = [];
                $scope.sort_by = order_value;
                $scope.ascending = !$scope.ascending;

                $rootScope.$broadcast("StickyReset");
                $scope.getPatients();
            };

            $scope.setStatusClass = function (item) {
                var value = "";
                switch (item) {
                    case "LABEL_EXPIRED_CONSENT":
                        value = "red-border";
                        break;
                }
                return value;
            };


            function errorFunction(response) {
                console.log(response);
                alertService.RenderErrorMessage('LABEL_SOMETHING_WENT_WRONG');
            };

            //Init ################################################            
            $scope.loadMore = function () {
                if ($scope.execute_scroll) return;
                $scope.is_scroll = true;
                $scope.getPatients();
            };

            commonServices.focusSearch();
        }]);
})();
