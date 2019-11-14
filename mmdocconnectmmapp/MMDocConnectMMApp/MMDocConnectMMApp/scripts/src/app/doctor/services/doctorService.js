define(['angularAMD', 'ajaxService'], function (app) {
    app.service('doctorService', ['ajaxService', function (ajaxService) {
        this.authenicateUser = function (route, successFunction, errorFunction) {
            var authenication = new Object();
            authenication.route = route;
            ajaxService.AjaxGetWithData(authenication, "api/main/AuthenicateUser", successFunction, errorFunction);
        };

        this.validateContractOverlaps = function (parameter, successFunction, errorFunction) {
            ajaxService.AjaxPost(parameter, "api/doctor/ValidateContractOverlaps", successFunction, errorFunction);
        };

        this.getDoctorsConsentDetails = function (parameter, successFunction, errorFunction) {
            ajaxService.AjaxGetWithData(parameter, "api/doctor/GetDoctorsConsentDetails", successFunction, errorFunction);
        };

        this.createPractice = function (practice, successFunction, errorFunction) {
            ajaxService.AjaxPost(practice, "api/doctor/CreatePractice", successFunction, errorFunction);
        };
        this.checkBsnr = function (parameter, successFunction, errorFunction) {
            ajaxService.AjaxPost(parameter, "api/doctor/CheckBsnr", successFunction, errorFunction);
        };
        this.createDoctor = function (doctor, successFunction, errorFunction) {
            ajaxService.AjaxPost(doctor, "api/doctor/CreateDoctor", successFunction, errorFunction);
        };

        this.checkLoginMail = function (practice, successFunction, errorFunction) {
            ajaxService.AjaxPost(practice, "api/doctor/CheckLoginEmail", successFunction, errorFunction);
        };
        this.GetAllPractices = function (successFunction, errorFunction) {
            ajaxService.AjaxGet("api/doctor/GetAllPractices", successFunction, errorFunction);
        };
        this.checkLanr = function (lanr, successFunction, errorFunction) {
            ajaxService.AjaxPost(lanr, "api/doctor/CheckLanr", successFunction, errorFunction);
        };
        this.GetBankAccountInfoforPracticeID = function (practiceForSend, successFunction, errorFunction) {
            ajaxService.AjaxPost(practiceForSend, "api/doctor/GetBankAccountInfoforPracticeID", successFunction, errorFunction);
        };
        this.GetDoctorPracticesList = function (objSort, successFunction, errorFunction) {
            ajaxService.AjaxPost(objSort, "api/doctor/GetDoctorPracticesList", successFunction, errorFunction);
        };      
        this.getDoctorDetails = function (id, successFunction, errorFunction) {
            ajaxService.AjaxGetWithData(id, "api/doctor/GetDoctorDetails", successFunction, errorFunction);
        };
        this.checkLanrForMerge = function (lanr, successFunction, errorFunction) {
            ajaxService.AjaxGetWithData(lanr, "api/doctor/CheckLanrForMerge", successFunction, errorFunction);
        };
        this.getPracticeDetails = function (id, successFunction, errorFunction) {
            ajaxService.AjaxGetWithData(id, "api/doctor/GetPracticeDetails", successFunction, errorFunction);
        };
        this.getDoctorsForPracticeID = function (practice, successFunction, errorFunction) {
            ajaxService.AjaxPost(practice, "api/doctor/GetDoctorsforPracticeID", successFunction, errorFunction);
        };

        this.mergeDoctor = function (doctor_id, successFunction, errorFunction) {
            ajaxService.AjaxPost(doctor_id, "api/doctor/MergeDoctor", successFunction, errorFunction);
        };

        this.getContractsForDropDown = function (successFunction, errorFunction) {
            ajaxService.AjaxGet("api/doctor/GetContractsForDropDown", successFunction, errorFunction);
        };
        this.saveDoctorsConsent = function (param, successFunction, errorFunction) {
            ajaxService.AjaxPost(param, "api/doctor/SaveDoctorsConsent", successFunction, errorFunction);
        };
        this.getDoctorContract = function (objDoc, successFunction, errorFunction) {
            ajaxService.AjaxPost(objDoc, "api/doctor/GetContractsforDoctorID", successFunction, errorFunction);
        };
        this.IBanValidation = function (objiban, successFunction, errorFunction) {
            ajaxService.AjaxPost(objiban, "api/doctor/IBanValidation", successFunction, errorFunction);
        };
        this.BicBankValidation = function (objbic, successFunction, errorFunction) {
            ajaxService.AjaxPost(objbic, "api/doctor/BicBankValidation", successFunction, errorFunction);
        };

    }]);
});