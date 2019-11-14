(function () {
    'use strict';
    angular.module('720kb.datepicker').directive('datepicker2', ['$filter', '$timeout', '$translate', 'validationService',
        function ($filter, $timeout, $translate, validationService) {
            return {
                restrict: 'E',
                templateUrl: 'scripts/src/common/view/datepicker2.html',
                scope: {
                    ngModel: '=ngModel',
                    placeholder: '=placeholder',
                    dateMaxLimit: '=dateMaxLimit',
                    dateMinLimit: '=dateMinLimit',
                    dateValidate: '=dateValidate',
                    dateInvalid: '=dateInvalid',
                    datepickerId: '@datepickerId'
                },
                controller: ['$scope', '$element', '$attrs', function ($scope, $element, $attrs) {

                    var TABKEY = 9;
                    var ENTER = 13;
                    var reset = true;

                    $scope.datepickerModel = angular.copy($scope.ngModel);

                    $translate($scope.placeholder).then(function (translate) {
                        $scope.datepickerPlaceholder = translate;
                    });

                    $scope.datepickerOptions = {};
                    if ($scope.dateMaxLimit) {
                        $scope.datepickerOptions.maxDate = $scope.dateMaxLimit;
                    }
                    if ($scope.dateMinLimit) {
                        $scope.datepickerOptions.minDate = $scope.dateMinLimit;
                    }

                    $scope.datepickerOpen = false;

                    $scope.$watch('ngModel', function (newValue) {
                        if (newValue == undefined && reset) {
                            $scope.datepickerModel = "";
                        } else {
                            $scope.datepickerModel = angular.copy($scope.ngModel);
                        }
                        $scope.$emit('datepicker2:updated', $scope.datepickerId);
                        reset = true;
                    });

                    $element.bind("keydown", function (event) {
                        if (event.which === ENTER || event.which == TABKEY) {
                            if (event.which === ENTER)
                                event.preventDefault();

                            var date = shorthandDateParser(event.target.value);
                            if (($attrs.dateValidate == undefined) || ($attrs.dateValidate === "true" && isDateInRange(date))) {
                                $scope.datepickerModel = date;
                                updateView(date);
                            } else {
                                $scope.datepickerModel = "";
                                updateView("");
                            }
                            $scope.datepickerOpen = false;
                            $scope.$apply();
                        }
                    });

                    $scope.open = function () {
                        if (!$scope.datepickerOpen) {
                            $scope.datepickerOpen = true;
                        }
                    };

                    $scope.updateDatepicker = function () {
                        updateView($scope.datepickerModel);
                    };

                    function shorthandDateParser(inputValue) {
                        var baseYear = 2000;
                        var currentYear = new Date().getFullYear();
                        var dateForSet = undefined;
                        var dateParam = [];
                        var dateParam2 = [];

                        var regex4 = /^(\d{2})(\d{2})$/i;
                        var regex5 = /^(\d{2})[.](\d{2})$/i;
                        var regex6a = /^(\d{2})[.](\d{2})[.]$/i;
                        var regex6b = /^(\d{2})(\d{2})(\d{2})$/i;
                        var regex8a = /^(\d{2})[.](\d{2})[.](\d{2})$/i;
                        var regex8b = /^(\d{2})(\d{2})(\d{4})$/i;
                        var regex10 = /^(\d{2})[.](\d{2})[.](\d{4})$/i;

                        switch (inputValue.length) {
                            case 4:
                                dateParam = inputValue.match(regex4);
                                if (dateParam) {
                                    dateParam.shift();
                                    dateParam.push(currentYear);
                                    dateForSet = dateParam.join(".");
                                }
                                break;

                            case 5:
                                dateParam = inputValue.match(regex5);
                                if (dateParam) {
                                    dateParam.shift();
                                    dateParam.push(currentYear);
                                    dateForSet = dateParam.join(".");
                                }
                                break;

                            case 6:
                                dateParam = inputValue.match(regex6a);
                                dateParam2 = inputValue.match(regex6b);

                                if (dateParam) {
                                    dateParam.push(currentYear);
                                    dateParam.shift();
                                    dateForSet = dateParam.join(".");
                                } else if (dateParam2) {
                                    dateParam2.shift();
                                    dateParam2.push(baseYear + parseInt(dateParam2.pop()));
                                    dateForSet = dateParam2.join(".");
                                }
                                break;

                            case 8:
                                dateParam = inputValue.match(regex8a);
                                dateParam2 = inputValue.match(regex8b);
                                if (dateParam) {
                                    dateParam.shift();
                                    dateParam.push(baseYear + parseInt(dateParam.pop()));
                                    dateForSet = dateParam.join(".");
                                } else if (dateParam2) {
                                    dateParam2.shift();
                                    dateForSet = dateParam2.join(".");
                                }
                                break;

                            case 10:
                                dateParam = inputValue.match(regex10);
                                if (dateParam) {
                                    dateForSet = inputValue;
                                }
                                break;
                        }

                        if (dateForSet && validationService.isValidDate(dateForSet)) {
                            return dateFromStringToObject(dateForSet);
                        } else {
                            return null;
                        }
                    }

                    function isDateInRange(dateForCheck) {
                        var flagValid = false;

                        if ($scope.dateMinLimit != undefined && dateForCheck >= $scope.dateMinLimit) {
                            flagValid = true;
                        }

                        if ($scope.dateMaxLimit != undefined && dateForCheck <= $scope.dateMaxLimit) {
                            flagValid = true;
                        }

                        if ($scope.dateMaxLimit != undefined && $scope.dateMinLimit != undefined) {
                            if (($scope.dateMinLimit < $scope.dateMaxLimit) && ($scope.dateMinLimit <= dateForCheck) && (dateForCheck <= $scope.dateMaxLimit)) {
                                flagValid = true;
                            } else {
                                flagValid = false;
                            }
                        }

                        return flagValid;
                    }

                    function updateView(value) {
                        reset = false;
                        $scope.ngModel = angular.copy(value);
                    }

                    function dateFromStringToObject(date) {
                        var dateArray = date.split(".");
                        return new Date(dateArray[2], dateArray[1] - 1, dateArray[0]);
                    }
                }]
            }
        }
    ]);
})();
