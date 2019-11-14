"use strict";
define(['application-configuration', 'settingsService'], function (app) {
    app.register.controller('employeeController', ['$scope', '$location', 'settingsService', '$timeout', '$rootScope', 'ajaxService', function ($scope, $location, settingsService, $timeout, $rootScope, ajaxService) {



        // ------------------------------------------------------------ VARIABLES -----------------------------------------------------------

        var sort_by = "name";
        var isAsc = true;
        $scope.isScrollDisabled = false;
        $scope.showData = false;
        $scope.scroll_down_params = new Object();
        $scope.scroll_down_params.infiniteScrollStep = 100;
        $scope.scroll_down_params.infiniteScrollStartIndex = 0;
        $scope.employees = [];
        $scope.showEditUserForm = false;
        $rootScope.$broadcast("StickyReset");

        // ------------------------------------------------------- USER AUTHENTICATION ------------------------------------------------------

        $scope.initializeController = function () {
            $scope.authenicateUser($location.path(), $scope.authenicateUserComplete, $scope.authenicateUserError);
        };

        $scope.authenicateUser = function (route, successFunction, errorFunction) {
            var authenication = new Object();
            authenication.route = route;
            ajaxService.AjaxGetWithData(authenication, "api/main/AuthenicateUser", successFunction, errorFunction);
        };

        $scope.authenicateUserComplete = function (response) {
            $scope.showData = true;
        };

        // --------------------------------------------------------- RETRIEVE DATA --------------------------------------------------------

        $scope.loadMore = function () {
            getEmployees();
        };

        function getEmployees() {
            var sort_parameter = new Object();
            sort_parameter.sort_by = sort_by;
            sort_parameter.isAsc = isAsc;
            sort_parameter.start_row_index = $scope.scroll_down_params.infiniteScrollStartIndex;

            settingsService.getEmployees(sort_parameter, getEmployeesComplete, errorFunction);
        };


        function getEmployeesComplete(response) {
            $scope.isScrollDisabled = response.length < $scope.scroll_down_params.infiniteScrollStep;

            $rootScope.$broadcast("StickyReset");
            $scope.employees = $scope.employees.concat(response);

        };

        function reloadData() {
            $scope.scroll_down_params.infiniteScrollStartIndex = 0;
            $scope.isScrollDisabled = true;
            $scope.employees = [];
            getEmployees();
        };

        // --------------------------------------------------------- ADD NEW USER --------------------------------------------------------

        $scope.openFormAddUser = function () {
            $scope.showUserForm = !$scope.showUserForm;
        };

        $scope.$on('CloseForm', function (event, data) {
            if (data.form === 'addNewUser') {
                $scope.mode = undefined;
                $scope.showUserForm = false;
                $scope.showEditUserForm = false;
                $scope.editUserID = undefined;
                reloadData();
            };
        });

        // ----------------------------------------------------------- EDIT USER ---------------------------------------------------------

        $scope.openEditForm = function (user) {

            $scope.mode = user;
            $scope.showUserForm = false;
            $scope.showEditUserForm = true;
            $scope.editUserID = user.id;

        };

        // ------------------------------------------------------- ERROR FUNCTIONS -------------------------------------------------------

        function errorFunction(response) {
            console.log(response);
        };

        $scope.authenicateUserError = function (response) {
            $rootScope.activeMenuItem = null;
            $window.location.replace(response.logoutUrl);
        };

        // ------------------------------------------------------------ UTIL -------------------------------------------------------------

        $scope.setTableHeaderClass = function (order_value) {
            if (isAsc && sort_by == order_value)
                return 'sorted_asc';
            else if (!isAsc && sort_by == order_value)
                return 'sorted_dsc'
            else
                return 'unsorted';
        };

        $scope.SortFunction = function (sort_value) {
            isAsc = !isAsc;
            $scope.employees = [];
            $scope.scroll_down_params.infiniteScrollStartIndex = 0;
            $scope.isScrollDisabled = false;
            $rootScope.$broadcast("StickyReset");
            getEmployees();
        };

        $timeout(function () { angular.element('#btnAddEmployee')[0].focus(); }, 300, false);

        // ------------------------------------------------------- CONTROLLER END --------------------------------------------------------
    }]);

});
