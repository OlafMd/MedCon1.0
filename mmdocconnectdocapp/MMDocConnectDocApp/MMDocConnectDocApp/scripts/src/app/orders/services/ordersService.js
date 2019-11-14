(function () {
    'use strict';
    angular.module('mainModule').service('ordersService', ['ajaxService', function (ajaxService) {
        // -------------------------------------------------------------------- GET --------------------------------------------------------------------

        this.getOrderDetails = function (id, successFunction, errorFunction) {
            ajaxService.AjaxGetWithData({ id: id }, "api/order/GetOrderDetails", successFunction, errorFunction);
        };

        this.getAllDrugs = function (successFunction, errorFunction) {
            ajaxService.AjaxGet("api/planning/GetAllDrugs", successFunction, errorFunction);
        };

        this.getPracticeDefaultSettings = function (successFunction, errorFunction) {
            ajaxService.AjaxGet("api/planning/GetPracticeDefaultSettings", successFunction, errorFunction);
        };

        this.GetPracticeAddressAndBacisInfo = function (successFunction, errorFunction) {
            ajaxService.AjaxGet("api/main/GetPracticeAddressAndBacisInfo", successFunction, errorFunction);
        };

        this.getOrderCount = function (sort_parameter, successFunction, errorFunction) {
            ajaxService.AjaxPost(sort_parameter, "api/order/GetOrderCount", successFunction, errorFunction);
        };

        this.getOrderComment = function (parameter, successFunction, errorFunction) {
            ajaxService.AjaxGetWithData(parameter, "api/order/GetOrderComment", successFunction, errorFunction);
        };

        this.getOrderReportURL = function (order_id, successFunction, errorFunction) {
            ajaxService.AjaxGetWithData({ order_id: order_id }, "api/order/GetOrderReportURL", successFunction, errorFunction);
        };

        // -------------------------------------------------------------------- POST --------------------------------------------------------------------

        this.getTreatmentDates = function (order_ids, successFunction, errorFunction) {
            ajaxService.AjaxPost({ order_ids: order_ids }, "api/order/GetTreatmentDates", successFunction, errorFunction);
        };

        this.getAllOrders = function (sort_parameter, successFunctionSettlement, errorFunctionSettlement) {
            ajaxService.AjaxPost(sort_parameter, "api/order/GetAllOrders", successFunctionSettlement, errorFunctionSettlement);
        };

        this.getOrders = function (sort_parameter, successFunctionSettlement, errorFunctionSettlement) {
            ajaxService.AjaxPost(sort_parameter, "api/order/GetOrders", successFunctionSettlement, errorFunctionSettlement);
        };

        this.submitOrder = function (parameter, successFunction, errorFunction) {
            ajaxService.AjaxPost(parameter, 'api/order/SubmitOrders', successFunction, errorFunction);
        };

        this.saveOrder = function (parameter, successFunction, errorFunction) {
            ajaxService.AjaxPost(parameter, 'api/order/SaveOrderDetails', successFunction, errorFunction);
        };

        this.verifyPassword = function (parameter, successFunction, errorFunction) {
            ajaxService.AjaxPost(parameter, "api/main/VerifyDoctorPassword", successFunction, errorFunction);
        };

        this.getOrderIDsToSubmit = function (parameter, successFunction, errorFunction) {
            ajaxService.AjaxPost(parameter, "api/order/GetOrderIDsToSubmit", successFunction, errorFunction);
        };

        this.cancelCase = function (case_param, successFunction, errorFunction) {
            ajaxService.AjaxPost(case_param, "api/planning/CancelCase", successFunction, errorFunction);
        };
        // ------------------------------------------------------------------- DELETE --------------------------------------------------------------------

        this.cancelOrder = function (id, successFunction, errorFunction) {
            ajaxService.AjaxDelete({ id: id }, 'api/order/CancelDrugOrder', successFunction, errorFunction);
        };
    }]);
})();
