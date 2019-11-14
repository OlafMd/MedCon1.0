(function () {
    'use strict';

    angular.module('mainModule').directive('editOctDirective', function () {

        return {
            templateUrl: 'scripts/src/app/settlement/view/editOct.html',
            scope: {
                oct: '='
            },
            replace: true,
            restrict: 'E',
            controller: ['$scope', '$rootScope', 'alertService', '$filter', 'octService', 'validationService', 'doctorsService', editOctController]
        };

        function editOctController($scope, $rootScope, alertService, $filter, octService, validationService, doctorsService) {
            // -- variables
            $scope.today = $filter('date')(new Date(), 'MM.dd.yyyy');

            $scope.oct.is_left_eye = $scope.oct.localization == 'L';
            $scope.patient_display_name = [$scope.oct.first_name, $scope.oct.last_name, '(' + $scope.oct.birthday + ')'].join(' ');

            // -- doctor data retrieval
            doctorsService.getDoctorsInPractice().then(function (response) {
                $scope.doctors = response;
            });

            // -- FS6 comment retrieval
            octService.getFS6CommentForDoctor({ case_id: $scope.oct.case_id, oct_id: $scope.oct.id }, getFS6CommentForDoctorComplete, errorFunction);

            function getFS6CommentForDoctorComplete(response) {
                $scope.comment = response;
            };

            // -- oct saving
            $scope.saveOct = function () {
                $scope.error = undefined;
                $scope.validation = undefined;

                if (!validationService.isValidDate($scope.oct.surgery_date_string)) {
                    $scope.error = 'LABEL_DATE_NOT_VALID';
                    return false;
                };

                // todo: save
                octService.errorCorrectionEdit($scope.oct, function (response) {
                    if (!response) {
                        alertService.RenderSuccessMessage('LABEL_CHANGES_SAVED');
                        $rootScope.$broadcast('CloseForm', { form: 'CloseCase' });
                    } else {
                        $scope.validation = response;
                    }
                }, errorFunction);
            };

            // -- util
            $scope.isLocalizationSelected = function () {
                if ($scope.oct !== undefined)
                    return $scope.oct.is_left_eye !== undefined;
                else
                    return false;
            };

            $scope.setClass = function () {
                $('.gray-content-holder').css("overflow", "visible");
            };

            $scope.closeCaseForm = function (reload) {
                $rootScope.$broadcast('CloseForm', { form: 'CloseCase', reload: reload });
            };

            // -- error functions
            function errorFunction(response) {
                console.log(response);
                alertService.RenderErrorMessage('LABEL_SOMETHING_WENT_WRONG');
            };
        };
    });
})();