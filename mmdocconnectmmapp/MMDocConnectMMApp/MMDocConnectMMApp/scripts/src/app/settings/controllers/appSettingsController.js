"use strict";
define(['application-configuration', 'settingsService'], function (app) {
    app.register.controller('appSettingsController', ['$scope', '$location', 'settingsService', 'validationService', 'alertsServices', '$timeout', '$interval',
        function ($scope, $location, settingsService, validationService, alertsServices, $timeout, $interval) {
            // ---------------------------------------------------------Company settings --------------------------------------------------------
            $scope.appSettings = { User: {} };
            $scope.FlagInvalid = false;
            var flagCheckDiv = false;

            function HideAllMessages() {
                $scope.divContainer = false;
                $scope.EmailNotValid = false;
                flagCheckDiv = false;
                $scope.FlagInvalid = false;
            };

            function successFunctionUsers(response) {
                $scope.user = response.users;
                settingsService.getCompanySettings(successFunctionSettings, errorFunctionSettings);
            };
            function errorFunctionUsers(response) {

            };
            settingsService.getUsers(successFunctionUsers, errorFunctionUsers);
            function successFunctionSettings(response) {
                $scope.appSettings.Email = response.appSettings.Email;
                $scope.appSettings.OrderInterval = response.appSettings.OrderInterval;
                $scope.appSettings.ImmediateOrderInterval = response.appSettings.ImmediateOrderInterval;
                $scope.appSettings.Password = "";
                for (var i = 0; i < $scope.user.length; i++) {
                    if ($scope.user[i].id === response.appSettings.AdminUser) {
                        $scope.appSettings.User = $scope.user[i];
                    }
                }

            };
            function errorFunctionSettings(response) {

            };

            $scope.submitAppSettingsForm = function () {
                HideAllMessages();
                var formValid = CheckAllValidations();
                if (!formValid) {
                    $scope.appSettings.AdminUser = $scope.appSettings.User.id;
                    settingsService.saveAppSettings($scope.appSettings, successFunctionSettingsSaved, errorFunctionSettingsSaved);
                };
            };

            $scope.closeAppSettingsForm = function () {
                HideAllMessages();
                $timeout(function () { $location.url('/dashboard/'); }, 1000);
            };
            function successFunctionSettingsSaved(response) {
                var message = "LABEL_APP_SETTINGS_SAVED";
                alertsServices.SuccessMessage(message);
                $timeout(function () { $location.url('/dashboard/'); }, 1000);
            };
            function errorFunctionSettingsSaved(response) {
                $scope.divContainer = true;
                $scope.passwordDontValidForm = true;
                $scope.FlagInvalid = true;
                flagCheckDiv = true;
            };

            function CheckAllValidations() {
                if (!validationService.isNotNullOrEmpty($scope.appSettings.Email)) { $scope.appSettings.Email = undefined; }
                if ($scope.appSettings.Email !== undefined) {
                    var IfValidMail = validationService.validateEmail($scope.appSettings.Email);
                    if (IfValidMail === false) {
                        $scope.divContainer = true;
                        $scope.EmailNotValid = true;
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

            var interval = $interval(function () {
                var element = angular.element('#inDefaultEmail')[0];
                if (element) {
                    $interval.cancel(interval);
                    element.focus();
                }
            }, 20, 100, false);
            //---------------------------------------------------------Controller end --------------------------------------------------------
        }]);

});