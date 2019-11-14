

// date filter that works with 720kb datepicker , if you want current year  add class = 2000Year , and if you want 1900+ add class = 1900Year , 
(function () {
    'use strict';
    angular.module('mainModule').directive('ngDatefilter', ['$filter', 'validationService',
        function ($filter, validationService) {
            return {
                restrict: 'A',
                scope: {
                    closeDatepicker: '=change',
                    validDate: '=',
                    validateDate: '=',
                    dateMinLimit: '=',
                    dateMaxLimit: '='
                },
                require: 'ngModel',
                link: function (scope, element, attrs, ngModel) {
                    scope.$watch(function () {
                        return ngModel.$modelValue;
                    }, scope.change = function () {
                        if (ngModel != undefined) {
                            if (ngModel.$modelValue > 0) {
                                $('._720kb-datepicker-calendar').removeClass('_720kb-datepicker-open');
                            }
                        }
                    },

                    element.bind("keydown", function (event) {
                        if (event.which === 13 || event.which === 9) {
                            if (event.which === 13)
                                event.preventDefault();

                            var baseYear;
                            var inputClasses = this.className.split(" ");
                            for (i = 0; i < inputClasses.length; i++) {
                                if (inputClasses[i] == "2000Year") {
                                    baseYear = 2000;
                                } else if (inputClasses[i] == "1900Year") {
                                    baseYear = 1900;
                                }
                            };

                            var dateForSet;
                            var inputDate = ngModel.$modelValue;
                            var da = new Date();
                            var year = da.getFullYear();

                            switch (inputDate.length) {
                                case 4:
                                    var characterInput = inputDate.charAt(2);
                                    if (characterInput != '.') {
                                        var day = inputDate.substring(0, 2);
                                        var month = inputDate.substring(2, 4);
                                        var str = (day + '.' + month + '.' + year);
                                        var dateforValid = validationService.isValidDate(str);
                                        if (dateforValid === true) {
                                            var dateDotFormat = new Date(parseInt(year), parseInt(month) - 1, parseInt(day))
                                            dateForSet = $filter('date')(dateDotFormat, 'dd.MM.yyyy');
                                        }
                                    }
                                    break;
                                case 5:
                                    var characterInput = inputDate.charAt(2);
                                    if (characterInput == '.') {
                                        var day = inputDate.substring(0, 2);
                                        var month = inputDate.substring(3, 5);
                                        var str = (day + '.' + month + '.' + year);
                                        var dateforValid = validationService.isValidDate(str);
                                        if (dateforValid === true) {
                                            var dateDotFormat = new Date(parseInt(year), parseInt(month) - 1, parseInt(day))
                                            dateForSet = $filter('date')(dateDotFormat, 'dd.MM.yyyy');
                                        }
                                    }
                                    break;
                                case 6:
                                    var characterInput = inputDate.charAt(2);
                                    var characterInput2 = inputDate.charAt(4);
                                    if (characterInput != '.' && characterInput2 != '.') {
                                        var day = inputDate.substring(0, 2);
                                        var month = inputDate.substring(2, 4);
                                        var yearInp = inputDate.substring(4, 6);
                                        var yearI = baseYear + parseInt(yearInp);
                                        var str = (day + '.' + month + '.' + yearI);
                                        var dateforValid = validationService.isValidDate(str);
                                        if (dateforValid === true) {
                                            var dateDotFormat = new Date(parseInt(yearI), parseInt(month) - 1, parseInt(day))
                                            dateForSet = $filter('date')(dateDotFormat, 'dd.MM.yyyy');
                                        }
                                    }
                                    break;
                                case 8:
                                    var characterInput = inputDate.charAt(2);
                                    var characterInput2 = inputDate.charAt(5);
                                    if (characterInput == '.' && characterInput2 == '.') {
                                        var day = inputDate.substring(0, 2);
                                        var month = inputDate.substring(3, 5);
                                        var yearInp = inputDate.substring(6, 8);
                                        var yearI = baseYear + parseInt(yearInp);
                                        var str = (day + '.' + month + '.' + yearI);
                                        var dateforValid = validationService.isValidDate(str);
                                        if (dateforValid === true) {
                                            var dateDotFormat = new Date(parseInt(yearI), parseInt(month) - 1, parseInt(day))
                                            dateForSet = $filter('date')(dateDotFormat, 'dd.MM.yyyy');
                                        }
                                    }

                                    else if (characterInput != '.' && characterInput2 != '.') {
                                        var day = inputDate.substring(0, 2);
                                        var month = inputDate.substring(2, 4);
                                        var yearInp = inputDate.substring(4, 8);

                                        var str = (day + '.' + month + '.' + yearInp);
                                        var dateforValid = validationService.isValidDate(str);
                                        if (dateforValid === true) {


                                            var dateDotFormat = new Date(parseInt(yearInp), parseInt(month) - 1, parseInt(day))

                                            dateForSet = $filter('date')(dateDotFormat, 'dd.MM.yyyy');

                                        }
                                    }
                                    break;
                                case 10:

                                    var characterInput = inputDate.charAt(2);
                                    var characterInput2 = inputDate.charAt(4);
                                    if (characterInput != '.' && characterInput2 != '.') {


                                        var day = inputDate.substring(0, 2);
                                        var month = inputDate.substring(3, 5);
                                        var yearInp = inputDate.substring(6, 10);

                                        var str = (day + '.' + month + '.' + yearInp);
                                        var dateforValid = validationService.isValidDate(str);
                                        if (dateforValid === true) {
                                            var dateDotFormat = new Date(parseInt(yearInp), parseInt(month) - 1, parseInt(day))
                                            dateForSet = $filter('date')(dateDotFormat, 'dd.MM.yyyy');
                                        }
                                    } else {
                                        dateForSet = $filter('date')(inputDate, 'dd.MM.yyyy');
                                    }

                                    break;
                            };

                            var flagValid = false;
                            var isdateForSetValid = validationService.isValidDate(dateForSet);
                            if (scope.validateDate) {
                                if (isdateForSetValid === true) {
                                    var day = dateForSet.substring(0, 2);
                                    var month = dateForSet.substring(3, 5);
                                    var yearInp = dateForSet.substring(6, 12);
                                    var dateForCheck = new Date(parseInt(yearInp), parseInt(month) - 1, parseInt(day));

                                    if (scope.dateMinLimit != undefined) {

                                        var month = scope.dateMinLimit.substring(0, 2);
                                        var day = scope.dateMinLimit.substring(3, 5);
                                        var yearInp = scope.dateMinLimit.substring(6, 12);
                                        var dateForCheckFrom = new Date(parseInt(yearInp), parseInt(month) - 1, parseInt(day));

                                        dateForSetFormated = new Date(dateForCheck);
                                        if (dateForCheckFrom > dateForSetFormated)
                                        { flagValid = true; }
                                    }

                                    if (scope.dateMaxLimit == "") { scope.dateMaxLimit = undefined }
                                    if (scope.dateMaxLimit !== undefined) {
                                        var dateForSetFormated = new Date(dateForCheck);
                                        var month = scope.dateMaxLimit.substring(0, 2);
                                        var day = scope.dateMaxLimit.substring(3, 5);
                                        var yearInp = scope.dateMaxLimit.substring(6, 12);
                                        var dateDotFormat1 = new Date(parseInt(yearInp), parseInt(month) - 1, parseInt(day));

                                        if (dateForSetFormated > dateDotFormat1) {
                                            flagValid = true;
                                        }
                                    }

                                    if (scope.dateMaxLimit != undefined && scope.dateMinLimit != undefined) {
                                        var month = scope.dateMinLimit.substring(0, 2);
                                        var day = scope.dateMinLimit.substring(3, 5);
                                        var yearInp = scope.dateMinLimit.substring(6, 12);
                                        var dateDotFormat1 = new Date(parseInt(yearInp), parseInt(month) - 1, parseInt(day));

                                        var month = scope.dateMaxLimit.substring(0, 2);
                                        var day = scope.dateMaxLimit.substring(3, 5);
                                        var yearInp = scope.dateMaxLimit.substring(6, 12);
                                        var dateDotFormat2 = new Date(parseInt(yearInp), parseInt(month) - 1, parseInt(day));
                                        if (dateDotFormat1 > dateDotFormat2)
                                        { flagValid = true; }

                                    };
                                    if (scope.$parent.selectedFrom != undefined && scope.dateMinLimit != undefined) {

                                        var dateTyped = new Date(dateForCheck);
                                        var dateRestrict = scope.$parent.selectedFrom;
                                        var month = dateRestrict.substring(0, 2);
                                        var day = dateRestrict.substring(3, 5);
                                        var yearInp = dateRestrict.substring(6, 12);
                                        var dateRestrictCheck = new Date(parseInt(yearInp), parseInt(month) - 1, parseInt(day));

                                        if (dateRestrictCheck > dateTyped) {
                                            flagValid = true;
                                        }
                                    };
                                } else {
                                    flagValid = true;
                                }
                            };

                            if (flagValid == false) {
                                scope.$apply(function () {
                                    scope.validDate = true;
                                    ngModel.$setViewValue(dateForSet);
                                    ngModel.$render();
                                });
                            } else {
                                scope.$apply(function () {
                                    scope.validDate = false;
                                    ngModel.$setViewValue("");
                                    ngModel.$render();
                                });
                            }
                        }
                    }));
                }
            }
        }]);
})();