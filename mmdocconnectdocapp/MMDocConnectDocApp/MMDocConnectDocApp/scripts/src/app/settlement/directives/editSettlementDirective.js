(function () {
    'use strict';

    angular.module('mainModule').directive('editSettlementDirective', function () {

        return {
            templateUrl: 'scripts/src/app/settlement/view/editSettlementAC.html',
            scope: {
                aftercare: '=',
                patient: '='
            },
            replace: true,
            restrict: 'E',
            controller: ['$scope', '$rootScope', 'alertService', '$filter', 'settlementServices', 'validationService', 'doctorsService', '$timeout',
                editSettlementController]
        };

        function editSettlementController($scope, $rootScope, alertService, $filter, settlementServices, validationService, doctorsService, $timeout) {
            $scope.today = $filter('date')(new Date(), 'MM.dd.yyyy');
            var treatment_date = $scope.aftercare.if_aftercare_treatment_date || $scope.aftercare.op_date_string;
            var yyyy = treatment_date.substr(6, 4);
            var mm = treatment_date.substr(3, 2);
            var dd = treatment_date.substr(0, 2);

            $scope.aftercare_treatment_date = $filter('date')(new Date(yyyy, mm - 1, dd), 'MM.dd.yyyy');
            if (!$scope.aftercare.surgery_date_string) {
                $scope.aftercare.surgery_date_string = $scope.aftercare.date_string;
            }

            $timeout(function () {
                var patient_name = $scope.aftercare.first_name ? $scope.aftercare.first_name + ' ' + $scope.aftercare.last_name + ' (' + $scope.aftercare.birthday + ')' : $scope.patient.name + ' (' + $scope.patient.birthday + ')';
                angular.element('#inPatientName').val(patient_name);
                angular.element('#inACDoctorName_value').val($scope.aftercare.doctor);
            });

            getFS6Comment();

            function getFS6Comment() {
                settlementServices.getFS6CommentForDoctor({ id: $scope.aftercare.case_id, secondary_id: $scope.aftercare.id }, getFS6CommentForDoctorComplete, getFS6CommentForDoctorError);
            }

            function getFS6CommentForDoctorComplete(response) {
                $scope.comment = response;
                $scope.show_error = true;
            };

            function getFS6CommentForDoctorError(response) {
                console.log(response);
                alertService.RenderErrorMessage('LABEL_SOMETHING_WENT_WRONG');
            };

            $scope.selectAftercare = function (selectedObject) {
                $scope.aftercare.aftercare_doctor_practice_id = selectedObject !== undefined && selectedObject.originalObject !== undefined ? selectedObject.originalObject.id : undefined;
                $scope.showAftercareNameStarReq = selectedObject.originalObject === undefined;
            };

            var case_param = new Object();
            case_param.case_id = $scope.id;

            $scope.remoteUrlRequestFn = function (str) {
                return { search_criteria: str };
            };

            $scope.closeCaseForm = function (reload) {
                $rootScope.$broadcast('CloseForm', { form: 'CloseCase', reload: reload });
            };

            $scope.createCase = function () {
                var is_aftercare_performed_date_valid = validationService.isValidDate($scope.aftercare.surgery_date_string);

                if (!is_aftercare_performed_date_valid) {
                    $scope.aftercare.surgery_date_string = is_aftercare_performed_date_valid ? $scope.aftercare.surgery_date_string : '';
                    return;
                };

                var param = new Object();
                param.case_id = $scope.aftercare.case_id;
                param.secondary_id = $scope.aftercare.aftercare_doctor_practice_id;
                param.tertiary_id = $scope.aftercare.patient_id;
                param.date_string = $scope.aftercare.surgery_date_string;
                param.date = treatment_date;
                param.diagnose_id = $scope.aftercare.diagnose_id;
                param.drug_id = $scope.aftercare.drug_id;
                param.flag = false;

                settlementServices.validateConsents(param, validateConsentsComplete, validateConsentsError);
            };

            function validateConsentsComplete(response) {
                if (response.length === 0) {
                    settlementServices.editErrorCorrectionAftercare($scope.aftercare, createCaseComplete, createCaseError);
                } else {
                    alertService.RenderNotificationMessage(response, $scope);
                };
            };

            function validateConsentsError(response) {
                alertService.RenderErrorMessage('LABEL_SOMETHING_WENT_WRONG');
            };


            function createCaseComplete() {
                alertService.RenderSuccessMessage('LABEL_CHANGES_SAVED');
                $rootScope.$broadcast('CloseForm', { form: 'CloseCase', reload: true });
            };

            function createCaseError() {
                alertService.RenderErrorMessage('LABEL_SOMETHING_WENT_WRONG');
                $rootScope.$broadcast('CloseForm', { form: 'CloseCase' });
            };

            $scope.fieldsNotValidated = function () {
                return $scope.aftercare.surgery_date_string === '' ||
                    $scope.aftercare.surgery_date_string === undefined ||
                    $scope.aftercare.surgery_date_string === null ||
                    $scope.aftercare.aftercare_doctor_practice_id === undefined;
            };


            $scope.setClass = function () {
                $('.gray-content-holder').css("overflow", "visible");
            };

            doctorsService.getDoctorsInPractice().then(getACDoctorsForPracticeIDComplete);

            function getACDoctorsForPracticeIDComplete(response) {
                $scope.ac_doctors = response;
                $scope.ac_doctors.unshift({ id: '00000000-0000-0000-0000-000000000000', display_name: ' ' });
            };
        };
    });
})();