"use strict";
define(['application-configuration'], function (app) {
    app.register.controller('contractDetailViewController', ['$scope', '$location', 'contractService', 'alertsServices', '$routeParams', '$rootScope', '$timeout', '$filter', 'validationService',
        function ($scope, $location, contractService, alertsServices, $routeParams, $rootScope, $timeout, $filter, validationService) {

            // ----------------------------------------------------- VARIABLES ------------------------------------------------------

            var ascending = true;
            var sort_by = "contract_name";
            $scope.contracts = [];
            $scope.ik_numbers = [];
            $scope.contract = new Object();
            $scope.isMaster = $rootScope.isMaster;

            // -------------------------------------------------------- INIT --------------------------------------------------------

            $scope.initializeController = function () {
                contractService.authenicateUser($location.path(), $scope.authenicateUserComplete, $scope.authenicateUserError);
            };

            $scope.authenicateUserComplete = function (response) {
                $scope.contract = contractService.getContract();
                $scope.contract.id = $routeParams.contract_id;
                
                if (contractService.isNotUndefined($scope.contract.id) && $scope.contract.id != 0) {
                    getContractDetails();
                } else {

                    setContractData({
                        contract_valid_from: $filter('date')(new Date(), 'dd.MM.yyyy'),
                        next_edifact_number: 1,
                        contract_type: $scope.contract_types[0].id,
                        message_type: $scope.message_types[0].id,
                        edifact_type: $scope.edifact_types[0].id,
                        merger_for_all_hips: false,
                        use_k_for_correction: true
                    });
                };
            };

           

            $scope.contract_types = [
               { 'display_name': 'LABEL_CONTRACT_TYPE_7', 'id': '7' },
               { 'display_name': 'LABEL_CONTRACT_TYPE_8', 'id': '8' },
            ];

            $scope.edifact_types = [
               { 'display_name': 'LABEL_EDIFACT_TYPE_3', 'id': '3' },
               { 'display_name': 'LABEL_EDIFACT_TYPE_4', 'id': '4' },
            ];

            $scope.message_types = [
               { 'display_name': 'LABEL_MESSAGE_TYPE_DIR73C', 'id': 'DIR73C' },
               { 'display_name': 'LABEL_MESSAGE_TYPE_DIR140', 'id': 'DIR140' },
            ];

            // ---------------------------------------------------- DATA RETRIEVAL ---------------------------------------------------

            function getContractDetails() {
                contractService.getContractDetails({ 'id': $routeParams.contract_id }, setContractData, errorFunction);
            };

            function setContractData(response) {
                contractService.setContract(response);

                $scope.contract = contractService.getContract();
                setIkNumbers(); 
                if ($scope.view_content === undefined)
                    $scope.view_content = 'hip';
                else
                    $rootScope.$broadcast('contractUpdated');
            };

            function setIkNumbers() {
                if (contractService.getContract().covered_insurance_companies){
                    $scope.ik_numbers = contractService.getContract().covered_insurance_companies.map(function (x) {
                        return {
                            'display_name': x.additional_info, 'id': x.additional_info
                        };
                    });

                    if ($scope.ik_numbers.length) {
                        if (!contractService.isNotUndefined($scope.contract.ik_number) || !isCurrentNumberExistInContract()) {
                            $scope.contract.ik_number = $scope.ik_numbers[0].id;
                        }
                    } else {
                        $scope.ik_numbers = [];
                        $scope.contract.ik_number = undefined;
                    }
                }
            }

            $scope.$on('update-ik-number-list', function (event, elementId) {
                setIkNumbers();
            });

            function isCurrentNumberExistInContract() {
                var exist = false;
                angular.forEach($scope.ik_numbers, function (value) {
                    if (value.id == $scope.contract.ik_number) {
                        exist = true;
                        return;
                    }
                });
                return exist;
            }
            // ---------------------------------------------------- SAVE CONTRACT ----------------------------------------------------

            $scope.saveContract = function () {
                var intRegExp = /\D/;
                var allValid = true;
                var dueDatesValid = true;
                var dueDatesValidation = new Object();

                if (!validationService.isValidDate($scope.contract.contract_valid_from)) {
                    $scope.validFromDateInvalid = true;
                    allValid = false;
                    angular.element('#contractValidFrom')[0].focus();
                } else {
                    $scope.validFromDateInvalid = false;
                };

                var valid_through_date_valid = contractService.isNotUndefined($scope.contract.contract_valid_through) && $scope.contract.contract_valid_through !== '∞' ? validationService.isValidDate($scope.contract.contract_valid_through) : true;
                if (!valid_through_date_valid) {
                    allValid = false;
                    $scope.validThroughDateInvalid = true;
                } else {
                    $scope.validThroughDateInvalid = false;
                };

                if (contractService.isNotUndefined($scope.contract.contract_valid_through) && $scope.contract.contract_valid_through !== '∞' && validationService.isValidDate($scope.contract.contract_valid_through)) {
                    if (compareDates($scope.contract.contract_valid_from, $scope.contract.contract_valid_through)) {
                        $scope.validThroughDateBeforeValidFromDate = true;
                        allValid = false;
                        angular.element('#contractValidThrough')[0].focus();
                    } else {
                        $scope.validThroughDateBeforeValidFromDate = false;
                    };
                };

                if (contractService.isNotUndefined($scope.contract.contract_due_dates) && contractService.isNotUndefined($scope.contract.contract_due_dates.participation_consent_duration)) {
                    if ($scope.contract.contract_due_dates.participation_consent_duration.active && intRegExp.test($scope.contract.contract_due_dates.participation_consent_duration.value)) {
                        dueDatesValidation.participationConsentInvalid = true;
                        dueDatesValid = false;
                    } else {
                        dueDatesValidation.participationConsentInvalid = undefined;
                    };
                };

                if (contractService.isNotUndefined($scope.contract.contract_due_dates) && contractService.isNotUndefined($scope.contract.contract_due_dates.participation_consent_duration)) {
                    if ($scope.contract.contract_due_dates.number_of_days_between_surgery_and_aftercare.active && intRegExp.test($scope.contract.contract_due_dates.number_of_days_between_surgery_and_aftercare.value)) {
                        dueDatesValidation.daysBetweenSurgeryAndAfterccareInvalid = true;
                        dueDatesValid = false;
                    } else {
                        dueDatesValidation.daysBetweenSurgeryAndAfterccareInvalid = undefined;
                    };
                };

                if (contractService.isNotUndefined($scope.contract.contract_due_dates) && contractService.isNotUndefined($scope.contract.contract_due_dates.participation_consent_duration)) {
                    if ($scope.contract.contract_due_dates.number_of_days_between_surgery_and_settlement_claim.active && intRegExp.test($scope.contract.contract_due_dates.number_of_days_between_surgery_and_settlement_claim.value)) {
                        dueDatesValidation.daysBetweenSurgeryAndSettlementInvalid = true;
                        dueDatesValid = false;
                    } else {
                        dueDatesValidation.daysBetweenSurgeryAndSettlementInvalid = undefined;
                    };
                };

                if (contractService.isNotUndefined($scope.contract.contract_due_dates) && contractService.isNotUndefined($scope.contract.contract_due_dates.participation_consent_duration)) {
                    if ($scope.contract.contract_due_dates.number_of_days_between_submission_to_hip_and_reply.active && intRegExp.test($scope.contract.contract_due_dates.number_of_days_between_submission_to_hip_and_reply.value)) {
                        dueDatesValidation.daysBetweenSubmissionAndReplyInvalid = true;
                        dueDatesValid = false;
                    } else {
                        dueDatesValidation.daysBetweenSubmissionAndReplyInvalid = undefined;
                    };
                };

                if (contractService.isNotUndefined($scope.contract.contract_due_dates) && contractService.isNotUndefined($scope.contract.contract_due_dates.participation_consent_duration)) {
                    if ($scope.contract.contract_due_dates.number_of_days_between_response_and_payment.active && intRegExp.test($scope.contract.contract_due_dates.number_of_days_between_response_and_payment.value)) {
                        dueDatesValidation.daysBetweenResponseAndPaymentInvalid = true;
                        dueDatesValid = false;
                    } else {
                        dueDatesValidation.daysBetweenResponseAndPaymentInvalid = undefined;
                    };
                };

                if (contractService.isNotUndefined($scope.contract.contract_due_dates) && contractService.isNotUndefined($scope.contract.contract_due_dates.participation_consent_duration)) {
                    if ($scope.contract.contract_due_dates.number_of_days_between_hip_response_and_rejection.active && intRegExp.test($scope.contract.contract_due_dates.number_of_days_between_hip_response_and_rejection.value)) {
                        dueDatesValidation.daysBetweenResponseAndRejectionInvalid = true;
                        dueDatesValid = false;
                    } else {
                        dueDatesValidation.daysBetweenResponseAndRejectionInvalid = undefined;
                    };
                };

                if (contractService.isNotUndefined($scope.contract.contract_due_dates) && contractService.isNotUndefined($scope.contract.contract_due_dates.number_of_max_preexaminations_value)) {
                    if ($scope.contract.contract_due_dates.number_of_max_preexaminations_value.active && intRegExp.test($scope.contract.contract_due_dates.number_of_max_preexaminations_value.value)) {
                        dueDatesValidation.preexaminationValueInvalid = true;
                        dueDatesValid = false;
                    } else {
                        dueDatesValidation.preexaminationValueInvalid = undefined;
                    };
                };

                if (contractService.isNotUndefined($scope.contract.contract_due_dates) && contractService.isNotUndefined($scope.contract.contract_due_dates.number_of_max_preexaminations_days)) {
                    if ($scope.contract.contract_due_dates.number_of_max_preexaminations_value.active && intRegExp.test($scope.contract.contract_due_dates.number_of_max_preexaminations_days.value)) {
                        dueDatesValidation.preexaminationDaysInvalid = true;
                        dueDatesValid = false;
                    } else {
                        dueDatesValidation.preexaminationDaysInvalid = undefined;
                    };
                };

                if (contractService.isNotUndefined($scope.contract.contract_due_dates) && contractService.isNotUndefined($scope.contract.contract_due_dates.oct_max_number_of_days_before_op)) {
                    if ($scope.contract.contract_due_dates.oct_max_number_of_days_before_op.active && intRegExp.test($scope.contract.contract_due_dates.oct_max_number_of_days_before_op.value)) {
                        dueDatesValidation.octMaxDaysBeforeOpInvalid = true;
                        dueDatesValid = false;
                    } else {
                        dueDatesValidation.octMaxDaysBeforeOpInvalid = undefined;
                    };
                };

                if (!dueDatesValid) {
                    $rootScope.$broadcast('DueDatesInvalid', { validation: dueDatesValidation });
                } else {
                    $rootScope.$broadcast('DueDatesValid', { validation: dueDatesValidation });
                };

                if (!allValid) {
                    $scope.divContainer = true;
                } else {
                    $scope.divContainer = false;
                };

                if (!dueDatesValid || !allValid)
                    return false;

                contractService.saveContract(saveContractComplete, errorFunction);
            };

            function saveContractComplete(response) {
                alertsServices.SuccessMessage($routeParams.contract_id != 0 ? 'LABEL_CHANGES_SAVED' : 'LABEL_CONTRACT_SAVED');
                if (!contractService.isNotUndefined($routeParams.contract_id) || $routeParams.contract_id == 0)
                    $location.url('/contract/contract_detail/' + response);
                else
                    getContractDetails();
            };

            // --------------------------------------------------- ERROR FUNCTIONS ---------------------------------------------------

            $scope.authenicateUserError = function (response) {
                $rootScope.activeMenuItem = null;
                $window.location.replace(response.logoutUrl);
            };

            function errorFunction(response) {
                console.log(response);
                alertsServices.ErrorMessage('LABEL_SOMETHING_WENT_WRONG');
            };

            // -------------------------------------------------------- UTIL --------------------------------------------------------

            $scope.redirectToMainPage = function () {
                $scope.contract = new Object();
                contractService.setContract(new Object());
                $location.url('/contract');
            };

            $scope.setClass = function () {
                $('.gray-content-holder').css('overflow', 'visible');
            };

            $timeout(function () { angular.element('#inContractName')[0].focus(); }, 460, false);


            $scope.isSelected = function (val) {
                return $scope.view_content === val;
            };

            function compareDates(date1, date2) {

                var parts = date1.split(".");
                var day = parseInt(parts[0], 10);
                var month = parseInt(parts[1], 10);
                var year = parseInt(parts[2], 10);

                var dateObject1 = new Date(year, month, day, 0, 0, 0, 0);

                parts = date2.split(".");
                day = parseInt(parts[0], 10);
                month = parseInt(parts[1], 10);
                year = parseInt(parts[2], 10);

                var dateObject2 = new Date(year, month, day, 0, 0, 0, 0);

                return dateObject1 > dateObject2;
            };

            $scope.$on('contractValidationError', function (event, data) {
                switch (data.validationFailed) {
                    case 'contractStartDateNotEntered':
                        $scope.validFromDateNotEntered = true;
                        $scope.divContainer = true;
                        angular.element('#contractValidFrom')[0].focus();

                        break;

                    case 'contractStartDateNotValid':
                        $scope.divContainer = true;
                        $scope.validFromDateInvalid = true;
                        angular.element('#contractValidFrom')[0].focus();

                        break;
                    case 'clearValidations':
                        $scope.validFromDateInvalid = false;
                        $scope.validFromDateNotEntered = false;
                        $scope.divContainer = false;
                        break;
                    default: break;
                };
            });

            // -------------------------------------------------------- END ---------------------------------------------------------
        }]);
});