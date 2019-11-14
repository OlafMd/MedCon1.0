define(['application-configuration', 'ajaxService'], function (app) {
    app.register.service('archiveService', ['ajaxService', 'Upload', function (ajaxService, Upload) {

        this.GetArchivedItems = function (sort_parameter, successFunction, errorFunction) {
            ajaxService.AjaxPost(sort_parameter, "api/archive/GetArchivedItems", successFunction, errorFunction);
        }
    
        this.DownloadDocumentItem = function (item, succesFunctionDownload, errorFunctionDownload) {
            ajaxService.AjaxPost(item, "api/archive/DownloadDocumentItem", succesFunctionDownload, errorFunctionDownload);
        }
    }]);
});