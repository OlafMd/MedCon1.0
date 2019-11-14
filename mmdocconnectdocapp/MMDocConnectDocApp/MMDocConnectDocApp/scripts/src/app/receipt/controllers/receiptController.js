(function () {
    'use strict';
    angular.module('mainModule').controller('receiptController', ['$scope', 'receiptService', '$timeout', '$rootScope', '$location',
     function ($scope, receiptService, $timeout, $rootScope, $location) {

         // ---------------------------------------------------------- VARIABLES ----------------------------------------------------------

         var sort_by = "filedate";
         var ascending = false;
         $scope.scroll_down_params = new Object();
         $scope.scroll_down_params.infiniteScrollStep = 100;
         $scope.scroll_down_params.infiniteScrollStartIndex = 0;
         $scope.isScrollDisabled = false;
         $scope.receipts = [];
         $scope.is_scroll = false;
         $rootScope.$broadcast("StickyReset");

         // ---------------------------------------------------------- INIT ---------------------------------------------------------------

         getReceiptsItems();

         // ---------------------------------------------------------- DATA RETRIEVAL -----------------------------------------------------

         function getReceiptsItems() {
             var sort_parameter = new Object();
             sort_parameter.sort_by = sort_by;
             sort_parameter.isAsc = ascending;
             sort_parameter.start_row_index = $scope.scroll_down_params.infiniteScrollStartIndex;
             receiptService.GetReceiptItems(sort_parameter, succesFunction, errorFunction);
         };

         function succesFunction(response) {
             $scope.receipts = response.receipts;
         };

         // ---------------------------------------------------------- ERROR FUNCTIONS ------------------------------------------------------

         function errorFunction(response) {
             console.log(response);
             alertService.RenderErrorMessage('LABEL_SOMETHING_WENT_WRONG');
         };

         // ---------------------------------------------------------- DOWNLOAD ----------------------------------------------------------

         $scope.DownloadDocument = function (item) {
             receiptService.DownloadDocumentItem(item, succesFunctionDownload, errorFunction);
         };

         function succesFunctionDownload(response) {
             var save = document.createElement('a');
             save.href = response;
             save.download = response;
             if (navigator.appVersion.toString().indexOf('.NET') > 0) {
                 $timeout(function () {
                     window.location = save;
                 }, 500, false);
             } else {
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

         // ---------------------------------------------------------- UTIL ----------------------------------------------------------

         $scope.setTableHeaderClass = function (receipt_value) {
             if (ascending && sort_by == receipt_value)
                 return 'sorted_asc';
             else if (!ascending && sort_by == receipt_value)
                 return 'sorted_dsc'
             else
                 return 'unsorted';
         };

         $scope.SortFunction = function (sort_value) {
             if (sort_by == sort_value) {
                 ascending = !ascending;
             };
             sort_by = sort_value;
             $scope.receipts.length = 0;
             $scope.scroll_down_params.infiniteScrollStartIndex = 0;
             $scope.isScrollDisabled = false;
             $scope.is_scroll = false;

             $rootScope.$broadcast("StickyReset");
             getReceiptsItems();
         };

         $scope.shouldStick = function () {
             return sort_by === 'filedate';
         };

         // ---------------------------------------------------------- CONTROLLER END ------------------------------------------------
     }]);
})();
