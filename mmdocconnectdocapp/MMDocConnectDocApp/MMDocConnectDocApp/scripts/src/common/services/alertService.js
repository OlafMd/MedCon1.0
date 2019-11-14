(function () {
    'use strict';
    angular.module('mainModule').service('alertService', ['$rootScope', 'ngDialog', '$timeout', 'ajaxService', '$location', '$q', '$interval', 'doctorsService', 'commonServices',
        function ($rootScope, ngDialog, $timeout, ajaxService, $location, $q, $interval, doctorsService, commonServices) {

            this.RenderErrorMessage = function (message) {
                renderDialog(message, 'bubble-rejected');
            };

            this.RenderSuccessMessage = function (message) {
                return renderDialog(message, 'bubble-accepted');
            };

            function renderDialog(message, class_name) {
                var deferred = $q.defer();
                var instance = ngDialog.open({
                    template: "<h2 class='" + class_name + "' " + "translate=" + message + "></h2>",
                    plain: true
                });

                var timeout = $timeout(function () {
                    instance.close();
                    deferred.resolve();
                }, 2000, false);

                instance.closePromise.then(function (data) {
                    $timeout.cancel(timeout);
                    deferred.resolve();
                });

                return deferred.promise;
            }

            this.RenderWarningMessage = function (message_header, messages, yes_button, no_button, $scope) {
                $scope.warning_messages = messages;
                $scope.warning_header = message_header;
                $scope.no_button = no_button;
                $scope.yes_button = yes_button;

                ngDialog.open({
                    template: 'scripts/src/common/view/warningPopupTemplate.html',
                    scope: $scope,
                    closeByDocument: false
                });

                $timeout(function () { angular.element('#yes_button')[0].focus(); }, 400, false);
            };

            this.showOctDoctorChangedPopup = function ($scope) {
                var deferred = $q.defer();
                $scope.parameter = {
                    withdraw_oct: true
                };

                $scope.confirmOctDoctorChange = function () {
                    ngDialog.close();
                    deferred.resolve($scope.parameter);
                };

                $scope.cancelOctDoctorChange = function () {
                    ngDialog.close();
                };

                ngDialog.open({
                    template: 'scripts/src/common/view/octDoctorChangePopup.html',
                    scope: $scope,
                    closeByDocument: false
                });

                return deferred.promise;
            };

            this.RenderWarningMessage_withRadioButtons = function (message_header, message, yes_button, no_button, $scope) {
                $scope.warning_message = message;
                $scope.warning_header = message_header;
                $scope.no_button = no_button;
                $scope.yes_button = yes_button;
                $scope.insurance_status_type = "1";

                $scope.checkCheckBoxOld = function () {
                    $scope.insurance_status_type = "2";
                };
                $scope.checkCheckBoxNew = function () {
                    $scope.insurance_status_type = "1";
                };

                ngDialog.open({
                    template: 'scripts/src/common/view/warningPopupTemplateRadioButtons.html',
                    scope: $scope,
                    closeByDocument: false
                });

                $timeout(function () { angular.element('#yes_button')[0].focus(); }, 400, false);
            };


            this.RenderNotificationMessage = function (messages, $scope, closePopupFunction, additionalData) {
                $scope.warning_messages = messages;
                $scope.closePopup = closePopupFunction === undefined ? ngDialog.close : closePopupFunction;
                $scope.dontShowMessage = false;

                if (additionalData) {
                    $scope.showCheckbox = additionalData.show_checkbox;
                    $scope.url = additionalData.url;
                    $scope.urlButtonMessage = additionalData.urlButtonMessage;

                    $scope.goToUrl = function () {
                        ngDialog.close();
                        $location.url($scope.url);
                    };
                };

                ngDialog.open({
                    template: 'scripts/src/common/view/notificationPopupTemplate.html',
                    scope: $scope,
                    closeByDocument: false
                });
            };

            this.RenderWarningMessage_AppRights = function (message) {
                $rootScope.warning_message = msgAlert;
                ngDialog.open({
                    template: 'scripts/src/common/view/errorNoAppRights.html',
                    scope: $rootScope,
                    closeByDocument: false
                });
            };

            this.RenderConfirmationDialog = function (title, content, confirm_button_text, cancel_button_text, confirmFunction, cancelFunction) {
                $rootScope.title = title;
                $rootScope.content = content;
                $rootScope.confirm_button = confirm_button_text;
                $rootScope.cancel_button = cancel_button_text;

                $rootScope.confirm = function () {
                    ngDialog.close();
                    $rootScope.$eval(confirmFunction);

                    cleanRootScope();
                };

                $rootScope.cancel = function () {
                    ngDialog.close();
                    $rootScope.$eval(cancelFunction);

                    cleanRootScope();
                };

                ngDialog.open({
                    template: 'scripts/src/common/view/confirmationPopupTemplate.html',
                    scope: $rootScope,
                    closeByDocument: false
                });
            };

            function cleanRootScope() {
                delete $rootScope.title;
                delete $rootScope.content;
                delete $rootScope.confirm;
                delete $rootScope.cancel;
                delete $rootScope.confirm_button;
                delete $rootScope.cancel_button;
            };

            this.ConfirmPassword = function ($scope, confirmFunction, cancelFunction, message, treatment_doctor_id, show_checkbox) {

                doctorsService.getDoctorsInPractice().then(getDoctorsSuccessfull);

                function getDoctorsSuccessfull(response) {
                    $scope.credentials_not_verified = false;
                    $scope.content = message;
                    $scope.show_checkbox = show_checkbox;
                    $scope.doctors = response;

                    $scope.confirmation = new Object();
                    $scope.confirmation.doctor = new Object();
                    $scope.disable_doctor_select = treatment_doctor_id && treatment_doctor_id != '00000000-0000-0000-0000-000000000000';
                    $scope.confirmation.doctor.id = treatment_doctor_id;

                    $scope.verifyPassword = function () {
                        ajaxService.AjaxPost($scope.confirmation, "api/main/VerifyDoctorPassword", $scope.passwordVerified, $scope.passwordNotVerified);
                    };

                    $scope.passwordVerified = function () {
                        $scope.credentials_not_verified = false;
                        ngDialog.close();
                        confirmFunction($scope.confirmation.doctor.id);
                    };

                    $scope.passwordNotVerified = function () {
                        $scope.credentials_not_verified = true;
                    };

                    $scope.passwordConfirmationCancel = function () {
                        ngDialog.close();
                        if (cancelFunction) {
                            cancelFunction();
                        }
                    };

                    ngDialog.open({
                        template: 'scripts/src/common/view/passwordConfirmationPopupTemplate.html',
                        scope: $scope,
                        closeByDocument: false,
                        closeByEscape: false
                    });

                    commonServices.focusElement('#inPassword');
                }
            };

            this.changePasswordPopup = function (id, type, $scope) {
                var pass = {};
                pass.accType = type;
                pass.id = id;
                $scope.AccInfo = pass;
                ngDialog.open({
                    controller: 'changePassController',
                    template: 'scripts/src/common/view/changePasswordPopup.html',
                    scope: $scope,
                    closeByDocument: false
                });
            };

            this.PopupClose = ngDialog.close;
        }]);
})();