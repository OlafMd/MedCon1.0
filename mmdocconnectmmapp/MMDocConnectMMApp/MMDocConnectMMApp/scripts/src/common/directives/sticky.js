/*
 * Name             Sticky
 * Authors          Vanja Benjocki
 * Contributors     /
 * Copyright (c)    Danulabs
 * Description      AngularJS directive for sticky table
 */
define(['angularAMD'], function (angularAMD) {
    angularAMD.directive('sticky', function ($timeout, $routeParams) {
        return {
            restrict: 'A',
            link: function (scope, element, attrs) {

                    var container = element[0];
                    var fixedOffset = 0;
                    var scrollOffset = 0;
                    var lastScrollOffset = 0;
                    var aboveHeaders = [];
                    var fixedHeader = null;
                    var firstHeader = null;
                    var belowHeaders = [];

                    var isInitLoad = true;
                    var numberOfElements = 0;

                    scope.$on('ngRepeatFinished', function (event, data) {
                        if(isInitLoad) {
                            isInitLoad = false;
                            belowHeaders = getAllHeaders();
                            if(belowHeaders.length)
                                stickyInit();
                        } else {
                            loadMoreElements();
                        }
                    });

                    scope.$on('GlobalSearch', function() {
                        resetSticky();
                    });

                    scope.$on('StickyReset', function() {
                        resetSticky();
                    });

                    element.bind('scroll', function (e) {
                        fixedOffset = container.offsetTop;
                        scrollOffset = container.scrollTop;
                        if(scrollOffset > lastScrollOffset) {
                            checkSticky(1);
                        } else {
                            checkSticky(-1);
                        }
                        lastScrollOffset = scrollOffset;
                    });

                    function stickyInit() {
                        firstHeader = belowHeaders[0].innerHTML;
                        changeFixedHeader(1);
                        if (fixedOffset == 0)
                            fixedOffset = (fixedHeader.offsetTop - container.scrollTop);

                        angular.element(fixedHeader).addClass("hide");
                        angular.element('#stickyHeaderBox').removeClass("hide");
                    }

                    function resetSticky() {
                        angular.element('#stickyHeaderBox').addClass("hide");

                        container = element[0];
                        fixedOffset = 0;
                        scrollOffset = 0;
                        lastScrollOffset = 0;
                        aboveHeaders = [];
                        fixedHeader = null;
                        firstHeader = null;
                        belowHeaders = [];

                        isInitLoad = true;
                        numberOfElements = 0;
                    }

                    function loadMoreElements() {
                        var lastNumberOfElements = numberOfElements;
                        var newElements = getAllHeaders().slice(lastNumberOfElements);
                        belowHeaders = belowHeaders.concat(newElements);
                    }

                    function getAllHeaders() {
                        var tempHeaders = [];
                        var elements = angular.element(".tableGroup");
                        numberOfElements = elements.length;
                        for (var i = 0; i < elements.length; i++) {
                            tempHeaders.push(elements[i]);
                        }

                        return tempHeaders;
                    }

                    function renderFixedHeader() {
                        if(!aboveHeaders.length)
                            angular.element('#stickyHeaderBox').html(firstHeader);
                        else
                            angular.element('#stickyHeaderBox').html(fixedHeader.innerHTML);
                    }

                    function changeFixedHeader(direction) {
                        if(direction == 1) {
                            if(fixedHeader != null)
                                aboveHeaders.push(fixedHeader);

                            fixedHeader = belowHeaders.shift();
                        } else {
                            belowHeaders.unshift(fixedHeader);
                            fixedHeader = aboveHeaders.pop();
                        }

                        renderFixedHeader();
                    }

                    function checkSticky(direction) {
                        if(direction == 1) {
                            if(belowHeaders.length) {
                                if((belowHeaders[0].offsetTop - container.scrollTop - fixedOffset + 16) < 0) {
                                    changeFixedHeader(direction);
                                }
                            }

                        } else {
                            if(aboveHeaders.length) {
                                if((fixedHeader.offsetTop - container.scrollTop - fixedOffset + 16) > 0) {
                                    changeFixedHeader(direction);
                                }
                            }
                        }
                    }
            }
        };

    });
});
