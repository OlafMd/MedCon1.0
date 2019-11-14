
"use strict";

define(['application-configuration', 'alertsServices', 'archiveService'], function (app) {
    app.register.controller('archiveController', ['$scope', '$rootScope', '$translate', 'ngDialog', 'alertsServices', 'Upload', '$filter', 'archiveService', '$routeParams', '$timeout', '$interval',
        function ($scope, $rootScope, $translate, ngDialog, alertsServices, Upload, $filter, archiveService, $routeParams, $timeout, $interval) {
            var sort_by = "filedate";
            var ascending = false;
            $scope.scroll_down_params = new Object();
            $scope.scroll_down_params.infiniteScrollStep = 100;
            $scope.scroll_down_params.infiniteScrollStartIndex = 0;
            $scope.isScrollDisabled = false;
            $scope.archive = [];
            $scope.is_scroll = false;
            $scope.execute_scroll = false;
            $rootScope.$broadcast("StickyReset");

            function getArchiveItems() {
                if ($scope.execute_scroll) return;
                $scope.execute_scroll = true;

                var sort_parameter = new Object();
                sort_parameter.sort_by = sort_by;
                sort_parameter.isAsc = ascending;
                sort_parameter.start_row_index = $scope.scroll_down_params.infiniteScrollStartIndex;
                if ($scope.search_data === undefined) {
                    sort_parameter.filter_by = '';
                    sort_parameter.search_params = '';
                    sort_parameter.date_from = "1-1-1";
                    sort_parameter.date_to = '';
                } else {
                    sort_parameter.search_params = $scope.search_data.text_search;
                    sort_parameter.filter_by = $scope.search_data.filter_by;
                    sort_parameter.date_from = $scope.search_data.date_from;
                    sort_parameter.date_to = $scope.search_data.date_to;
                };
                archiveService.GetArchivedItems(sort_parameter, succesFunction, errorFunction);
            };
            function succesFunction(response) {
                $scope.execute_scroll = false;
                $scope.scroll_down_params.infiniteScrollStartIndex = $scope.scroll_down_params.infiniteScrollStartIndex + $scope.scroll_down_params.infiniteScrollStep;
                if (response.ArchItem.length < $scope.scroll_down_params.infiniteScrollStep)
                    $scope.isScrollDisabled = true;
                if ($scope.is_scroll)
                    $scope.archive = $scope.archive.concat(response.ArchItem);
                else {
                    $rootScope.$broadcast("StickyReset");
                    $scope.archive.length = 0;
                    $scope.archive = response.ArchItem;
                };
            }

            function errorFunction(response) {
                $scope.execute_scroll = false;
            }

            $scope.DownloadDocument = function (item) {
                archiveService.DownloadDocumentItem(item, succesFunctionDownload, errorFunctionDownload);
            };

            function succesFunctionDownload(response) {


                var save = document.createElement('a');
                save.href = response;
                save.download = response;
                if (navigator.appVersion.toString().indexOf('.NET') > 0) {
                    $timeout(function () {
                        window.location = save;
                    }, 500, false);
                }
                else {
                    $timeout(function () {
                        var event = document.createEvent("MouseEvents");
                        event.initMouseEvent(
                                "click", true, false, window, 0, 0, 0, 0, 0
                                , false, false, false, false, 0, null
                        );
                        save.dispatchEvent(event);
                    }, 500, false);
                };
            };

            function errorFunctionDownload(response) {
                console.log(response);
                alertsServices.ErrorMessage('LABEL_SOMETHING_WENT_WRONG');
            }

            $scope.SortFunction = function (sort_value) {
                if (sort_by == sort_value) {
                    ascending = !ascending;
                };

                sort_by = sort_value;
                $scope.archive.length = 0;
                $scope.scroll_down_params.infiniteScrollStartIndex = 0;
                $scope.isScrollDisabled = false;
                $scope.is_scroll = false;
                $rootScope.$broadcast("StickyReset");
                getArchiveItems();
            };

            $scope.setTableHeaderClass = function (order_value) {
                if (ascending && sort_by == order_value)
                    return 'sorted_asc';
                else if (!ascending && sort_by == order_value)
                    return 'sorted_dsc'
                else
                    return 'unsorted';
            };

            $scope.$on('GlobalSearch', function (event, data) {
                $scope.search_data = data;
                $scope.scroll_down_params.infiniteScrollStartIndex = 0;
                $scope.is_scroll = false;
                $scope.isScrollDisabled = false;
                getArchiveItems();
            });

            $scope.loadMore = function () {
                $scope.is_scroll = true;
                getArchiveItems();
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
