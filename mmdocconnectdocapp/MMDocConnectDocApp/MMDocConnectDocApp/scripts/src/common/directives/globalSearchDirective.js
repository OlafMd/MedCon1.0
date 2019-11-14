/// <reference path="../view/globalSearchTemplate.html" />
(function () {
    'use strict';
    angular.module('mainModule').directive('globalSearchDirective', ['$location', '$compile', '$http', 'validationService', 'practiceSettingsService', '$templateCache',
        function ($location, $compile, $http, validationService, practiceSettingsService, $templateCache) {

            return {
                scope: {},
                replace: true,
                restrict: 'E',
                controller: ['$scope', '$rootScope', '$location', '$filter', 'ngDialog', '$http', '$interval', globalSearchController],
                link: linker
            };

            function getTemplate() {
                var template = '';
                var a = $location;

                switch ($location.path().toLowerCase()) {
                    case '/aftercare/':
                        template = 'scripts/src/common/view/globalSearchTemplates/globalSearchAftercareTemplate.html';
                        break;
                    case '/settlement/':
                        template = 'scripts/src/common/view/globalSearchTemplates/globalSearchSettlementTemplate.html';
                        break;
                    case '/planning/':
                        template = 'scripts/src/common/view/globalSearchTemplates/globalSearchPlanningTemplate.html';
                        break;
                    case '/oct/':
                        template = 'scripts/src/common/view/globalSearchTemplates/globalSearchOctTemplate.html';
                        break;
                    case '/patient/':
                        template = 'scripts/src/common/view/globalSearchTemplates/globalSearchPatientTemplate.html';
                        break;
                    case '/shoppingcart/':
                        template = 'scripts/src/common/view/globalSearchTemplates/globalSearchShoppingCartTemplate.html';
                        break;
                    case '/order/':
                        template = 'scripts/src/common/view/globalSearchTemplates/globalSearchOrderTemplate.html';
                        break;
                    default:
                        template = 'scripts/src/common/view/globalSearchTemplates/globalSearchTemplate.html';
                        break;
                };

                return template;
            };

            function linker(scope, element, attrs) {
                scope.$on("$routeChangeSuccess", function (event, current, previous) {
                    if (current !== previous) {
                        var tpl = $templateCache.get(getTemplate());
                        if (tpl) {
                            element.html($compile(tpl)(scope));
                        } else {
                            $http.get(getTemplate())
                              .then(function (response) {
                                  element.html($compile(response.data)(scope));
                              });
                        }
                    }
                });

                element.bind('mousedown', function (event) {
                    scope.mousedown_on = event.target.id;
                });
            };

            function globalSearchController($scope, $rootScope, $location, $filter, ngDialog, $http, $interval) {
                $scope.current = "";
                $scope.global_search = {
                    text_search: ''
                };
                $scope.hips = [];
                var searchTimeout = undefined;
                var pagesWithHipFilter = ['/patient/', '/settlement/', '/planning/', '/aftercare/', '/oct/', '/shoppingcart/', '/order/'];

                $scope.$on('pressEnterToSearchChanged', function (val) {
                    $scope.pressEnterToSearch = val;
                });

                practiceSettingsService.getPracticeSettings().then(function (settings) {
                    $scope.pressEnterToSearch = settings.PressEnterToSearch;
                });

                var loadingHips = false;
                getHips();

                function getHips() {
                    if (!loadingHips) {
                        loadingHips = true;
                        $http({
                            method: 'GET',
                            url: 'api/patient/GetUsedHips'
                        }).then(function (response) {
                            loadingHips = false;
                            $scope.hips = response.data;
                            $scope.hips.unshift({ name: '', display_name: 'LABEL_EMPTY' });
                        });
                    }
                }

                $scope.search = function ($event) {
                    if (($event.ctrlKey && $event.which == 65) || $event.which == 17) {
                        return false;
                    }

                    var shouldSearch = true;
                    if ($scope.filter.hip) {
                        $scope.filter.all = false;
                    }

                    if ($scope.pressEnterToSearch) {
                        shouldSearch = $event.which === 13;
                    }

                    if (shouldSearch) {
                        if ($scope.pressEnterToSearch) {
                            search();
                        } else {
                            if (searchTimeout === undefined) {
                                searchTimeout = setTimeout(search, 1000);
                            } else {
                                clearTimeout(searchTimeout);
                                searchTimeout = setTimeout(search, 1000);
                            }
                        }
                    }
                };

                function search() {
                    if ($location.path().indexOf('aftercare') > -1 && !$scope.filter.all && !$scope.filter.current && $scope.global_search.filter_by.filter_status.length === 0) {
                        $scope.global_search.filter_by.filter_status.push(angular.element('#ac1')[0].value);
                    } else {
                        $scope.global_search.filter_by.filter_current = $scope.filter.current;
                    }

                    if ($location.path().indexOf('oct') > -1 && !$scope.filter.all && !$scope.filter.current && $scope.global_search.filter_by.filter_status.length === 0) {
                        $scope.global_search.filter_by.filter_status.push(angular.element('#oct1')[0].value);
                    } else {
                        $scope.global_search.filter_by.filter_current = $scope.filter.current;
                    }

                    $scope.global_search.filter_by.all = $scope.filter.all;
                    $scope.global_search.filter_by.hip_name = $scope.filter.hip;
                    $scope.global_search.filter_by.ops_with_overdue_acs = $scope.filter.ops_with_overdue_acs;

                    $scope.global_search.filter_by.this_practice = $scope.filter.thisPractice;
                    $scope.global_search.filter_by.different_practice = $scope.filter.differentPractice;
                    $scope.global_search.filter_by.invalid_consent = $scope.filter.invalidConsent;
                    $scope.global_search.filter_by.show_only_with_rejected_octs = $scope.filter.show_only_with_rejected_octs;
                    $scope.global_search.filter_by.ordered_drugs = $scope.filter.ordered;

                    $rootScope.$broadcast("GlobalSearch", $scope.global_search);
                    var wrapper = angular.element('#wrapper')[0];
                    if (wrapper !== undefined) {
                        wrapper.scrollTop = 0;
                    }
                }

                //on route change reset search parameters
                $rootScope.$on('$routeChangeStart', function (scope, next, current) {

                    $scope.global_search = new Object();
                    $scope.global_search.date_from = '1-1-1';
                    $scope.global_search.date_to = $filter('date')(new Date(), 'yyyy-MM-dd');
                    $scope.global_search.filter_by = new Object();
                    $scope.global_search.filter_by.filter_status = [];
                    $scope.global_search.filter_by.filter_type = [];
                    $scope.filter = new Object();

                    $scope.filter.all = $location.path() === "/settlement/";
                    if ($location.path() === "/aftercare/") {
                        $scope.filter.current = !$scope.filter.all;
                    }

                    if ($location.path() === "/planning/") {
                        $scope.filter.current = !$scope.filter.all;
                        $scope.ItemCheckedtreatmentorder = '';
                        $scope.ItemCheckedorder = '';
                        $scope.ItemCheckedtreatment = '';
                    }

                    if ($location.path() === '/oct/') {
                        $scope.filter.current = !$scope.filter.all;
                    }

                    if ($location.path() === '/order/') {
                        $scope.filter.ordered = !$scope.filter.all;
                    }

                    if ($location.path() === '/patient/') {
                        $scope.filter.all = true;
                    }

                    $scope.today = new Date();
                    $scope.checkBoxParameters = [];
                    getHips();
                });

                $scope.date_dropdown_items = [
                    {
                        id: 0,
                        display_name: 'LABEL_THIS_WEEK'
                    }, {
                        id: 1,
                        display_name: 'LABEL_LAST_4_WEEKS'
                    }, {
                        id: 2,
                        display_name: 'LABEL_LAST_90_DAYS'
                    }
                ];

                $scope.date_dropdown_itemsArchive = [
                  {
                      id: 3,
                      display_name: 'LABEL_THIS_WEEK'
                  }, {
                      id: 4,
                      display_name: 'LABEL_LAST_WEEK'
                  }, {
                      id: 5,
                      display_name: 'LABEL_THIS_MONTH'
                  },
                  {
                      id: 6,
                      display_name: 'LABEL_LAST_MONTH'
                  }
                ];


                $scope.showDateDropdown = function () {
                    $scope.show_date_dropdown = !$scope.show_date_dropdown;
                };

                $scope.closeDateDropdown = function () {
                    if (!isNaN($scope.mousedown_on) && $scope.mousedown_on !== '')
                        $scope.select($scope.mousedown_on);
                    else {
                        if ($scope.mousedown_on === 'btnSetPeriod') {
                            $scope.setPeriod();
                        };
                    };
                    $scope.show_date_dropdown = false;
                };

                $scope.select = function (id) {
                    $scope.global_search.date_to = $filter('date')(new Date(), 'yyyy-MM-dd');
                    switch (id) {
                        case '0':
                            $scope.global_search.date_from = $filter('date')(getMonday(), 'yyyy-MM-dd');

                            break;
                        case '1':
                            var d = new Date();
                            $scope.global_search.date_from = $filter('date')(new Date(new Date().setDate(d.getDate() - 28)), 'yyyy-MM-dd');
                            break;
                        case '2':
                            var d = new Date();
                            $scope.global_search.date_from = $filter('date')(new Date(new Date().setDate(d.getDate() - 90)), 'yyyy-MM-dd');
                            break;
                        case '3':
                            $scope.global_search.date_from = $filter('date')(getMonday(), 'yyyy-MM-dd');
                            break;
                        case '4':
                            var beforeOneWeek = new Date(new Date().getTime() - 60 * 60 * 24 * 7 * 1000)
                            var day = beforeOneWeek.getDay();
                            var diffToMonday = beforeOneWeek.getDate() - day + (day === 0 ? -6 : 1);
                            var lastMonday = new Date(beforeOneWeek.setDate(diffToMonday));
                            $scope.global_search.date_from = $filter('date')(lastMonday, 'yyyy-MM-dd');
                            $scope.global_search.date_to = $filter('date')(new Date(beforeOneWeek.setDate(diffToMonday + 6)), 'yyyy-MM-dd');
                            break;
                        case '5':
                            var d = new Date();
                            $scope.global_search.date_from = $filter('date')(new Date(d.getFullYear(), d.getMonth(), 1), 'yyyy-MM-dd');;
                            break;
                        case '6':
                            var d = new Date();
                            var month = d.getMonth();
                            var monthCounted;
                            if (month === 1) {
                                monthCounted = 11;
                            }
                            else {
                                monthCounted = month - 1;
                            }
                            $scope.global_search.date_from = $filter('date')(new Date(d.getFullYear(), monthCounted, 1), 'yyyy-MM-dd');
                            $scope.global_search.date_to = $filter('date')(new Date(d.getFullYear(), monthCounted + 1, 0), 'yyyy-MM-dd');
                            break;
                    };

                    $scope.filter.all = false;
                    $scope.search({ which: 13 });
                };


                function getMonday() {
                    d = new Date();
                    var day = d.getDay(),
                        diff = d.getDate() - day + (day == 0 ? -6 : 1);

                    return new Date(d.setDate(diff));
                };

                $scope.setPeriod = function () {
                    $scope.global_search.date_to = '';
                    $scope.global_search.date_from = '';

                    ngDialog.open({
                        template: 'scripts/src/common/view/datePeriodTemplate.html',
                        plain: false,
                        scope: $scope
                    });
                };

                $scope.closeSetPeriodDialog = function () {
                    ngDialog.close();
                };

                $scope.submitDatePeriod = function () {
                    var is_from_date_valid = $scope.global_search.date_from !== '' && $scope.global_search.date_from !== undefined && $scope.global_search.date_from !== null ? validationService.isValidDate($scope.global_search.date_from) : true;
                    var is_to_date_valid = $scope.global_search.date_to !== '' && $scope.global_search.date_to !== undefined && $scope.global_search.date_to !== null ? validationService.isValidDate($scope.global_search.date_to) : true;

                    if (!is_from_date_valid || !is_to_date_valid) {
                        $scope.global_search.date_from = is_from_date_valid ? $scope.global_search.date_from : '';
                        $scope.global_search.date_to = is_to_date_valid ? $scope.global_search.date_to : '';
                        return;
                    };

                    ngDialog.close();
                    $scope.filter.all = false;

                    $scope.global_search.date_from = $scope.global_search.date_from !== '' && $scope.global_search.date_from !== null && $scope.global_search.date_from !== undefined ? $filter('date')(new Date(parseInt($scope.global_search.date_from.substr(6, 4)), parseInt($scope.global_search.date_from.substr(3, 2) - 1), parseInt($scope.global_search.date_from.substr(0, 2))), 'yyyy-MM-dd') : '1-1-1';

                    if ($scope.global_search.date_to !== undefined && $scope.global_search.date_to !== '' && $scope.global_search.date_to !== null) {
                        yyyy = $scope.global_search.date_to.substr(6, 4);
                        mm = $scope.global_search.date_to.substr(3, 2) - 1;
                        dd = $scope.global_search.date_to.substr(0, 2);

                        $scope.global_search.date_to = new Date(parseInt(yyyy), parseInt(mm), parseInt(dd));
                    } else {
                        $scope.global_search.date_to = new Date();
                    };

                    $scope.global_search.date_to = $filter('date')($scope.global_search.date_to, 'yyyy-MM-dd');
                    $scope.search({ which: 13 });
                };

                $scope.prepareSearch = function (is_all, treatmentOrders, deselect) {
                    $scope.was_all_selected = is_all;
                    $scope.filter.all = is_all;
                    if ($scope.filter.all) {
                        $scope.global_search.filter_by = new Object();
                        $scope.global_search.filter_by.filter_status = [];
                        $scope.global_search.filter_by.filter_type = [];
                        $scope.global_search.filter_by.filter_current = false;
                        $scope.global_search.filter_by.orders = null;
                        $scope.global_search.filter_by.localization = null;
                        $scope.global_search.date_from = '1-1-1';
                        $scope.global_search.date_to = $filter('date')(new Date(), 'yyyy-MM-dd');
                        $scope.global_search.text_search = '';
                        $scope.ItemCheckedtreatmentorder = '';
                        $scope.ItemCheckedorder = '';
                        $scope.ItemCheckedtreatment = '';
                        $scope.filter = new Object();
                        $scope.filter.all = true;
                    } else {
                        $scope.global_search.filter_by.filter_type = [];
                        $scope.global_search.filter_by.filter_status = [];
                        $scope.global_search.filter_by.filter_current = false;

                        //check if all items from filter are false, and set current to true
                        var filter_has_value = 'true';
                        var filter_has_value_value = "";
                        for (var filter_has_value in $scope.filter) {
                            if ($scope.filter[filter_has_value] === true) {
                                filter_has_value_value += $scope.filter[filter_has_value];
                                break;
                            }
                        };
                        if (filter_has_value_value === "") {
                            if ($location.path() !== '/patient/') {
                                $scope.filter.current = true;
                                if (angular.element('#ordered')[0]) {
                                    $scope.filter.ordered = true;
                                }
                                treatmentOrders = true
                            } else {
                                $scope.filter.all = true;
                            }
                        };

                        if ($location.path() === "/order/") {
                            $scope.filter.current = false;

                            if (treatmentOrders === "onlyOrders") {
                                $scope.filter = new Object();
                                $scope.filter.orders = true;
                                $scope.global_search.filter_by.orders = true;
                            } else {
                                $scope.filter.orders = false;
                                $scope.global_search.filter_by.orders = false;
                            }


                            if ($scope.filter.mo4) {
                                if ($scope.global_search.filter_by.filter_status.indexOf(angular.element('#mo4')[0].value) == -1)
                                    $scope.global_search.filter_by.filter_status.push(angular.element('#mo4')[0].value);
                            } else if ($scope.filter.mo4 != undefined) {
                                var index = $scope.global_search.filter_by.filter_status.indexOf(angular.element('#mo4')[0].value);
                                if (index !== -1) {
                                    $scope.global_search.filter_by.filter_status.splice(index, 1);
                                };
                            };
                            if ($scope.filter.mo6) {
                                if ($scope.global_search.filter_by.filter_status.indexOf(angular.element('#mo6')[0].value) == -1)
                                    $scope.global_search.filter_by.filter_status.push(angular.element('#mo6')[0].value);
                            } else if ($scope.filter.mo6 != undefined) {
                                var index = $scope.global_search.filter_by.filter_status.indexOf(angular.element('#mo6')[0].value);
                                if (index !== -1) {
                                    $scope.global_search.filter_by.filter_status.splice(index, 1);
                                };
                            };

                            if ($scope.filter.mo9) {
                                if ($scope.global_search.filter_by.filter_status.indexOf(angular.element('#mo9')[0].value) == -1)
                                    $scope.global_search.filter_by.filter_status.push(angular.element('#mo9')[0].value);
                            } else if ($scope.filter.mo9 != undefined) {
                                var index = $scope.global_search.filter_by.filter_status.indexOf(angular.element('#mo9')[0].value);
                                if (index !== -1) {
                                    $scope.global_search.filter_by.filter_status.splice(index, 1);
                                };
                            };


                            $scope.search({ which: 13 });
                            return;

                        }

                        //#Start filter by type
                        if ($scope.filter.op) {
                            if ($scope.global_search.filter_by.filter_type.indexOf(angular.element('#op')[0].value) == -1)
                                $scope.global_search.filter_by.filter_type.push(angular.element('#op')[0].value);
                        } else if ($scope.filter.op != undefined) {
                            var index = $scope.global_search.filter_by.filter_type.indexOf(angular.element('#op')[0].value);
                            if (index !== -1) {
                                $scope.global_search.filter_by.filter_type.splice(index, 1);
                            };
                        };
                        if ($scope.filter.ac) {
                            if ($scope.global_search.filter_by.filter_type.indexOf(angular.element('#ac')[0].value) == -1)
                                $scope.global_search.filter_by.filter_type.push(angular.element('#ac')[0].value);
                        } else if ($scope.filter.ac != undefined) {
                            var index = $scope.global_search.filter_by.filter_type.indexOf(angular.element('#ac')[0].value);
                            if (index !== -1) {
                                $scope.global_search.filter_by.filter_type.splice(index, 1);
                            };
                        };

                        if ($scope.filter.oct) {
                            if ($scope.global_search.filter_by.filter_type.indexOf(angular.element('#oct')[0].value) == -1)
                                $scope.global_search.filter_by.filter_type.push(angular.element('#oct')[0].value);
                        } else if ($scope.filter.oct != undefined) {
                            var index = $scope.global_search.filter_by.filter_type.indexOf(angular.element('#oct')[0].value);
                            if (index !== -1) {
                                $scope.global_search.filter_by.filter_type.splice(index, 1);
                            };
                        };
                        //#End filter by type
                        if ($scope.filter.ac1) {
                            if ($scope.global_search.filter_by.filter_status.indexOf(angular.element('#ac1')[0].value) == -1)
                                $scope.global_search.filter_by.filter_status.push(angular.element('#ac1')[0].value);
                        } else if ($scope.filter.ac1 != undefined) {
                            var index = $scope.global_search.filter_by.filter_status.indexOf(angular.element('#ac1')[0].value);
                            if (index !== -1) {
                                $scope.global_search.filter_by.filter_status.splice(index, 1);
                            };
                        };
                        if ($scope.filter.ac3) {
                            if ($scope.global_search.filter_by.filter_status.indexOf(angular.element('#ac3')[0].value) == -1)
                                $scope.global_search.filter_by.filter_status.push(angular.element('#ac3')[0].value);
                        } else if ($scope.filter.ac3 != undefined) {
                            var index = $scope.global_search.filter_by.filter_status.indexOf("ac3");
                            if (index !== -1) {
                                $scope.global_search.filter_by.filter_status.splice(index, 1);
                            };
                        };
                        if ($scope.filter.ac4) {
                            if ($scope.global_search.filter_by.filter_status.indexOf(angular.element('#ac4')[0].value) == -1)
                                $scope.global_search.filter_by.filter_status.push(angular.element('#ac4')[0].value);
                        } else if ($scope.filter.ac4 != undefined) {
                            var index = $scope.global_search.filter_by.filter_status.indexOf(angular.element('#ac4')[0].value);
                            if (index !== -1) {
                                $scope.global_search.filter_by.filter_status.splice(index, 1);
                            };
                        };

                        // filter oct
                        if ($scope.filter.oct1) {
                            if ($scope.global_search.filter_by.filter_status.indexOf(angular.element('#oct1')[0].value) == -1)
                                $scope.global_search.filter_by.filter_status.push(angular.element('#oct1')[0].value);
                        } else if ($scope.filter.oct1 != undefined) {
                            var index = $scope.global_search.filter_by.filter_status.indexOf(angular.element('#oct1')[0].value);
                            if (index !== -1) {
                                $scope.global_search.filter_by.filter_status.splice(index, 1);
                            };
                        };
                        if ($scope.filter.oct3) {
                            if ($scope.global_search.filter_by.filter_status.indexOf(angular.element('#oct3')[0].value) == -1)
                                $scope.global_search.filter_by.filter_status.push(angular.element('#oct3')[0].value);
                        } else if ($scope.filter.oct3 != undefined) {
                            var index = $scope.global_search.filter_by.filter_status.indexOf("oct3");
                            if (index !== -1) {
                                $scope.global_search.filter_by.filter_status.splice(index, 1);
                            };
                        };
                        if ($scope.filter.oct4) {
                            if ($scope.global_search.filter_by.filter_status.indexOf(angular.element('#oct4')[0].value) == -1)
                                $scope.global_search.filter_by.filter_status.push(angular.element('#oct4')[0].value);
                        } else if ($scope.filter.oct4 != undefined) {
                            var index = $scope.global_search.filter_by.filter_status.indexOf(angular.element('#oct4')[0].value);
                            if (index !== -1) {
                                $scope.global_search.filter_by.filter_status.splice(index, 1);
                            };
                        };
                        if ($scope.filter.oct5) {
                            if ($scope.global_search.filter_by.filter_status.indexOf(angular.element('#oct5')[0].value) == -1)
                                $scope.global_search.filter_by.filter_status.push(angular.element('#oct5')[0].value);
                        } else if ($scope.filter.oct5 != undefined) {
                            var index = $scope.global_search.filter_by.filter_status.indexOf("oct5");
                            if (index !== -1) {
                                $scope.global_search.filter_by.filter_status.splice(index, 1);
                            };
                        };
                        if ($scope.filter.oct6) {
                            if ($scope.global_search.filter_by.filter_status.indexOf(angular.element('#oct6')[0].value) == -1)
                                $scope.global_search.filter_by.filter_status.push(angular.element('#oct6')[0].value);
                        } else if ($scope.filter.oct6 != undefined) {
                            var index = $scope.global_search.filter_by.filter_status.indexOf(angular.element('#oct6')[0].value);
                            if (index !== -1) {
                                $scope.global_search.filter_by.filter_status.splice(index, 1);
                            };
                        };

                        //filter FS statuses
                        if ($scope.filter.fs1) {
                            if ($scope.global_search.filter_by.filter_status.indexOf(angular.element('#ready')[0].value) == -1)
                                $scope.global_search.filter_by.filter_status.push(angular.element('#ready')[0].value);
                        } else if ($scope.filter.fs1 != undefined) {
                            var index = $scope.global_search.filter_by.filter_status.indexOf(angular.element('#ready')[0].value);
                            if (index !== -1) {
                                $scope.global_search.filter_by.filter_status.splice(index, 1);
                            };
                        };
                        if ($scope.filter.fs2) {
                            if ($scope.global_search.filter_by.filter_status.indexOf(angular.element('#submitted')[0].value) == -1)
                                $scope.global_search.filter_by.filter_status.push(angular.element('#submitted')[0].value);
                        } else if ($scope.filter.fs2 != undefined) {
                            var index = $scope.global_search.filter_by.filter_status.indexOf(angular.element('#submitted')[0].value);
                            if (index !== -1) {
                                $scope.global_search.filter_by.filter_status.splice(index, 1);
                            };
                        };
                        if ($scope.filter.fs4) {
                            if ($scope.global_search.filter_by.filter_status.indexOf(angular.element('#confirmed')[0].value) == -1)
                                $scope.global_search.filter_by.filter_status.push(angular.element('#confirmed')[0].value);
                        } else if ($scope.filter.fs4 != undefined) {
                            var index = $scope.global_search.filter_by.filter_status.indexOf(angular.element('#confirmed')[0].value);
                            if (index !== -1) {
                                $scope.global_search.filter_by.filter_status.splice(index, 1);
                            };
                        };
                        if ($scope.filter.fs6) {
                            if ($scope.global_search.filter_by.filter_status.indexOf(angular.element('#correction')[0].value) == -1)
                                $scope.global_search.filter_by.filter_status.push(angular.element('#correction')[0].value);
                        } else if ($scope.filter.fs6 != undefined) {
                            var index = $scope.global_search.filter_by.filter_status.indexOf(angular.element('#correction')[0].value);
                            if (index !== -1) {
                                $scope.global_search.filter_by.filter_status.splice(index, 1);
                            };
                        };
                        if ($scope.filter.fs8) {
                            if ($scope.global_search.filter_by.filter_status.indexOf(angular.element('#cancelled')[0].value) == -1)
                                $scope.global_search.filter_by.filter_status.push(angular.element('#cancelled')[0].value);
                        } else if ($scope.filter.fs8 != undefined) {
                            var index = $scope.global_search.filter_by.filter_status.indexOf(angular.element('#cancelled')[0].value);
                            if (index !== -1) {
                                $scope.global_search.filter_by.filter_status.splice(index, 1);
                            };
                        };
                        if ($scope.filter.fs7) {
                            if ($scope.global_search.filter_by.filter_status.indexOf(angular.element('#reclaim')[0].value) == -1)
                                $scope.global_search.filter_by.filter_status.push(angular.element('#reclaim')[0].value);
                        } else if ($scope.filter.fs7 != undefined) {
                            var index = $scope.global_search.filter_by.filter_status.indexOf(angular.element('#reclaim')[0].value);
                            if (index !== -1) {
                                $scope.global_search.filter_by.filter_status.splice(index, 1);
                            };
                        };
                        if ($scope.filter.fs12) {
                            if ($scope.global_search.filter_by.filter_status.indexOf(angular.element('#paid')[0].value) == -1)
                                $scope.global_search.filter_by.filter_status.push(angular.element('#paid')[0].value);
                        } else if ($scope.filter.fs12 != undefined) {
                            var index = $scope.global_search.filter_by.filter_status.indexOf(angular.element('#paid')[0].value);
                            if (index !== -1) {
                                $scope.global_search.filter_by.filter_status.splice(index, 1);
                            };
                        };
                        if ($scope.filter.fs21) {
                            if ($scope.global_search.filter_by.filter_status.indexOf(angular.element('#fs21')[0].value) == -1)
                                $scope.global_search.filter_by.filter_status.push(angular.element('#fs21')[0].value);
                        } else if ($scope.filter.fs21 != undefined) {
                            var index = $scope.global_search.filter_by.filter_status.indexOf(angular.element('#fs21')[0].value);
                            if (index !== -1) {
                                $scope.global_search.filter_by.filter_status.splice(index, 1);
                            };
                        };
                        if ($scope.filter.fs13) {
                            if ($scope.global_search.filter_by.filter_status.indexOf(angular.element('#fs13')[0].value) == -1)
                                $scope.global_search.filter_by.filter_status.push(angular.element('#fs13')[0].value);
                        } else if ($scope.filter.fs13 != undefined) {
                            var index = $scope.global_search.filter_by.filter_status.indexOf(angular.element('#fs13')[0].value);
                            if (index !== -1) {
                                $scope.global_search.filter_by.filter_status.splice(index, 1);
                            };
                        };
                        //End filter by FS statuses
                        //Planning filter

                        if ($scope.filter.current) {
                            if (treatmentOrders === true) {
                                if ($location.path() !== '/patient/') {
                                    $scope.filter = new Object();
                                }

                                $scope.filter.current = true;

                                if (angular.element('#ordered')[0]) {
                                    $scope.filter.ordered = true;
                                }
                                $scope.global_search.filter_by.filter_current = true;
                                $scope.global_search.filter_by.filter_type = [];
                                $scope.global_search.filter_by.filter_status = [];
                                $scope.global_search.filter_by.orders = null;
                                $scope.global_search.filter_by.localization = null;

                                $scope.ItemCheckedtreatmentorder = '';
                                $scope.ItemCheckedorder = '';
                                $scope.ItemCheckedtreatment = '';
                            } else {
                                $scope.filter.current = false;
                                $scope.global_search.filter_by.filter_current = false;
                            }
                        };

                        if ($scope.filter.op1) {

                            $scope.global_search.filter_by.filter_current = false;
                            if ($scope.global_search.filter_by.filter_status.indexOf(angular.element('#scheduled')[0].value) == -1)
                                $scope.global_search.filter_by.filter_status.push(angular.element('#scheduled')[0].value);
                        } else if ($scope.filter.op1 !== undefined) {
                            var index = $scope.global_search.filter_by.filter_status.indexOf(angular.element('#scheduled')[0].value);
                            if (index !== -1) {
                                $scope.global_search.filter_by.filter_status.splice(index, 1);
                            };
                        };
                        if ($scope.filter.op3) {

                            $scope.global_search.filter_by.filter_current = false;
                            if ($scope.global_search.filter_by.filter_status.indexOf(angular.element('#overdue')[0].value) == -1)
                                $scope.global_search.filter_by.filter_status.push(angular.element('#overdue')[0].value);
                        } else if ($scope.filter.op3 !== undefined) {
                            var index = $scope.global_search.filter_by.filter_status.indexOf(angular.element('#overdue')[0].value);
                            if (index !== -1) {
                                $scope.global_search.filter_by.filter_status.splice(index, 1);
                            };
                        };

                        if ($scope.filter.op4) {

                            $scope.global_search.filter_by.filter_current = false;
                            if ($scope.global_search.filter_by.filter_status.indexOf(angular.element('#canceleddeleted')[0].value) == -1)
                                $scope.global_search.filter_by.filter_status.push(angular.element('#canceleddeleted')[0].value);
                        } else if ($scope.filter.op4 !== undefined) {
                            var index = $scope.global_search.filter_by.filter_status.indexOf(angular.element('#canceleddeleted')[0].value);
                            if (index !== -1) {
                                $scope.global_search.filter_by.filter_status.splice(index, 1);
                            };
                        };

                        if (treatmentOrders === "treatmentorder") {

                            $scope.filter.all = false;
                            $scope.global_search.filter_by.is_all = false;
                            $scope.filter.current = false;
                            $scope.global_search.filter_by.filter_current = false;
                            if ($scope.ItemCheckedtreatmentorder !== " active") {
                                $scope.ItemCheckedtreatmentorder = ' active';
                                $scope.ItemCheckedorder = '';
                                $scope.ItemCheckedtreatment = '';
                                $scope.filter.orders = true;
                                $scope.filter.treatments = false;
                                $scope.global_search.filter_by.localization = "!-";
                                $scope.global_search.filter_by.orders = true;
                            }
                            else {
                                $scope.ItemCheckedtreatmentorder = '';

                                $scope.global_search.filter_by.localization = null;
                                $scope.global_search.filter_by.orders = null;
                            };
                        };
                        if (treatmentOrders === "treatments") {

                            $scope.filter.all = false;
                            $scope.filter.current = false;
                            $scope.global_search.filter_by.is_all = false;
                            $scope.global_search.filter_by.filter_current = false;
                            $scope.ItemCheckedtreatmentorder = '';
                            $scope.ItemCheckedorder = '';
                            if ($scope.ItemCheckedtreatment !== " active") {
                                $scope.ItemCheckedtreatment = ' active';
                                $scope.filter.treatmentOrders = false;
                                $scope.filter.orders = false;
                                $scope.global_search.filter_by.localization = null;
                                $scope.global_search.filter_by.orders = false;
                            }
                            else {
                                $scope.ItemCheckedtreatment = '';
                                $scope.global_search.filter_by.localization = null;
                                $scope.global_search.filter_by.orders = null;
                            };
                        };

                        //End Planning filter
                    };
                    if ($scope.global_search.filter_by.filter_type.length === 0) {
                        if ($scope.global_search.filter_by.filter_status.length === 0 && ($location.path() !== "/planning/" && $location.path() !== "/order/" && $location.path() !== '/oct/' && $location.path() !== '/aftercare/' && $location.path() !== '/patient/')) {
                            $scope.filter.all = true;
                        }

                        if ($location.path() !== '/patient/' && $scope.global_search.filter_by.filter_status.length === 0 && $scope.global_search.filter_by.filter_current === false && $scope.global_search.filter_by.filter_type.length === 0 && $scope.global_search.filter_by.localization === null && $scope.global_search.filter_by.orders === null && $scope.filter.all === false) {
                            $scope.filter = new Object();
                            $scope.filter.current = true;

                            if (angular.element('#ordered')[0]) {
                                $scope.filter.ordered = true;
                            }
                            $scope.global_search.filter_by.filter_current = true;
                        };

                        if (angular.element('#op')[0] !== undefined)
                            $scope.global_search.filter_by.filter_type = [angular.element('#op')[0].value, angular.element('#ac')[0].value, angular.element('#oct')[0].value];

                        if (angular.element('#practice')[0] !== undefined)
                            $scope.global_search.filter_by.filter_type = [angular.element('#practice')[0].value, angular.element('#doctor')[0].value];
                    };
                    
                    if ($location.path().indexOf('settlement') > -1) {
                        if (!$scope.filter.ops_with_overdue_acs) {
                            var fs_statuses = ["fs1", "fs2", "fs4", "fs6", "fs7", "fs8", "fs12", "fs21", "fs13", "op", "ac", "oct"];
                            var any_fs_status_selected = false;
                            for (var i = 0; i < fs_statuses.length; i++) {
                                if ($scope.filter[fs_statuses[i]]) {
                                    any_fs_status_selected = true;
                                    break;
                                };
                            };
                            $scope.filter.all = !any_fs_status_selected;
                        } else {
                            $scope.filter.all = false;
                        }
                    };

                    if (deselect) {
                        switch (deselect) {
                            case 'this':
                                unselectThisPractice();
                                break;

                            case 'different':
                                unselectDifferentPractice();
                                break;

                            default:
                                break;
                        }
                    }

                    $scope.search({ which: 13 });
                };

                function unselectDifferentPractice() {
                    if ($scope.filter.differentPractice) {
                        $scope.filter.differentPractice = false;
                    }
                };

                function unselectThisPractice() {
                    if ($scope.filter.thisPractice) {
                        $scope.filter.thisPractice = false;
                    }
                };


                $scope.$on('SetFilter', function (event, data) {
                    $scope.filter.all = false;
                    $scope.filter = new Object();
                    if (data.status === 'fs3') {
                        $scope.filter.fs3 = true;
                    };
                    if (data.status === 'fs5') {
                        $scope.filter.fs5 = true;
                    };

                    if (data.patientName !== undefined) {
                        $scope.global_search.text_search = data.patientName;
                    };
                });

                $scope.isSubmitDisabled = function () {
                    return ($scope.global_search.date_from === '' || $scope.global_search.date_from === null || $scope.global_search.date_from === undefined) && ($scope.global_search.date_to === '' || $scope.global_search.date_to === null || $scope.global_search.date_to === undefined);
                };

            };
        }]);
})();
