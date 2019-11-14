
"use strict";

define(['application-configuration', 'patientService'], function (app) {
    app.register.controller('patientController', ['$scope', '$rootScope', 'patientService', '$location', 'alertsServices', 'ngDialog', 'validationService', '$window', '$timeout', '$interval',
        function ($scope, $rootScope, patientService, $location, alertsServices, ngDialog, validationService, $window, $timeout, $interval) {

            $scope.sort_by = "name";
            $scope.ascending = true;
            $scope.showPatientData = true;
            $scope.isScrollDisabled = false;
            $scope.patientList = [];
            $scope.search_params = "";
            $scope.scroll_down_params = new Object();
            $scope.scroll_down_params.infiniteScrollStep = 100;
            $scope.scroll_down_params.infiniteScrollStartIndex = 0;
            $scope.isScrollDisabled = false;
            $scope.is_scroll = false;
            $scope.execute_scroll = false;
            $rootScope.$broadcast("StickyReset");

            $scope.$on('GlobalSearch', function (event, data) {
                $scope.search_params = data.text_search;
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

            $scope.redirectToDetailView = function (id) {
                $location.url('/patient/patient_detail/' + id);
            };

            $scope.getPatientsSucess = function (response) {

                $scope.execute_scroll = false;
                $scope.scroll_down_params.infiniteScrollStartIndex = $scope.scroll_down_params.infiniteScrollStartIndex + $scope.scroll_down_params.infiniteScrollStep;

                $scope.isScrollDisabled = response.patients.length < $scope.scroll_down_params.infiniteScrollStep;
                if ($scope.is_scroll) {
                    $scope.patientList = $scope.patientList.concat(response.patients);
                } else {
                    $rootScope.$broadcast("StickyReset");
                    $scope.patientList = response.patients;
                };
            };

            $scope.getPatientsError = function (response) {
                $scope.execute_scroll = false;
                alertsServices.ErrorMessage("LABEL_SOMETHING_WENT_WRONG");
            };

            $scope.getPatients = function () {
                if ($scope.execute_scroll) return;
                $scope.execute_scroll = true;

                var object = new Object();
                object.sort_by = $scope.sort_by;
                object.isAsc = $scope.ascending;
                object.start_row_index = $scope.scroll_down_params.infiniteScrollStartIndex;
                object.search_params = $scope.search_params;

                patientService.getPatients(object, $scope.getPatientsSucess, $scope.getPatientsError)
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

            $scope.ifParticipationConsentInactive = function (item) {
                return item == "LABEL_EXPIRED_CONSENT";
            };

            $scope.setStatusClass = function (item) {
                var value = "";
                switch (item) {
                    case "LABEL_EXPIRED_CONSENT":
                        value = "red-row red-border";
                        break;
                    case "LABEL_ACTIVE_CONSENT":
                        value = "green-row";
                        break;
                }
                return value;
            };
            //User authentification ################################################
            $scope.authenicateUserComplete = function (response) {
                $scope.showPatientDirective = false;
                $scope.showPatientData = true;
            };

            $scope.authenicateUserError = function (response) {
                $rootScope.activeMenuItem = null;
                $location.url(response.logoutUrl);
            };

            $scope.initializeController = function () {
                patientService.authenicateUser($location.path(), $scope.authenicateUserComplete, $scope.authenicateUserError);
            };

            $scope.loadMore = function () {
                if ($scope.execute_scroll) return;
                $scope.is_scroll = true;
                $scope.getPatients();
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
