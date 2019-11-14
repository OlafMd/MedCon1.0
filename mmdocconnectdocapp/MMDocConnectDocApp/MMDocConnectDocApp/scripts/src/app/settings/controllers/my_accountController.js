(function () {
    'use strict';
    angular.module('mainModule').controller('my_accountController', ['$scope', '$rootScope', '$location', '$routeParams', 'my_accountService', 'alertService', 'validationService', 'commonServices',
        function ($scope, $rootScope, $location, $routeParams, my_accountService, alertService, validationService, commonServices) {
            //parameters ---------------------------------------------------------
            $scope.doctor = [];
            $scope.pass = [];
            $scope.FlagInvalid = false;
            var flagCheckDiv = false;
            $scope.salutation = [{ label: 'Herr', value: 'Herr' },
                             { label: 'Frau', value: 'Frau' }
            ];


            //Get data ---------------------------------------------------------
            $scope.accountDetailsComplete = function (response) {
                $scope.doctor = response.doctor;
                $scope.isPracticeLoggedIn = response.isPracticeLoggedIn;
            };
            $scope.accountDetailsError = function (response) {
                alertService.RenderErrorMessage("LABEL_SOMETHING_WENT_WRONG");
            };
            $scope.getAccountDetails = function () {
                my_accountService.getAccountDetails($scope.accountDetailsComplete, $scope.accountDetailsError);
            };

            //init ---------------------------------------------
            $scope.getAccountDetails();

            //Change password ---------------------------------------------------
            $scope.ResetPassword = function () {
                alertService.changePasswordPopup($scope.doctor.id, 'Arzt', $scope);
            };
            $scope.$on('ChangePass', function (event, data) {
                $scope.pass = data;
            });

            //Save changes, cancel, validate -------------------------------------
            $scope.Cancel = function () {
                redirect();
            };

            function redirect() {
                var url = '';
                if ($routeParams.previous_page) {
                    url = $routeParams.previous_page;
                } else {
                    url = '/planning';
                    if (!$rootScope.isOpRole) {
                        url = '/aftercare';
                    }
                }

                $location.url(url);
            }


            function HideAllMessages() {
                $scope.divContainer = false;
                $scope.EmailNotValid = false;
                $scope.IBANinvalid = false;
                $scope.BICBankinvalid = false;
                $scope.BICinvalid = false;
                $scope.BankInvalid = false;
                $scope.passwordDontMAtch = false;
                $scope.FlagInvalid = false;
            };

            //Validate IBAN ------------------------------------------------------
            $scope.IbanRetrievenotOK = function (response) {
                alertService.RenderErrorMessage("LABEL_SOMETHING_WENT_WRONG");
            };
            $scope.IbanRetrieveOK = function (response) {

                if (response.BicIban.length > 0) {

                    if ($scope.doctor.bic === "" || $scope.doctor.bic === null) { $scope.doctor.bic = undefined; }
                    if ($scope.doctor.bic === undefined) {

                        $scope.doctor.bic = response.BicIban[0].bic;
                    }
                    if ($scope.doctor.bank_name === "" || $scope.doctor.bank_name === null) { $scope.doctor.bank_name = undefined; }
                    if ($scope.doctor.bank_name === undefined) {
                        $scope.doctor.bank_name = response.BicIban[0].BankName;
                    }

                }


            };
            $scope.BicBanknotOK = function (response) {

            };
            $scope.BicBankOK = function (response) {

                if (response.BicIban.length > 0) {
                    if ($scope.doctor.bic === "" || $scope.doctor.bic === null) { $scope.doctor.bic = undefined; }
                    if ($scope.doctor.bic === undefined) {

                        $scope.doctor.bic = response.BicIban[0].bic;
                    }
                    if ($scope.doctor.bank_name === "" || $scope.doctor.bank_name === null) { $scope.doctor.bank_name = undefined; }
                    if ($scope.doctor.bank_name === undefined) {
                        $scope.doctor.bank_name = response.BicIban[0].BankName;
                    }
                }
            };
            $scope.CheckIbanFillBic = function () {

                if ($scope.doctor.iban === "") { $scope.doctor.iban = undefined; }
                if ($scope.doctor.iban != undefined) {
                    var IbanValidBool = validationService.IBANvalidator($scope.doctor.iban);
                    if (IbanValidBool === true) {
                        var objiban = {};
                        objiban.iban = $scope.doctor.iban;
                        my_accountService.IBanValidation(objiban, $scope.IbanRetrieveOK, $scope.IbanRetrievenotOK);
                    }

                }
            };
            $scope.CheckBicFillBank = function () {

                if ($scope.doctor.bic === "" || $scope.doctor.bic === null) { $scope.doctor.bic = undefined; }
                if (!angular.isUndefined($scope.doctor.bic)) {

                    var BicValidBool = validationService.validateBIC($scope.doctor.bic);
                    if (BicValidBool === true) {
                        var objbic = {};
                        objbic.bic = $scope.doctor.bic;
                        my_accountService.BicBankValidation(objbic, $scope.BicBankOK, $scope.BicBanknotOK);

                    }

                }
            }

            //Save----------------------------------------------------------------
            //Alert messages----------------------------------------------------
            $scope.doctorSaved = function (response) {
                $scope.parameters = {};
                $scope.parameters.isPracticeLoggedIn = $scope.isPracticeLoggedIn;
                $scope.parameters.name = $scope.doctor.title ? $scope.doctor.title + " " + $scope.doctor.first_name + " " + $scope.doctor.last_name : $scope.doctor.first_name + " " + $scope.doctor.last_name;
                $scope.$emit("AccountEdited", $scope.parameters)
                var message = 'LABEL_CHANGES_SAVED';
                alertService.RenderSuccessMessage(message);
                $scope.pass = [];
                redirect();
            };

            $scope.doctorNotSaved = function (response) {
                alertService.RenderErrorMessage('LABEL_SOMETHING_WENT_WRONG');
            };

            $scope.SaveDoctor = function () {
                if ($scope.pass.ID != undefined) {
                    commonServices.changeAccountPassword($scope.pass, $scope.successFunctionPass, $scope.errorFunctionPass);
                };
                HideAllMessages();
                my_accountService.saveAccount($scope.doctor, $scope.doctorSaved, $scope.doctorNotSaved);
            };

            $scope.sendDoctorForm = function () {
                HideAllMessages();

                if (!CheckAllValidations())
                    $scope.SaveDoctor();

            };
            function CheckAllValidations() {

                if (!validationService.isNotNullOrEmpty($scope.doctor.bic)) { $scope.doctor.bic = undefined; }
                if (!angular.isUndefined($scope.doctor.bic)) {
                    if ($scope.doctor.bank_name === undefined || $scope.doctor.bank_name === "") {
                        var BicValidBool = validationService.validateBIC($scope.doctor.bic);
                        if (BicValidBool === false) {
                            $scope.BICinvalid = true;
                        };
                        $scope.divContainer = true;
                        $scope.BankInvalid = true;
                        $scope.FlagInvalid = true;
                    } else {
                        var BicValidBool = validationService.validateBIC($scope.doctor.bic);
                        if (BicValidBool === false) {
                            $scope.divContainer = true;
                            $scope.BICinvalid = true;
                            $scope.FlagInvalid = true;
                        };
                    };
                };

                if (!validationService.isNotNullOrEmpty($scope.doctor.bank_name)) { $scope.doctor.bank_name = undefined; }
                if ($scope.doctor.bank_name != undefined && $scope.doctor.bic == undefined) {
                    $scope.divContainer = true;
                    $scope.BICBankinvalid = true;
                    $scope.FlagInvalid = true;
                };

                if (!validationService.isNotNullOrEmpty($scope.doctor.email)) { $scope.doctor.email = undefined; }
                if ($scope.doctor.email !== undefined) {
                    var IfValidMail = validationService.validateEmail($scope.doctor.email);
                    if (IfValidMail === false) {
                        $scope.divContainer = true;
                        $scope.EmailNotValid = true;
                        $scope.FlagInvalid = true;
                        flagCheckDiv = true;
                    };
                };

                if (!validationService.isNotNullOrEmpty($scope.doctor.iban)) { $scope.doctor.iban = undefined; }
                if ($scope.doctor.iban != undefined) {
                    var IbanValidBool = validationService.IBANvalidator($scope.doctor.iban);

                    if (IbanValidBool === false) {
                        $scope.divContainer = true;
                        $scope.IBANinvalid = true;
                        $scope.FlagInvalid = true;
                    };
                };

                if ($scope.FlagInvalid == true) {
                    return true;
                }
                else {
                    return false;
                }
                //end of validations
            };

            //Fill Practice Bank information------------------------------------
            $scope.PracticeInfoFound = function (response) {
                HideAllMessages();
                if ($scope.doctor.is_bank_inherited) {
                    if ((response[0].IBAN !== null && response[0].IBAN.length > 0) || (response[0].BankName.length > 0 && response[0].BICCode.length > 0)) {
                        $scope.practice_bank_details = angular.copy(response[0]);

                        $scope.doctor.is_bank_inherited = true;
                        $scope.doctor.account_holder = $scope.practice_bank_details.OwnerText;
                        $scope.doctor.bank_name = $scope.practice_bank_details.BankName;
                        $scope.doctor.bic = $scope.practice_bank_details.BICCode;
                        $scope.doctor.iban = $scope.practice_bank_details.IBAN;
                    }
                }
            };
            $scope.PracticeInfonotFound = function (response) {
                console.log(response);
            };
            $scope.FindPracticeBankAccountInfo = function () {
                my_accountService.GetBankAccountInfoforPracticeID($scope.doctor.practice_id, $scope.PracticeInfoFound, $scope.PracticeInfonotFound);
            };       
        }]);
})();