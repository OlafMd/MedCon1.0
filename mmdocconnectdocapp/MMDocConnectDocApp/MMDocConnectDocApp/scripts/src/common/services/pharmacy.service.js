(function () {
    'use strict';
    angular.module('mainModule').service('pharmacyService', ['$q', 'ajaxService', 'commonServices', function ($q, ajaxService, commonServices) {
        var pharmacies = null;
        var instance = {};

        // method binding
        instance.getPharmacies = getPharmacies;

        // public
        function getPharmacies() {
            var deferred = $q.defer();

            if (pharmacies) {
                deferred.resolve(commonServices.cloneData(pharmacies));
            } else {
                ajaxService.AjaxGet('api/pharmacy/GetPharmacies', function (response) {
                    pharmacies = response;
                    deferred.resolve(commonServices.cloneData(pharmacies));
                }, commonServices.errorFunction);
            }

            return deferred.promise;
        }

        return instance;
    }]);
})();