define(['angularAMD'], function (angularAMD) {

    angularAMD.directive('addMedicationDirective', function () {

        return {

            templateUrl:
                'scripts/src/app/master_data/view/addMedicationTemplate.html',

            scope: {
                fromEdit: '=fromEdit'
            },
            replace: true,
            restrict: 'E',
            controller: addMedicationController
        };
        function addMedicationController($scope, $rootScope, $translate, medicationService, validationService, ngDialog, $timeout, $routeParams, commonServices, $location, alertsServices, $interval) {
            $scope.medication = {};
            $scope.closeMedicationForm = function () {

                $scope.$parent.fromEdit = null
                $scope.medication = {};
                $scope.proprietaryDrugYes = false;
                $scope.proprietaryDrugNo = false;
                $rootScope.$broadcast('CloseForm', ["CloseMedication"]);
            }
            $scope.sendMedicationForm = function () {
                medicationService.saveMedication($scope.medication, successFunctionMedicineSave, errorFunctionMedicineSave);
            };

            successFunctionMedicineSave = function (response) {
                alertsServices.SuccessMessage('LABEL_MEDICATION_SAVED');
                $rootScope.$broadcast('CloseForm', ["CloseMedication"]);
                $scope.medication = {};
                $scope.$parent.fromEdit = null;
            }

            errorFunctionMedicineSave = function (response) {
                alertsServices.ErrorMessage('LABEL_SOMETHING_WENT_WRONG');
                $rootScope.$broadcast('CloseForm', ["CloseMedication"]);
                $scope.medication = {};
                $scope.$parent.fromEdit = null;
            }

            if ($scope.$parent.fromEdit === undefined) { $scope.$parent.fromEdit = null }
            if ($scope.$parent.fromEdit !== null) {
                $scope.proprietaryDrugYes = false;
                $scope.proprietaryDrugNo = false;
                if ($scope.$parent.fromEdit.ProprietaryDrug === true)
                    $scope.proprietaryDrug = true;
                else
                    $scope.proprietaryDrug = false;
                $scope.medication = $scope.$parent.fromEdit;
            };

            var interval = $interval(function () {
                var element = angular.element('#inMedication')[0];
                if (element) {
                    $interval.cancel(interval);
                    element.focus();
                }
            }, 20, 100, false);

            //END OF CONTROLLER
        };
    });
});