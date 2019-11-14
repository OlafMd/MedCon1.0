define(['angularAMD'], function (app) {
    app.service('commonServices', ['ajaxService', '$interval',
        function (ajaxService, $interval) {

            // ------------------------------------------------------------ GET -----------------------------------------------------------

            this.getEmployeesForRightID = function (isMaster, successFunction, errorFunction) {
                ajaxService.AjaxGetWithData(isMaster, 'api/main/GetEmployeesForRightID', successFunction, errorFunction);
            };

            // ----------------------------------------------------------- POST -----------------------------------------------------------

            this.changeAccountPassword = function (pass, successFunction, errorFunction) {
                ajaxService.AjaxPost(pass, "api/main/ChangeAccountPassword", successFunction, errorFunction);
            };


            this.focusElement = function (id) {
                var interval = $interval(function () {
                    var element = angular.element(id)[0];
                    if (element && element.clientHeight) {
                        $interval.cancel(interval);
                        element.focus();
                    }
                }, 20, 100, false);
            }
        }]);
});