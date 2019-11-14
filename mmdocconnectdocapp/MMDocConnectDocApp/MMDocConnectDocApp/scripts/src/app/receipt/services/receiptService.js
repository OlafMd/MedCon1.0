(function () {
    'use strict';
    angular.module('mainModule').service('receiptService', ['ajaxService', function (ajaxService) {

        // ----------------------------------------------------- GET ------------------------------------------------------

        this.GetReceiptItems = function (sort_parameter, successFunction, errorFunction) {
            ajaxService.AjaxPost(sort_parameter, "api/receipt/GetReceiptItems", successFunction, errorFunction);
        };

        // ----------------------------------------------------- POST -----------------------------------------------------

        this.DownloadDocumentItem = function (item, succesFunctionDownload, errorFunctionDownload) {
            ajaxService.AjaxPost(item, "api/receipt/DownloadDocumentItem", succesFunctionDownload, errorFunctionDownload);
        };
    }]);
})();