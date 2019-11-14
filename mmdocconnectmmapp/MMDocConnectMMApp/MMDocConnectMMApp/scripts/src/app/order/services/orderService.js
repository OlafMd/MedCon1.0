define(['application-configuration', 'ajaxService'], function (app) {

    app.register.service('orderService', ['ajaxService', function (ajaxService) {

        this.authenicateUser = function (route, successFunction, errorFunction) {
            var authenication = new Object();
            authenication.route = route;
            ajaxService.AjaxGetWithData(authenication, "api/main/AuthenicateUser", successFunction, errorFunction);
        };

        this.getOrderData = function (sort_parameter, successFunction, errorFunction) {
            ajaxService.AjaxPost(sort_parameter, "api/order/getOrderData", successFunction, errorFunction);
        };

        this.rejectOrderStatus = function (orderClicked, succesFunctionRejectOrder, errorFunctionRejectOrder) {

            ajaxService.AjaxPost(orderClicked, "api/order/rejectOrderStatus", succesFunctionRejectOrder, errorFunctionRejectOrder);
        }
    }]);
});