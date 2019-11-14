(function () {
    'use strict';
    angular.module('mainModule').service('my_accountService', ['ajaxService', function (ajaxService) {

        /******************************************************************************
        * GET Methods
        *******************************************************************************/
        this.getAccountDetails = function ( successFunction, errorFunction) {
            ajaxService.AjaxGet(" api/settings/GetAccountDetails", successFunction, errorFunction);
        };
        this.GetBankAccountInfoforPracticeID = function (id, successFunction, errorFunction) {
            var param = new Object();
            param.id = id;
            ajaxService.AjaxGetWithData(param, "api/settings/GetBankAccountInfoforPracticeID", successFunction, errorFunction);
        };

       
        this.IBanValidation = function (param, successFunction, errorFunction) {
            ajaxService.AjaxPost(param, "api/settings/IBanValidation", successFunction, errorFunction);
        };
        this.saveAccount = function (param, successFunction, errorFunction) {
            ajaxService.AjaxPost(param, "api/settings/SaveAccount", successFunction, errorFunction);
        };
        this.BicBankValidation = function (objbic, successFunction, errorFunction) {
            ajaxService.AjaxPost(objbic, "api/settings/BicBankValidation", successFunction, errorFunction);
        };

    }]);
})();