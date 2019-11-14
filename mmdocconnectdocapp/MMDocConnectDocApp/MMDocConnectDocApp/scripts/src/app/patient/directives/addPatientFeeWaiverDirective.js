(function () {
    'use strict';

    angular.module('mainModule').directive('addPatientFeeWaiverDirective', function () {

        return {
            templateUrl: 'scripts/src/app/patient/view/addPatientFeeWaiverTemplate.html',
            scope: {

            },
            replace: true,
            restrict: 'E',
            controller: ['$scope', '$rootScope', 'patientService', 'alertService', '$routeParams', 'commonServices', 'validationService', addPatientFeeWaiverController]
        };

        function addPatientFeeWaiverController($scope, $rootScope, patientService, alertService, $routeParams, commonServices, validationService) {

            // ----------------------------------------------------------------- VARIABLES -----------------------------------------------------------------
            $scope.isIssueDateValid = true;

            // ----------------------------------------------------------------- SUBMIT -----------------------------------------------------------------

            $scope.submitPatientFeeWaiverForm = function () {
                $scope.showMessageContainer = false;
                $scope.isIssueDateValid = true;
                $scope.feeWaiverExistsForSelectedYear = false;

                if (validationService.isValidDate($scope.feeWaiver.issue_date)) {
                    patientService.checkPatientFeeWaiverForYear({ patient_id: $routeParams.patient_id, issue_date: $scope.feeWaiver.issue_date }, checkFunctionComplete, errorFunction);
                } else {
                    $scope.showMessageContainer = true;
                    $scope.isIssueDateValid = false;
                }
            };

            function checkFunctionComplete(response) {
                if (!response.exists) {
                    patientService.savePatientFeeWaiver({ patient_id: $routeParams.patient_id, issue_date: $scope.feeWaiver.issue_date }, savePatientFeeWaiverComplete, errorFunction);
                } else {
                    $scope.showMessageContainer = true;
                    $scope.feeWaiverExistsForSelectedYear = true;
                    $scope.feeWaiver.existsForYear = response.year;
                }
            }

            function savePatientFeeWaiverComplete(response) {
                $scope.closefeeWaiverForm();
                alertService.RenderSuccessMessage("LABEL_PATIENT_FEE_WAIVER_SAVED");
            };

            // ----------------------------------------------------------------- ERROR FUNCTIONS -----------------------------------------------------------------

            function errorFunction(response) {
                console.log(response);
                alertService.RenderErrorMessage('LABEL_SOMETHING_WENT_WRONG');
            };

            // ----------------------------------------------------------------- UTIL -----------------------------------------------------------------
            $scope.closefeeWaiverForm = function () {
                $scope.isIssueDateValid = true;
                $rootScope.$broadcast('CloseForm', { form: 'CloseCase' });
            };

            $scope.SetClass = function () {
                $('.gray-content-holder').css("overflow", "visible");
            };

            commonServices.focusElement('#dpIssue_date');

            // ------------------------------------------------------------- DIRECTIVE END -------------------------------------------------------------
        };
    });
})();