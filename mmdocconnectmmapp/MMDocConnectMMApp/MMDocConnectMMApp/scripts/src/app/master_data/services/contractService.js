define(['angularAMD', 'ajaxService'], function (app) {
    app.service('contractService', ['ajaxService', function (ajaxService) {

        // ------------------------------------------------------ VARIABLES ----------------------------------------------------

        var self = this;
        var contract = new Object();

        // --------------------------------------------------- GETTER/SETTER ---------------------------------------------------

        self.getContract = function () {
            return contract;
        };

        self.setContract = function (ctr) {
            contract = ctr;
        };

        // -------------------------------------------------------- GET --------------------------------------------------------

        self.authenicateUser = function (route, successFunction, errorFunction) {
            var authenication = new Object();
            authenication.route = route;
            ajaxService.AjaxGetWithData(authenication, "api/main/AuthenicateUser", successFunction, errorFunction);
        };

        self.getAllContracts = function (sort_parameter, successFunction, errorFunction) {
            ajaxService.AjaxGetWithData(sort_parameter, "api/contract/GetAllContracts", successFunction, errorFunction);
        };

        self.getContractDetails = function (param, successFunction, errorFunction) {
            ajaxService.AjaxGetWithData(param, "api/contract/GetContractDetails", successFunction, errorFunction);
        };
   

        // ------------------------------------------------------- POST --------------------------------------------------------

        self.getConsentStartDate = function (param, successFunction, errorFunction) {
            ajaxService.AjaxPost(param, "api/contract/GetConsentStartDate", successFunction, errorFunction);
        };

        self.saveContract = function (successFunction, errorFunction) {
            ajaxService.AjaxPost(contract, "api/contract/SaveContract", successFunction, errorFunction);
        };

        self.copyContract = function (contract_id, successFunction, errorFunction) {
            ajaxService.AjaxPost(contract_id, "api/contract/CopyContract", successFunction, errorFunction);
        };

        self.validateContractOverlaps = function (parameter, successFunction, errorFunction) {
            ajaxService.AjaxPost(parameter, "api/contract/ValidateContractOverlaps", successFunction, errorFunction);
        };

        // ------------------------------------------------------- UTIL -------------------------------------------------------
        
        self.isNotUndefined = function (data) {
            return data !== undefined && data !== null && data != '';
        };
        
        // -------------------------------------------------------- END --------------------------------------------------------

    }]);
});