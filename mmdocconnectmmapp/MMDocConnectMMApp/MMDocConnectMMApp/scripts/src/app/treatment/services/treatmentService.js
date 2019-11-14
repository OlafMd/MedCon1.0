define(['angularAMD'], function (app) {
    app.service('treatmentService', ['ajaxService', function (ajaxService) {

        // ------------------------------------------------ GET -------------------------------------------------- //

        this.authenicateUser = function (route, successFunction, errorFunction) {
            var authenication = new Object();
            authenication.route = route;
            ajaxService.AjaxGetWithData(authenication, "api/main/AuthenicateUser", successFunction, errorFunction);
        };
    
        // ------------------------------------------------ POST -------------------------------------------------- //

        this.getSubmittedCases = function (param, succesFunction, errorFunction) {
            ajaxService.AjaxPost(param, "api/treatment/GetSubmittedCases", succesFunction, errorFunction);
        };

        this.submitCaseForErrorCorrection = function (param, succesFunction, errorFunction) {
            ajaxService.AjaxPost(param, "api/treatment/SubmitCaseForErrorCorrection", succesFunction, errorFunction);
        };

        this.getResponseFromHIP = function (param, succesFunction, errorFunction) {
            ajaxService.AjaxPost(param, "api/treatment/GetResponseFromHIP", succesFunction, errorFunction);
        };

        this.changeCaseStatus = function (param, succesFunction, errorFunction) {
            ajaxService.AjaxPost(param, "api/treatment/ChangeCaseStatus", succesFunction, errorFunction);
        };

        this.getSubmittedCasesCount = function (parameter, succesFunction, errorFunction) {
            ajaxService.AjaxPost(parameter, "api/treatment/GetSubmittedCasesCount", succesFunction, errorFunction);
        };
        
        this.verifyPassword = function (parameter, succesFunction, errorFunction) {
            ajaxService.AjaxPost(parameter, "api/main/VerifyPassword", succesFunction, errorFunction);
        };

        this.getEligibleCases = function(parameter, succesFunction, errorFunction) {
            ajaxService.AjaxPost(parameter, "api/treatment/GetEligibleCases", succesFunction, errorFunction);
        };

        // ----------------------------------------- SERVICE END ----------------------------------------------- //
    }]);
});