define(['angularAMD', 'ajaxService'], function (app) {
    app.service('settingsService', ['ajaxService', function (ajaxService) {

        // ----------------------------------------------------- GET ------------------------------------------------------

        this.authenicateUser = function (route, successFunction, errorFunction) {
            var authenication = new Object();
            authenication.route = route;
            ajaxService.AjaxGetWithData(authenication, "api/main/AuthenicateUser", successFunction, errorFunction);
        };
      
        this.getUsers = function ( successFunctionUsers, errorFunctionUsers) {
            ajaxService.AjaxGet("api/settings/getUsers", successFunctionUsers, errorFunctionUsers);
        };

        this.getCompanySettings = function (successFunctionSettings, errorFunctionSettings) {
            ajaxService.AjaxGet("api/settings/GetCompanySettings", successFunctionSettings, errorFunctionSettings);
        };
        // ----------------------------------------------------- POST -----------------------------------------------------

        this.createUser = function (user, successFunction, errorFunction) {
            ajaxService.AjaxPost(user, "api/settings/CreteUser", successFunction, errorFunction);
        };

        this.getEmployees = function (sort_parameter, successFunction, errorFunction) {
            ajaxService.AjaxPost(sort_parameter, "api/settings/GetEmployees", successFunction, errorFunction);
        };
        this.AddUser = function (userData, successFunction, errorFunction) {
            ajaxService.AjaxPost(userData, "api/settings/AddUser", successFunction, errorFunction);
        };

        this.checkLoginMail = function (practice, successFunction, errorFunction) {
            ajaxService.AjaxPost(practice, "api/doctor/CheckLoginEmail", successFunction, errorFunction);
        };

        this.saveAppSettings = function (settingsData, successFunctionAppSettings, errorFunctionAppSettings) {
            ajaxService.AjaxPost(settingsData, "api/settings/SaveAppSettings", successFunctionAppSettings, errorFunctionAppSettings);
        };

        this.GetUserForAccountID = function (userID, successFunction, errorFunction) {
            ajaxService.AjaxPost(userID, "api/settings/GetUserForAccountID", successFunction, errorFunction);
        };
        //settingsService.GetUserForMyAccount(successUserFound, errorUserNotfound);
        this.GetUserForMyAccount = function ( successFunction, errorFunction) {
            ajaxService.AjaxGet("api/settings/GetUserForMyAccount", successFunction, errorFunction);
        };
    }]);
});