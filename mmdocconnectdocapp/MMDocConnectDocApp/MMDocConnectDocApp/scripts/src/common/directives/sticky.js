(function () {
    'use strict';
    angular.module('mainModule').directive('sticky', ['$timeout', '$compile', '$rootScope',
        function ($timeout, $compile, $rootScope) {
            return {
                restrict: 'A',
                link: function (scope, element, attrs) {
                    var fixedHeaderId = '#stickyHeaderBox';
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
                        if (isInitLoad) {
                            isInitLoad = false;
                            belowHeaders = getAllHeaders();
                            if (belowHeaders.length)
                                stickyInit();
                        } else {
                            loadMoreElements();
                        }
                    });

                    scope.$on('GlobalSearch', function () {
                        resetSticky();
                    });

                    scope.$on('StickyReset', function () {
                        resetSticky();
                    });

                    element.bind('scroll', function (e) {
                        fixedOffset = container.offsetTop;
                        scrollOffset = container.scrollTop;
                        if (scrollOffset > lastScrollOffset) {
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
                        angular.element(fixedHeaderId).removeClass("hide");
                    }

                    function resetSticky() {
                        angular.element(fixedHeaderId).addClass("hide");
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
                    scope.stickyGroupChecked = function (groupName) {
                        var currentGroupName = angular.element('#stickyData')[0].textContent.trim();
                        if (groupName == currentGroupName) {
                            $rootScope.$broadcast('sticky:group-checked', {
                                group: currentGroupName
                            });
                        }
                    };

                    function renderFixedHeader() {
                        var html = !aboveHeaders.length ? firstHeader : fixedHeader.innerHTML;
                        $timeout(function () {
                            var groupNameElement = angular.element('#stickyData')[0];
                            if (groupNameElement) {
                                var currentGroupName = groupNameElement.textContent.trim();
                                if (!scope.item) {
                                    scope.item = {};
                                }

                                var item = scope.getGroupItem(currentGroupName);

                                if (item) {
                                    scope.item.is_group_selected = item.is_group_selected;
                                }
                            }
                        });

                        var compiledHtml = $compile(html)(scope);
                        angular.element(fixedHeaderId).html(compiledHtml);
                    }

                    scope.$on('sticky:group-deselected', function (event, data) {
                        var groupNameElement = angular.element('#stickyData')[0];
                        if (groupNameElement) {
                            var currentGroupName = groupNameElement.textContent.trim();
                            if (currentGroupName == data.group) {
                                scope.item.is_group_selected = false;
                            }
                        }
                    });

                    function changeFixedHeader(direction) {
                        if (direction == 1) {
                            if (fixedHeader != null)
                                aboveHeaders.push(fixedHeader);

                            fixedHeader = belowHeaders.shift();
                        } else {
                            belowHeaders.unshift(fixedHeader);
                            fixedHeader = aboveHeaders.pop();
                        }

                        renderFixedHeader();
                    }

                    function checkSticky(direction) {
                        if (direction == 1) {
                            if (belowHeaders.length) {
                                if ((belowHeaders[0].offsetTop - container.scrollTop - fixedOffset + 16) < 0) {
                                    changeFixedHeader(direction);
                                }
                            }

                        } else {
                            if (aboveHeaders.length) {
                                if ((fixedHeader.offsetTop - container.scrollTop - fixedOffset + 16) > 0) {
                                    changeFixedHeader(direction);
                                }
                            }
                        }
                    }
                }
            };

        }]);
})();
