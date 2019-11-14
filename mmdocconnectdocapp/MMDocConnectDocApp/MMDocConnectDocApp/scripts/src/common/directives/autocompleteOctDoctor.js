(function () {
    'use strict';
    angular.module('mainModule').directive('autocompleteOctDoctor', ['ajaxService', 'alertService', '$timeout',
        function (ajaxService, alertService, $timeout) {
            return {
                restrict: 'E',
                require: 'ngModel',
                templateUrl: 'scripts/src/common/view/autocompleteOctDoctor.html',
                link: function ($scope, element, attrs, ngModelCtrl) {

                    var debounce = null;
                    var typed = false;

                    $timeout(function () {
                        $scope.selectedItem = angular.copy(ngModelCtrl.$modelValue);
                    }, 0);

                    $scope.octDoctors = {};
                    $scope.isOpen = false;
                    $scope.autocompleteId = attrs.autocompleteId || "";
                    $scope.dropdownRight = attrs.dropdownAligment && attrs.dropdownAligment == "right";

                    getOctDoctors();

                    $scope.selectItem = function (item) {
                        $scope.selectedItem = item;
                        updateView(item);
                    };

                    $scope.updateInput = function () {
                        typed = true;
                        $scope.searching = $scope.selectedItem.display_name;
                        $scope.octDoctors.doctors = [];
                        $scope.isOpen = true;
                        $scope.noDataFound = false;
                        updateView();
                        if (!debounce) {
                            setDebounce();
                        } else {
                            $timeout.cancel(debounce);
                            setDebounce();
                        }
                    };

                    function setDebounce() {
                        debounce = $timeout(function () {
                            getOctDoctors($scope.selectedItem.display_name);
                        }, attrs.debounceValue ? attrs.debounceValue : 0);
                    }

                    function updateView(value) {
                        ngModelCtrl.$setViewValue(value);
                        ngModelCtrl.$render();
                    }

                    function getOctDoctors(param) {
                        var search_value = param !== undefined && param !== null ? param : '';

                        ajaxService.AjaxGetWithData({ search_criteria: search_value }, "api/planning/GetOctDoctors", function (response) {
                            $scope.searching = false;
                            $scope.octDoctors = response.items[0];
                            $scope.noDataFound = typed && !$scope.octDoctors.doctors.length && $scope.selectedItem.display_name;
                        }, errorFunction);
                    }

                    function errorFunction(response) {
                        console.log(response);
                        alertService.RenderErrorMessage('LABEL_SOMETHING_WENT_WRONG');
                    }

                    element.bind("keydown", function (event) {
                        if (event.which === 9) {
                            $scope.isOpen = false;
                        }
                    });
                }
            };
        }
    ]);
})();
