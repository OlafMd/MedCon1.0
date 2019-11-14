(function () {
    'use strict';
    angular.module('mainModule').controller('praxisController', ['$scope', '$rootScope', '$routeParams', 'practiceSettingsService',
        'alertService', '$location', 'my_accountService', 'validationService', 'commonServices', 'pharmacyService',
        function ($scope, $rootScope, $routeParams, practiceSettingsService, alertService, $location, my_accountService, validationService, commonServices, pharmacyService) {

            //parameters ---------------------------------------------------------
            $scope.practice = {};
            $scope.pass = [];

            var emptyGuid = '00000000-0000-0000-0000-000000000000';
            var nonePharmacy = { 'display_name': "LABEL_NONE", 'id': emptyGuid };
            $scope.pharmacies = [];

            $scope.isQuickOrderBtnEnabled = false;

            $scope.FlagInvalid = false;
            var flagCheckDiv = false;
            //init ---------------------------------------------------------------
            getPracticeDetails();
            //Get data -----------------------------------------------------------
            function practiceDetailsComplete(response) {
                $scope.getPharmacies();
                $scope.isPracticeLoggedIn = response.isPracticeLoggedIn;


                var address_details = response.address.split(' ');
                var number = address_details.pop();
                var town_details = response.town.split(' ');
                var zip = town_details.shift();

                $scope.practice.name = response.name;
                $scope.practice.address = response.address;
                $scope.practice.No = response.No;;

                $scope.practice.Zip = parseInt(response.Zip);
                $scope.practice.town = response.town;
                $scope.practice.bsnr = parseInt(response.bsnr);
                $scope.practice.email = response.email === null ? "" : response.email;
                $scope.practice.phone = response.phone;
                $scope.practice.fax = response.fax;
                $scope.practice.contact_person_name = response.contact_person_name;
                $scope.practice.contact_email = response.contact_email;
                $scope.practice.contact_telephone = response.contact_telephone;
                $scope.practice.default_shipping_date_offset = response.default_shipping_date_offset;
                $scope.practice.login_email = response.login_email;
                $scope.practice.account_holder = response.account_holder;
                $scope.practice.iban = response.iban;
                $scope.practice.bic = response.bic;
                $scope.practice.bank = response.bank;
                $scope.practice.password = response.password;
                $scope.practice.id = response.id;
                $scope.practice.IsSurgeryPractice = response.IsSurgeryPractice;
                $scope.practice.IsOrderDrugs = response.IsOrderDrugs;
                $scope.practice.IsOnlyLabelRequired = response.IsOnlyLabelRequired;
                $scope.practice.isWaiveServiceFee = response.isWaiveServiceFee;
                $scope.practice.ShouldDownloadReportUponSubmission = response.ShouldDownloadReportUponSubmission;
                $scope.practice.PressEnterToSearch = response.PressEnterToSearch;
                $scope.practice.PracticeHasOctDevice = !!response.PracticeHasOctDevice;

                $scope.practice.DefaultPharmacy = response.DefaultPharmacy;
                $scope.practice.IsQuickOrderActive = response.IsQuickOrderActive;
                $scope.practice.DeliveryDateFrom = response.DeliveryDateFrom;
                $scope.practice.DeliveryDateTo = response.DeliveryDateTo;
                $scope.practice.UseGracePeriod = response.UseGracePeriod;

            };

            $scope.practiceDetailsError = function (response) {
                alertService.RenderErrorMessage("LABEL_SOMETHING_WENT_WRONG");
            };

            function getPracticeDetails() {
                practiceSettingsService.getPracticeSettings(true).then(practiceDetailsComplete);
            };

            //#region pharmacies
            $scope.getPharmacies = function () {
                pharmacyService.getPharmacies().then($scope.getPharmaciesComplete);
            }

            $scope.getPharmaciesComplete = function (response) {
                $scope.pharmacies = response.map(function (x) {
                    return {
                        'display_name': x.pharmacyName, 'id': x.pharmacyID
                    };
                });

                $scope.pharmacies.push(nonePharmacy);
            }

            $scope.checkIsQuickOrderDisabled = function () {
                $scope.isQuickOrderBtnEnabled =
                    $scope.practice.DefaultPharmacy &&
                    $scope.practice.DefaultPharmacy != emptyGuid &&
                    $scope.practice.address != undefined && $scope.practice.address.length &&
                    $scope.practice.No != undefined && $scope.practice.No.length &&
                    $scope.practice.Zip != undefined && $scope.practice.Zip > -1 &&
                    $scope.practice.town != undefined && $scope.practice.town.length &&
                    $scope.practice.DeliveryDateFrom != undefined && $scope.practice.DeliveryDateFrom.length &&
                    $scope.practice.DeliveryDateTo != undefined && $scope.practice.DeliveryDateTo.length;

                if (!$scope.isQuickOrderBtnEnabled) {
                    $scope.practice.IsQuickOrderActive = false;
                    return true;
                }
                return false;
            }
            // ---------------------------------------------------------- DELIVERY TIME ------------------------------------------------------------------

            $scope.fixTime = function (time) {
                if ($scope.practice[time] && $scope.practice[time].length < 5) {
                    var time_array = $scope.practice[time].split(':');
                    if (time_array.length > 1) {
                        var zeros = time_array[1] !== '' ? '0' : '00';
                        $scope.practice[time] = $scope.practice[time] + zeros;
                    } else {
                        $scope.practice[time] = time_array[0] < 10 ? '0' + $scope.practice[time] + ':00' : $scope.practice[time] + ':00';
                    };
                };
            };
            //#endregion

            //Change password ---------------------------------------------------
            $scope.ResetPassword = function () {
                alertService.changePasswordPopup($scope.practice.id, 'Praxis', $scope);
            };

            $scope.$on('ChangePass', function (event, data) {
                $scope.pass = data;
            });

            // --------------------------------- practice has oct device -------------------------------------
            $scope.changePracticeHasOctDevice = function (icon_clicked) {
                if (!icon_clicked) {
                    $scope.practice.PracticeHasOctDevice = !$scope.practice.PracticeHasOctDevice;
                }

                alertService.ConfirmPassword($scope, confirmChangePracticeHasOctDevice, undefined, 'LABEL_PLEASE_ENTER_YOUR_PASSWORD_TO_CHANGE_PRACTICE_HAS_OCT_DEVICE_SETTING', $rootScope.isDoctor ? $rootScope.id : undefined);
            };
            function confirmChangePracticeHasOctDevice() {
                $scope.practice.PracticeHasOctDevice = !$scope.practice.PracticeHasOctDevice;
            }

            //Cancel, validate -------------------------------------------------
            $scope.Cancel = function () {
                redirect();
            };

            function HideAllMessages() {
                $scope.divContainer = false;
                $scope.BICinvalid = false;
                $scope.BICBankinvalid = false;
                $scope.bsnrExists = false;
                $scope.BankInvalid = false;
                $scope.LoginEmailNotValid = false;
                $scope.MainEmailNotValid = false;
                $scope.EmailNotValid = false;
                $scope.passwordDontValidForm = false;
                $scope.bsnrLengthnotValid = false;
                $scope.IBANinvalid = false;
                $scope.passwordDontMatch = false;
                $scope.passwordInvalidEmpty = false;
                $scope.LoginEmailExists = false;
                $scope.FlagInvalid = false;
                $scope.IBANnotFound = false;
                $scope.fromDateInvalid = false;
                $scope.toDateInvalid = false;
                $scope.fromIsGreaterThanTo = false;
            };
            //Save and check BSNR-------------------------------------------------
            $scope.SavePractice = function () {
                $rootScope.$broadcast('pressEnterToSearchChanged', $scope.practice.PressEnterToSearch);
                if ($scope.pass.ID != undefined) {
                    commonServices.changeAccountPassword($scope.pass, $scope.successFunctionPass, $scope.errorFunctionPass);
                };
                HideAllMessages();
                practiceSettingsService.savePracticeSettings($scope.practice).then(practiceSaved);
            };
            $scope.sendPracticeForm = function () {
                HideAllMessages();

                if (!CheckAllValidations())
                    $scope.SavePractice();


            };

            //Validate IBAN ------------------------------------------------------
            $scope.IbanRetrievenotOK = function (response) {
                alertService.RenderErrorMessage("LABEL_SOMETHING_WENT_WRONG");
            };
            $scope.IbanRetrieveOK = function (response) {

                if (response.BicIban.length > 0) {

                    if ($scope.practice.bic === "" || $scope.practice.bic === null) { $scope.practice.bic = undefined; }
                    if ($scope.practice.bic === undefined) {

                        $scope.practice.bic = response.BicIban[0].bic;
                    }
                    if ($scope.practice.bank === "" || $scope.practice.bank === null) { $scope.practice.bank = undefined; }
                    if ($scope.practice.bank === undefined) {
                        $scope.practice.bank = response.BicIban[0].BankName;
                    }

                }


            };
            $scope.BicBanknotOK = function (response) {

            };
            $scope.BicBankOK = function (response) {


                if (response.BicIban.length > 0) {
                    if ($scope.practice.bic === "" || $scope.practice.bic === null) { $scope.practice.bic = undefined; }
                    if ($scope.practice.bic === undefined) {

                        $scope.practice.bic = response.BicIban[0].bic;
                    }
                    if ($scope.practice.bank === "" || $scope.practice.bank === null) { $scope.practice.bank = undefined; }
                    if ($scope.practice.bank === undefined) {
                        $scope.practice.bank = response.BicIban[0].BankName;
                    }
                }
            };
            $scope.CheckIbanFillBic = function () {


                if ($scope.practice.iban === "") { $scope.practice.iban = undefined; }
                if ($scope.practice.iban != undefined) {
                    var IbanValidBool = validationService.IBANvalidator($scope.practice.iban);
                    if (IbanValidBool === true) {
                        var objiban = {};
                        objiban.iban = $scope.practice.iban;
                        my_accountService.IBanValidation(objiban, $scope.IbanRetrieveOK, $scope.IbanRetrievenotOK);
                    }

                }
            };
            $scope.CheckBicFillBank = function () {

                if ($scope.practice.bic === "" || $scope.practice.bic === null) { $scope.practice.bic = undefined; }
                if (!angular.isUndefined($scope.practice.bic)) {

                    var BicValidBool = validationService.validateBIC($scope.practice.bic);
                    if (BicValidBool === true) {
                        var objbic = {};
                        objbic.bic = $scope.practice.bic;
                        my_accountService.BicBankValidation(objbic, $scope.BicBankOK, $scope.BicBanknotOK);
                    }

                }
            };

            //Validate----------------------------------------------------------------------------------------------------------------
            function CheckAllValidations() {
                if (!validationService.isNotNullOrEmpty($scope.practice.bic)) { $scope.practice.bic = undefined; }
                if (!angular.isUndefined($scope.practice.bic)) {
                    if ($scope.practice.bank === undefined || $scope.practice.bank === "") {
                        var BicValidBool = validationService.validateBIC($scope.practice.bic);
                        if (BicValidBool === false) {
                            $scope.BICinvalid = true;
                        };
                        $scope.divContainer = true;
                        $scope.BankInvalid = true;
                        $scope.FlagInvalid = true;
                    } else {
                        var BicValidBool = validationService.validateBIC($scope.practice.bic);
                        if (BicValidBool === false) {
                            $scope.divContainer = true;
                            $scope.BICinvalid = true;
                            $scope.FlagInvalid = true;
                        };
                    };
                };

                if (!validationService.isNotNullOrEmpty($scope.practice.bank)) { $scope.practice.bank = undefined; }
                if ($scope.practice.bank != undefined && $scope.practice.bic == undefined) {
                    $scope.divContainer = true;
                    $scope.BICBankinvalid = true;
                    $scope.FlagInvalid = true;
                };



                if (!validationService.isNotNullOrEmpty($scope.practice.email)) { $scope.practice.email = undefined; }
                if ($scope.practice.email !== undefined) {
                    var IfValidMail = validationService.validateEmail($scope.practice.email);
                    if (IfValidMail === false) {
                        $scope.divContainer = true;
                        $scope.EmailNotValid = true;
                        $scope.FlagInvalid = true;
                        flagCheckDiv = true;
                    };
                };

                if ($scope.practice.contact_email === "") { $scope.practice.contact_email = undefined; }
                if ($scope.practice.contact_email !== undefined) {
                    var IfValidMail = validationService.validateEmail($scope.practice.contact_email);
                    if (IfValidMail === false) {
                        $scope.divContainer = true;
                        $scope.MainEmailNotValid = true;
                        $scope.FlagInvalid = true;
                        flagCheckDiv = true;
                    };

                };

                if (!validationService.isNotNullOrEmpty($scope.practice.iban)) { $scope.practice.iban = undefined; }
                if ($scope.practice.iban != undefined) {
                    var IbanValidBool = validationService.IBANvalidator($scope.practice.iban);

                    if (IbanValidBool === false) {
                        $scope.divContainer = true;
                        $scope.IBANinvalid = true;
                        $scope.FlagInvalid = true;
                    };
                };

                if (!validationService.isNotNullOrEmpty($scope.practice.bank)) { $scope.practice.bank = undefined; }
                if ($scope.practice.bank != undefined && $scope.practice.bic == undefined) {
                    $scope.divContainer = true;
                    $scope.BICBankinvalid = true;
                    $scope.FlagInvalid = true;
                };

                //#region delivery dates
                if ($scope.practice.DeliveryDateFrom && $scope.practice.DeliveryDateTo) {
                    var from_array = $scope.practice.DeliveryDateFrom.split(':');
                    var from = new Date(1970, 0, 1, from_array[0], from_array[1], 0);
                    var to_array = $scope.practice.DeliveryDateTo.split(':');
                    var to = new Date(1970, 0, 1, to_array[0], to_array[1], 0);

                    if (!isDeliveryDateTimeValid($scope.practice.DeliveryDateFrom)) {
                        $scope.divContainer = true;
                        $scope.fromDateInvalid = true;
                        $scope.FlagInvalid = true;
                    }

                    if (!isDeliveryDateTimeValid($scope.practice.DeliveryDateTo)) {
                        $scope.divContainer = true;
                        $scope.toDateInvalid = true;
                        $scope.FlagInvalid = true;
                    }

                    if (from > to) {
                        $scope.divContainer = true;
                        $scope.fromIsGreaterThanTo = true;
                        $scope.FlagInvalid = true;
                    }
                } else if ($scope.practice.DeliveryDateFrom && !$scope.practice.DeliveryDateTo) {
                    $scope.divContainer = true;
                    $scope.toDateInvalid = true;
                    $scope.FlagInvalid = true;
                } else if (!$scope.practice.DeliveryDateFrom && $scope.practice.DeliveryDateTo) {
                    $scope.divContainer = true;
                    $scope.fromDateInvalid = true;
                    $scope.FlagInvalid = true;
                }
                //#endregion

                if ($scope.FlagInvalid == true) {
                    return true;
                }
                else {
                    return false;
                }
            };

            function isDeliveryDateTimeValid(dateTime) {
                if (/[0-9]{2}:[0-9]{2}/.test(dateTime) === false) {
                    return false;
                }
                else {
                    if (parseInt(dateTime.substring(0, 2)) > 23 || parseInt(dateTime.substring(3, 5)) > 59) {
                        return false;
                    }
                    return true;
                }
            }
            //Alert messages----------------------------------------------------
            function practiceSaved(response) {
                $scope.parameters = {};
                $scope.parameters.isPracticeLoggedIn = $scope.isPracticeLoggedIn;
                $scope.parameters.practice_name = $scope.practice.name;
                $scope.$emit("AccountEdited", $scope.parameters)
                alertService.RenderSuccessMessage('LABEL_CHANGES_SAVED');
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
        }]);
})();
