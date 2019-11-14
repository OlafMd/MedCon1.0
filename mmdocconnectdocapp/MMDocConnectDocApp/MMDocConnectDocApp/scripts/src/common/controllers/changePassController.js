(function () {
    'use strict';
    angular.module('mainModule').controller('changePassController', ['$scope', '$location', '$translate', 'ajaxService', '$rootScope', 'alertService', 'validationService',
        function ($scope, $location, $translate, ajaxService, $rootScope, alertService, validationService) {
            $scope.pass = {};
            console.log($scope.AccInfo);
            $scope.pass.accType = "(Account" + " " + $scope.AccInfo.accType + ")";
            $scope.pass.acc = $scope.AccInfo.accType;
            $scope.closePopUpPassword = function () {

                $scope.pass = {};
                alertService.PopupClose();

            };

            function HideAllMessages() {
                $scope.divContainer = false;
                $scope.passwordDontMAtch = false;
                $scope.passwordInvalidEmpty = false;
                $scope.passwordDontValidForm = false;
            }
            $scope.SetInitialPass = function () {
                HideAllMessages();
                $scope.ckPass = '1';
                $scope.genPassdis = true;
                $scope.typedPassdis = true;
                $scope.pass.generatedPass = validationService.generatePassword();

            };

            $scope.GeneratePass = function () {
                HideAllMessages();
                $scope.disablesubmit = false;
                $scope.pass.typedPass = "";
                $scope.pass.confirmedPass = "";
                $scope.genPassdis = true;
                $scope.typedPassdis = true;
            };

            $scope.typePass = function () {
                $scope.disablesubmit = true;
                $scope.genPassdis = true;
                $scope.typedPassdis = false;

            };

            $scope.changePassword = function () {
                $scope.FlagInvalid = false;
                HideAllMessages();
                if ($scope.ckPass == '1') {
                    $scope.pass.password = $scope.pass.generatedPass;
                }
                else {
                    if ($scope.pass.typedPassd === "") { $scope.pass.typedPass = undefined; };
                    if ($scope.pass.confirmedPass === "") { $scope.pass.confirmedPass = undefined; };
                    if ($scope.pass.typedPass === undefined || $scope.pass.confirmedPass === undefined) {
                        $scope.divContainer = true;
                        $scope.passwordInvalidEmpty = true;
                        $scope.FlagInvalid = true;
                    }
                    else if ($scope.pass.typedPass != $scope.pass.confirmedPass) {
                        $scope.divContainer = true;
                        $scope.passwordDontMAtch = true;
                        $scope.FlagInvalid = true;
                    }
                    else {
                        var passwordValidation = validationService.ValidatePassword($scope.pass.typedPass);
                        if (passwordValidation === false) {
                            $scope.divContainer = true;
                            $scope.passwordDontValidForm = true;
                            $scope.FlagInvalid = true;
                        }
                    }
                    $scope.pass.password = $scope.pass.typedPass;
                }

                if ($scope.FlagInvalid === false) {
                    $scope.pass.ID = $scope.AccInfo.id;
                    $scope.pass.type = $scope.AccInfo.accType;
                    alertService.PopupClose();
                    $rootScope.$broadcast('ChangePass', $scope.pass);
                };
            };


        }]);

})();