(function () {
    'use strict';
    angular.module('mainModule').service('practiceSettingsService', ['$q', 'ajaxService', 'commonServices', function ($q, ajaxService, commonServices) {
        var practiceSettings = null;
        var instance = {};
        var pharmacies = null;

        // method binding
        instance.getPracticeSettings = getPracticeSettings;
        instance.savePracticeSettings = savePracticeSettings;
        instance.getPharmacies = getPharmacies;

        // public
        function getPracticeSettings(shouldLoad) {
            var deferred = $q.defer();

            if (!shouldLoad && practiceSettings) {
                deferred.resolve(commonServices.cloneData(practiceSettings));
            } else {
                ajaxService.AjaxGet('api/settings/GetPracticeDetails', function (response) {
                    practiceSettings = response.practice;
                    deferred.resolve(commonServices.cloneData(practiceSettings));
                }, commonServices.errorFunction);
            }

            return deferred.promise;
        }

        function savePracticeSettings(settings) {
            var deferred = $q.defer();

            ajaxService.AjaxPost(settings, 'api/settings/CreatePractice', function (response) {
                practiceSettings = settings;
                deferred.resolve();
            }, commonServices.errorFunction);

            return deferred.promise;
        }

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