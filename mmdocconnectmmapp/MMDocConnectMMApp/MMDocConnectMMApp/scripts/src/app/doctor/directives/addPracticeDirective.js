
define(['angularAMD'], function (angularAMD) {

    //angularAMD.directive('showPracticeTemplate',['$scope', '$rootScope', '$translate', 'doctorService', 'ajaxService', 'validationService', 'ngDialog', '$timeout',  function ($scope, $rootScope, $translate, doctorService, ajaxService, validationService, ngDialog, $timeout) {
    angularAMD.directive('addPracticeDirective', function () {
        return {

            templateUrl:
                'scripts/src/app/doctor/view/addPracticeTemplate.html',

            scope: {
                mode: "=mode"
            },
            replace: true,
            restrict: 'E',
            controller: addPracticeController
        };

        function addPracticeController($scope, $rootScope, $translate, doctorService, ajaxService, validationService, pharmacyService, ngDialog, $timeout, $routeParams, alertsServices, commonServices, $interval) {
            flagCheckDiv = false;

            var emptyGuid = '00000000-0000-0000-0000-000000000000';
            var nonePharmacy = { 'display_name': "LABEL_NONE", 'id': emptyGuid };
            $scope.pharmacies = [];

            $scope.isQuickOrderBtnEnabled = false;

            $scope.HideAllMessages = function () {
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
                flagCheckDiv = false;
                $scope.fromDateInvalid = false;
                $scope.toDateInvalid = false;
                $scope.fromIsGreaterThanTo = false;
            };

            var previous_account_status = false;
            var practice_has_doctors = false;
            $scope.pass = {};
            $scope.practice = {};
            $scope.practice.Bank = "";
            $scope.practice.Bic = "";
            $scope.HideAllMessages();
            $scope.BlockCloseDiv = false;
            SetInitialPass();
            $scope.showValidationMessages = false;

            if (!$scope.mode) {
                $scope.practice.IsOrderDrugs = true;
            }

            $scope.FlagInvalid = false;


            $scope.closePracticeForm = function () {
                $scope.HideAllMessages();
                $scope.practice = {};
                $scope.FlagInvalid = false;
                $rootScope.$broadcast('CloseForm', ["ClosePractice"]);
            };
            $scope.closePracticeFormModal = function ($event) {
                if ($event.target.id != "btnDoctorDir") {
                    $scope.closePracticeForm();
                }
            };

            function SetInitialPass() {

                $scope.CKGeneratePassword = '1';
                $scope.practice.inPassword = "";
                $scope.practice.inPassword = validationService.generatePassword();
                $scope.defDisabled = true;
                $scope.genDisabled = true;
            };


            $scope.GenPass = function () {
                $scope.CKGeneratePassword = '1';
                $scope.practice.DefinePassword = "";
                $scope.defDisabled = true;
                $scope.genDisabled = true;
                $scope.practice.inPassword = validationService.generatePassword();
            };

            $scope.TypePass = function () {
                $scope.CKGeneratePassword = '2';
                $scope.practice.inPassword = "";
                $scope.practice.DefinePassword = "";
                $scope.genDisabled = false;
                $scope.defDisabled = false;

            };

            $scope.ResetPassword = function () {

                alertsServices.changePasswordPopup($routeParams.practice_id, 'Praxis', $scope);
            }

            $scope.practiceDetailsComplete = function (response) {
                var address_details = response.practice.address.split(' ');
                var number = address_details.pop();
                var town_details = response.practice.town.split(' ');
                var zip = town_details.shift();

                $scope.practice.practiceName = response.practice.name;
                $scope.practice.Street = address_details.join(' ');
                $scope.practice.No = number;

                $scope.practice.Zip = parseInt(zip);
                $scope.practice.City = town_details.join(' ');
                $scope.practice.Bsnr = response.practice.bsnr;
                $scope.practice.MainEmail = response.practice.email === null ? "" : response.practice.email;
                $scope.practice.MainPhone = response.practice.phone;
                $scope.practice.Fax = response.practice.fax;
                $scope.practice.ContactPerson = response.practice.contact.name;
                $scope.practice.Email = response.practice.contact.email;
                $scope.practice.Phone = response.practice.contact.phone;
                $scope.practice.IsSurgeryPractice = response.practice.is_surgery_practice;
                $scope.practice.IsOrderDrugs = response.practice.is_order_drugs;
                $scope.practice.IsOnlyLabelRequired = response.practice.is_only_label_required;
                $scope.practice.isWaiveServiceFee = response.practice.is_waive_service_fee;
                $scope.practice.DefaultShippingDateOffset = response.practice.default_shipping_date_offset;
                $scope.practice.LoginEmail = response.practice.login_email;
                $scope.practice.AccountHolder = response.practice.account_holder;
                $scope.practice.Iban = response.practice.iban;
                $scope.practice.Bic = response.practice.bic;
                $scope.practice.Bank = response.practice.bank;
                $scope.practice.IsAccountDeactivated = response.practice.account_deactivated;
                $scope.practice.ShouldDownloadReportUponSubmission = response.practice.shouldDownloadReportUponSubmission;
                $scope.practice.PressEnterToSearch = response.practice.pressEnterToSearch;

                $scope.practice.DefaultPharmacy = response.practice.defaultPharmacy;
                $scope.practice.IsQuickOrderActive = response.practice.isQuickOrderActive;
                $scope.practice.DeliveryDateFrom = response.practice.deliveryDateFrom;
                $scope.practice.DeliveryDateTo = response.practice.deliveryDateTo;
                $scope.practice.UseGracePeriod = response.practice.useGracePeriod;

                previous_account_status = response.practice.account_deactivated;
                practice_has_doctors = response.practice.practice_has_doctors; 
            };

            $scope.practiceDetailsError = function (response) {
                console.log(response.ReturnMessage[0]);
            };

            $scope.getPharmacies = function () {
                pharmacyService.getPharmacies(null, getPharmaciesComplete, $scope.practiceDetailsError);
            }

            $scope.getPracticeDetails = function () {
                var practice = new Object();
                practice.ID = $routeParams.practice_id;
                doctorService.getPracticeDetails(practice, $scope.practiceDetailsComplete, $scope.practiceDetailsError);
            };

            if ($scope.mode) {
                $scope.getPracticeDetails();
            };
            $scope.getPharmacies();

            $scope.sendPracticeForm = function () {
                $scope.HideAllMessages();

                var bsnr = $scope.practice.Bsnr.toString();

                if (bsnr.length !== 9) {
                    $scope.divContainer = true;
                    $scope.bsnrLengthnotValid = true;
                    $scope.CheckAllValidations();
                } else {
                    $scope.bsnrNotNumber = !/^\d+$/.test(bsnr);

                    if ($scope.bsnrNotNumber) {
                        $scope.divContainer = true;
                        $scope.CheckAllValidations();
                        return false;
                    };

                    var parameter = new Object();
                    parameter.BSNR = bsnr;

                    if ($scope.mode) {
                        parameter.PracticeID = $routeParams.practice_id;
                    };

                    doctorService.checkBsnr(parameter, $scope.BsnrOK, $scope.bsnrNotValid);
                };
            };


            //#region pharmacies
            function getPharmaciesComplete(response) {
                $scope.pharmacies = response.map(function (x) {
                    return {
                        'display_name': x.pharmacyName, 'id': x.pharmacyID
                    };
                });
                $scope.pharmacies.push(nonePharmacy)

                if (!$scope.mode) {
                    $scope.practice.DefaultPharmacy = emptyGuid;
                }
            }

            $scope.checkIsQuickOrderDisabled = function () {
                $scope.isQuickOrderBtnEnabled = $scope.practice.DefaultPharmacy != emptyGuid &&
                   $scope.practice.Street != undefined && $scope.practice.Street.length > 0 &&
                   $scope.practice.No != undefined && $scope.practice.No.length > 0 &&
                   $scope.practice.Zip != undefined && $scope.practice.Zip > -1 &&
                   $scope.practice.City != undefined && $scope.practice.City.length > 0 &&
                   $scope.practice.DeliveryDateFrom != undefined && $scope.practice.DeliveryDateFrom.length > 0 &&
                   $scope.practice.DeliveryDateTo != undefined && $scope.practice.DeliveryDateTo.length > 0;

                if (!$scope.isQuickOrderBtnEnabled) {
                    $scope.practice.IsQuickOrderActive = false;
                    return true;
                }
                return false;
            }

            //DELIVERY TIME
            $scope.fixTime = function (time) {
                if ($scope.practice[time].length > 0 && $scope.practice[time].length < 5) {
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
            $scope.practiceSaved = function (response) {
                $scope.parameters = {};
                $scope.parameters.isPracticeLoggedIn = $scope.isPracticeLoggedIn;
                $scope.parameters.practice_name = $scope.practice.name;
                $scope.$emit("AccountEdited", $scope.parameters)
                alertService.RenderSuccessMessage('LABEL_CHANGES_SAVED');
                redirect();
            };

            $scope.LoginMailnotOK = function (response) {
                $scope.LoginEmailExists = true;
            };

            $scope.LoginMailOK = function (response) {

            };

            $scope.$on('ChangePass', function (event, data) {
                $scope.pass = data;
            });
            $scope.successFunctionPass = function () { };
            $scope.errorFunctionPass = function () { };

            $scope.PracticeReadyForSave = function () {
                if ($scope.mode) {
                    $scope.practice.PracticeID = $routeParams.practice_id;
                    if (practice_has_doctors && previous_account_status != $scope.practice.IsAccountDeactivated) {
                        $scope.title = previous_account_status ? "LABEL_ACTIVATE_DOCTOR_ACCOUNTS_TITLE" : "LABEL_DEACTIVATE_DOCTOR_ACCOUNTS_TITLE";

                        $scope.message = previous_account_status ? "LABEL_ACTIVATE_DOCTOR_ACCOUNTS_CONTENT" : "LABEL_DEACTIVATE_DOCTOR_ACCOUNTS_CONTENT";

                        alertsServices.RenderNotificationMessage($scope);
                    } else {
                        doctorService.createPractice($scope.practice, $scope.successFunction, $scope.errorFunction);
                        $scope.HideAllMessages();
                    }
                } else {

                    doctorService.createPractice($scope.practice, $scope.successFunction, $scope.errorFunction);
                    $scope.HideAllMessages();
                };
            };

            $scope.closePopup = function () {
                ngDialog.close();
                $scope.practice.Change_Doctor_Account_Statuses = true;
                doctorService.createPractice($scope.practice, $scope.successFunction, $scope.errorFunction);
                $scope.HideAllMessages();
            };

            $scope.BsnrOK = function (response) {

                var validateBool = $scope.CheckAllValidations();
                if ($scope.practice.LoginEmail === "") { $scope.practice.LoginEmail = undefined; }
                if ($scope.practice.LoginEmail !== undefined && !$scope.mode) {
                    $scope.ValidateEmailForLogin();
                }
                else if (validateBool === false) {
                    $scope.PracticeReadyForSave();
                }

            };

            $scope.bsnrNotValid = function (response) {
                $scope.divContainer = true;
                $scope.bsnrExists = true;
                flagCheckDiv = true;
                $scope.CheckAllValidations();


                var validationParameter = new Object();
                validationParameter.Type = 'practice';
                validationParameter.ContentToValidate = $scope.practice.LoginEmail;

                if ($scope.mode === 'edit') {
                    validationParameter.ID = $routeParams.practice_id;
                }

                doctorService.checkLoginMail(validationParameter, $scope.LoginMailOK, $scope.LoginMailnotOK);

            };

            $scope.IbannotOK = function (response) {

            };
            $scope.IbanOK = function (response) {

                if (response.BicIban.length > 0) {

                    if ($scope.practice.Bic === "" || $scope.practice.Bic === null) { $scope.practice.Bic = undefined; }
                    if ($scope.practice.Bic === undefined) {
                        $scope.practice.Bic = response.BicIban[0].bic;
                    }
                    if ($scope.practice.Bank === "" || $scope.practice.Bank === null) { $scope.practice.Bank = undefined; }
                    if ($scope.practice.Bank === undefined) {
                        $scope.practice.Bank = response.BicIban[0].BankName;
                    }

                }


            };
            $scope.CheckIbanFillBic = function () {

                if ($scope.practice.Iban === "") { $scope.practice.Iban = undefined; }
                if ($scope.practice.Iban != undefined) {
                    var IbanValidBool = validationService.IBANvalidator($scope.practice.Iban);
                    if (IbanValidBool === true) {
                        var objiban = {};
                        objiban.Iban = $scope.practice.Iban;
                        doctorService.IBanValidation(objiban, $scope.IbanOK, $scope.IbannotOK);
                    }


                }
            };

            $scope.BicBanknotOK = function (response) {

            };
            $scope.BicBankOK = function (response) {

                if (response.BicIban.length > 0) {
                    if ($scope.practice.Bic === "" || $scope.practice.Bic === null) { $scope.practice.Bic = undefined; }
                    if ($scope.practice.Bic === undefined) {
                        $scope.practice.Bic = response.BicIban[0].bic;
                    }
                    if ($scope.practice.Bank === "" || $scope.practice.Bank === null) { $scope.practice.Bank = undefined; }
                    if ($scope.practice.Bank === undefined) {
                        $scope.practice.Bank = response.BicIban[0].BankName;
                    }
                }
            };

            $scope.CheckBicFillBank = function () {

                if ($scope.practice.Bic === "" || $scope.practice.Bic === null) { $scope.practice.Bic = undefined; }
                if (!angular.isUndefined($scope.practice.Bic)) {

                    BicValidBool = validationService.validateBIC($scope.practice.Bic);
                    if (BicValidBool === true) {

                        objbic = {};
                        objbic.bic = $scope.practice.Bic;
                        doctorService.BicBankValidation(objbic, $scope.BicBankOK, $scope.BicBanknotOK);

                    }

                }
            }

            $scope.CheckAllValidations = function () {

                if ($scope.practice.Bic === "" || $scope.practice.Bic === null) { $scope.practice.Bic = undefined; }
                if (!angular.isUndefined($scope.practice.Bic)) {
                    if ($scope.practice.Bank == undefined || $scope.practice.Bank == "") {
                        BicValidBool = validationService.validateBIC($scope.practice.Bic);
                        if (BicValidBool === false) {
                            $scope.BICinvalid = true;
                        };
                        $scope.divContainer = true;
                        $scope.BankInvalid = true;
                        flagCheckDiv = true;
                        $scope.FlagInvalid = true;
                    } else {
                        var BicValidBool = validationService.validateBIC($scope.practice.Bic);
                        if (BicValidBool === false) {
                            $scope.divContainer = true;
                            $scope.BICinvalid = true;
                            flagCheckDiv = true;
                            $scope.FlagInvalid = true;
                        };
                    };
                };

                if ($scope.practice.Bank === "") { $scope.practice.Bank = undefined; }
                if ($scope.practice.Bank != undefined && $scope.practice.Bic == undefined) {
                    $scope.divContainer = true;
                    $scope.BICBankinvalid = true;
                    $scope.FlagInvalid = true;
                };


                if ($scope.practice.Email === "") { $scope.practice.Email = undefined; }
                if ($scope.practice.Email !== undefined) {
                    var IfValidMail = validationService.validateEmail($scope.practice.Email);

                    if (IfValidMail === false) {
                        $scope.divContainer = true;
                        $scope.EmailNotValid = true;
                        $scope.FlagInvalid = true;
                        flagCheckDiv = true;
                    };

                };
                if ($scope.practice.MainEmail === "") { $scope.practice.MainEmail = undefined; }
                if ($scope.practice.MainEmail !== undefined) {
                    var IfValidMail = validationService.validateEmail($scope.practice.MainEmail);
                    if (IfValidMail === false) {
                        $scope.divContainer = true;
                        $scope.MainEmailNotValid = true;
                        $scope.FlagInvalid = true;
                        flagCheckDiv = true;
                    };

                };

                if ($scope.practice.LoginEmail === "") { $scope.practice.LoginEmail = undefined; }
                if ($scope.practice.LoginEmail !== undefined) {
                    var IfValidMail = validationService.validateEmail($scope.practice.LoginEmail); 
                    if (IfValidMail === false) {
                        $scope.divContainer = true;
                        $scope.LoginEmailNotValid = true;
                        $scope.FlagInvalid = true;
                        flagCheckDiv = true;
                    }
                };


                if ($scope.practice.Iban === "") { $scope.practice.Iban = undefined; }
                if ($scope.practice.Iban != undefined) {
                    var IbanValidBool = validationService.IBANvalidator($scope.practice.Iban);

                    if (IbanValidBool === false) {
                        $scope.divContainer = true;
                        $scope.IBANinvalid = true;
                        $scope.FlagInvalid = true;
                    }

                };

                if ($scope.CKGeneratePassword == '2') {
                    if ($scope.practice.DefinePassword === "") { $scope.practice.DefinePassword = undefined; };
                    if ($scope.practice.inPassword === "") { $scope.practice.inPassword = undefined; };
                    if ($scope.practice.LoginEmail === "") { $scope.practice.LoginEmail = undefined; }
                    if ($scope.practice.LoginEmail !== undefined) {
                        if ($scope.practice.DefinePassword === undefined || $scope.practice.inPassword === undefined) {
                            $scope.divContainer = true;
                            $scope.passwordInvalidEmpty = true;
                            flagCheckDiv = true;
                            $scope.FlagInvalid = true;
                        };
                    };
                };

                if ($scope.practice.DefinePassword === "") { $scope.practice.DefinePassword = undefined; }
                if ($scope.practice.DefinePassword != undefined) {
                    if ($scope.practice.LoginEmail === "") { $scope.practice.LoginEmail = undefined; }
                    if ($scope.practice.LoginEmail !== undefined) {
                        var passwordValidation = validationService.ValidatePassword($scope.practice.inPassword);

                        if (passwordValidation === false) {
                            $scope.divContainer = true;
                            $scope.passwordDontValidForm = true;
                            flagCheckDiv = true;
                            $scope.FlagInvalid = true;
                            if ($scope.practice.DefinePassword != $scope.practice.inPassword) {
                                $scope.passwordDontMatch = true;
                                flagCheckDiv = true;
                            };
                        };

                        if ($scope.practice.DefinePassword != $scope.practice.inPassword) {
                            $scope.divContainer = true;
                            $scope.passwordDontMatch = true;
                            flagCheckDiv = true;
                            $scope.FlagInvalid = true;
                        };
                    };

                };

                //Validation for delivery date
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

                if ($scope.FlagInvalid == true) {
                    return true;
                }
                else {
                    return false;
                }

            };

            $scope.ValidateEmailForLogin = function () {
                if ($scope.practice.LoginEmail === "") { $scope.practice.LoginEmail = undefined; };
                if ($scope.practice.LoginEmail !== undefined) {

                    var validationParameter = new Object();
                    validationParameter.Type = 'practice';
                    validationParameter.ContentToValidate = $scope.practice.LoginEmail;

                    if ($scope.mode === 'edit') {
                        validationParameter.ID = $routeParams.practice_id;
                    }

                    doctorService.checkLoginMail(validationParameter, $scope.LoginMailOKSend, $scope.LoginMailNotOKSend);
                }
            };

            $scope.LoginMailOKSend = function (response) {
                if ($scope.FlagInvalid == false) {
                    $scope.PracticeReadyForSave();
                }
            };
            $scope.LoginMailNotOKSend = function (response) {
                $scope.divContainer = true;
                $scope.LoginEmailExists = true;
                $scope.FlagInvalid = true;
                $scope.CheckAllValidations();
            };

            $scope.successFunction = function (response) {
                if ($scope.pass.ID == null) { $scope.pass.ID == undefined }
                if ($scope.pass.ID != undefined) {
                    commonServices.changeAccountPassword($scope.pass, $scope.successFunctionPass, $scope.errorFunctionPass);
                }
                showMessagePopupSuccess();
                $rootScope.$broadcast('CloseForm', ["ClosePractice"]);
            };

            $scope.errorFunction = function (response) {
                message = 'LABEL_SOMETHING_WENT_WRONG';
                alertsServices.ErrorMessage(message);
            };

            function showMessagePopupSuccess() {
                if ($scope.mode) {
                    message = 'LABEL_CHANGES_SAVED';
                } else {
                    message = 'LABEL_PRACTICE_ADDED';
                };

                alertsServices.SuccessMessage(message);
                $scope.practice = {};
            };
        
            var interval = $interval(function () {
                var element = angular.element('#inPracticeName')[0];
                if (element) {
                    $interval.cancel(interval);
                    element.focus();
                }
            }, 20, 100, false);
        };
    });
});