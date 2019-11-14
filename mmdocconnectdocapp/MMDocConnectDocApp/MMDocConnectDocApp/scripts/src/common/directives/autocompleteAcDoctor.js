(function () {
    'use strict';
    angular.module('mainModule').directive('autocompleteAcDoctor', ['$timeout', 'ajaxService', 'alertService', 'ngDialog',
        function ($timeout, ajaxService, alertService, ngDialog) {
            return {
                restrict: 'E',
                templateUrl: 'scripts/src/common/view/autocompleteAcDoctor.html',
                scope: {
                    ngModel: '=',
                    appendToBody: '=autocompleteAppendToBody',
                    inputDisable: '=autocompleteDisable',
                    addAftercare: '=autocompleteAddAc',
                    dropupEnabled: '=autocompleteDropupEnabled'
                },
                controller: ['$scope', '$element', '$attrs', function ($scope, $element, $attrs) {

                    var debounce = null;
                    var typed = false;
                    var isModelSetted = false;

                    $scope.selectedItem = angular.copy($scope.ngModel);

                    $scope.$watch('ngModel', function (newValue) {
                        if (!isModelSetted && newValue !== undefined) {
                            $scope.selectedItem = newValue;
                            isModelSetted = true;
                        }
                    });

                    if ($scope.appendToBody) {
                        $scope.dropdownAppendToElement = angular.element("body");
                    } else {
                        $scope.dropdownAppendToElement = null;
                    }

                    $scope.ac = {};
                    $scope.isOpen = false;
                    $scope.autocompleteId = $attrs.autocompleteId || "";
                    $scope.dropdownRight = $attrs.dropdownAligment && $attrs.dropdownAligment == "right";

                    getAcDoctosAndPractices();

                    $scope.selectItem = function (item) {
                        $scope.selectedItem = item;
                        updateView(item);
                    }

                    $scope.updateInput = function () {
                        typed = true;
                        $scope.searching = $scope.selectedItem.display_name;
                        $scope.ac.doctors = [];
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
                            if ($scope.selectedItem) {
                                getAcDoctosAndPractices($scope.selectedItem.display_name);
                            }
                        }, $attrs.autocompleteDebounce ? $attrs.autocompleteDebounce : 0);
                    }

                    function updateView(value) {
                        $scope.ngModel = value;
                    }

                    function getAcDoctosAndPractices(param) {
                        var search_value = param !== undefined && param !== null ? param : '';

                        ajaxService.AjaxGetWithData({ search_criteria: search_value }, "api/planning/GetACDoctorsAndPractices", function (response) {
                            $scope.searching = false;
                            $scope.ac = response.items[0];
                            $scope.noDataFound = typed && !$scope.ac.doctors.length && !$scope.ac.practices.length && $scope.selectedItem.display_name;
                        }, errorFunction);
                    }

                    function errorFunction(response) {
                        console.log(response);
                        alertService.RenderErrorMessage('LABEL_SOMETHING_WENT_WRONG');
                    }

                    $element.bind("keydown", function (event) {
                        if (event.which === 9) {
                            $scope.isOpen = false;
                        }
                    });

                    $scope.addNewAftercareDoctor = function () {
                        ngDialog.open({
                            template: '<add-temporary-aftercare-directive></add-temporary-aftercare-directive>',
                            plain: true,
                            closeByDocument: false
                        });
                    };

                    $scope.$on('TemporaryAftercareDoctorCreated', function (event, new_doctor) {
                        $scope.selectedItem = new_doctor;
                        updateView(new_doctor);
                        ngDialog.close();
                    });
                }]
            }
        }
    ]);
})();
