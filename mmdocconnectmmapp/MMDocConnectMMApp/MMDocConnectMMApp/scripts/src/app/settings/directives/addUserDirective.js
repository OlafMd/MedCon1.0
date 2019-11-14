define(['angularAMD'], function (angularAMD) {

    angularAMD.directive('addUserDirective', function ($http, $compile, $routeParams) {

        return {
            templateUrl:
              'scripts/src/app/settings/view/addUserTemplate.html',


            scope: {
                mode: "=mode"
            },
            replace: true,
            restrict: 'E',
            controller: addUserController
        };
        function addUserController($scope, $routeParams, $rootScope, $translate, validationService, settingsService, alertsServices, commonServices, $timeout, $interval) {

            $scope.user = {};
            drSetInitialPass();
            $scope.FlagInvalid = false;
            var LoginEmail;
            $scope.passForChange = false;
            var flagCheckDiv = false;
            var userID = undefined;

            $scope.salutation = [{ label: 'LABEL_MR', value: 1 },
                              { label: 'LABEL_MIS', value: 2 }];
            $scope.user.Salutation = $scope.salutation[1];

            if ($scope.$parent.mode == undefined) { $scope.$parent.mode = null }
            if ($scope.$parent.mode != null) {
                $scope.edit = true;
                userID = $scope.$parent.mode.id;
                GetUserForEdit();
            };
           
         
            function GetUserForEdit() {
                var user = new Object();
                user.id = userID;
                settingsService.GetUserForAccountID(user, successUserFound, errorUserNotfound);
            }
            function successUserFound(response) {
                for (var i = 0; i < $scope.salutation.length ; i++) {
                    if ($scope.salutation[i].label === response.user.Salutation) {
                        $scope.user.Salutation = $scope.salutation[i];
                    }
                }
                $scope.user.Title = response.user.Title;
                $scope.user.FirstName = response.user.FirstName;
                $scope.user.LastName = response.user.LastName;
                $scope.user.Email = response.user.Email;
                $scope.user.Phone = response.user.Phone;
                $scope.user.isAdmin = response.user.isAdmin;
                $scope.user.LoginEmail = response.user.LoginEmail;
                $scope.user.isDeactivated = response.user.isDeactivated;
                $scope.user.ReceiveNotification = response.user.ReceiveNotification;
                LoginEmail = response.user.LoginEmail;
            };
            function errorUserNotfound(response) {

            };
            function HideAllMessages() {
                $scope.divContainer = false;             
                $scope.EmailNotValid = false;
                $scope.passwordDontValidForm = false;            
                $scope.passwordDontMatch = false;
                $scope.passwordInvalidEmpty = false;               
                $scope.LoginEmailNotValid = false;
                $scope.LoginEmailExists = false;           
                $scope.passwordDontMAtch = false;
                flagCheckDiv = false;
                $scope.FlagInvalid = false;
            };

            function drSetInitialPass() {
                $scope.drCKGeneratePassword = '1';
                $scope.user.inPassword = "";
                $scope.user.inPassword = validationService.generatePassword();
                $scope.drdefDisabled = true;
                $scope.drgenDisabled = true;
            };
            $scope.drGenPass = function () {
                $scope.drCKGeneratePassword = '1';
                $scope.user.DefinePassword = "";
                $scope.drdefDisabled = true;
                $scope.drgenDisabled = true;
                $scope.user.inPassword = validationService.generatePassword();
            };

            $scope.drTypePass = function () {
                $scope.drCKGeneratePassword = '2';
                $scope.user.inPassword = "";
                $scope.user.DefinePassword = "";
                $scope.drgenDisabled = false;
                $scope.drdefDisabled = false;

            };

            $scope.closeUserForm = function () {
                $scope.user = {};
                userID = undefined;
              //  $scope.$parent.mode = undefined;
                $scope.edit = false;
                $rootScope.$broadcast('CloseForm', { form: 'addNewUser' });
            };
            $scope.submitUserForm = function () {
                HideAllMessages();
                var formValid = CheckAllValidations();
                if (!formValid) {
                    var validationParameter = new Object();
                    validationParameter.Type = 'user';
                    if (LoginEmail === undefined && $scope.user.LoginEmail != LoginEmail) {
                        validationParameter.ContentToValidate = $scope.user.LoginEmail;
                        settingsService.checkLoginMail(validationParameter, $scope.LoginMailValid, $scope.LoginMailNotValid);
                    }
                    else {
                        var salutation = $scope.user.Salutation.label;
                        $scope.user.Salutation = salutation;
                        $scope.user.id = userID != undefined ? userID : null;
                        if ($scope.pass == null) { $scope.pass == undefined }
                        if ($scope.pass != undefined) {
                            commonServices.changeAccountPassword($scope.pass,successFunctionPass, errorFunctionPass);
                        }
                        settingsService.AddUser($scope.user, successUserAdded, errorUserAdded);
                    }
                }

            }
            function successUserAdded(response) {
                if (response === "LABEL_ADMIN_USER_INFO") {
                    alertsServices.ErrorMessage(response);
                }
                else {
                $scope.closeUserForm();
                alertsServices.SuccessMessage(response);
                }
            };

            function errorUserAdded(response) {
                message = 'LABEL_SOMETHING_WENT_WRONG';
                alertsServices.ErrorMessage(message);
            };
            function successFunctionPass(response) {

            };
            function errorFunctionPass(response) {

            };
            $scope.LoginMailValid = function (response) {

                var salutation = $scope.user.Salutation.label;
                $scope.user.Salutation = salutation;
                $scope.user.id = $scope.$parent.mode!=undefined? $scope.$parent.mode.id : null;
                if ($scope.pass == null) { $scope.pass == undefined }
                if ($scope.pass != undefined) {
                    commonServices.changeAccountPassword($scope.pass, $scope.successFunctionPass, $scope.errorFunctionPass);
                }


                settingsService.AddUser($scope.user, successUserAdded, errorUserAdded);

            };

            $scope.LoginMailNotValid = function (response) {
                $scope.divContainer = true;
                $scope.LoginEmailExists = true;
                $scope.FlagInvalid = true;
                $scope.CheckAllValidations();

            };

            function CheckAllValidations() {
                if (!validationService.isNotNullOrEmpty($scope.user.Email)) { $scope.user.Email = undefined; }
                if ($scope.user.Email !== undefined) {
                    var IfValidMail = validationService.validateEmail($scope.user.Email);
                    if (IfValidMail === false) {
                        $scope.divContainer = true;
                        $scope.EmailNotValid = true;
                        $scope.FlagInvalid = true;
                        flagCheckDiv = true;
                    };
                };
                if (!validationService.isNotNullOrEmpty($scope.user.LoginEmail)) { $scope.user.LoginEmail = undefined; }
                if ($scope.user.LoginEmail !== undefined) {
                    var IfValidMail = validationService.validateEmail($scope.user.LoginEmail);
                    if (IfValidMail === false) {
                        $scope.divContainer = true;
                        $scope.LoginEmailNotValid = true;
                        $scope.FlagInvalid = true;
                        flagCheckDiv = true;
                    };
                };
                if ($scope.drCKGeneratePassword == '2') {
                    if ($scope.user.DefinePassword === "") { $scope.user.DefinePassword = undefined; };
                    if ($scope.user.inPassword === "") { $scope.user.inPassword = undefined; };
                    if ($scope.user.LoginEmail === "" || $scope.user.LoginEmail === null) { $scope.user.LoginEmail = undefined; }
                    if ($scope.user.LoginEmail !== undefined) {
                        if ($scope.user.DefinePassword === undefined || $scope.user.inPassword === undefined) {
                            $scope.divContainer = true;
                            $scope.passwordInvalidEmpty = true;
                            $scope.FlagInvalid = true;
                            flagCheckDiv = true;
                        };
                    };
                };

                if ($scope.user.DefinePassword === "") { $scope.user.DefinePassword = undefined; }
                if ($scope.user.DefinePassword != undefined) {
                    if ($scope.user.LoginEmail === "") { $scope.user.LoginEmail = undefined; }
                    if ($scope.user.LoginEmail !== undefined) {
                        var passwordValidation = validationService.ValidatePassword($scope.user.inPassword);

                        if (passwordValidation === false) {
                            $scope.divContainer = true;
                            $scope.passwordDontValidForm = true;
                            $scope.FlagInvalid = true;
                            flagCheckDiv = true;
                            if ($scope.user.DefinePassword != $scope.user.inPassword) {
                                $scope.passwordDontMAtch = true;
                                flagCheckDiv = true;
                            };
                        };

                        if ($scope.user.DefinePassword != $scope.user.inPassword) {
                            $scope.divContainer = true;
                            $scope.passwordDontMAtch = true;
                            $scope.FlagInvalid = true;
                            flagCheckDiv = true;
                        };
                    };
                };

                if ($scope.FlagInvalid == true) {
                    return true;
                }
                else {
                    return false;
                }

            };

            $scope.ResetPassword = function () {

                alertsServices.changePasswordPopup($scope.$parent.mode.id, 'Mitarbeiter', $scope);
            }
           
            $scope.$on('ChangePass', function (event, data) {
                $scope.pass = data;
            });
            
            var interval = $interval(function () {
                var element = angular.element('#ddSalutation_value')[0];
                if (element) {
                    $interval.cancel(interval);
                    element.focus();
                }
            }, 20, 100, false);
            //end of controller
        };
    });
});