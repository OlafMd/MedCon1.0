(function () {
    'use strict';
    angular.module('mainModule').directive('dateAdaptation', ['$filter', 'validationService',
        function ($filter, validationService) {
            return {
                restrict: 'A',
                require: 'ngModel',
                link: function (scope, element, attrs, ngModelCtrl) {

                    element.bind("keydown", function (event) {
                        if (event.which === 13 || event.which === 9) {
                            if (event.which === 13)
                                event.preventDefault();

                            var baseYear = 2000;
                            var dateForSet;
                            var inputDate = event.target.value;
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
                            }

                            var flagValid = false;
                            var isdateForSetValid = validationService.isValidDate(dateForSet);
                            if (attrs.dateValidate === "true") {
                                if (isdateForSetValid === true) {
                                    var dfs = dateForSet.split(".");
                                    var dateForCheck = new Date(parseInt(dfs[2]), parseInt(dfs[1]) - 1, parseInt(dfs[0]));

                                    var minLimit, dateForCheckFrom;
                                    var maxLimit, dateForCheckTo;

                                    if (attrs.dateMinLimit != undefined) {
                                        minLimit = attrs.dateMinLimit.split(".");
                                        dateForCheckFrom = new Date(parseInt(minLimit[2]), parseInt(minLimit[1]) - 1, parseInt(minLimit[0]));

                                        if (dateForCheck >= dateForCheckFrom)
                                            flagValid = true;
                                    }

                                    if (attrs.dateMaxLimit != undefined) {
                                        maxLimit = attrs.dateMaxLimit.split(".");
                                        dateForCheckTo = new Date(parseInt(maxLimit[2]), parseInt(maxLimit[1]) - 1, parseInt(maxLimit[0]));

                                        if (dateForCheck <= dateForCheckTo)
                                            flagValid = true;
                                    }

                                    if (attrs.dateMaxLimit != undefined && attrs.dateMinLimit != undefined) {
                                        if ((dateForCheckFrom < dateForCheckTo) && (dateForCheckFrom <= dateForCheck) && (dateForCheck <= dateForCheckTo)) {
                                            flagValid = true;
                                        } else {
                                            flagValid = false;
                                        }
                                    } 


                                    if (scope.$parent.selectedFrom != undefined && attrs.dateMinLimit != undefined) {
                                        var dateRestrict = scope.$parent.selectedFrom.split(".");
                                        var dateRestrictCheck = new Date(parseInt(dateRestrict[2]), parseInt(dateRestrict[1]) - 1, parseInt(dateRestrict[0]));

                                        if (dateRestrictCheck >= dateForCheck)
                                            flagValid = true;
                                    }
                                } else {
                                    flagValid = false;
                                }
                            } else {
                                flagValid = true;
                            };

                            if (flagValid) {
                                scope[attrs.isOpen] = false;
                                updateView(dateForSet);
                            } else {
                                scope[attrs.isOpen] = false;
                                updateView("");                        
                            }

                        }
                    });

                    function updateView(value) {
                        ngModelCtrl.$setViewValue(value);
                        ngModelCtrl.$render();
                        scope.$apply();
                    }
                }
            }
        }
    ]);
})();
