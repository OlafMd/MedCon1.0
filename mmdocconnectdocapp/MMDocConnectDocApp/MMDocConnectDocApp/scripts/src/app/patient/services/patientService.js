(function () {
    'use strict';
    angular.module('mainModule').service('patientService', ['ajaxService', function (ajaxService) {

        //------------------------------------------------GET--------------------------------------------------//
        this.checkIfHINumberIsUnique = function (patient_id, hi_number, first_name, last_name, birthday, health_insuracne_status, sex, isOldValidationPHIS, successFunction, errorFunction) {
            var object = new Object();
            object.hi_number = hi_number;
            object.first_name = first_name;
            object.last_name = last_name;
            object.birthday = birthday;
            object.sex = sex;
            if (patient_id === undefined)
                object.patient_id = "";
            else
                object.patient_id = patient_id;
            object.health_insuracne_status = health_insuracne_status;
            object.isOldValidationPHIS = isOldValidationPHIS;
            ajaxService.AjaxGetWithData(object, "api/patient/CheckIfHINumberIsUnique", successFunction, errorFunction);
        };

        this.getInitalData = function (successFunction, errorFunction) {
            ajaxService.AjaxGet("api/patient/GetInitalData", successFunction, errorFunction);
        };

        this.getPatients = function (parameterObject, successFunction, errorFunction) {
            ajaxService.AjaxGetWithData(parameterObject, "api/patient/GetPatients", successFunction, errorFunction);
        };

        this.getPatientDetails = function (id, successFunction, errorFunction) {
            ajaxService.AjaxGetWithData(id, "api/patient/Get_PatientDetails", successFunction, errorFunction);
        };

        this.getPatientEditInitalData = function (parameterObject, successFunction, errorFunction) {
            ajaxService.AjaxGetWithData(parameterObject, "api/patient/Get_PatientDataWithInitalData", successFunction, errorFunction);
        };

        this.checkNewKVNRValidation = function (insuranceNumber, successFunction, errorFunction) {
            var object = new Object();
            object.insuranceNumber = insuranceNumber;
            ajaxService.AjaxGetWithData(object, "api/patient/CheckNewKVNRValidation", successFunction, errorFunction);
        };

        this.Get_contractID = function (parameterObject, successFunction, errorFunction) {
            ajaxService.AjaxGetWithData(parameterObject, "api/patient/Get_contractID", successFunction, errorFunction);
        };

        this.getContractsWhereHIPisParticipating = function (parameterObject, successFunction, errorFunction) {
            ajaxService.AjaxGetWithData(parameterObject, "api/patient/getContractsWhereHIPisParticipating", successFunction, errorFunction);
        };

        this.canChangeHIP = function (parameterObject, successFunction, errorFunction) {
            ajaxService.AjaxGetWithData(parameterObject, "api/patient/CanChangeHIP", successFunction, errorFunction);
        };

        this.checkIsSameOctDoctor = function (parameter, successFunction, errorFunction) {
            ajaxService.AjaxGetWithData(parameter, 'api/oct/CheckIsSameOctDoctor', successFunction, errorFunction);
        };

        this.checkPatientFeeWaiverForYear = function (parameter, successFunction, errorFunction) {
            ajaxService.AjaxGetWithData(parameter, 'api/patient/CheckPatientFeeWaiverForYear', successFunction, errorFunction);
        };

        //------------------------------------------------POST--------------------------------------------------//
        this.savePatient = function (patient, successFunction, errorFunction) {
            ajaxService.AjaxPost(patient, "api/patient/CreatePatient", successFunction, errorFunction);
        };
        this.savePatientParticipationConsent = function (participation_consent, successFunction, errorFunction) {
            ajaxService.AjaxPost(participation_consent, "api/patient/SavePatientParticipationConsent", successFunction, errorFunction);
        };

        this.editOctDoctor = function (parameter, successFunction, errorFunction) {
            ajaxService.AjaxPost(parameter, "api/oct/EditOctDoctor", successFunction, errorFunction);
        };

        this.savePatientFeeWaiver = function (parameter, successFunction, errorFunction) {
            ajaxService.AjaxPost(parameter, "api/patient/SavePatientFeeWaiver", successFunction, errorFunction);
        };


        // -------------------------------------------- DELETE -------------------------------------------------------//
        this.deletePatientFeeWaiver = function (parameter, successFunction, errorFunction) {
            ajaxService.AjaxDelete(parameter, "api/patient/DeletePatientFeeWaiver", successFunction, errorFunction);
        };

        this.deleteCase = function (parameter, successFunction, errorFunction) {
            ajaxService.AjaxDelete(parameter, "api/patient/DeleteDocumentationCase", successFunction, errorFunction);
        };
    }]);
})();