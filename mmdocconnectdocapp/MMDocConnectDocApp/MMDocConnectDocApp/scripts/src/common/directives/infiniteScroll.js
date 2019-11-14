/**
  * Infinite scroll attributes:
  *     -infinite-scroll-distance
  *     -infinite-scroll-parent
  *     -infinite-scroll-child
  *     -infinite-scroll-disabled
  */


(function () {
    'use strict';
    angular.module('infinite.scroll', []).directive('infiniteScroll', ['$rootScope', '$timeout',
        function ($rootScope, $timeout) {
            return {
                restrict: 'A',
                link: function (scope, elem, attrs) {
                    var checkWhenEnabled, handler, scrollDistance, scrollEnabled;

                    var $parent = angular.element(attrs.infiniteScrollParent);
                    var $child = angular.element(attrs.infiniteScrollChild);

                    scrollDistance = 0;
                    scrollEnabled = true;
                    checkWhenEnabled = false;
                    initialise(attrs);



                    handler = function () {

                        if (attrs.infiniteScrollDisabled != null) {
                            scope.$watch(attrs.infiniteScrollDisabled, function (value) {
                                scrollEnabled = !Boolean(value);
                            });
                        }
                        var elementBottom, remaining, shouldScroll, windowBottom;

                        windowBottom = $child.height() - $parent.scrollTop() - $parent.height();
                        shouldScroll = windowBottom < scrollDistance;

                        if (shouldScroll && scrollEnabled) {
                            if ($rootScope.$$phase) {
                                return scope.$eval(attrs.infiniteScroll);
                            } else {
                                return scope.$apply(attrs.infiniteScroll);
                            }
                        } else if (shouldScroll) {
                            return checkWhenEnabled = true;
                        }
                    };

                    $parent.on('scroll', handler);

                    scope.$on('$destroy', function () {
                        return $parent.off('scroll', handler);
                    });
                    return $timeout((function () {
                        if (attrs.infiniteScrollImmediateCheck) {
                            if (scope.$eval(attrs.infiniteScrollImmediateCheck)) {
                                return handler();
                            }
                        } else {
                            return handler();
                        }
                    }), 0);


                    /**
                     * Initialize the directive. Set scroll distance, if scroll is enabled or disabled
                     */
                    function initialise(attrs) {
                        if (attrs.infiniteScrollDistance != null) {
                            scope.$watch(attrs.infiniteScrollDistance, function (value) {
                                return scrollDistance = parseInt(value, 10);
                            });
                        }

                        if (attrs.infiniteScrollDisabled != null) {
                            scope.$watch(attrs.infiniteScrollDisabled, function (value) {
                                scrollEnabled = !value;
                                if (scrollEnabled && checkWhenEnabled) {
                                    checkWhenEnabled = false;
                                    return handler();
                                }
                            });
                        }
                    };
                }
            };
        }
    ])
})();