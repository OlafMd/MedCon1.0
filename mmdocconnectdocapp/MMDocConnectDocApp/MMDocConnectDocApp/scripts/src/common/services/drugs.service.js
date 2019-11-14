(function () {
    'use strict';
    angular.module('mainModule').service('drugsService', ['$q', 'ajaxService', 'commonServices', function ($q, ajaxService, commonServices) {
        var cases = [];
        var drugs = [];
        var instance = {};

        // method binding
        instance.getAll = getAll;


        // public
        function getAll() {
            var deferred = $q.defer();

            if (drugs.length) {
                deferred.resolve(commonServices.cloneData(drugs));
            } else {
                ajaxService.AjaxGet('api/planning/GetAllDrugs', function (response) {
                    drugs = response.items;
                    deferred.resolve(commonServices.cloneData(drugs));
                }, commonServices.errorFunction);
            }

            return deferred.promise;
        }

        return instance;
    }]);
})();