(function () {
    'use strict';
    angular.module('mainModule').service('planningService', ['ajaxService', function (ajaxService) {

        //-------------------------------------------------GET---------------------------------------------------//
        
        this.getContractList = function (patient_id, successFunction, errorFunction) {
            ajaxService.AjaxGetWithData({ patient_id: patient_id }, "api/planning/GetContractList", successFunction, errorFunction);
        };

        this.getIsPatientHipOnAnOctContract = function (patient_id, successFunction, errorFunction) {
            ajaxService.AjaxGetWithData({ patient_id: patient_id }, 'api/planning/GetIsPatientHipOnAnOctContract', successFunction, errorFunction);
        };

        this.checkIsSameOctDoctor = function (parameter, successFunction, errorFunction) {
            ajaxService.AjaxGetWithData(parameter, 'api/oct/CheckIsSameOctDoctor', successFunction, errorFunction);
        };

        this.getIsPatientFeeWaived = function (parameter, successFunction, errorFunction) {
            ajaxService.AjaxGetWithData(parameter, 'api/planning/GetIsPatientFeeWaived', successFunction, errorFunction);
        };

        this.getIsOrderSubmitted = function (parameter, successFunction, errorFunction) {
            ajaxService.AjaxGetWithData(parameter, 'api/planning/GetIsOrderSubmitted', successFunction, errorFunction);
        };

        this.getCaseHasOctPending = function (parameter, successFunction, errorFunction) {
            ajaxService.AjaxGetWithData(parameter, 'api/planning/GetCaseHasOctPending', successFunction, errorFunction);
        };

        this.getMissingIvomCaseExists = function (parameter, successFunction, errorFunction) {
            ajaxService.AjaxGetWithData(parameter, 'api/planning/GetMissingIvomCaseExists', successFunction, errorFunction);
        };

        this.canShowOrderMessage = function (successFunction, errorFunction) {
            ajaxService.AjaxGet('api/planning/CanShowOrderMessage', successFunction, errorFunction);
        };

        //------------------------------------------------POST--------------------------------------------------//
        this.getPatientsForAutocomplete = function (searchCriteria, successFunction, errorFunction) {
            ajaxService.AjaxPost(searchCriteria, "api/planning/GetPatientsForAutocomplete", successFunction, errorFunction);
        };

        this.createCase = function (newCase, successFunction, errorFunction) {
            ajaxService.AjaxPost(newCase, "api/planning/CreateCase", successFunction, errorFunction);
        };

        this.getCaseDetails = function (case_param, successFunction, errorFunction) {
            ajaxService.AjaxPost(case_param, "api/planning/GetCaseDetails", successFunction, errorFunction);
        };

        this.getCases = function (sort_parameter, successFunction, errorFunction) {
            ajaxService.AjaxPost(sort_parameter, "api/planning/GetCases", successFunction, errorFunction);
        };


        this.verifyTreatmentEligibility = function (param, successFunction, errorFunction) {
            ajaxService.AjaxPost(param, "api/planning/VerifyTreatmentEligibility", successFunction, errorFunction);
        };

        this.submitCase = function (case_param, successFunction, errorFunction) {
            ajaxService.AjaxPost(case_param, "api/planning/SubmitCase", successFunction, errorFunction);
        };
        this.cancelCase = function (case_param, successFunction, errorFunction) {
            ajaxService.AjaxPost(case_param, "api/planning/CancelCase", successFunction, errorFunction);
        };

        this.getPreviousCaseData = function (param, successFunction, errorFunction) {
            ajaxService.AjaxPost(param, "api/planning/GetPreviousCaseDataforPatientID", successFunction, errorFunction);
        };

        this.getCasesCount = function (param, successFunction, errorFunction) {
            ajaxService.AjaxPost(param, "api/planning/GetCasesCount", successFunction, errorFunction);
        };

        this.multiEditCase = function (case_param, successFunction, errorFunction) {
            ajaxService.AjaxPost(case_param, "api/planning/MultiEditCase", successFunction, errorFunction);
        };

        this.multiEditCaseCheckEligibility = function (case_param, successFunction, errorFunction) {
            ajaxService.AjaxPost(case_param, "api/planning/MultiEditCaseCheckEligibility", successFunction, errorFunction);
        };

        this.validateConsents = function (parameter, successFunctionSettlement, errorFunctionSettlement) {
            ajaxService.AjaxPost(parameter, "api/planning/ValidateConsents", successFunctionSettlement, errorFunctionSettlement);
        };

        this.validateConsentsMulti = function (parameter, successFunctionSettlement, errorFunctionSettlement) {
            ajaxService.AjaxPost(parameter, "api/planning/ValidateConsentsMulti", successFunctionSettlement, errorFunctionSettlement);
        };

        this.initiateMultiSubmit = function (parameter, successFunction, errorFunction) {
            ajaxService.AjaxPost(parameter, "api/planning/InitiateMultiSubmit", successFunction, errorFunction);
        };

        this.createTemporaryAftercareDoctor = function (parameter, successFunction, errorFunction) {
            ajaxService.AjaxPost(parameter, "api/planning/CreateTemporaryAftercareDoctor", successFunction, errorFunction);
        };

        this.getWillOrderBeCancelled = function (parameter, successFunction, errorFunction) {
            ajaxService.AjaxPost(parameter, "api/planning/GetWillOrderBeCancelled", successFunction, errorFunction);
        };
        this.verifyPassword = function (parameter, successFunction, errorFunction) {
            ajaxService.AjaxPost(parameter, "api/main/VerifyDoctorPassword", successFunction, errorFunction);
        };
        this.checkIfAlreadyExistTreatment = function (parameter, successFunction, errorFunction) {
            ajaxService.AjaxPost(parameter, "api/planning/CheckIfAlreadyExistTreatment", successFunction, errorFunction);
        };

        this.saveOrderMessageVisability = function (successFunction, errorFunction) {
            ajaxService.AjaxPost(null, "api/planning/SaveOrderMessageVisability", successFunction, errorFunction);
        };

        this.checkIfAlreadyExistAnyTreatment = function (parameter, successFunction, errorFunction) {
            ajaxService.AjaxPost(parameter, "api/planning/CheckIfAlreadyExistAnyTreatment", successFunction, errorFunction);
        };
        
        this.checkIfOCTCanBeSubmitted = function (parameter, successFunction, errorFunction) {
            ajaxService.AjaxPost(parameter, "api/planning/CheckIfOCTCanBeSubmitted", successFunction, errorFunction);
        };

        this.canSaveCaseAfterChangeLocalization = function (parameter, successFunction, errorFunction) {
            ajaxService.AjaxPost(parameter, "api/planning/CanSaveCaseAfterChangeLocalization", successFunction, errorFunction);
        };
    }]);
})();