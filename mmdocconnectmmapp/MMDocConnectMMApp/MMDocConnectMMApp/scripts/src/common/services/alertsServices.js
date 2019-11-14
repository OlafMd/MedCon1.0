
define(['angularAMD'], function (angularAMD) {
    angularAMD.service('alertsServices', ['ngDialog', '$timeout', '$rootScope', 'ajaxService', function (ngDialog, $timeout, $rootScope, ajaxService) {

        this.PopupClose = ngDialog.close;

        this.RenderNotificationMessage = function ($scope) {

            ngDialog.open({
                template: 'scripts/src/common/view/notificationPopupTemplate.html',
                scope: $scope,
                closeByDocument: false
            });
        };

        this.RenderNotificationMessageRedHeader = function (messages, $scope, closePopupFunction) {
            $scope.warning_messages = messages;
            $scope.closePopup = closePopupFunction === undefined ? ngDialog.close : closePopupFunction;

            ngDialog.open({
                template: 'scripts/src/common/view/notificationPopupTemplateRedHeader.html',
                scope: $scope,
                closeByDocument: false
            });
        };

        this.SuccessMessage = function (message) {
            var instance = ngDialog.open({
                template: this.generateMessagePopupTemplateSuccess(message),
                plain: true
            });

            $timeout(function () {
                instance.close();
            }, 2000, false);
        };

        this.generateMessagePopupTemplateSuccess = function (message) {
            return "<h2 class='bubble-accepted' translate=" + message + "></h2>";
        };

        this.ErrorMessage = function (message) {
            var instance = ngDialog.open({
                template: this.generateMessagePopupTemplateError(message),
                plain: true
            });

            $timeout(function () {
                instance.close();
            }, 2000, false);
        };

        this.generateMessagePopupTemplateError = function (message) {
            return "<h2 class='bubble-rejected' translate=" + message + "></h2>";
        };


        this.PopUpFormClose = function (message, $scope) {

            $scope.warning_message = message;
            $scope.no_button = "Cancel";
            $scope.yes_button = "Confirm";
            ngDialog.open({
                templateURL: 'scripts/src/common/doctor/view/closeFormModal.html',
                scope: $scope
            });

        };
        this.changePasswordPopup = function (id, type, $scope) {
            pass = {};
            pass.accType = type;
            pass.id = id;
            $scope.AccInfo = pass;
            ngDialog.open({
                controller: 'changePassController',
                template: 'scripts/src/common/view/changePasswordPopup.html',
                scope: $scope,
                closeByDocument: false
            });

        }

        
        this.InformationMessage = function (message) {
            var instance = ngDialog.open({
                template: this.generateMessagePopupInformationMessage(message),
                plain: true
            });

            $timeout(function () {
                instance.close();
            }, 2000, false);

        };


        this.generateMessagePopupInformationMessage = function (message) {
            return "<h2 class='bubble-information' translate=" + message + "></h2>";
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
                template: 'scripts/src/common/view/confirmPopupTemplate.html',
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

            delete $rootScope.credentials_not_verified;
            delete $rootScope.doctors;
            delete $rootScope.is_practice;
            delete $rootScope.confirmation;
            delete $rootScope.verifyPassword;
            delete $rootScope.passwordVerified;
            delete $rootScope.passwordNotVerified;
            delete $rootScope.passwordConfirmationCancel;
            delete $rootScope.content;
        };

        this.ConfirmPassword = function (users, logged_in_email, confirmFunction, cancelFunction, message) {

            $rootScope.content = message;
            $rootScope.confirmation = new Object();
            $rootScope.users = users;
            $rootScope.confirmation.user_login_email = logged_in_email;
            
            $rootScope.verifyPassword = function () {
                ajaxService.AjaxPost($rootScope.confirmation, "api/main/VerifyPassword", $rootScope.passwordVerified, $rootScope.passwordNotVerified);
            };

            $rootScope.passwordVerified = function () {
                $rootScope.credentials_not_verified = false;
                ngDialog.close();
                $rootScope.$eval(confirmFunction);

                cleanRootScope();
            };

            $rootScope.passwordNotVerified = function () {
                $rootScope.credentials_not_verified = true;
            };

            $rootScope.passwordConfirmationCancel = function () {
                ngDialog.close();
                $rootScope.$eval(cancelFunction);

                cleanRootScope();
            };

            ngDialog.open({
                template: 'scripts/src/common/view/passwordConfirmationPopupTemplateforTenant.html',
                scope: $rootScope,
                closeByDocument: false
            });

            $rootScope.$on('ngDialog.opened', function () {
                angular.element('#inPassword')[0].focus();
            });
        };
    }]);    
});