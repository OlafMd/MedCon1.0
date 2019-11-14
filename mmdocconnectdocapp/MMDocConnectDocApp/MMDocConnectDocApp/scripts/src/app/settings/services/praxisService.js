(function () {
    'use strict';
    angular.module('mainModule').service('praxisService', ['ajaxService', function (ajaxService) {

        /******************************************************************************
        * GET Methods
        *******************************************************************************/
        this.getPracticeDetails = function (successFunction, errorFunction) {
            ajaxService.AjaxGet("api/settings/GetPracticeDetails", successFunction, errorFunction);
        };
       /*******************************************************************************
       * POST Methods
       *******************************************************************************/
        this.savePractice = function (param, successFunction, errorFunction) {
            ajaxService.AjaxPost(param, "api/settings/CreatePractice", successFunction, errorFunction);
        };

        this.checkIfAutentificationNeeded = function (successFunction, errorFunction) {
            ajaxService.AjaxGet("api/settings/CheckIfAutentificationNeeded", successFunction, errorFunction);
        };
        
    }]);
})();
