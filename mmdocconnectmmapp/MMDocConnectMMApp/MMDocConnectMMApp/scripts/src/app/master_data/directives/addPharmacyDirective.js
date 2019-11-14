define(['angularAMD'], function (angularAMD) {

    angularAMD.directive('addPharmacyDirective', function () {

        return {
            templateUrl: 'scripts/src/app/master_data/view/addPharmacyTemplate.html',
            replace: true,
            restrict: 'E',
            scope: {
                fromEdit: '=fromEdit'
            },
            controller: addPharmacyController
        };

        function addPharmacyController($scope, $rootScope, $translate, pharmacyService, validationService, ngDialog, $timeout, $routeParams, commonServices, $location, alertsServices, $interval) {
            $scope.pharmacy = {};
            $scope.emailNotValid = true;
            $scope.isFormSubmitted = false;

            $scope.pharmacy = $scope.fromEdit;

            $scope.closePharmacyForm = function () {
                $scope.$parent.fromEdit = null
                $scope.pharmacy = {};
                $rootScope.$broadcast('CloseForm', ["ClosePharmacy"]);
            };

            $scope.sendPharmacyForm = function () {
                $scope.isFormSubmitted = true;
                if ($scope.pharmacy.email !== undefined) {
                    $scope.emailIsValid = validationService.validateEmail($scope.pharmacy.email);
                }

                if (!$scope.emailIsValid) {
                    return;
                }

                pharmacyService.savePharmacy($scope.pharmacy, successFunctionPharmacySave, errorFunctionPharmacySave);
            };

            successFunctionPharmacySave = function (response) {
                alertsServices.SuccessMessage('LABEL_PHARMACY_SAVED');
                $rootScope.$broadcast('CloseForm', ["ClosePharmacy"]);
                $scope.pharmacy = {};
                $scope.$parent.fromEdit = null;
                $scope.emailIsValid = true;
                $scope.isFormSubmitted = false;
            }

            errorFunctionPharmacySave = function (response) {
                alertsServices.ErrorMessage('LABEL_SOMETHING_WENT_WRONG');
                $rootScope.$broadcast('CloseForm', ["CloseMedication"]);
                $scope.pharmacy = {};
                $scope.$parent.fromEdit = null;
                $scope.emailIsValid = true;
                $scope.isFormSubmitted = false;
            }

            if ($scope.$parent.fromEdit === undefined) { $scope.$parent.fromEdit = null }
            if ($scope.$parent.fromEdit !== null) {
                if ($scope.$parent.fromEdit.ProprietaryDrug === true)
                    $scope.proprietaryDrug = true;
                else
                    $scope.proprietaryDrug = false;
                $scope.medication = $scope.$parent.fromEdit;
            };

            var interval = $interval(function () {
                var element = angular.element('#inPharmacy')[0];
                if (element) {
                    $interval.cancel(interval);
                    element.focus();
                }
            }, 20, 100, false);

            //END OF CONTROLLER
        };
    });
});
