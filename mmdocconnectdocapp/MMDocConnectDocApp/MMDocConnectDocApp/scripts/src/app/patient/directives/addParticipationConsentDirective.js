(function () {
    'use strict';

    angular.module('mainModule').directive('addParticipationConsentDirective', function () {

        return {
            templateUrl: 'scripts/src/app/patient/view/addParticipationConsentTemplate.html',
            scope: {
                mode: "=",
                id: '=',
                participationid: '=',
                participationdate: '=',
                treatmentDate: '=',
                contractList: '=',
                contractid: '=',
                isPopup: '='
            },
            replace: true,
            restrict: 'E',
            controller: ['$scope', '$rootScope', 'patientService', 'alertService', 'ngDialog', '$filter', 'validationService', 'commonServices', addParticipationConsentController]
        };

        function addParticipationConsentController($scope, $rootScope, patientService, alertService, ngDialog, $filter, validationService, commonServices) {

            // ----------------------------------------------------------------- VARIABLES -----------------------------------------------------------------

            $scope.participation_consent = new Object();
            $scope.participation_consent.issue_date = "";
            $scope.participation_consent.contract = undefined;
            $scope.isIssueDateValid = true;
            $scope.isIssueDateHIgherOrEqualToContractStartDate = true;
            $scope.showMessageContainer = false;
            $scope.ValidThrough = undefined;

            // ----------------------------------------------------------------- DATA RETRIEVAL -----------------------------------------------------------------

            if ($scope.mode === "edit") {
                $scope.participation_consent.issue_date = $filter('date')($scope.participationdate, 'dd.MM.yyyy');
                for (var i = 0; i < $scope.contractList.length; i++) {
                    if ($scope.contractList[i].id === $scope.contractid) {
                        $scope.participation_consent.contract = $scope.contractList[i];
                        break;
                    };
                };
            };

            // ----------------------------------------------------------------- SUBMIT -----------------------------------------------------------------

            $scope.submitPatientParticipationForm = function () {
                if ($scope.validateForm()) {
                    var participation = new Object();
                    participation.patient_id = $scope.id;
                    participation.contract_id = $scope.participation_consent.contract.id;
                    participation.issue_date = $scope.participation_consent.issue_date;
                    participation.participation_consent_valid_days = $scope.participation_consent.contract.participation_consent_valid_days;
                    participation.contract_ValidTo = $scope.participation_consent.contract.ValidTo;
                    participation.participation_id = $scope.participationid;
                    patientService.savePatientParticipationConsent(participation, $scope.submitPatientParticipationFormSuccess, $scope.submitPatientParticipationFormError);
                }
            };

            $scope.submitPatientParticipationFormSuccess = function (response) {
                ngDialog.close();
                $scope.closeParticipationForm();
                alertService.RenderSuccessMessage("LABEL_SAVED_NEW_PARTICIPATION_CONSENT");
            };

            // ----------------------------------------------------------------- ERROR FUNCTIONS -----------------------------------------------------------------

            $scope.submitPatientParticipationFormError = function (response) {
                console.log(response);
                alertService.RenderErrorMessage('LABEL_SOMETHING_WENT_WRONG');
            };

            // ----------------------------------------------------------------- UTIL -----------------------------------------------------------------

            $scope.showErrorMessageContainer = function () { }

            $scope.validateForm = function () {
                if ($scope.participation_consent.issue_date === undefined || $scope.participation_consent.issue_date === "")
                    $scope.isIssueDateValid = true;
                else {
                    $scope.isIssueDateValid = _isDateValid($scope.participationForm.dpIssue_date.$viewValue);

                    if ($scope.isIssueDateValid) {
                        var dateFrom = new Date(parseInt($scope.participationForm.dpIssue_date.$viewValue.substring(6)), parseInt($scope.participationForm.dpIssue_date.$viewValue.substring(3, 5)) - 1, parseInt($scope.participationForm.dpIssue_date.$viewValue.substring(0, 2)));
                        var contractFrom = new Date($scope.participation_consent.contract.ValidFrom);
                        var contractTo = new Date($scope.participation_consent.contract.ValidTo);
                        var isContractValidIndefinite = contractTo.getFullYear() === 1;
                        var consentDateValidComparedToValidThroughDate = isContractValidIndefinite ? true : dateFrom.withoutTime() < contractTo;
                        $scope.isIssueDateHIgherOrEqualToContractStartDate = dateFrom.withoutTime() >= contractFrom.withoutTime() && consentDateValidComparedToValidThroughDate;
                    } else {
                        $scope.isIssueDateHIgherOrEqualToContractStartDate = true;
                    };
                };

                if ($scope.isIssueDateValid && $scope.isIssueDateHIgherOrEqualToContractStartDate) {
                    $scope.showMessageContainer = false;
                    return true;
                } else {
                    $scope.contractValidFromStr = $filter('date')(new Date($scope.participation_consent.contract.ValidFrom), 'dd.MM.yyyy');
                    $scope.contractValidToStr = new Date($scope.participation_consent.contract.ValidTo).getFullYear() !== 1 ? $filter('date')(new Date($scope.participation_consent.contract.ValidTo), 'dd.MM.yyyy') : '∞';
                    $scope.showMessageContainer = true;
                    return false;
                };
            };

            $scope.selectedContract = function () {
                if ($scope.participation_consent.contract !== undefined) {
                    $scope.ValidFrom = $filter('date')(new Date($scope.participation_consent.contract.ValidFrom), 'MM.dd.yyyy');
                    var validThroughDate = new Date($scope.participation_consent.contract.ValidTo);
                    if (validThroughDate.getFullYear() !== 1) {
                        $scope.ValidThrough = $filter('date')(new Date($scope.participation_consent.contract.ValidTo), 'MM.dd.yyyy');
                    };

                    if ($scope.participation_consent.issue_date === undefined || $scope.participation_consent.issue_date === null || $scope.participation_consent.issue_date === '')
                        $scope.participation_consent.issue_date = $filter('date')(new Date(), 'dd.MM.yyyy');
                };
            };

            $scope.closeParticipationForm = function () {
                $rootScope.$broadcast('CloseForm', { form: 'participationConsent' });
            };

            function _isDateValid(inputDate) {
                if (inputDate.length == 10) {
                    var characterInput = inputDate.charAt(2);
                    var characterInput2 = inputDate.charAt(4);

                    var day = inputDate.substring(0, 2);
                    var month = inputDate.substring(3, 5);
                    var yearInp = inputDate.substring(6, 10);

                    var str = (day + '.' + month + '.' + yearInp);
                    return validationService.isValidDate(str);
                }
                else {
                    return false;
                }
            };

            $scope.SetClass = function () {
                $('.gray-content-holder').css("overflow", "visible");
            };

            $scope.contractNotSelected = function () {
                return $scope.participation_consent.contract === undefined || $scope.participation_consent.contract === null;
            };

            commonServices.focusElement('#dpIssue_date');

            // ------------------------------------------------------------- DIRECTIVE END -------------------------------------------------------------
        };
    });
})();