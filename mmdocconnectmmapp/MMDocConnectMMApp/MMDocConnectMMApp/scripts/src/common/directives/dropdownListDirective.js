/// <reference path="../view/globalSearchTemplate.html" />
define(['angularAMD'], function (angularAMD) {
    angularAMD.directive('dropdownList', function ($timeout, $filter) {

        return {
            templateUrl: 'scripts/src/common/view/dropdownListTemplate.html',
            scope: {
                id: '@',
                items: '=',
                ngModel: '=',
                disableInput: '=',
                params: '=',
                additionalClass: '=',
                isRequired: '=',
                dropdownClass: '='
            },
            replace: true,
            restrict: 'E',
            link: dropdownListController
        };

        function dropdownListController($scope, elem, attrs) {
            $scope.currentIndex = -1;
            $scope.showDropdown = false;
            $scope.name_ordinal = $scope.params === undefined || $scope.params.display_name === undefined ? 'display_name' : $scope.params.display_name;
            $scope.id_ordinal = $scope.params === undefined || $scope.params.id === undefined ? 'id' : $scope.params.id;
            var is_model_object = $scope.params === undefined || $scope.params.is_model_object === undefined ? false : $scope.params.is_model_object;

            $scope.$watch('ngModel', function () {
                $scope.$parent.$eval(attrs.ngChange);
            });

            elem.bind('keydown', function ($event) {
                if ($event.which > 64 && $event.which < 91) {
                    var letter = String.fromCharCode($event.keyCode).toLowerCase();
                    var start_index = $scope.items[0][$scope.name_ordinal] !== undefined && $scope.items[0][$scope.name_ordinal] !== '' && $scope.items[0][$scope.name_ordinal] !== ' ' ? 0 : 1;
                    var name_index = $scope.params === undefined ? 0 : $scope.params.has_prefix === undefined ? 0 : $scope.items[0][$scope.name_ordinal] !== undefined && $scope.items[0][$scope.name_ordinal] !== '' && $scope.items[0][$scope.name_ordinal] !== ' ' ? $scope.items[0][$scope.name_ordinal].indexOf(' ') + 1 : $scope.items[1][$scope.name_ordinal].indexOf(' ') + 1;
                    for (var i = start_index; i < $scope.items.length; i++) {
                        if ($filter('translate')($scope.items[i][$scope.name_ordinal])[name_index].toLowerCase() === letter && $scope.currentIndex !== i) {
                            $scope.currentIndex = i;
                            break;
                        };
                    };

                    $scope.ngModel = is_model_object ? $scope.items[$scope.currentIndex] : $scope.items[$scope.currentIndex][$scope.id_ordinal];
                    $scope.selectedItem = $filter('translate')($scope.items[$scope.currentIndex][$scope.name_ordinal]);
                    $scope.showDropdown = false;
                } else {
                    switch ($event.which) {
                        case 8:
                            $event.preventDefault();
                            break;
                        case 13:
                            $event.preventDefault();
                            $scope.ngModel = is_model_object ? $scope.items[$scope.currentIndex] : $scope.items[$scope.currentIndex][$scope.id_ordinal];
                            $scope.selectedItem = $filter('translate')($scope.items[$scope.currentIndex][$scope.name_ordinal]);
                            $scope.showDropdown = !$scope.showDropdown;
                            break;
                        case 38:
                            $event.preventDefault();
                            if (!$scope.showDropdown)
                                $scope.showDropdown = true;
                            else
                                $scope.currentIndex = $scope.currentIndex > 0 ? $scope.currentIndex - 1 : 0;
                            break;
                        case 40:
                            $event.preventDefault();
                            if (!$scope.showDropdown)
                                $scope.showDropdown = true;
                            else
                                $scope.currentIndex = $scope.currentIndex == $scope.items.length - 1 ? $scope.currentIndex : $scope.currentIndex + 1;
                            break;
                    };
                };
            });

            $scope.$watch('ngModel', function () {
                if ($scope.ngModel) {
                    var keepGoing = true;
                    angular.forEach($scope.items, function (item) {
                        if (keepGoing) {
                            if ((!is_model_object && item[$scope.id_ordinal] === $scope.ngModel) || (is_model_object && item[$scope.id_ordinal] === $scope.ngModel[$scope.id_ordinal])) {
                                $scope.selectedItem = $filter('translate')(item[$scope.name_ordinal]);
                                keepGoing = false;
                            };
                        };
                    });
                };
            });

            $scope.$watch('items', function () {
                if ($scope.ngModel && $scope.items) {
                    if ($scope.items.length !== 0) {
                        var keepGoing = true;
                        angular.forEach($scope.items, function (item) {
                            if (keepGoing) {
                                if ((!is_model_object && item[$scope.id_ordinal] === $scope.ngModel) || (is_model_object && item[$scope.id_ordinal] === $scope.ngModel[$scope.id_ordinal])) {
                                    $scope.selectedItem = $filter('translate')(item[$scope.name_ordinal]);
                                    keepGoing = false;
                                };
                            };
                        });
                    };
                } else {
                    $scope.selectedItem = ""
                };
            });

            $scope.hideDropdown = function ($event) {
                $timeout(function () {
                    $scope.showDropdown = false;
                }, 150);
            };

            $scope.selectResult = function (item) {
                $scope.ngModel = is_model_object ? $scope.items[$scope.currentIndex] : $scope.items[$scope.currentIndex][$scope.id_ordinal];
                $scope.selectedItem = $filter('translate')($scope.items[$scope.currentIndex][$scope.name_ordinal]);
                $scope.showDropdown = false;
                angular.element('#' + elem[0].id + '_value')[0].focus();
            };

            $scope.triggerDropdown = function () {
                $scope.showDropdown = !$scope.showDropdown;
                $('.gray-content-holder').css('overflow', 'visible');
            };

            $scope.hoverRow = function (index) {
                $scope.currentIndex = index;
            };

            $scope.onFocusHandler = function () {
                var index = -1;
                if ($scope.ngModel !== undefined) {
                    for (var i = 0; i < $scope.items.length; i++) {
                        if ((!is_model_object && $scope.items[i][$scope.id_ordinal] === $scope.ngModel) || (is_model_object && $scope.items[i][$scope.id_ordinal] === $scope.ngModel[$scope.id_ordinal])) {
                            index = i;
                            break;
                        };
                    };
                };

                $scope.currentIndex = index;
            };

            $scope.handleKeyEvent = function ($event) {
                return false;
            };
        };

    });
});