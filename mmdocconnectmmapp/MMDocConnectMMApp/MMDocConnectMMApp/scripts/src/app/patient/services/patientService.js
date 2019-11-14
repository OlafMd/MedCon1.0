
define(['angularAMD', 'ajaxService'], function (app) {
    app.service('patientService', ['ajaxService', function (ajaxService) {

        this.getPatients = function (parameterObject, successFunction, errorFunction) {
            ajaxService.AjaxPost(parameterObject, "api/patient/getPatients", successFunction, errorFunction);
        };

        this.getPatientDetails = function (id, successFunction, errorFunction) {
            ajaxService.AjaxGetWithData(id, "api/patient/getPatientDetails", successFunction, errorFunction);
        };

        this.getIsPatientHipOnAnOctContract = function (patient_id, successFunction, errorFunction) {
            ajaxService.AjaxGetWithData({ patient_id: patient_id }, 'api/patient/GetIsPatientHipOnAnOctContract', successFunction, errorFunction);
        };
    }]);
});