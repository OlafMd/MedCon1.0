define(['angularAMD', 'ajaxService'], function (app) {
    app.service('medicationService', ['ajaxService', function (ajaxService) {
        this.saveMedication = function (medication, successFunction, errorFunction) {
            ajaxService.AjaxPost(medication, "api/medication/SaveMedication", successFunction, errorFunction);
        };

        this.GetMedications = function (obj, successFunction, errorFunction) {
            ajaxService.AjaxPost(obj, "api/medication/GetMedications", successFunction, errorFunction);
        };
       
        this.getMedicationforMedicationID = function (id, successFunction, errorFunction) {
            ajaxService.AjaxPost(id, "api/medication/getMedicationforMedicationID", successFunction, errorFunction);
        };
    }]);
});