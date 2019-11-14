define(['angularAMD', 'ajaxService'], function (app) {
    app.service('pharmacyService', ['ajaxService', function (ajaxService) {
        var self = this;

        self.getPharmacies = function (sort_parameter, successFunction, errorFunction) {
            ajaxService.AjaxPost(sort_parameter, "api/pharmacy/GetPharmacies", successFunction, errorFunction);
        }

        self.deletePharmacy = function (pharmacyID, successFunction, errorFunction) {
            ajaxService.AjaxPost({ pharmacyID: pharmacyID }, "api/pharmacy/DeletePharmacy", successFunction, errorFunction);
        }

        self.savePharmacy = function (pharmacy, successFunction, errorFunction) {
            ajaxService.AjaxPost(pharmacy, "api/pharmacy/SavePharmacy", successFunction, errorFunction);
        }
    }]);
});
