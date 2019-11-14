(function () {
    'use strict';

    angular.module('mainModule').service('aftercareService', ['ajaxService', function (ajaxService) {

        // ------------------------------------------------ GET -------------------------------------------------- //
       
        // ------------------------------------------------ POST -------------------------------------------------- //

        this.getAftercares = function (sort_param, successFunction, errorFunction) {
            ajaxService.AjaxPost(sort_param, "api/aftercare/GetAftercares", successFunction, errorFunction);
        };

        this.submitAftercare = function (aftercare_param, successFunction, errorFunction) {
            ajaxService.AjaxPost(aftercare_param, "api/aftercare/SubmitAftercare", successFunction, errorFunction);
        };

        this.getAftercaresCount = function (param, successFunction, errorFunction) {
            ajaxService.AjaxPost(param, "api/aftercare/GetAftercaresCount", successFunction, errorFunction);
        };

        this.validateConsents = function (parameter, successFunctionSettlement, errorFunctionSettlement) {
            ajaxService.AjaxPost(parameter, "api/aftercare/ValidateConsents", successFunctionSettlement, errorFunctionSettlement);
        };

        this.multiEditAftercare = function (case_param, successFunction, errorFunction) {
            ajaxService.AjaxPost(case_param, "api/aftercare/MultiEditAftercare", successFunction, errorFunction);
        };

        this.validateConsentsMulti = function (parameter, successFunctionSettlement, errorFunctionSettlement) {
            ajaxService.AjaxPost(parameter, "api/aftercare/ValidateConsentsMulti", successFunctionSettlement, errorFunctionSettlement);
        };

        this.validateAftercareDate = function (parameter, successFunctionSettlement, errorFunctionSettlement) {
            ajaxService.AjaxPost(parameter, "api/aftercare/ValidateAftercareDate", successFunctionSettlement, errorFunctionSettlement);
        };

        this.initiateMultiSubmit = function (parameter, successFunction, errorFunction) {
            ajaxService.AjaxPost(parameter, "api/aftercare/InitiateMultiSubmit", successFunction, errorFunction);
        };

        this.checkIfAlreadyExistAftercare = function (parameter, successFunctionSettlement, errorFunctionSettlement) {
            ajaxService.AjaxPost(parameter, "api/aftercare/CheckIfAlreadyExistAftercare", successFunctionSettlement, errorFunctionSettlement);
        };
    }]);
})();
