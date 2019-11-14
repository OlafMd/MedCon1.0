define(['angularAMD'], function (angularAMD) {

    angularAMD.directive('timeInput', function () {
        return {
            restrict: "A",
            require: 'ngModel',
            scope: {
                inputValue: '=ngModel',
                needValidation: '=needValidation'
            },

            link: function (scope, iElement, iAttributes, ngModel) {

                var backspacePressed = false;

                scope.$watch(function () { return iElement.val(); }, function () {
                    if (scope.inputValue !== undefined) {
                        $(iElement).keydown(function (e) {
                            if (e.keyCode === 8)
                                backspacePressed = true;
                        });

                        for (var i = 0; i < scope.inputValue.length; i++) {
                            if (!scope.inputValue[i].match(/[0-9]/g)) {
                                scope.inputValue = scope.inputValue.replace(scope.inputValue[i], '');
                            }
                        }

                        // check if : exists
                        for (var i = 0; i < scope.inputValue.length; i++) {
                            if (scope.inputValue[i] === ":") {
                                scope.inputValue.replace(scope.inputValue[i], '');
                            }
                        }

                        if (scope.inputValue.length === 2 && !backspacePressed) {
                            scope.inputValue += ":";
                            return;
                        }

                        else {
                            backspacePressed = false;
                        }

                        if (scope.inputValue.length > 2) {
                            scope.inputValue = scope.inputValue.substring(0, 2) + ":" + scope.inputValue.substring(2, scope.inputValue.length);
                        }

                        if (scope.inputValue.length > 5) {
                            scope.inputValue = scope.inputValue.substring(0, 2) + ":" + scope.inputValue.substring(3, 5);
                        }

                        if (scope.needValidation == true) {
                            if (/[0-9]{2}:[0-9]{2}/.test(scope.inputValue) === false) {
                                ngModel.$setValidity('timeInput', false);
                                return false;
                            }
                            else {

                                if (parseInt(scope.inputValue.substring(0, 2)) > 23 || parseInt(scope.inputValue.substring(3, 5)) > 59) {
                                    ngModel.$setValidity('timeInput', false);
                                    return false;
                                }

                                ngModel.$setValidity('timeInput', true);
                                return true;
                            }
                        }
                    }
                });
            }
        };
    });
});