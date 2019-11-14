define(['angularAMD'], function (app) {
    app.service('dashboardService', ['ajaxService', 'Upload', function (ajaxService, Upload) {

        // -------------------------------------------------------- GET --------------------------------------------------------

        this.authenicateUser = function (route, successFunction, errorFunction) {
            var authenication = new Object();
            authenication.route = route;
            ajaxService.AjaxGetWithData(authenication, "api/main/AuthenicateUser", successFunction, errorFunction);
        };

        this.getTilesInfo = function (param, successFunction, errorFunction) {
            ajaxService.AjaxGetWithData(param, "api/dashboard/GetTilesInfo", successFunction, errorFunction);
        };

        this.getAllCasesInStatus = function (successFunction, errorFunction) {
            ajaxService.AjaxGet("api/dashboard/getAllCasesInStatus", successFunction, errorFunction);
        };

        this.getOrderForTile = function (successFunction, errorFunction) {
            ajaxService.AjaxGet("api/dashboard/getOrderForTile", successFunction, errorFunction);
        };

        this.CreateReportAndChangeStatusToFs2 = function (dateFrom, successFunctionToFs2, errorFunctionToFs2) {
            ajaxService.AjaxGetWithData({ dateFrom: dateFrom }, "api/dashboard/CreateReportAndChangeStatusToFs2", successFunctionToFs2, errorFunctionToFs2);
        };

        this.getAllCasesOnHold = function (succesCasesOnHold, errorCasesOnHold) {
            ajaxService.AjaxGet("api/dashboard/getAllCasesOnHold", succesCasesOnHold, errorCasesOnHold);
        };

        this.getAllCasesError = function (succesCasesError, errorCasesError) {
            ajaxService.AjaxGet("api/dashboard/getAllCasesError", succesCasesError, errorCasesError);
        };

        this.getAllCasesForPositiveResponse = function (successFunctionPositive, errorFunctionPositive) {
            ajaxService.AjaxGet("api/dashboard/getAllCasesForPositiveResponse", successFunctionPositive, errorFunctionPositive);
        };

        this.getAllCasesForPayment = function (succesCasesForPayment, errorCasesForPayment) {
            ajaxService.AjaxGet("api/dashboard/getAllCasesForPayment", succesCasesForPayment, errorCasesForPayment);
        };


        this.getAllCasesForReport = function (succesCasesForReport, errorCasesForReport) {
            ajaxService.AjaxGet("api/dashboard/getAllCasesForReport", succesCasesForReport, errorCasesForReport);
        };


        //// Olaf
        //this.createReport2AndDownloadIt = function (succesCreateReportAndDownload, errorCreateReportAndDownload) {
        //    ajaxService.AjaxGet("api/dashboard/createReport2AndDownloadIt?start=2019", succesCreateReportAndDownload, errorCreateReportAndDownload);
        //};

        //this.createReportAndDownloadIt = function (succesCreateReportAndDownload, errorCreateReportAndDownload) {
        //    ajaxService.AjaxGet("api/dashboard/createReportAndDownloadIt", succesCreateReportAndDownload, errorCreateReportAndDownload);
        //};

        this.createReportAndDownloadItAok = function (succesCreateReportAndDownload, errorCreateReportAndDownload) {
            ajaxService.AjaxGet("api/dashboard/createReportAndDownloadItAok", succesCreateReportAndDownload, errorCreateReportAndDownload);
        };
        this.createReportAndDownloadItNonAok = function (succesCreateReportAndDownload, errorCreateReportAndDownload) {
            ajaxService.AjaxGet("api/dashboard/createReportAndDownloadItNonAok", succesCreateReportAndDownload, errorCreateReportAndDownload);
        };


        this.getTemporaryAcDoctorsCount = function (successFunction, errorFunction) {
            ajaxService.AjaxGet("api/dashboard/GetTemporaryAcDoctorsCount", successFunction, errorFunction);
        };

        this.changeAllOrderStatus = function (successFunction, errorFunction) {
            ajaxService.AjaxGet("api/dashboard/ChangeAllOrderStatus", successFunction, errorFunction);
        };

        this.createCompleteOrdersReport = function (successFunction, errorFunction) {
            ajaxService.AjaxGet("api/dashboard/CreateCompleteOrdersReport", successFunction, errorFunction);
        };

        // -------------------------------------------------------- POST --------------------------------------------------------

        this.ChangeCasesPayment = function (payment, succesChangeCasesPayment, errorChangeCasesPayment) {
            ajaxService.AjaxPost(payment, "api/dashboard/ChangeCasesPayment", succesChangeCasesPayment, errorChangeCasesPayment);
        };

        this.changeOrders = function (ordersForShipping, successFunctionOrders, errorFunctionOrders) {
            ajaxService.AjaxPost(ordersForShipping, "api/dashboard/changeOrders", successFunctionOrders, errorFunctionOrders);
        };

        this.ordersFromXls = function (file, successFunctionOrders, errorFunctionOrders) {
            Upload.upload({
                url: "api/dashboard/ordersFromXls",
                file: file

            }).success(successFunctionOrders).error(errorFunctionOrders);
        };

        this.PositiveResponse = function (file, succesPositiveResponse, errorPositiveResponse) {
            Upload.upload({
                url: "api/dashboard/PositiveResponse",
                file: file

            }).success(succesPositiveResponse).error(errorPositiveResponse);
        };

        this.positiveResponseConfirm = function (positiveResponse, succesPositiveResponseConfirmed, cancelPositiveResponseConfirmed) {
            ajaxService.AjaxPost(positiveResponse, "api/dashboard/positiveResponseConfirm", succesPositiveResponseConfirmed, cancelPositiveResponseConfirmed);
        };
        this.negativeResponseConfirm = function (negativeResponse, succesNegativeResponseConfirmed, cancelNegativeResponseConfirmed) {
            ajaxService.AjaxPost(negativeResponse, "api/dashboard/NegativeResponse", succesNegativeResponseConfirmed, cancelNegativeResponseConfirmed);
        };
    }]);
});