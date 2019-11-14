(function () {
    'use strict';
    angular.module('mainModule').service('casesService', ['$q', 'ajaxService', 'commonServices', function ($q, ajaxService, commonServices) {
        var cases = [];
        var latestCaseFetchedForPatientId = null;
        var latestCaseForPatient = null;
        var instance = {};

        // method binding
        instance.getLatestPatientCase = getLatestPatientCase;


        // public
        function getLatestPatientCase(patientId) {
            var deferred = $q.defer();

            if (latestCaseFetchedForPatientId && latestCaseFetchedForPatientId == patientId) {
                deferred.resolve(commonServices.cloneData(latestCaseForPatient));
            } else {
                ajaxService.AjaxPost({
                    patient_id: patientId
                },
                'api/planning/GetPreviousCaseDataforPatientID',
                function (response) {
                    latestCaseFetchedForPatientId = patientId;
                    latestCaseForPatient = response;
                    deferred.resolve(commonServices.cloneData(latestCaseForPatient));
                }, commonServices.errorFunction);
            }

            return deferred.promise;
        }

        return instance;
    }]);
})();