(function () {
    'use strict';
    angular.module('mainModule').service('diagnosesService', ['$q', 'ajaxService', 'commonServices', function ($q, ajaxService, commonServices) {
        var cases = [];
        var patientDiagnoses = [];
        var previousPatientId = null;
        var instance = {};

        // method binding
        instance.getPatientDiagnoses = getPatientDiagnoses;


        // public
        function getPatientDiagnoses(patientId) {
            var deferred = $q.defer();

            if (patientDiagnoses.length && previousPatientId == patientId) {
                deferred.resolve(commonServices.cloneData(patientDiagnoses));
            } else {
                ajaxService.AjaxGetWithData({
                    patient_id: patientId
                },
                'api/planning/GetAllDiagnoses',
                function (response) {
                    previousPatientId = patientId;
                    patientDiagnoses = response.items;
                    deferred.resolve(commonServices.cloneData(patientDiagnoses));
                }, commonServices.errorFunction);
            }

            return deferred.promise;
        }

        return instance;
    }]);
})();