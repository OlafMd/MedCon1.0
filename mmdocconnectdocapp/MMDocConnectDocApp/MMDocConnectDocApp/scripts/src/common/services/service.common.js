(function () {
    'use strict';
    angular.module('mainModule').service('commonServices', ['ajaxService', '$interval', '$timeout', function (ajaxService, $interval, $timeout) {
        this.changeAccountPassword = function (pass, successFunction, errorFunction) {
            ajaxService.AjaxPost(pass, "api/main/ChangeAccountPassword", successFunction, errorFunction);
        };

        this.download = function (response) {
            if (response !== null && response.length !== 0 && response !== '' ) {
                var save = document.createElement('a');
                save.href = response;
                save.download = response;
                if (navigator.appVersion.toString().indexOf('.NET') > 0) {
                    $timeout(function () {
                        window.location = save;
                    }, 500, false);
                } else {
                    $timeout(function () {
                        var event = document.createEvent("MouseEvents");
                        event.initMouseEvent(
                                "click", true, false, window, 0, 0, 0, 0, 0
                                , false, false, false, false, 0, null
                        );
                        save.dispatchEvent(event);
                    }, 500, false);
                };
            };
        };

        this.focusSearch = function () {
            this.focusElement('#globalSearchInput');
        }

        this.focusElement = function (id) {
            $timeout(function () {
                var interval = $interval(function () {
                    var element = angular.element(id)[0];
                    if (element && element.clientHeight) {
                        $interval.cancel(interval);
                        element.focus();
                    }
                }, 20, 100, false);
            }, 0, false);

        }

        this.errorFunction = function (response) {
            console.error(response);
            // todo: show red banner (sth went wrong).
        }

        this.cloneData = function (data) {
            var result = [];
            angular.copy(data, result);
            return result;
        }
    }]);
})();