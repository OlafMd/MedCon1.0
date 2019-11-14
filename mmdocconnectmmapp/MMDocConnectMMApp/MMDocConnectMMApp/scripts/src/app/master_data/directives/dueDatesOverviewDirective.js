define(['angularAMD'], function (angularAMD) {

    angularAMD.directive('dueDatesOverviewDirective', function () {

        return {

            templateUrl: 'scripts/src/app/master_data/view/contract_templates/dueDatesOverviewTemplate.html',
            scope: {
                mode: '='
            },
            replace: true,
            restrict: 'E',
            controller: dueDatesOverviewController
        };
        function dueDatesOverviewController($scope, $rootScope, $translate, contractService, validationService, ngDialog, $timeout, $routeParams, $location, alertsServices, $filter) {

            // --------------------------------------------------------- VARIABLES --------------------------------------------------------

            $scope.validation = new Object();

            // ----------------------------------------------------------- INIT -----------------------------------------------------------

            $scope.initializeController = function () {
                contractService.authenicateUser($location.path(), $scope.authenicateUserComplete, $scope.authenicateUserError);
            };

            $scope.authenicateUserComplete = function (response) {
                if (!contractService.isNotUndefined(contractService.getContract().contract_due_dates))
                    contractService.getContract().contract_due_dates = getNewDueDatesObject();

                $scope.due_dates = contractService.getContract().contract_due_dates;
            };

            // ------------------------------------------------------ ERROR FUNCTIONS -----------------------------------------------------

            $scope.authenicateUserError = function (response) {
                $rootScope.activeMenuItem = null;
                $window.location.replace(response.logoutUrl);
            };

            function errorFunction(response) {
                console.log(response);
                alertsServices.ErrorMessage('LABEL_SOMETHING_WENT_WRONG');
            };

            // ----------------------------------------------------------- UTIL -----------------------------------------------------------

            function getNewDueDatesObject() {
                return {
                    'participation_consent_duration': new Object(),
                    'number_of_days_between_surgery_and_aftercare': new Object(),
                    'number_of_days_between_surgery_and_settlement_claim': new Object(),
                    'number_of_days_between_submission_to_hip_and_reply': new Object(),
                    'number_of_days_between_response_and_payment': new Object(),
                    'number_of_days_between_hip_response_and_rejection': new Object(),
                    'number_of_max_preexaminations_value': new Object(),
                    'number_of_max_preexaminations_days': new Object(),
                    'oct_max_number_of_days_before_op': new Object(),
                    'op_renews_patient_consent': new Object(),
                    'use_settlement_year': new Object(),
                    'doctor_needs_certification': new Object(),
                };
            };

            $scope.$on('DueDatesInvalid', function (event, data) {
                $scope.divContainer = true;
                if (data.validation !== undefined) {
                    $scope.validation = data.validation;
                };
            });

            $scope.$on('DueDatesValid', function (event, data) {
                $scope.divContainer = false;
                if (data.validation !== undefined) {
                    $scope.validation = data.validation;
                };
            });

            $scope.updateField = function (field) {
                switch (field) {
                    case 'consent': $scope.due_dates.participation_consent_duration.value = $scope.due_dates.participation_consent_duration.active ? 12 : ''; break;
                    case 'surgeryAftercare': $scope.due_dates.number_of_days_between_surgery_and_aftercare.value = ''; break;
                    case 'surgerySettlement': $scope.due_dates.number_of_days_between_surgery_and_settlement_claim.value = ''; break;
                    case 'submissionReply': $scope.due_dates.number_of_days_between_submission_to_hip_and_reply.value = ''; break;
                    case 'responsePayment': $scope.due_dates.number_of_days_between_response_and_payment.value = ''; break;
                    case 'responseRejection': $scope.due_dates.number_of_days_between_hip_response_and_rejection.value = ''; break;
                    case 'octMaxDaysBeforeOp': $scope.oct_max_number_of_days_before_op.value = ''; break;
                    case 'preexamination': {
                        $scope.due_dates.number_of_max_preexaminations_value.value = '';
                        if ($scope.due_dates.number_of_max_preexaminations_days === undefined)
                            $scope.due_dates.number_of_max_preexaminations_days = { value: 365 };
                        $scope.due_dates.number_of_max_preexaminations_days.value = $scope.due_dates.number_of_max_preexaminations_value.active ? 365 : '';
                        break;
                    }
                };
            };

            // ----------------------------------------------------------- WATCHERS -------------------------------------------------------

            $scope.$on('contractUpdated', function () {
                $scope.due_dates = contractService.getContract().contract_due_dates;
            });

            // ----------------------------------------------------------- END ------------------------------------------------------------
        };
    });
});