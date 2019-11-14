"use strict";
define(['application-configuration', 'doctorService'], function (app) {
    app.register.controller('practiceDetailViewController', ['$scope', '$location', '$routeParams', 'doctorService', '$translate', 'validationService', '$timeout',
        function ($scope, $location, $routeParams, doctorService, $translate, validationService, $timeout) {

        $scope.practice_detail = [];
        $scope.practice_doctors = [];
        var sort_by = "name_untouched";
        var ascending = true;
        $scope.NoDoctors = false;

        $scope.scroll_down_params = new Object();
        $scope.scroll_down_params.infiniteScrollStep = 100;
        $scope.scroll_down_params.infiniteScrollStartIndex = 0;
        $scope.isScrollDisabled = false;
        $scope.cases = [];
        $scope.showData = false;
        $scope.execute_scroll = false;

        $scope.showDoctorDirective = false;
        $scope.showDoctorDirectiveButton = true;


        $scope.initializeController = function () {
            doctorService.authenicateUser($location.path(), $scope.authenicateUserComplete, $scope.authenicateUserError);
        };

        $scope.authenicateUserComplete = function (response) {
                $scope.getPracticeDetails();
                $scope.showData = true;
        };

        $scope.authenicateUserError = function (response) {
            $rootScope.activeMenuItem = null;
            $window.location.replace(response.logoutUrl);
        };


        $scope.practiceDetailsComplete = function (response) {
            $scope.practice_detail = response.practice;
        };

        $scope.practiceDetailsError = function (response) {
            console.log(response.ReturnMessage[0]);
        };

        $scope.getPracticeDetails = function () {
            var practice = new Object();
            practice.ID = $routeParams.practice_id;
            doctorService.getPracticeDetails(practice, $scope.practiceDetailsComplete, $scope.practiceDetailsError);
        };

        $scope.redirectToMainPage = function () {
            $location.url('/doctor');
        };

        $scope.practiceDoctorsComplete = function (response) {

            $scope.execute_scroll = false;
            $scope.scroll_down_params.infiniteScrollStartIndex = $scope.scroll_down_params.infiniteScrollStartIndex + $scope.scroll_down_params.infiniteScrollStep;
            if (response.length < $scope.scroll_down_params.infiniteScrollStep)
                $scope.isScrollDisabled = true;
            $scope.practice_doctors = $scope.practice_doctors.concat(response);


            $scope.NoDoctors = $scope.practice_doctors.length === 0;            
        };

        $scope.practiceDoctorsError = function (response) {
            $scope.NoDoctors = true;
            console.log(response.ReturnMessage[0]);
        };

        $scope.getPracticeDoctors = function () {
            if ($scope.execute_scroll) return;
            $scope.execute_scroll = true;

            var practice = new Object();
            practice.practice_id = $routeParams.practice_id;
            practice.ascending = ascending;
            practice.sortfield = sort_by;
            practice.start_row_index = $scope.scroll_down_params.infiniteScrollStartIndex;

            doctorService.getDoctorsForPracticeID(practice, $scope.practiceDoctorsComplete, $scope.practiceDoctorsError);
        };

        //$scope.getPracticeDoctors();


        $scope.OpenFormAddDoctor = function () {
            $scope.showDoctorDirective = !$scope.showDoctorDirective;
            $scope.showDoctorDirectiveButton = !$scope.showDoctorDirectiveButton;

            $scope.showPracticeDirective = false;

            event.stopPropagation();
        };

        $scope.$on('CloseForm', function (event, data) {
            $scope.showDoctorDirective = false;
            $scope.showDoctorDirectiveButton = true;

            $scope.showPracticeDirective = false;
            $scope.scroll_down_params.infiniteScrollStartIndex = 0;
            $scope.isScrollDisabled = false;
            $scope.practice_doctors = [];

            $scope.getPracticeDetails();
            $scope.getPracticeDoctors();
        });

        $scope.loadMore = function () {
            $scope.getPracticeDoctors();
        };


        $scope.OpenFormEditPractice = function () {
            $scope.showPracticeDirective = !$scope.showPracticeDirective;
            $scope.showDoctorDirectiveButton = true;
            $scope.showDoctorDirective = false;
           
            event.stopPropagation();
        };

        $scope.SortFunction = function (sort_value) {
            if (sort_by === sort_value) {
                ascending = !ascending;
            };

            sort_by = sort_value;

            $scope.practice_doctors.length = 0;
            $scope.scroll_down_params.infiniteScrollStartIndex = 0;
            $scope.isScrollDisabled = false;
            $scope.practice_doctors = [];

            $scope.getPracticeDoctors();
        };

        $scope.setTableHeaderClass = function (order_value) {
            if (ascending && sort_by == order_value)
                return 'sorted_asc';
            else if (!ascending && sort_by == order_value)
                return 'sorted_dsc'
            else
                return 'unsorted';
        };


        $scope.redirectToDoctorDetailView = function (id) {
            $location.url('/doctor/doctor_detail/' + id);
        };

        $scope.ifAccountInactive = function (item) {
            return item.account_status !== 'aktiv';
        };

        $scope.isNotNullOrEmpty = validationService.isNotNullOrEmpty;

        $timeout(function () { angular.element('#btnEdtiPractice')[0].focus(); }, 1000, false);
    }]);

});