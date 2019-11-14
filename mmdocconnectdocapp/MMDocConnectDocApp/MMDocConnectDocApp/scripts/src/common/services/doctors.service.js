(function () {
    'use strict';
    angular.module('mainModule').service('doctorsService', ['$q', 'ajaxService', 'commonServices',
        function ($q, ajaxService, commonServices) {
            var doctorsInPractice = [];
            var instance = {};

            // method binding
            instance.getDoctorsInPractice = getDoctorsInPractice;

            // public
            function getDoctorsInPractice() {
                var deferred = $q.defer();

                if (doctorsInPractice.length) {
                    deferred.resolve(commonServices.cloneData(doctorsInPractice));
                } else {
                    ajaxService.AjaxGet('api/main/GetDoctorsForDropdown', function (response) {
                        doctorsInPractice = response.doctors;
                        deferred.resolve(commonServices.cloneData(doctorsInPractice));
                    }, commonServices.errorFunction);
                }

                return deferred.promise;

            }

            return instance;
        }]);
})();