/*global angular navigator*/

//(function withAngular(angular) {

//  'use strict';

// angular.module('720kb.datepicker', [])

define(['angularAMD'], function (angularAMD) {
    angularAMD.directive('datepicker', ['$window', '$compile', '$locale', '$filter', function manageDirective($window, $compile, $locale, $filter) {

        var A_DAY_IN_MILLISECONDS = 86400000;
        return {
            'restrict': 'AEC',

            //  'templateUrl': 'scripts/src/common/view/datePickerTemplate.html',
            'scope': {
                'dateSet': '@',
                'dateMinLimit': '@',
                'dateMaxLimit': '@',
                dateModel: '=',
                isRight: '='
            },
            'link': function linkingFunction($scope, element, attr) {
                var parentDiv = $('.gray-content-holder');

                var node = element.parent;
                while (node != null) {
                    if (node == parentDiv) {
                        return true;
                    }
                    node = node.parent;
                }



                //get child input
                var selector = attr.selector
                  , thisInput = angular.element(selector ? element[0].querySelector('.' + selector) : element[0].children[0])
                  , theCalendar
                  , defaultPrevButton = '<b class="datepicker-default-button">&lang;</b>'
                  , defaultNextButton = '<b class="datepicker-default-button">&rang;</b>'
                  , prevButton = attr.buttonPrev || defaultPrevButton
                  , nextButton = attr.buttonNext || defaultNextButton
                  , dateFormat = attr.dateFormat
                  , dateMinLimit
                  , dateMaxLimit
                  , date = new Date()
                  , isMouseOn = false
                  , isMouseOnInput = false
                  , datetime = $locale.DATETIME_FORMATS
                  , pageDatepickers
                  , currentDay = undefined

                  , htmlTemplate = '<div class="_720kb-datepicker-calendar" ng-class="{\'calendar-right\': isRight}" ng-blur="hideCalendar()">' +
                  //motnh+year header
                  '<div class="_720kb-datepicker-calendar-header" ng-hide="isMobile()">' +
                  '<div class="_720kb-datepicker-calendar-header-left">' +
                  '<a class="jsblockClose" href="javascript:void(0)" ng-click="prevMonth()" tabIndex="-1">' + prevButton + '</a>' +
                  '</div>' +
                  '<div class="_720kb-datepicker-calendar-header-middle _720kb-datepicker-calendar-month">' +
                  '{{month}} <a tabIndex="-1" href="javascript:void(0)" ng-click="showYearsPagination = !showYearsPagination"><span>{{year}} <i ng-if="!showYearsPagination">&dtrif;</i> <i ng-if="showYearsPagination">&urtri;</i> </span> </a>' +
                  '</div>' +
                  '<div class="_720kb-datepicker-calendar-header-right">' +
                  '<a class="jsblockClose" href="javascript:void(0)" ng-click="nextMonth()" tabIndex="-1">' + nextButton + '</a>' +
                  '</div>' +
                  '</div>' +
                  //Mobile month+year pagination
                  //'<div class="_720kb-datepicker-calendar-header" ng-show="isMobile()">' +
                  //'<div class="_720kb-datepicker-calendar-header-middle _720kb-datepicker-mobile-item _720kb-datepicker-calendar-month">' +
                  //'<select ng-model="month" ng-change="selectedMonthHandle(month)">' +
                  //'<option ng-repeat="item in months" ng-selected="month === item" ng-disabled=\'!isSelectableMaxDate(item + " " + day + ", " + year) || !isSelectableMinDate(item + " " + day + ", " + year)\' ng-value="item">{{item}}</option>' +
                  //'</select>' +
                  //'</div>' +
                  //'</div>' +
                  //'<div class="_720kb-datepicker-calendar-header" ng-show="isMobile()">' +
                  //'<div class="_720kb-datepicker-calendar-header-middle _720kb-datepicker-mobile-item _720kb-datepicker-calendar-month">' +
                  //'<select ng-model="mobileYear" ng-change="setNewYear(mobileYear)">' +
                  //'<option ng-repeat="item in paginationYears" ng-selected="year === item" ng-value="item" ng-disabled="!isSelectableMinYear(item) || !isSelectableMaxYear(item)">{{item}}</option>' +
                  //'</select>' +
                  //'</div>' +
                  //'</div>' +
                  ////years pagination header
                  //'<div class="_720kb-datepicker-calendar-header" ng-show="showYearsPagination">' +
                  //'<div class="_720kb-datepicker-calendar-years-pagination">' +
                  //'<a ng-class="{\'_720kb-datepicker-active\': y === year, \'_720kb-datepicker-disabled\': !isSelectableMaxYear(y) || !isSelectableMinYear(y)}" href="javascript:void(0)" ng-click="setNewYear(y)" ng-repeat="y in paginationYears">{{y}}</a>' +
                  //'</div>' +
                  //'<div class="_720kb-datepicker-calendar-years-pagination-pages">' +
                  //'<a href="javascript:void(0)" ng-click="paginateYears(paginationYears[0])" ng-class="{\'_720kb-datepicker-item-hidden\': paginationYearsPrevDisabled}">' + prevButton + '</a>' +
                  //'<a href="javascript:void(0)" ng-click="paginateYears(paginationYears[paginationYears.length -1 ])" ng-class="{\'_720kb-datepicker-item-hidden\': paginationYearsNextDisabled}">' + nextButton + '</a>' +
                  //'</div>' +
                  //'</div>' +
                  //days column
                  '<div class="_720kb-datepicker-calendar-days-header">' +
                  '<div ng-repeat="d in daysInString" tabIndex="-1"> {{d}} </div> ' +
                  '</div>' +
                  //days
                  '<div class="_720kb-datepicker-calendar-body">' +
                  '<a tabIndex="-1" href="javascript:void(0)" ng-repeat="px in prevMonthDays" class="_720kb-datepicker-calendar-day _720kb-datepicker-disabled">{{px}}</a>' +
                  '<a tabIndex="-1" href="javascript:void(0)" ng-repeat="item in days" ng-click="setDatepickerDay(item)"ng-class="{\'_720kb-datepicker-active\': day === item, \'_720kb-datepicker-disabled\': !isSelectableMinDate(year + \'/\' + monthNumber + \'/\' + item ) || !isSelectableMaxDate(year + \'/\' + monthNumber + \'/\' + item)}" class="_720kb-datepicker-calendar-day jsblockClose">{{item}}</a>' +
                  '<a tabIndex="-1" href="javascript:void(0)" ng-repeat="nx in nextMonthDays" class="_720kb-datepicker-calendar-day _720kb-datepicker-disabled">{{nx}}</a>' +
                  '</div>' +
                  '</div>' +
                  '</div>';


                GetMonthGer = function (monthStr) {
                    var mnth;
                    switch (monthStr) {
                        case "January":
                            mnth = "Januar";
                            break;
                        case "February":
                            mnth = "Februar";
                            break;
                        case "March":
                            mnth = "Marz";
                            break;
                        case "April":
                            mnth = "April";
                            break;
                        case "May":
                            mnth = "Mai";
                            break;
                        case "June":
                            mnth = "Juni";
                            break;
                        case "July":
                            mnth = "Juli";
                            break;
                        case "August":
                            mnth = "August";
                            break;
                        case "September":
                            mnth = "September";
                            break;
                        case "October":
                            mnth = "Oktober";
                            break;
                        case "November":
                            mnth = "November";
                            break;
                        case "December":
                            mnth = "Dezember";
                            break;
                    }
                    return mnth;
                };

                $scope.$watch('dateSet', function dateSetWatcher(value) {
                    if (value) {
                        date = new Date(value);
                        var tempMonth = $filter('date')(date, 'MMMM');
                        $scope.month = GetMonthGer(tempMonth);//December-November like
                        $scope.monthNumber = Number($filter('date')(date, 'MM')); // 01-12 like
                        $scope.day = Number($filter('date')(date, 'dd')); //01-31 like
                        $scope.year = Number($filter('date')(date, 'yyyy'));//2014 like
                    }
                });

                $scope.$watch('dateMinLimit', function dateMinLimitWatcher(value) {
                    if (value) {
                        dateMinLimit = value;
                    }
                });

                $scope.$watch('dateMaxLimit', function dateMaxLimitWatcher(value) {
                    if (value) {
                        dateMaxLimit = value;
                    }
                });

                var tempMonth = $filter('date')(date, 'MMMM');
                $scope.month = GetMonthGer(tempMonth);//December-November like
                $scope.monthNumber = Number($filter('date')(date, 'MM')); // 01-12 like
                $scope.day = Number($filter('date')(date, 'dd')); //01-31 like
                $scope.year = Number($filter('date')(date, 'yyyy'));//2014 like
                $scope.months = datetime.MONTH;

                $scope.daysInString = ['Mo.', 'Di.', 'Mi.', 'Do.', 'Fr.', 'Sa.', 'So.'];

                $scope.$watch('dateModel', function (newVal, oldVal) {
                    if (newVal !== undefined && newVal.length === 10) {
                        $scope.year = parseInt(newVal.substr(6, 4));
                        $scope.monthNumber = parseInt(newVal.substr(3, 2));
                        $scope.day = parseInt(newVal.substr(0, 2));

                        $scope.month = GetMonthGer($filter('date')(new Date($scope.year + '/' + $scope.monthNumber + '/01'), 'MMMM'));
                        //reinit days
                        $scope.setDaysInMonth($scope.monthNumber, $scope.year);
                    };
                });

                //create the calendar holder
                thisInput.after($compile(angular.element(htmlTemplate))($scope));

                //get the calendar as element
                theCalendar = element[0].querySelector('._720kb-datepicker-calendar');
                //some tricky dirty events to fire if click is outside of the calendar and show/hide calendar when needed
                thisInput.bind('focus click', function onFocusAndClick() {

                    isMouseOnInput = true;

                    $scope.showCalendar();
                });

                thisInput.bind('focusout', function onBlurAndFocusOut() {

                    if (!isMouseOn) {

                        $scope.hideCalendar();
                    }
                    isMouseOnInput = false;
                });

                angular.element(theCalendar).bind('mouseenter', function onMouseEnter() {

                    isMouseOn = true;
                });

                angular.element(theCalendar).bind('mouseleave', function onMouseLeave() {

                    isMouseOn = false;
                });

                angular.element(theCalendar).bind('focusin', function onCalendarFocus() {

                    isMouseOn = true;
                });

                angular.element($window).bind('click focus', function onClickOnWindow() {

                    if (!isMouseOn &&
                      !isMouseOnInput) {

                        $scope.hideCalendar();
                    }
                });

                $scope.isMobile = function isMobile() {

                    if (navigator.userAgent && (navigator.userAgent.match(/Android/i)
                       || navigator.userAgent.match(/webOS/i)
                       || navigator.userAgent.match(/iPhone/i)
                       || navigator.userAgent.match(/iPad/i)
                       || navigator.userAgent.match(/iPod/i)
                       || navigator.userAgent.match(/BlackBerry/i)
                       || navigator.userAgent.match(/Windows Phone/i))) {

                        return true;
                    }
                };

                $scope.resetToMinDate = function manageResetToMinDate() {
                    if (dateMinLimit != undefined) {
                        var month = dateMinLimit.substring(0, 2);
                        var day = dateMinLimit.substring(3, 5);
                        var yearInp = dateMinLimit.substring(6, 10);
                        var dateMinD = new Date(parseInt(yearInp), parseInt(month) - 1, parseInt(day));
                    }
                    $scope.month = GetMonthGer($filter('date')(new Date(dateMinD), 'MMMM'));
                    $scope.monthNumber = Number($filter('date')(new Date(dateMinD), 'MM'));
                    $scope.day = Number($filter('date')(new Date(dateMinD), 'dd'));
                    $scope.year = Number($filter('date')(new Date(dateMinD), 'yyyy'));
                };

                $scope.resetToMaxDate = function manageResetToMaxDate() {

                    $scope.month = GetMonthGer($filter('date')(new Date(dateMaxLimit), 'MMMM'));
                    $scope.monthNumber = Number($filter('date')(new Date(dateMaxLimit), 'MM'));
                    $scope.day = Number($filter('date')(new Date(dateMaxLimit), 'dd'));
                    $scope.year = Number($filter('date')(new Date(dateMaxLimit), 'yyyy'));
                };

                $scope.nextMonth = function manageNextMonth() {

                    if ($scope.monthNumber === 12) {

                        $scope.monthNumber = 1;
                        //its happy new year
                        $scope.nextYear();
                    } else {

                        $scope.monthNumber += 1;
                    }
                    //set next month
                    $scope.month = GetMonthGer($filter('date')(new Date($scope.year + '/' + $scope.monthNumber + '/01'), 'MMMM'));
                    //reinit days
                    $scope.setDaysInMonth($scope.monthNumber, $scope.year);

                    //check if max date is ok
                    if (dateMaxLimit) {
                        if (!$scope.isSelectableMaxDate($scope.year + '/' + $scope.monthNumber + '/' + $scope.day)) {

                            //$scope.resetToMaxDate();
                        }
                    }
                    //deactivate selected day
                    $scope.day = undefined;
                };

                $scope.selectedMonthHandle = function manageSelectedMonthHandle(selectedMonth) {

                    $scope.monthNumber = Number($filter('date')(new Date('01 ' + selectedMonth + ' 2000'), 'MM'));
                    $scope.setDaysInMonth($scope.monthNumber, $scope.year);
                    $scope.setInputValue();
                };

                $scope.prevMonth = function managePrevMonth() {

                    if ($scope.monthNumber === 1) {

                        $scope.monthNumber = 12;
                        //its happy new year
                        $scope.prevYear();
                    } else {

                        $scope.monthNumber -= 1;
                    }
                    //set next month
                    $scope.month = GetMonthGer($filter('date')(new Date($scope.year + '/' + $scope.monthNumber + '/01'), 'MMMM'));

                    //reinit days
                    $scope.setDaysInMonth($scope.monthNumber, $scope.year);
                    //check if min date is ok
                    if (dateMinLimit) {

                        if (!$scope.isSelectableMinDate($scope.year + '/' + $scope.monthNumber + '/' + $scope.day)) {

                            //$scope.resetToMinDate();
                        }
                    }
                    //deactivate selected day
                    $scope.day = undefined;
                };

                $scope.setNewYear = function setNewYear(year) {

                    //deactivate selected day
                    $scope.day = undefined;

                    if (dateMaxLimit && $scope.year < Number(year)) {

                        if (!$scope.isSelectableMaxYear(year)) {

                            return;
                        }
                    } else if (dateMinLimit && $scope.year > Number(year)) {

                        if (!$scope.isSelectableMinYear(year)) {

                            return;
                        }
                    }

                    $scope.year = Number(year);
                    $scope.setDaysInMonth($scope.monthNumber, $scope.year);
                    $scope.paginateYears(year);
                };

                $scope.nextYear = function manageNextYear() {

                    $scope.year = Number($scope.year) + 1;
                };

                $scope.prevYear = function managePrevYear() {

                    $scope.year = Number($scope.year) - 1;
                };

                $scope.setInputValue = function manageInputValue() {

                    if ($scope.isSelectableMinDate($scope.year + '/' + $scope.monthNumber + '/' + $scope.day)
                        && $scope.isSelectableMaxDate($scope.year + '/' + $scope.monthNumber + '/' + $scope.day)) {

                        var modelDate = new Date($scope.year + '/' + $scope.monthNumber + '/' + $scope.day);

                        if (attr.dateFormat) {

                            thisInput.val($filter('date')(modelDate, dateFormat));
                        } else {

                            thisInput.val(modelDate);
                        }

                        thisInput.triggerHandler('input');
                        thisInput.triggerHandler('change');//just to be sure;
                    } else {

                        return false;
                    }
                };

                $scope.showCalendar = function manageShowCalendar() {
                    //lets hide all the latest instances of datepicker
                    pageDatepickers = $window.document.getElementsByClassName('_720kb-datepicker-calendar');

                    angular.forEach(pageDatepickers, function forEachDatepickerPages(value, key) {

                        pageDatepickers[key].classList.remove('_720kb-datepicker-open');
                    });

                    theCalendar.classList.add('_720kb-datepicker-open');
                };

                $scope.hideCalendar = function manageHideCalendar() {
                    theCalendar.classList.remove('_720kb-datepicker-open');
                };

                $scope.setDaysInMonth = function setDaysInMonth(month, year) {

                    var i
                      , limitDate = new Date(year, month, 0).getDate()
                      , firstDayMonthNumber = new Date(year + '/' + month + '/' + 1).getDay()
                      , lastDayMonthNumber = new Date(year + '/' + month + '/' + limitDate).getDay()
                      , prevMonthDays = []
                      , nextMonthDays = []
                      , howManyNextDays
                      , howManyPreviousDays
                      , monthAlias;

                    $scope.days = [];

                    for (i = 1; i <= limitDate; i += 1) {

                        $scope.days.push(i);
                    }
                    //get previous month days is first day in month is not Sunday
                    if (firstDayMonthNumber !== 1) {

                        howManyPreviousDays = firstDayMonthNumber === 0 ? 6 : firstDayMonthNumber - 1;

                        //get previous month
                        if (Number(month) === 1) {

                            monthAlias = 12;
                        } else {

                            monthAlias = month - 1;
                        }
                        //return previous month days
                        for (i = 1; i <= new Date(year, monthAlias, 0).getDate() ; i += 1) {

                            prevMonthDays.push(i);
                        }
                        //attach previous month days
                        $scope.prevMonthDays = prevMonthDays.slice(-howManyPreviousDays);
                    } else {
                        //no need for it
                        $scope.prevMonthDays = [];
                    }

                    //get next month days is first day in month is not Sunday
                    if (lastDayMonthNumber < 7 && lastDayMonthNumber > 0) {

                        howManyNextDays = 7 - lastDayMonthNumber;
                        //get previous month

                        //return next month days
                        for (i = 1; i <= howManyNextDays; i += 1) {

                            nextMonthDays.push(i);
                        }
                        //attach previous month days
                        $scope.nextMonthDays = nextMonthDays;
                    } else {
                        //no need for it
                        $scope.nextMonthDays = [];
                    }
                };

                $scope.setDatepickerDay = function setDatepickeDay(day) {
                    element[0].children[0].focus();
                    $scope.day = Number(day);
                    $scope.setInputValue();
                    $scope.hideCalendar();
                };

                $scope.paginateYears = function paginateYears(startingYear) {

                    $scope.paginationYears = [];

                    var i
                      , theNewYears = []
                      , daysToAppendPrepend = 10;

                    if ($scope.isMobile()) {

                        daysToAppendPrepend = 50;
                    }

                    for (i = daysToAppendPrepend/* Years */; i > 0; i -= 1) {

                        theNewYears.push(Number(startingYear) - i);
                    }

                    for (i = 0; i < daysToAppendPrepend/* Years */; i += 1) {

                        theNewYears.push(Number(startingYear) + i);
                    }

                    //check range dates
                    if (dateMaxLimit && theNewYears && theNewYears.length && !$scope.isSelectableMaxYear(Number(theNewYears[theNewYears.length - 1]) + 1)) {

                        $scope.paginationYearsNextDisabled = true;
                    } else {

                        $scope.paginationYearsNextDisabled = false;
                    }

                    if (dateMinLimit && theNewYears && theNewYears.length && !$scope.isSelectableMinYear(Number(theNewYears[0]) - 1)) {

                        $scope.paginationYearsPrevDisabled = true;
                    } else {

                        $scope.paginationYearsPrevDisabled = false;
                    }

                    $scope.paginationYears = theNewYears;
                };


                $scope.isSelectableMinDate = function isSelectableMinDate(aDate) {
                    var aDateD = new Date(aDate);
                    if (dateMinLimit != undefined) {
                        var month = dateMinLimit.substring(0, 2);
                        var day = dateMinLimit.substring(3, 5);
                        var yearInp = dateMinLimit.substring(6, 10);
                        var dateMinD = new Date(parseInt(yearInp), parseInt(month) - 1, parseInt(day));

                        //if current date
                        if (!!dateMinD &&
                           !!new Date(dateMinD) &&
                           new Date(aDateD) < new Date(dateMinD)) {

                            return false;
                        }
                    }


                    return true;
                };

                $scope.isSelectableMaxDate = function isSelectableMaxDate(aDate) {
                    var aDateD = new Date(aDate);
                    if (dateMaxLimit != undefined) {
                        var month = dateMaxLimit.substring(0, 2);
                        var day = dateMaxLimit.substring(3, 5);
                        var yearInp = dateMaxLimit.substring(6, 10);
                        var dateMaxD = new Date(parseInt(yearInp), parseInt(month) - 1, parseInt(day));

                        //if current date
                        if (!!dateMaxD &&
                           !!new Date(dateMaxD) &&
                           new Date(aDateD) > new Date(dateMaxD)) {

                            return false;
                        };
                    };
                    return true;

                };

                $scope.isSelectableMaxYear = function isSelectableMaxYear(year) {

                    if (!!dateMaxLimit &&
                      year > new Date(dateMaxLimit).getFullYear()) {

                        return false;
                    }

                    return true;
                };

                $scope.isSelectableMinYear = function isSelectableMinYear(year) {

                    if (!!dateMinLimit &&
                      year < new Date(dateMinLimit).getFullYear()) {

                        return false;
                    }

                    return true;
                };

                //check always if given range of dates is ok
                if (dateMinLimit && !$scope.isSelectableMinYear($scope.year)) {

                    $scope.resetToMinDate();
                }

                if (dateMaxLimit && !$scope.isSelectableMaxYear($scope.year)) {

                    $scope.resetToMaxDate();
                }

                $scope.paginateYears($scope.year);
                $scope.setDaysInMonth($scope.monthNumber, $scope.year);

                $scope.checkDate = function (day, year, monthNumber, item) {
                    var itemMin = $scope.isSelectableMinDate(year + '/' + monthNumber + '/' + item);
                    var itemMax = $scope.isSelectableMaxDate(year + '/' + monthNumber + '/' + item);
                    if (day === item) {
                        return '_720kb-datepicker-active '
                    } else if (!itemMin || !itemMax) {

                        return '_720kb-datepicker-disabled'
                    } else {
                        return '_720kb-datepicker-active'
                    };
                };
            }
        };
    }]);

    return angularAMD;
});
//}(angular));
