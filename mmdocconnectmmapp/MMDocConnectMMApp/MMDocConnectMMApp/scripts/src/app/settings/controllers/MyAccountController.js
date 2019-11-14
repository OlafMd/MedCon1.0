"use strict";
define(['application-configuration', 'settingsService'], function (app) {
    app.register.controller('myAccountController', ['$scope', 'settingsService', 'validationService', '$location', 'alertsServices', '$timeout', 'commonServices', '$interval',
        function ($scope, settingsService, validationService, $location, alertsServices, $timeout, commonServices, $interval) {

            $scope.MyAccount = {};
            drSetInitialPass();
            $scope.FlagInvalid = false;
            var flagCheckDiv = false;
            var accountID = "";
            var LoginEmail;
            $scope.salutation = [{ label: 'LABEL_MR', value: 1 },
                                 { label: 'LABEL_MIS', value: 2 }];

            settingsService.GetUserForMyAccount(successUserFound, errorUserNotfound);
            function drSetInitialPass() {
                $scope.MyAccount.inPassword = "";
                $scope.MyAccount.inPassword = validationService.generatePassword();
                $scope.drgenDisabled = true;
            };

            function HideAllMessages() {
                $scope.divContainer = false;
                $scope.EmailNotValid = false;
                $scope.LoginEmailNotValid = false;
                $scope.LoginEmailExists = false;
                flagCheckDiv = false;
                $scope.FlagInvalid = false;
            };

            function successUserFound(response) {
                for (var i = 0; i < $scope.salutation.length ; i++) {
                    if ($scope.salutation[i].label === response.user.Salutation) {
                        $scope.MyAccount.Salutation = $scope.salutation[i];
                    }
                };
                $scope.MyAccount.Title = response.user.Title;
                $scope.MyAccount.FirstName = response.user.FirstName;
                $scope.MyAccount.LastName = response.user.LastName;
                $scope.MyAccount.Email = response.user.Email;
                $scope.MyAccount.Phone = response.user.Phone;
                $scope.MyAccount.LoginEmail = response.user.LoginEmail;
                $scope.MyAccount.isAdmin = response.user.isAdmin;
                $scope.MyAccount.isDeactivated = response.user.isDeactivated;
                $scope.MyAccount.ReceiveNotification = response.user.ReceiveNotification;
                accountID = response.user.id;
                LoginEmail = response.user.LoginEmail;
            };
            function errorUserNotfound(response) {
            };
            $scope.ResetPassword = function () {
                alertsServices.changePasswordPopup(accountID, 'Mitarbeiter', $scope);
            };

            $scope.$on('ChangePass', function (event, data) {
                $scope.pass = data;
            });
            $scope.submitMyAccountForm = function () {
                HideAllMessages();
                var formValid = CheckAllValidations();
                if (!formValid) {
                    var validationParameter = new Object();
                    validationParameter.Type = 'user';
                    if (LoginEmail === undefined && $scope.MyAccount.LoginEmail != LoginEmail) {
                        validationParameter.ContentToValidate = $scope.MyAccount.LoginEmail;
                        settingsService.checkLoginMail(validationParameter, $scope.LoginMailValid, $scope.LoginMailNotValid);
                    }
                    else {

                        var salutation = $scope.MyAccount.Salutation != undefined ? $scope.MyAccount.Salutation.label : "";
                        $scope.MyAccount.Salutation = salutation == "" ? salutation : null;
                        $scope.MyAccount.id = accountID != undefined ? accountID : null;
                        if ($scope.pass == null) { $scope.pass == undefined }
                        if ($scope.pass != undefined) {
                            commonServices.changeAccountPassword($scope.pass, successFunctionPass, errorFunctionPass);
                        }
                        settingsService.AddUser($scope.MyAccount, successUserAdded, errorUserAdded);
                    };
                };
            };
            function successUserAdded(response) {
                $scope.parameters = {};
                $scope.$emit("AccountEdited", $scope.parameters)

                var message = 'LABEL_MY_ACCOUNT_EDITED';
                alertsServices.SuccessMessage(message);
                $timeout(function () { $location.url('/dashboard/'); }, 1000);

            };
            function successFunctionPass(response) {

            };
            function errorFunctionPass(response) {

            };
            function errorUserAdded(response) {
                var message = 'LABEL_SOMETHING_WENT_WRONG';
                alertsServices.ErrorMessage(message);
            };
            function CheckAllValidations() {
                if (!validationService.isNotNullOrEmpty($scope.MyAccount.Email)) { $scope.MyAccount.Email = undefined; }
                if ($scope.MyAccount.Email !== undefined) {
                    var IfValidMail = validationService.validateEmail($scope.MyAccount.Email);
                    if (IfValidMail === false) {
                        $scope.divContainer = true;
                        $scope.EmailNotValid = true;
                        $scope.FlagInvalid = true;
                        flagCheckDiv = true;
                    };
                };
                if (!validationService.isNotNullOrEmpty($scope.MyAccount.LoginEmail)) { $scope.MyAccount.LoginEmail = undefined; }
                if ($scope.MyAccount.LoginEmail !== undefined) {
                    var IfValidMail = validationService.validateEmail($scope.MyAccount.LoginEmail);
                    if (IfValidMail === false) {
                        $scope.divContainer = true;
                        $scope.LoginEmailNotValid = true;
                        $scope.FlagInvalid = true;
                        flagCheckDiv = true;
                    };
                };

                if ($scope.FlagInvalid == true) {
                    return true;
                }
                else {
                    return false;
                };

            };
            $scope.LoginMailValid = function (response) {

                var salutation = $scope.MyAccount.Salutation.label;
                $scope.MyAccount.Salutation = salutation;
                $scope.MyAccount.id = accountID != undefined ? accountID : null;
                if ($scope.pass == null) { $scope.pass == undefined }
                if ($scope.pass != undefined) {
                    commonServices.changeAccountPassword($scope.pass, $scope.successFunctionPass, $scope.errorFunctionPass);
                }
                settingsService.AddUser($scope.MyAccount, successUserAdded, errorUserAdded);

            };

            $scope.closeMyAccountForm = function () {
                $location.url('/dashboard/');
            };

            var interval = $interval(function () {
                var element = angular.element('#ddSalutation_value')[0];
                if (element) {
                    $interval.cancel(interval);
                    element.focus();
                }
            }, 20, 100, false);

            // --------------------------------------------------------- END OF CONTROLLER --------------------------------------------------------
        }]);
});