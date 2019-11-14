(function () {
    'use strict';
    angular.module('mainModule').directive('addTemporaryAftercareDirective', function () {

        return {
            templateUrl: 'scripts/src/app/planning/view/addTemporaryAftercarePopupTemplate.html',
            replace: true,
            restrict: 'E',
            controller: ['$scope', '$rootScope', 'alertService', 'ngDialog', 'planningService', 'commonServices', addTemporaryAftercareController]
        };

        function addTemporaryAftercareController($scope, $rootScope, alertService, ngDialog, planningService, commonServices) {

            $scope.doctor = new Object();

            // ----------------------------------------------------------- CREATE TEMPORARY AFTERCARE DOCTOR ---------------------------------------------------------

            $scope.closeAddNewACDoctorForm = function () {
                ngDialog.close();
            };

            $scope.createTemporaryAftercareDoctor = function () {
                if ($scope.doctor.email && $scope.doctor.email !== '' && !validateEmail($scope.doctor.email)) {
                    $scope.doctor.email = '';
                    $scope.emailNotValid = true;
                    angular.element('#inEmail')[0].focus();
                } else {
                    ngDialog.close();
                    planningService.createTemporaryAftercareDoctor($scope.doctor, createTemporaryAftercareDoctorComplete, errorFunction);
                };
            };

            function createTemporaryAftercareDoctorComplete(response) {
                alertService.RenderSuccessMessage('LABEL_TEMPORARY_DOCTOR_CREATED');
                $rootScope.$broadcast('TemporaryAftercareDoctorCreated', { id: response, display_name: $scope.doctor.name });
            };


            function validateEmail(email) {
                var re = /^(([^<>()[\]\\.,;:\s@"]+(\.[^<>()[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
                return re.test(email);
            };

            // ------------------------------------------------------------------ ERROR FUNCTIONS ------------------------------------------------------------------

            function errorFunction(response) {
                console.log(response);
                alertService.RenderErrorMessage('LABEL_SOMETHING_WENT_WRONG');
            };

            // ------------------------------------------------------------------------ UTIL -----------------------------------------------------------------------

            commonServices.focusElement('#inName');


            // ------------------------------------------------------------------- DIRECTIVE END -------------------------------------------------------------------
        };
    });
})();