/// <reference path="../view/globalSearchTemplate.html" />
define(['angularAMD'], function (angularAMD) {
    angularAMD.directive('elipsisDirective', function ($timeout, $filter) {

        return {
            templateUrl: 'scripts/src/common/view/elipsisDirectiveTemplate.html',
            scope: {
                data: '='
            },
            replace: true,
            restrict: 'A',
            link: elipsisLinker
        };

        function elipsisLinker($scope, elem, attrs) {

            //  --------------------------------------------- VARIABLES ---------------------------------------------

            var font = angular.element('body').css('font-size') + ' ' + angular.element('body').css('font-family');
            $scope.inView = $scope.data;

            // ---------------------------------------------- TRANSFORM ---------------------------------------------


            // TODO: Responsive
            function doTransform() {
                $scope.more = new Object();
                $scope.more.numberOfHidden = 0;
                $scope.inView = $scope.data;

                $timeout(transform);
            };

            doTransform();

            function transform() {
                var suffix = ', ...';
                var suffixLength = getTextWidth(suffix, font);
                var viewArray = [];
                var dataArray = $scope.data.split(', ');
                var dataWidth = getTextWidth($scope.data, font);
                var elementWidth = elem[0].offsetWidth + suffixLength;
                if (elementWidth < dataWidth) {
                    var remaining = dataArray.length;
                    var totalLength = 0;
                    for (var i = 0; i < dataArray.length; i++) {
                        totalLength += getTextWidth(dataArray[i], font);
                        if (totalLength > elementWidth) {
                            break;
                        } else {
                            viewArray.push(dataArray[i]);
                            remaining--;
                        };
                    };

                    if (remaining !== 0) {
                        if (remaining !== dataArray.length) {
                            $scope.inView = viewArray.join(', ') + suffix;
                        } else {
                            $scope.inView = '...';
                        };
                        $scope.more.numberOfHidden = remaining;
                        $scope.more.label = 'LABEL_ELIPSIS_MORE';

                        var toolTipArray = dataArray.slice(dataArray.length - remaining);
                        $scope.more.toolTipView = toolTipArray.join(', ');
                    };
                } else {
                    $scope.numberOfHidden = undefined;
                    $scope.inView = $scope.data;
                };

            };


            $(window).resize(doTransform);

            // ------------------------------------------------ UTIL ------------------------------------------------

            function getTextWidth(text, font) {
                var canvas = getTextWidth.canvas || (getTextWidth.canvas = document.createElement("canvas"));
                var context = canvas.getContext("2d");
                context.font = font;
                var metrics = context.measureText(text);
                return metrics.width;
            };

            // ------------------------------------------------- END ------------------------------------------------
        };

    });
});