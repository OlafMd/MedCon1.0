"use strict";

define(['application-configuration', 'doctorService'], function (app) {
    app.register.controller('doctorController', ['$scope', '$rootScope', '$translate', 'doctorService', 'ngDialog', '$timeout', '$location', '$filter', '$window', '$routeParams', '$interval',
    function ($scope, $rootScope, $translate, doctorService, ngDialog, $timeout, $location, $filter, $window, $routeParams, $interval) {
        var dataforList = {};
        $scope.NoData = false;
        var sort_by = "name_untouched";
        var isAsc = true;
        $scope.scroll_down_params = new Object();
        $scope.scroll_down_params.infiniteScrollStep = 100;
        $scope.scroll_down_params.infiniteScrollStartIndex = 0;
        $scope.isScrollDisabled = false;
        $scope.showData = false;
        $scope.is_scroll = false;
        var filterTemp = undefined;
        $scope.DoctorPrList = [];
        $scope.execute_scroll = false;
        $rootScope.$broadcast("StickyReset");


        $scope.initializeController = function () {
            doctorService.authenicateUser($location.path(), $scope.authenicateUserComplete, $scope.authenicateUserError);
        };

        if ($routeParams.status) {
            filterTemp = true;
            $rootScope.$broadcast('SetFilter', { status: $routeParams.status });
        };

        $scope.authenicateUserComplete = function (response) {
            $scope.showData = true;
        };

        $scope.authenicateUserError = function (response) {
            $rootScope.activeMenuItem = null;
            $window.location.replace(response.logoutUrl);
        };

        $scope.OpenFormAddPractice = function () {
            $scope.hideDoctorButton = false;
            $scope.showPracticeDirective = !$scope.showPracticeDirective;
            if ($scope.showPracticeDirective == true) {
                $scope.hidePracticeButton = true;
            };

            $scope.showDoctorDirective = false;
            return false;
        };

        $scope.OpenFormAddDoctor = function () {
            $scope.hidePracticeButton = false;
            $scope.showDoctorDirective = !$scope.showDoctorDirective;
            if ($scope.showDoctorDirective == true) {
                $scope.hideDoctorButton = true;
            };

            $scope.showPracticeDirective = false;
            return false;
        };

        $scope.$on('CloseForm', function (event, data) {
            if (data == "CloseDoctor") {
                $scope.showDoctorDirective = false;
                $scope.hideDoctorButton = false;
                $scope.hidePracticeButton = false;
                $scope.scroll_down_params.infiniteScrollStartIndex = 0;
                $scope.is_scroll = false;
                $scope.isScrollDisabled = false;
                GetDoctorPracticesList();
            } else if (data == "ClosePractice") {
                $scope.showPracticeDirective = false;
                $scope.hidePracticeButton = false;
                $scope.hideDoctorButton = false;
                $scope.scroll_down_params.infiniteScrollStartIndex = 0;
                $scope.is_scroll = false;
                $scope.isScrollDisabled = false;
                GetDoctorPracticesList();
            };
        });

        $scope.PracticeDocFound = function (response) {
            $scope.execute_scroll = false;
            doctorService.GetAllPractices(successItemsFound, $scope.errorItemsNotFound);
            $scope.scroll_down_params.infiniteScrollStartIndex = $scope.scroll_down_params.infiniteScrollStartIndex + $scope.scroll_down_params.infiniteScrollStep;

            $scope.isScrollDisabled = response.length < $scope.scroll_down_params.infiniteScrollStep;

            if ($scope.is_scroll)
                $scope.DoctorPrList = $scope.DoctorPrList.concat(response);
            else {
                $rootScope.$broadcast("StickyReset");
                $scope.DoctorPrList = response;
            };
        };

        $scope.PracticeDocnotFound = function (response) {
            $scope.execute_scroll = false;
            $scope.DoctorPrList = [];
            $scope.DoctorPrList = response;
        };

        function successItemsFound(response) {
            if (response.length === 0) {
                $scope.DisableDoctorbtn = true;
            }
            else {
                $scope.DisableDoctorbtn = false;
            };
        }

        function errorItemsNotFound(response) {

        }

        $scope.getPathForRedirect = function (id, type) {
            if (type == "Doctor")
                return '#/doctor/doctor_detail/' + id;
            else if (type == "Practice")
                return '#/doctor/practice_detail/' + id;
        }

        $scope.SortFunction = function (sort_value) {
            if (sort_by == sort_value) {
                isAsc = !isAsc;
            };

            sort_by = sort_value;
            $scope.DoctorPrList.length = 0;
            $scope.scroll_down_params.infiniteScrollStartIndex = 0;
            $scope.isScrollDisabled = false;
            $scope.is_scroll = false;
            $rootScope.$broadcast("StickyReset");
            GetDoctorPracticesList();
        };

        function GetDoctorPracticesList() {
            if ($scope.execute_scroll) return;
            $scope.execute_scroll = true;

            var sort_parameter = new Object();
            sort_parameter.sort_by = sort_by;
            sort_parameter.isAsc = isAsc;
            sort_parameter.start_row_index = $scope.scroll_down_params.infiniteScrollStartIndex;

            if ($scope.search_data === undefined) {
                sort_parameter.filter_by = new Object();
                sort_parameter.filter_by.filter_status = filterTemp === undefined ? [] : ['temp'];
                sort_parameter.search_params = '';
                sort_parameter.date_from = "1-1-1";
                sort_parameter.date_to = '';
            } else {
                sort_parameter.search_params = $scope.search_data.text_search;
                sort_parameter.filter_by = $scope.search_data.filter_by;
                sort_parameter.date_from = $scope.search_data.date_from;
                sort_parameter.date_to = $scope.search_data.date_to;
            };


            doctorService.GetDoctorPracticesList(sort_parameter, $scope.PracticeDocFound, $scope.PracticeDocnotFound);
        };

        $scope.setTableHeaderClass = function (order_value) {
            if (isAsc && sort_by == order_value)
                return 'sorted_asc';
            else if (!isAsc && sort_by == order_value)
                return 'sorted_dsc'
            else
                return 'unsorted';
        };

        $scope.ifAccountInactive = function (item) {
            return item.account_status !== 'aktiv';
        };


        $scope.getBorderClassName = function (item) {
            switch (item.account_status) {
                case 'aktiv':
                    return '';
                case 'inaktiv':
                    return 'red-row red-border';
                case 'temp':
                    return 'yellow-row yellow-border';
                default:
                    return '';
            }
        };

        var selected_action_ids = [];
        var deselected_action_ids = [];
        $scope.$on('GlobalSearch', function (event, data) {
            $scope.search_data = data;
            $scope.selected_count = $scope.all_selected ? $scope.selected_count : 0;
            deselected_action_ids = $scope.search_data.all_selected ? deselected_action_ids : [];
            selected_action_ids = $scope.search_data.all_selected ? selected_action_ids : [];
            $scope.scroll_down_params.infiniteScrollStartIndex = 0;
            $scope.isScrollDisabled = true;
            $scope.is_scroll = false;
            GetDoctorPracticesList();
        });
        $scope.loadMore = function () {
            $scope.is_scroll = true;
            GetDoctorPracticesList();
        };

        var interval = $interval(function () {
            var element = angular.element('#globalSearchInput')[0];
            if (element) {
                $interval.cancel(interval);
                element.focus();
            }
        }, 20, 100, false);
    }]);

    app.directive('autoFillSync', function ($timeout) {
        return {
            require: 'ngModel',
            link: function (scope, elem, attrs, ngModel) {
                var origVal = elem.val();
                $timeout(function () {
                    var newVal = elem.val();
                    if (ngModel.$pristine && origVal !== newVal) {
                        ngModel.$setViewValue(newVal);
                    }
                }, 500);
            }
        }
    });
});
