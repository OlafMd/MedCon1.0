(function () {
    'use strict';
    angular.module('mainModule').service('octService', ['$q', 'ajaxService',
        function ($q, ajaxService) {

            this.getAllOCT = function (parameter, errorFunction) {
                var deferred = $q.defer();

                ajaxService.AjaxPost(parameter, "api/oct/GetOcts", function (response) {
                    for (var i = 0; i < response.length; i++) {
                        var oct = response[i];
                        var date = new Date(oct.oct_date);
                        if (date.getFullYear() === 1) {
                            oct.oct_date = null;
                        }
                    }
                    deferred.resolve(response);
                }, errorFunction);

                return deferred.promise;
            };

            this.getOctCount = function (parameter, errorFunction) {
                var deferred = $q.defer();

                ajaxService.AjaxPost(parameter, 'api/oct/GetOctCount', function (response) {
                    deferred.resolve(response);
                }, errorFunction);

                return deferred.promise;
            }

            this.validateConsents = function (parameter, successFunctionSettlement, errorFunctionSettlement) {
                ajaxService.AjaxPost(parameter, "api/oct/ValidateConsents", successFunctionSettlement, errorFunctionSettlement);
            };

            this.SubmitOct = function (parameter, successFunction, errorFunction) {
                ajaxService.AjaxPost(parameter, 'api/oct/SubmitOct', successFunction, errorFunction);
            };

            this.getDoctorsInPractice = function (successFunction, errorFunction) {
                ajaxService.AjaxGet('api/oct/GetDoctorsInPractice', successFunction, errorFunction);
            };

            this.initiateMultiEditSubmit = function (parameter, errorFunction) {
                var deferred = $q.defer();

                ajaxService.AjaxPost(parameter, 'api/oct/InitiateMultiSubmit', function (response) {
                    deferred.resolve(response);
                }, errorFunction);

                return deferred.promise;
            };

            this.validateOctDate = function (parameter, successFunction, errorFunction) {
                ajaxService.AjaxPost(parameter, 'api/oct/ValidateOctDate', successFunction, errorFunction);
            };

            this.multiEditOct = function (parameter, successFunction, errorFunction) {
                ajaxService.AjaxPost(parameter, 'api/oct/MultiEditOct', successFunction, errorFunction);
            };

            this.validateConsentsMulti = function (parameter, successFunction, errorFunction) {
                ajaxService.AjaxPost(parameter, 'api/oct/ValidateConsentsMulti', successFunction, errorFunction);
            };

            this.rejectOct = function (parameter, successFunction, errorFunction) {
                ajaxService.AjaxPost(parameter, 'api/oct/RejectOct', successFunction, errorFunction);
            };

            this.errorCorrectionEdit = function (parameter, successFunction, errorFunction) {
                ajaxService.AjaxPost(parameter, 'api/oct/ErrorCorrectionEdit', successFunction, errorFunction);
            };

            this.getFS6CommentForDoctor = function (parameter, successFunction, errorFunction) {
                ajaxService.AjaxGetWithData(parameter, 'api/oct/GetFS6CommentForDoctor', successFunction, errorFunction);
            };

            // ------------------------------------------------------------------- VALIDATION --------------------------------------------------------------------

            this.checkIfAlreadyExistOCT = function (parameter, successFunction, errorFunction) {
                ajaxService.AjaxPost(parameter, "api/oct/CheckIfAlreadyExistOCT", successFunction, errorFunction);
            };
        }
    ]);
})();
