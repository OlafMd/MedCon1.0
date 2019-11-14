(function () {
    'use strict';
    angular.module('mainModule').service('settlementServices', ['ajaxService', function (ajaxService) {

        // -------------------------------------------------------------------- GET --------------------------------------------------------------------

        this.downloadAllNonDowloadedReports = function (successFunction, errorFunction) {
            ajaxService.AjaxGet("api/settlement/DownloadAllNonDowloadedReports", successFunction, errorFunction);
        };

        this.isDownloadAllNonDownloadedReportsVisible = function (successFunction, errorFunction) {
            ajaxService.AjaxGet("api/settlement/IsDownloadAllNonDownloadedReportsVisible", successFunction, errorFunction);
        };

        // -------------------------------------------------------------------- POST --------------------------------------------------------------------

        this.getSettlementitems = function (sort_parameter, successFunctionSettlement, errorFunctionSettlement) {
            ajaxService.AjaxPost(sort_parameter, "api/settlement/getSettlementItems", successFunctionSettlement, errorFunctionSettlement);
        };

        this.getFS6CommentForDoctor = function (parameter, successFunctionSettlement, errorFunctionSettlement) {
            ajaxService.AjaxPost(parameter, "api/settlement/GetFS6CommentForDoctor", successFunctionSettlement, errorFunctionSettlement);
        };

        this.validateConsents = function (parameter, successFunctionSettlement, errorFunctionSettlement) {
            ajaxService.AjaxPost(parameter, "api/settlement/ValidateConsents", successFunctionSettlement, errorFunctionSettlement);
        };
        this.submitCase = function (case_param, successFunction, errorFunction) {
            ajaxService.AjaxPost(case_param, "api/settlement/SubmitCase", successFunction, errorFunction);
        };

        this.verifyPassword = function (parameter, successFunctionSettlement, errorFunctionSettlement) {
            ajaxService.AjaxPost(parameter, "api/main/VerifyDoctorPassword", successFunctionSettlement, errorFunctionSettlement);
        };
        this.CancelCase = function (parameter, successFunctionSettlement, errorFunctionSettlement) {
            ajaxService.AjaxPost(parameter, "api/settlement/CancelCase", successFunctionSettlement, errorFunctionSettlement);
        };

        this.createCase = function (newCase, successFunction, errorFunction) {
            ajaxService.AjaxPost(newCase, "api/settlement/CreateCase", successFunction, errorFunction);
        };

        this.editErrorCorrectionAftercare = function (aftercare, successFunction, errorFunction) {
            ajaxService.AjaxPost(aftercare, "api/settlement/EditAftercareInErrorCorrectionState", successFunction, errorFunction);
        };
        this.multiEditSaveCase = function (parameter, successMultiEditSaveFunction, errorMultiEditSaveFunction) {
            ajaxService.AjaxPost(parameter, "api/settlement/multiEditSaveCase", successMultiEditSaveFunction, errorMultiEditSaveFunction);
        };
        this.getCaseDetails = function (case_param, successFunction, errorFunction) {
            ajaxService.AjaxPost(case_param, "api/settlement/GetCaseDetails", successFunction, errorFunction);
        };

        this.getSettlementitemsForMultiSelect = function (sort_parameter, successFunctionMultiSelect, errorFunctionMultiSelect) {
            ajaxService.AjaxPost(sort_parameter, "api/settlement/getSettlementitemsForMultiSelect", successFunctionMultiSelect, errorFunctionMultiSelect);
        };
        this.multiEditConfirmSaveCase = function (parameter, successConfirmMultiEditSaveFunction, errorConfirmMultiEditSaveFunction) {
            ajaxService.AjaxPost(parameter, "api/settlement/ConfirmMultiEditSaveCase", successConfirmMultiEditSaveFunction, errorConfirmMultiEditSaveFunction);
        };
        this.downloadSubmissionReport = function (parameter, successConfirmMultiEditSaveFunction, errorConfirmMultiEditSaveFunction) {
            ajaxService.AjaxPost(parameter, "api/settlement/DownloadSubmissionReport", successConfirmMultiEditSaveFunction, errorConfirmMultiEditSaveFunction);
        };

        this.validateAndSubmitPreexaminationData = function (preexamination, successFunction, errorFunction) {
            ajaxService.AjaxPost(preexamination, "api/settlement/ValidateAndSubmitPreexaminationData", successFunction, errorFunction);
        };

    }]);
})();