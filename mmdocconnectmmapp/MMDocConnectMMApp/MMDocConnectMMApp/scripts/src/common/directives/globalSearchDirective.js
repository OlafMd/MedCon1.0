/// <reference path="../view/globalSearchTemplate.html" />
define(['angularAMD'], function (angularAMD) {
    angularAMD.directive('globalSearchDirective', ['$location', '$compile', '$http', function ($location, $compile, $http) {

        return {
            scope: {},
            replace: true,
            restrict: 'E',
            controller: globalSearchController,
            link: linker
        };

        function getTemplate() {
            var template = '';
            var a = $location;

            switch ($location.path()) {
                case '/treatment/':
                    template = 'scripts/src/common/view/globalSearchTemplates/globalSearchTreatmentTemplate.html';
                    break;
                case '/archive/':
                    template = 'scripts/src/common/view/globalSearchTemplates/globalSearchArchiveTemplate.html';
                    break;
                case '/doctor/':
                    template = 'scripts/src/common/view/globalSearchTemplates/globalSearchDoctorTemplate.html';
                    break;
                case '/order/':
                    template = 'scripts/src/common/view/globalSearchTemplates/globalSearchOrdersTemplate.html';
                    break;
                case '/patient/':
                    template = 'scripts/src/common/view/globalSearchTemplates/globalSearchTemplate.html';
                    break;
                default:
                    template = 'scripts/src/common/view/globalSearchTemplates/globalSearchTemplateNoSearch.html';
                    break;
            };

            return template;
        };

        function linker(scope, element, attrs) {
            scope.$on("$routeChangeSuccess", function (event, current, previous) {
                if (current !== previous) {
                    $http.get(getTemplate())
                      .then(function (response) {
                          element.html($compile(response.data)(scope));
                      });
                }
            });

            element.bind('mousedown', function (event) {
                scope.mousedown_on = event.target.id;
            });
        };

        function globalSearchController($scope, $rootScope, $location, $filter, ngDialog) {
            $scope.global_search = new Object();
            $scope.global_search.date_from = '1-1-1';
            $scope.global_search.date_to = $filter('date')(new Date(), 'yyyy-MM-dd');
            $scope.global_search.filter_by = new Object();
            $scope.global_search.filter_by.filter_status = [];
            $scope.global_search.filter_by.filter_type = [];
            $scope.filter = new Object();
            $scope.filter.all = true;
            $scope.today = $filter('date')(new Date(), 'MM.dd.yyyy');
            $scope.checkBoxParameters = [];

            $scope.search = function () {
                $rootScope.$broadcast("GlobalSearch", $scope.global_search);
                var wrapper = angular.element('#wrapper')[0];
                if (wrapper !== undefined)
                    wrapper.scrollTop = 0;
            };

            //on route change reset search parameters
            $rootScope.$on('$routeChangeStart', function (scope, next, current) {
                $scope.global_search = new Object();
                $scope.global_search.filter_by = new Object();
                $scope.global_search.filter_by.filter_status = [];
                $scope.global_search.filter_by.filter_type = [];
                $scope.filter = new Object();
                $scope.filter.all = true;
                $scope.checkBoxParameters = [];

                switch ($location.path()) {
                    case '/dashboard':
                        template = 'scripts/src/common/view/global_search_templates/globalSearchTemplate.html';
                        break;
                    case '/treatment':
                        template = 'scripts/src/common/view/global_search_templates/globalSearchTreatmentTemplate.html';
                        break;
                    case '/order':
                        template = 'scripts/src/common/view/globalSearchTemplates/globalSearchOrdersTemplate.html';
                        break;
                    default:
                        template = 'scripts/src/common/view/global_search_templates/globalSearchTemplate.html';
                        break;
                };

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

            $scope.getIsDateSelected = function () {
                return ($scope.global_search.date_from !== undefined && $scope.global_search.date_from !== '1-1-1') || ($scope.global_search.date_to !== undefined && $scope.global_search.date_to !== $filter('date')(new Date(), 'yyyy-MM-dd'));
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
                $scope.search();
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
                var is_from_date_valid = $scope.global_search.date_from !== '' && $scope.global_search.date_from !== undefined && $scope.global_search.date_from !== null ? isValidDate($scope.global_search.date_from) : true;
                var is_to_date_valid = $scope.global_search.date_to !== '' && $scope.global_search.date_to !== undefined && $scope.global_search.date_to !== null ? isValidDate($scope.global_search.date_to) : true;

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
                $scope.search();
            };

            $scope.prepareSearch = function (is_all) {
                $scope.was_all_selected = is_all;
                $scope.filter.all = is_all;

                if ($scope.filter.all) {
                    $scope.global_search.filter_by = new Object();
                    $scope.global_search.filter_by.filter_status = [];
                    $scope.global_search.filter_by.filter_type = [];
                    $scope.global_search.date_from = '1-1-1';
                    $scope.global_search.date_to = $filter('date')(new Date(), 'yyyy-MM-dd');
                    $scope.global_search.text_search = '';
                    $scope.filter = new Object();
                    $scope.filter.all = true;
                } else {
                    $scope.global_search.filter_by.filter_type = [];
                    $scope.global_search.filter_by.filter_status = [];
                    if ($scope.filter.op) {
                        if ($scope.global_search.filter_by.filter_type.indexOf(angular.element('#op')[0].value) == -1)
                            $scope.global_search.filter_by.filter_type.push(angular.element('#op')[0].value);
                    } else if ($scope.filter.op != undefined) {
                        var index = $scope.global_search.filter_by.filter_type.indexOf(angular.element('#op')[0].value);
                        if (index !== -1) {
                            $scope.global_search.filter_by.filter_type.splice(index, 1);
                        };
                    };
                    if ($scope.filter.mo1) {
                        if ($scope.global_search.filter_by.filter_status.indexOf(angular.element('#mo1')[0].value) == -1)
                            $scope.global_search.filter_by.filter_status.push(angular.element('#mo1')[0].value);
                    } else if ($scope.filter.mo1 != undefined) {
                        var index = $scope.global_search.filter_by.filter_status.indexOf(angular.element('#mo1')[0].value);
                        if (index !== -1) {
                            $scope.global_search.filter_by.filter_status.splice(index, 1);
                        };
                    };
                    if ($scope.filter.mo10) {
                        if ($scope.global_search.filter_by.filter_status.indexOf(angular.element('#mo10')[0].value) == -1)
                            $scope.global_search.filter_by.filter_status.push(angular.element('#mo10')[0].value);
                    } else if ($scope.filter.mo10 != undefined) {
                        var index = $scope.global_search.filter_by.filter_status.indexOf(angular.element('#mo10')[0].value);
                        if (index !== -1) {
                            $scope.global_search.filter_by.filter_status.splice(index, 1);
                        };
                    };
                    if ($scope.filter.mo2) {
                        if ($scope.global_search.filter_by.filter_status.indexOf(angular.element('#mo2')[0].value) == -1)
                            $scope.global_search.filter_by.filter_status.push(angular.element('#mo2')[0].value);
                    } else if ($scope.filter.mo2 != undefined) {
                        var index = $scope.global_search.filter_by.filter_status.indexOf(angular.element('#mo2')[0].value);
                        if (index !== -1) {
                            $scope.global_search.filter_by.filter_status.splice(index, 1);
                        };
                    };
                    if ($scope.filter.mo4) {
                        if ($scope.global_search.filter_by.filter_status.indexOf(angular.element('#mo4')[0].value) == -1)
                            $scope.global_search.filter_by.filter_status.push(angular.element('#mo4')[0].value);
                    } else if ($scope.filter.mo4 != undefined) {
                        var index = $scope.global_search.filter_by.filter_status.indexOf(angular.element('#mo4')[0].value);
                        if (index !== -1) {
                            $scope.global_search.filter_by.filter_status.splice(index, 1);
                        };
                    };
                    if ($scope.filter.mo3) {
                        if ($scope.global_search.filter_by.filter_status.indexOf(angular.element('#mo3')[0].value) == -1)
                            $scope.global_search.filter_by.filter_status.push(angular.element('#mo3')[0].value);
                    } else if ($scope.filter.momo3 != undefined) {
                        var index = $scope.global_search.filter_by.filter_status.indexOf(angular.element('#mo3')[0].value);
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
                    if ($scope.filter.overdue) {
                        if ($scope.global_search.filter_by.filter_status.indexOf(angular.element('#overdue')[0].value) == -1)
                            $scope.global_search.filter_by.filter_status.push(angular.element('#overdue')[0].value);
                    } else if ($scope.filter.overdue != undefined) {
                        var index = $scope.global_search.filter_by.filter_status.indexOf(angular.element('#overdue')[0].value);
                        if (index !== -1) {
                            $scope.global_search.filter_by.filter_status.splice(index, 1);
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
                    if ($scope.filter.fs3) {
                        if ($scope.global_search.filter_by.filter_status.indexOf(angular.element('#on_hold')[0].value) == -1)
                            $scope.global_search.filter_by.filter_status.push(angular.element('#on_hold')[0].value);
                    } else if ($scope.filter.fs3 != undefined) {
                        var index = $scope.global_search.filter_by.filter_status.indexOf(angular.element('#on_hold')[0].value);
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
                    if ($scope.filter.fs5) {
                        if ($scope.global_search.filter_by.filter_status.indexOf(angular.element('#errors')[0].value) == -1)
                            $scope.global_search.filter_by.filter_status.push(angular.element('#errors')[0].value);
                    } else if ($scope.filter.fs5 != undefined) {
                        var index = $scope.global_search.filter_by.filter_status.indexOf(angular.element('#errors')[0].value);
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
                    if ($scope.filter.fs7) {
                        if ($scope.global_search.filter_by.filter_status.indexOf(angular.element('#paid')[0].value) == -1)
                            $scope.global_search.filter_by.filter_status.push(angular.element('#paid')[0].value);
                    } else if ($scope.filter.fs7 != undefined) {
                        var index = $scope.global_search.filter_by.filter_status.indexOf(angular.element('#paid')[0].value);
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
                    if ($scope.filter.fs9) {
                        if ($scope.global_search.filter_by.filter_status.indexOf(angular.element('#rejected')[0].value) == -1)
                            $scope.global_search.filter_by.filter_status.push(angular.element('#rejected')[0].value);
                    } else if ($scope.filter.fs9 != undefined) {
                        var index = $scope.global_search.filter_by.filter_status.indexOf(angular.element('#rejected')[0].value);
                        if (index !== -1) {
                            $scope.global_search.filter_by.filter_status.splice(index, 1);
                        };
                    };
                    if ($scope.filter.fs10) {
                        if ($scope.global_search.filter_by.filter_status.indexOf(angular.element('#reclaim')[0].value) == -1)
                            $scope.global_search.filter_by.filter_status.push(angular.element('#reclaim')[0].value);
                    } else if ($scope.filter.fs10 != undefined) {
                        var index = $scope.global_search.filter_by.filter_status.indexOf(angular.element('#reclaim')[0].value);
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
                    if ($scope.filter.settlement) {
                        if ($scope.global_search.filter_by.filter_status.indexOf(angular.element('#settlement')[0].value) == -1)
                            $scope.global_search.filter_by.filter_status.push(angular.element('#settlement')[0].value);
                    } else if ($scope.filter.settlement != undefined) {
                        var index = $scope.global_search.filter_by.filter_status.indexOf(angular.element('#settlement')[0].value);
                        if (index !== -1) {
                            $scope.global_search.filter_by.filter_status.splice(index, 1);
                        };
                    };
                    if ($scope.filter.edifact) {
                        if ($scope.global_search.filter_by.filter_type.indexOf(angular.element('#edifact')[0].value) == -1) {
                            $scope.global_search.filter_by.filter_type.push(angular.element('#edifact')[0].value);
                            $scope.global_search.filter_by.filter_status.push(angular.element('#edifact')[0].value);
                        }
                    } else if ($scope.filter.edifact != undefined) {
                        var index = $scope.global_search.filter_by.filter_type.indexOf(angular.element('#edifact')[0].value);
                        var index2 = $scope.global_search.filter_by.filter_status.indexOf(angular.element('#edifact')[0].value);
                        if (index !== -1) {
                            $scope.global_search.filter_by.filter_type.splice(index, 1);
                        };
                        if (index2 !== -1) {
                            $scope.global_search.filter_by.filter_status.splice(index2, 1);
                        };
                    };
                    if ($scope.filter.datev) {
                        if ($scope.global_search.filter_by.filter_status.indexOf(angular.element('#datev')[0].value) == -1)
                            $scope.global_search.filter_by.filter_status.push(angular.element('#datev')[0].value);
                    } else if ($scope.filter.datev != undefined) {
                        var index = $scope.global_search.filter_by.filter_status.indexOf(angular.element('#datev')[0].value);
                        if (index !== -1) {
                            $scope.global_search.filter_by.filter_status.splice(index, 1);
                        };
                    };
                    if ($scope.filter.kvimport) {
                        if ($scope.global_search.filter_by.filter_status.indexOf(angular.element('#kvimport')[0].value) == -1)
                            $scope.global_search.filter_by.filter_status.push(angular.element('#kvimport')[0].value);
                    } else if ($scope.filter.kvimport != undefined) {
                        var index = $scope.global_search.filter_by.filter_status.indexOf(angular.element('#kvimport')[0].value);
                        if (index !== -1) {
                            $scope.global_search.filter_by.filter_status.splice(index, 1);
                        };
                    };
                    if ($scope.filter.kverror) {
                        if ($scope.global_search.filter_by.filter_status.indexOf(angular.element('#kverror')[0].value) == -1)
                            $scope.global_search.filter_by.filter_status.push(angular.element('#kverror')[0].value);
                    } else if ($scope.filter.kverror != undefined) {
                        var index = $scope.global_search.filter_by.filter_status.indexOf(angular.element('#kverror')[0].value);
                        if (index !== -1) {
                            $scope.global_search.filter_by.filter_status.splice(index, 1);
                        };
                    };
                    if ($scope.filter.steribase) {
                        if ($scope.global_search.filter_by.filter_status.indexOf(angular.element('#steribase')[0].value) == -1)
                            $scope.global_search.filter_by.filter_status.push(angular.element('#steribase')[0].value);
                    } else if ($scope.filter.steribase != undefined) {
                        var index = $scope.global_search.filter_by.filter_status.indexOf(angular.element('#steribase')[0].value);
                        if (index !== -1) {
                            $scope.global_search.filter_by.filter_status.splice(index, 1);
                        };
                    };

                    if ($scope.filter.doctor) {
                        if ($scope.global_search.filter_by.filter_type.indexOf(angular.element('#doctor')[0].value) == -1)
                            $scope.global_search.filter_by.filter_type.push(angular.element('#doctor')[0].value);
                    } else if ($scope.filter.doctor != undefined) {
                        var index = $scope.global_search.filter_by.filter_type.indexOf(angular.element('#doctor')[0].value);
                        if (index !== -1) {
                            $scope.global_search.filter_by.filter_type.splice(index, 1);
                        };
                    };
                    if ($scope.filter.practice) {
                        if ($scope.global_search.filter_by.filter_type.indexOf(angular.element('#practice')[0].value) == -1)
                            $scope.global_search.filter_by.filter_type.push(angular.element('#practice')[0].value);
                    } else if ($scope.filter.practice != undefined) {
                        var index = $scope.global_search.filter_by.filter_type.indexOf(angular.element('#practice')[0].value);
                        if (index !== -1) {
                            $scope.global_search.filter_by.filter_type.splice(index, 1);
                        };
                    };
                    if ($scope.filter.inaktiv) {
                        if ($scope.global_search.filter_by.filter_status.indexOf(angular.element('#inaktiv')[0].value) == -1)
                            $scope.global_search.filter_by.filter_status.push(angular.element('#inaktiv')[0].value);
                    } else if ($scope.filter.inaktiv != undefined) {
                        var index = $scope.global_search.filter_by.filter_status.indexOf(angular.element('#inaktiv')[0].value);
                        if (index !== -1) {
                            $scope.global_search.filter_by.filter_status.splice(index, 1);
                        };
                    };
                    if ($scope.filter.aktiv) {
                        if ($scope.global_search.filter_by.filter_status.indexOf(angular.element('#aktiv')[0].value) == -1)
                            $scope.global_search.filter_by.filter_status.push(angular.element('#aktiv')[0].value);
                    } else if ($scope.filter.aktiv != undefined) {
                        var index = $scope.global_search.filter_by.filter_status.indexOf(angular.element('#aktiv')[0].value);
                        if (index !== -1) {
                            $scope.global_search.filter_by.filter_status.splice(index, 1);
                        };
                    };
                    if ($scope.filter.temp) {
                        if ($scope.global_search.filter_by.filter_status.indexOf(angular.element('#temp')[0].value) == -1)
                            $scope.global_search.filter_by.filter_status.push(angular.element('#temp')[0].value);
                    } else if ($scope.filter.temp != undefined) {
                        var index = $scope.global_search.filter_by.filter_status.indexOf(angular.element('#temp')[0].value);
                        if (index !== -1) {
                            $scope.global_search.filter_by.filter_status.splice(index, 1);
                        };
                    };
                };

                if ($scope.global_search.filter_by.filter_type.length === 0) {
                    if ($scope.global_search.filter_by.filter_status.length === 0)
                        $scope.filter.all = true;
                    if (angular.element('#op')[0] !== undefined)
                        $scope.global_search.filter_by.filter_type = [angular.element('#op')[0].value, angular.element('#ac')[0].value, angular.element('#oct')[0].value];

                    if (angular.element('#practice')[0] !== undefined)
                        $scope.global_search.filter_by.filter_type = [angular.element('#practice')[0].value, angular.element('#doctor')[0].value];
                };



                $scope.search();
            };

            $scope.$on('SetFilter', function (event, data) {
                $scope.filter.all = false;
                $scope.filter = new Object();
                if (data.status === 'fs3') {
                    $scope.filter.fs3 = true;
                } else if (data.status === 'fs5') {
                    $scope.filter.fs5 = true;
                } else if (data.status === 'temp') {
                    $scope.filter.temp = true;
                };
            });

            function isValidDate(dateString) {
                if (dateString.match(/[a-z]/i)) {
                    return false;
                }
                if (dateString.length !== 10) {
                    return false;
                }

                var yyyy = parseInt(dateString.substr(6, 4));
                var mm = parseInt(dateString.substr(3, 2)) - 1;
                var dd = parseInt(dateString.substr(0, 2));

                var date = new Date(yyyy, mm, dd);

                return date;
            };

            $scope.isSubmitDisabled = function () {
                return ($scope.global_search.date_from === '' || $scope.global_search.date_from === null || $scope.global_search.date_from === undefined) && ($scope.global_search.date_to === '' || $scope.global_search.date_to === null || $scope.global_search.date_to === undefined);
            };

        };
    }]);
});