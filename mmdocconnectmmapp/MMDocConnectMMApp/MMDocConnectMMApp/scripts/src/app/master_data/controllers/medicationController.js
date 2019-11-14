
"use strict";
define(['application-configuration'], function (app) {
    app.register.controller('medicationController', ['$scope', '$location', '$rootScope', 'medicationService', function ($scope, $location, $rootScope, medicationService) {
        $scope.hideMedicationButton = false;
        var isASC = true;
        $scope.frKey = "Medication";
        var obj = {};
        getMedications();
        $scope.OpenFormAddMedication = function () {
            $scope.hideMedicationButton = true;
            $scope.showMedicationDirective = !$scope.showMedicationDirective;
            return false;
        }

        $scope.OpenFormEditMedication = function (item) {
            if ($scope.showMedicationDirective) {
                $scope.hideMedicationButton = false;
                $scope.showMedicationDirective = false;
            }
            else {
                $scope.editMedicationID = item.MedicationID;
                $scope.fromEdit = item;
                $scope.showEditMedicationDirective = true;
            }   
            return false;
        }

        $scope.$on('CloseForm', function (event, data) {
            $scope.hideMedicationButton = false;
            $scope.showMedicationDirective = false;
            $scope.fromEdit = null;
            $scope.showEditMedicationDirective = false;
            $scope.editMedicationID = undefined;

            getMedications();

        });
        function getMedications() {
            obj.isAsc = isASC;
            obj.frKey = $scope.frKey;
            medicationService.GetMedications(obj, successFunction, errorFunction);
        }

        function successFunction(response) {
            $scope.Medications = {};
            $scope.Medications = response.medications;

        }
        function errorFunction(response) {
        }

        $scope.SortFunction = function (item) {
            if ($scope.frKey == item) {
                isASC = !isASC;
            };

            $scope.frKey = item;
            getMedications();
        };
        $scope.setTableHeaderClass = function (item) {
            if (isASC && $scope.frKey == item)
                return 'sorted_asc';
            else if (!isASC && $scope.frKey == item)
                return 'sorted_dsc';
            else
                return 'unsorted';

        }

        //END OF CONTROLLER
    }]);

});