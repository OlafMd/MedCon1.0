define(['angularAMD'], function (angularAMD) {

    angularAMD.directive('addDoctorDirective', function () {

        return {

            templateUrl:
                'scripts/src/app/doctor/view/addDoctorTemplate.html',

            scope: {
                mode: "=mode"
            },
            replace: true,
            restrict: 'E',
            controller: addDoctorController
        };



        function addDoctorController($scope, $rootScope, $translate, doctorService, validationService, ngDialog, $timeout, $routeParams, alertsServices, commonServices, $location, $interval) {

            var practiceID;
            $scope.doctor = {};
            $scope.showstarReq = true;
            HideAllMessages();
            drSetInitialPass();
            SetCheckBox();
            $scope.practices = [];
            $scope.practice_bank_details = {};
            $scope.pass = {};
            $scope.not_mergeable = true;

            flagCheckDiv = false;
            $scope.FlagInvalid = false;

            function HideAllMessages() {
                $scope.divContainer = false;
                $scope.lanrLengthnotValid = false;
                $scope.lanrNotValid = false;
                $scope.lanrExists = false;
                $scope.EmailNotValid = false;
                $scope.passwordDontValidForm = false;
                $scope.IBANinvalid = false;
                $scope.passwordDontMatch = false;
                $scope.passwordInvalidEmpty = false;
                $scope.BICBankinvalid = false;
                $scope.BICinvalid = false;
                $scope.LoginEmailNotValid = false;
                $scope.LoginEmailExists = false;
                $scope.BankInvalid = false;
                $scope.passwordDontMAtch = false;
                $scope.FlagInvalid = false;
                $scope.LanrNotnumber = false;
                flagCheckDiv = false;
            };

            $scope.PracticeInfoFound = function (response) {
                if ((response[0].IBAN !== null && response[0].IBAN.length > 0) || (response[0].BankName.length > 0 && response[0].BICCode.length > 0)) {
                    $scope.practice_bank_details = angular.copy(response[0]);

                    $scope.doctor.IsUserPRacticeBank = true;
                    $scope.doctor.AccountHolder = $scope.practice_bank_details.OwnerText;
                    $scope.doctor.Bank = $scope.practice_bank_details.BankName;
                    $scope.doctor.Bic = $scope.practice_bank_details.BICCode;
                    $scope.doctor.Iban = $scope.practice_bank_details.IBAN;

                    $scope.ChPracticeDisabled = false;
                    $scope.DrinAccountHolderDis = true;
                    $scope.DrinIbanDis = true;
                    $scope.DrinBicDis = true;
                    $scope.DrinBankDis = true;
                } else {
                    $scope.doctor.IsUserPRacticeBank = false;
                    $scope.ChPracticeDisabled = true;
                    $scope.DrinAccountHolderDis = false;
                    $scope.DrinIbanDis = false;
                    $scope.DrinBicDis = false;
                    $scope.DrinBankDis = false;
                };
            };

            $scope.doctorDetailsComplete = function (response) {
                var practiceForSend = new Object();
                practiceForSend.PracticeID = response.doctor.practice_id;

                $scope.doctor.Title = response.doctor.title;
                $scope.doctor.FirstName = response.doctor.first_name;
                $scope.doctor.LastName = response.doctor.last_name;
                $scope.doctor.Email = response.doctor.email;
                $scope.doctor.Phone = response.doctor.phone;
                $scope.doctor.LANR = response.doctor.lanr;
                $scope.doctor.PracticeName = response.doctor.practice;
                $scope.doctor.PracticeID = response.doctor.practice_id;
                $scope.doctor.IsUserPRacticeBank = response.doctor.is_bank_inherited;
                $scope.doctor.LoginEmail = response.doctor.login_email;
                $scope.doctor.Password = 'password';
                $scope.doctor.Bank = response.doctor.bank_name;
                $scope.doctor.Bic = response.doctor.bic;
                $scope.doctor.Iban = response.doctor.iban;
                $scope.doctor.AccountHolder = response.doctor.account_holder;
                $scope.doctor.IsAccountDeactivated = response.doctor.account_deactivated;
                $scope.doctor.is_temp = response.doctor.is_temp;
                $scope.doctor.Salutation = response.doctor.salutation;
                $scope.doctor.CustomerNumber = response.doctor.customer_number;
                $scope.doctor.IsCertificatedForOCT = response.doctor.is_certificated_for_oct;
                $scope.doctor.OctvalidFrom = response.doctor.oct_valid_from;

                $scope.is_temp = response.doctor.is_temp;
                $scope.not_mergeable = !$scope.is_temp;

                if ($scope.is_temp) {
                    $scope.doctor.TemporaryDoctorID = $routeParams.doctor_id;
                };

                if (response.doctor.is_temp)
                    $scope.doctor.comment = response.doctor.comment;

                if ($scope.doctor.IsUserPRacticeBank) {
                    doctorService.GetBankAccountInfoforPracticeID(practiceForSend, $scope.PracticeInfoFound, $scope.PracticeInfonotFound);
                } else {
                    $scope.doctor.IsUserPRacticeBank = false;
                    $scope.DrinAccountHolderDis = false;
                    $scope.DrinIbanDis = false;
                    $scope.DrinBicDis = false;
                    $scope.DrinBankDis = false;
                };
            };

            $scope.isCertificatedForOctChanged = function () {
                if ($scope.doctor.IsCertificatedForOCT === undefined || !$scope.doctor.IsCertificatedForOCT) {
                    $scope.doctor.OctvalidFrom = undefined;
                }
            }

            $scope.doctorDetailsError = function (response) {
                console.log(response.ReturnMessage[0]);
            };

            $scope.getDoctorDetails = function () {
                var doctor = new Object();
                doctor.ID = $routeParams.doctor_id;
                doctorService.getDoctorDetails(doctor, $scope.doctorDetailsComplete, $scope.doctorDetailsError);
            };

            $scope.PracticeInfonotFound = function (response) {
                console.log(response);
            };

            if ($scope.mode === 'add_from_practice') {
                var practice = new Object();
                practice.PracticeID = $routeParams.practice_id;
                doctorService.GetBankAccountInfoforPracticeID(practice, $scope.PracticeInfoFound, $scope.PracticeInfonotFound);
            } else if ($scope.mode === 'edit') {
                $scope.getDoctorDetails();
            };

            $scope.closeDoctorForm = function () {
                $scope.doctor = {};
                $scope.FlagInvalid = false;
                $rootScope.$broadcast('CloseForm', ["CloseDoctor"]);
            };
            $scope.closeDoctorFormModal = function ($event) {
                if ($event.target.id != "btnPracticeDir") {
                    $scope.closeDoctorForm();
                }
            };

            $scope.salutation = [{ label: 'LABEL_MR', value: 'Herr' },
                         { label: 'Frau', value: 'Frau' }
            ];

            $scope.doctor.Salutation = $scope.salutation[1];

            $scope.practicesFound = function (response) {
                $scope.practices = response;
            };

            $scope.practicesError = function (response) {

            };

            doctorService.GetAllPractices($scope.practicesFound, $scope.practicesError);

            function drSetInitialPass() {
                $scope.drCKGeneratePassword = '1';
                $scope.doctor.inPassword = "";
                $scope.doctor.inPassword = validationService.generatePassword();
                $scope.drdefDisabled = true;
                $scope.drgenDisabled = true;
            };
            $scope.ResetPassword = function () {

                alertsServices.changePasswordPopup($routeParams.doctor_id, 'Arzt', $scope);
            }

            $scope.drGenPass = function () {
                $scope.drCKGeneratePassword = '1';
                $scope.doctor.DefinePassword = "";
                $scope.drdefDisabled = true;
                $scope.drgenDisabled = true;
                $scope.doctor.inPassword = validationService.generatePassword();
            };

            $scope.drTypePass = function () {
                $scope.drCKGeneratePassword = '2';
                $scope.doctor.inPassword = "";
                $scope.doctor.DefinePassword = "";
                $scope.drgenDisabled = false;
                $scope.drdefDisabled = false;

            };

            function SetCheckBox() {

                HideAllMessages();
                $scope.doctor.IsUserPRacticeBank = true;

                $scope.DrinAccountHolderDis = true;
                $scope.DrinIbanDis = true;
                $scope.DrinBicDis = true;
                $scope.DrinBankDis = true;

            };

            $scope.sendDoctorForm = function () {
                HideAllMessages();
                var lanr = $scope.doctor.LANR;
                var isnum = /^\d+$/.test(lanr);

                if (lanr.length !== 9) {
                    $scope.divContainer = true;
                    CheckAllValidations();
                    $scope.lanrLengthnotValid = true;
                }
                else if (!isnum) {
                    $scope.divContainer = true;
                    CheckAllValidations();
                    $scope.LanrNotnumber = true;
                }
                else {
                    var IfValidLanr = validationService.LANRValidation(lanr);
                    if (!IfValidLanr) {
                        CheckAllValidations();
                        $scope.divContainer = true;
                        $scope.lanrNotValid = true;
                        flagCheckDiv = true;

                        var validationParameter = new Object();
                        validationParameter.Type = 'doctor';
                        validationParameter.ContentToValidate = $scope.doctor.LoginEmail;

                        if ($scope.mode === 'edit' && !$scope.is_temp) {
                            validationParameter.ID = $routeParams.doctor_id;
                        }

                        doctorService.checkLoginMail(validationParameter, $scope.LoginMailValid, $scope.LoginMailNotValid);
                    } else {
                        if (!$scope.not_mergeable) {
                            doctorService.checkLanrForMerge({ lanr: $scope.doctor.LANR, practice_id: $scope.doctor.PracticeID }, checkLanrForMergeComplete, checkLanrForMergeError);
                        } else {
                            var validationParameter = new Object();

                            validationParameter.Type = 'doctor';
                            validationParameter.ContentToValidate = $scope.doctor.LoginEmail;

                            if ($scope.mode === 'edit' && !$scope.is_temp) {
                                validationParameter.ID = $routeParams.doctor_id;
                            };

                            doctorService.checkLoginMail(validationParameter, LoginMailValid, LoginMailNotValid);
                        };
                    };
                };
            };

            function LoginMailValid() {
                var validations_not_passed = CheckAllValidations();
                if (!validations_not_passed) {
                    if ($scope.is_temp) {
                        doctorService.checkLanrForMerge({ lanr: $scope.doctor.LANR, practice_id: $scope.doctor.PracticeID }, checkLanrForMergeComplete, checkLanrForMergeError);
                    } else {
                        var doctor = new Object();

                        if ($scope.mode === 'edit') {
                            doctor.DoctorID = $routeParams.doctor_id;
                        }

                        doctor.LANR = $scope.doctor.LANR;
                        doctor.PracticeID = $scope.doctor.PracticeID;
                        doctorService.checkLanr(doctor, $scope.LanrOK, $scope.LanrNotValid);
                    };
                };
            };

            function LoginMailNotValid() {
                $scope.LoginEmailExists = true;
                $scope.divContainer = true;
            };

            function checkLanrForMergeComplete(response) {
                if (response.exists) {
                    $scope.merge_doctor = { doctor_id: response.doctors[0].doctor_id };
                    $scope.content = new Object();
                    $scope.content.doctors = response.doctors;

                    ngDialog.open({
                        template: 'scripts/src/app/doctor/view/mergeDoctorPopupTemplate.html',
                        scope: $scope,
                        closeByDocument: false
                    });
                } else {
                    if (!$scope.not_mergeable)
                        alertsServices.RenderConfirmationDialog('LABEL_MERGE_DOCTOR_TITLE', { message: 'LABEL_LANR_NOT_FOUND' }, 'BUTTON_YES', 'BUTTON_NO', confirmContinueWithoutMerge, cancelContinueWithoutMerge);
                    else {
                        var validated = !CheckAllValidations();

                        doctorService.createDoctor($scope.doctor, $scope.doctorSaved, $scope.doctorNotSaved);
                    };
                };
            };

            function confirmContinueWithoutMerge() {
                $scope.not_mergeable = true;
                $timeout(function () { angular.element('#ddSalutation_value')[0].focus(); }, 0, false);
                return false;
            };

            function cancelContinueWithoutMerge() {
                ngDialog.close();
                $timeout(function () { angular.element('#inLANR')[0].focus(); }, 0, false);
            };

            $scope.confirmMergeDoctor = function () {
                ngDialog.close();
                doctorService.mergeDoctor({ doctor_id: $scope.merge_doctor.doctor_id, temporary_doctor_id: $routeParams.doctor_id }, mergeDoctorComplete, mergeDoctorError);
            };

            function mergeDoctorComplete(response) {
                alertsServices.SuccessMessage('LABEL_DOCTOR_MERGED');
                $location.url('/doctor/doctor_detail/' + response);
            };

            function mergeDoctorError(response) {
                console.log(response);
                alertsServices.ErrorMessage('LABEL_SOMETHING_WENT_WRONG');
            };

            $scope.cancelMergeDoctor = function () {
                ngDialog.close();
                $scope.merge_doctor = new Object();
            };

            function checkLanrForMergeError(response) {
                console.log(response);
                alertsServices.ErrorMessage('LABEL_SOMETHING_WENT_WRONG');
            };

            $scope.$on('ChangePass', function (event, data) {
                $scope.pass = data;
            });
            $scope.successFunctionPass = function () { };
            $scope.errorFunctionPass = function () { };
            function DoctorReadyForSave() {
                $scope.customerNumberFormatInvalid = undefined;
                $scope.octValidFromDateInvalid = undefined;

                if ($scope.doctor.CustomerNumber !== undefined && $scope.doctor.CustomerNumber !== '' && $scope.doctor.CustomerNumber !== null) {
                    if (!/^\d+$/.test($scope.doctor.CustomerNumber)) {
                        $scope.customerNumberFormatInvalid = true;
                        $scope.divContainer = true;
                        angular.element('#inCustomerNumber')[0].focus();
                    };
                };

                if ($scope.doctor.IsCertificatedForOCT !== undefined && $scope.doctor.IsCertificatedForOCT && !validationService.isValidDate($scope.doctor.OctvalidFrom)) {
                    $scope.octValidFromDateInvalid = true;
                    $scope.divContainer = true;
                    angular.element('#octValidFrom')[0].focus();
                }

                if ($scope.customerNumberFormatInvalid || $scope.octValidFromDateInvalid) {
                    return false;
                }

                if ($scope.mode === 'add_from_practice') {
                    $scope.doctor.PracticeID = $routeParams.practice_id;
                } else if ($scope.mode === 'edit') {
                    if ($scope.doctor.is_temp) {
                        $scope.doctor.DoctorID = null;
                    } else {
                        $scope.doctor.DoctorID = $routeParams.doctor_id;
                    };
                };


                doctorService.createDoctor($scope.doctor, $scope.doctorSaved, $scope.doctorNotSaved);

                HideAllMessages();

            };

            $scope.LanrOK = function (response) {
                var validateBool = CheckAllValidations();

                if ($scope.doctor.LoginEmail === "") { $scope.doctor.LoginEmail = undefined; }
                if ($scope.doctor.LoginEmail !== undefined) {
                    $scope.ValidateEmailForLogin();

                } else if (!validateBool) {
                    DoctorReadyForSave();
                };
            };


            $scope.LoginMailValid = function (response) {

            };

            $scope.LoginMailNotValid = function (response) {
                $scope.LoginEmailExists = true;
                flagCheckDiv = true;
            };

            $scope.LanrNotValid = function (response) {
                $scope.divContainer = true;
                $scope.lanrExists = true;

                CheckAllValidations();
                var validationParameter = new Object();

                validationParameter.Type = 'doctor';
                validationParameter.ContentToValidate = $scope.doctor.LoginEmail;

                if ($scope.mode === 'edit' && !$scope.is_temp) {
                    validationParameter.ID = $routeParams.doctor_id;
                }

                doctorService.checkLoginMail(validationParameter, $scope.LoginMailValid, $scope.LoginMailNotValid);
            };

            $scope.doctorSaved = function (response) {
                if ($scope.pass.ID == null) { $scope.pass.ID == undefined }
                if ($scope.pass.ID != undefined) {
                    commonServices.changeAccountPassword($scope.pass, $scope.successFunctionPass, $scope.errorFunctionPass);
                };

                showMessagePopupSuccess();
                if ($scope.is_temp) {
                    $location.url('/doctor/doctor_detail/' + response);
                } else {
                    $rootScope.$broadcast('CloseForm', ["CloseDoctor"]);
                }
            };
            $scope.doctorNotSaved = function (response) {
                console.log(response);
                alertsServices.ErrorMessage('LABEL_SOMETHING_WENT_WRONG');
            };

            $scope.IbannotOK = function (response) {

            };
            $scope.IbanOK = function (response) {

                if (response.BicIban.length > 0) {

                    if ($scope.doctor.Bic === "" || $scope.doctor.Bic === null) { $scope.doctor.Bic = undefined; }
                    if ($scope.doctor.Bic === undefined) {

                        $scope.doctor.Bic = response.BicIban[0].bic;
                    }
                    if ($scope.doctor.Bank === "" || $scope.doctor.Bank === null) { $scope.doctor.Bank = undefined; }
                    if ($scope.doctor.Bank === undefined) {
                        $scope.doctor.Bank = response.BicIban[0].BankName;
                    }

                };
            };
            $scope.CheckIbanFillBic = function () {


                if ($scope.doctor.Iban === "") { $scope.doctor.Iban = undefined; }
                if ($scope.doctor.Iban != undefined) {
                    var IbanValidBool = validationService.IBANvalidator($scope.doctor.Iban);
                    if (IbanValidBool === true) {
                        var objiban = {};
                        objiban.Iban = $scope.doctor.Iban;
                        doctorService.IBanValidation(objiban, $scope.IbanOK, $scope.IbannotOK);
                    }

                }
            };

            $scope.BicBanknotOK = function (response) {

            };
            $scope.BicBankOK = function (response) {

                if (response.BicIban.length > 0) {
                    if ($scope.doctor.Bic === "" || $scope.doctor.Bic === null) { $scope.doctor.Bic = undefined; }
                    if ($scope.doctor.Bic === undefined) {
                        $scope.doctor.Bic = response.BicIban[0].bic;
                    }
                    if ($scope.doctor.Bank === "" || $scope.doctor.Bank === null) { $scope.doctor.Bank = undefined; }
                    if ($scope.doctor.Bank === undefined) {
                        $scope.doctor.Bank = response.BicIban[0].BankName;

                    }
                }
            };

            $scope.CheckBicFillBank = function () {

                if ($scope.doctor.Bic === "" || $scope.doctor.Bic === null) { $scope.doctor.Bic = undefined; }
                if (!angular.isUndefined($scope.doctor.Bic)) {

                    BicValidBool = validationService.validateBIC($scope.doctor.Bic);
                    if (BicValidBool === true) {
                        var objbic = {};
                        objbic.bic = $scope.doctor.Bic;
                        doctorService.BicBankValidation(objbic, $scope.BicBankOK, $scope.BicBanknotOK);
                    }

                }
            }


            function CheckAllValidations() {
                if (!validationService.isNotNullOrEmpty($scope.doctor.Bic)) { $scope.doctor.Bic = undefined; }
                if (!angular.isUndefined($scope.doctor.Bic)) {
                    if ($scope.doctor.Bank === undefined || $scope.doctor.Bank === "") {
                        BicValidBool = validationService.validateBIC($scope.doctor.Bic);
                        if (BicValidBool === false) {
                            $scope.BICinvalid = true;
                        };
                        $scope.divContainer = true;
                        $scope.BankInvalid = true;
                        $scope.FlagInvalid = true;
                    } else {
                        var BicValidBool = validationService.validateBIC($scope.doctor.Bic);
                        if (BicValidBool === false) {
                            $scope.divContainer = true;
                            $scope.BICinvalid = true;
                            $scope.FlagInvalid = true;
                        };
                    };
                };

                if (!validationService.isNotNullOrEmpty($scope.doctor.Bank)) { $scope.doctor.Bank = undefined; }
                if ($scope.doctor.Bank != undefined && $scope.doctor.Bic == undefined) {
                    $scope.divContainer = true;
                    $scope.BICBankinvalid = true;
                    $scope.FlagInvalid = true;
                };

                if (!validationService.isNotNullOrEmpty($scope.doctor.Email)) { $scope.doctor.Email = undefined; }
                if ($scope.doctor.Email !== undefined) {
                    var IfValidMail = validationService.validateEmail($scope.doctor.Email);
                    if (IfValidMail === false) {
                        $scope.divContainer = true;
                        $scope.EmailNotValid = true;
                        $scope.FlagInvalid = true;
                        flagCheckDiv = true;
                    };
                };

                if (!validationService.isNotNullOrEmpty($scope.doctor.LoginEmail)) { $scope.doctor.LoginEmail = undefined; }
                if ($scope.doctor.LoginEmail !== undefined) {
                    var IfValidMail = validationService.validateEmail($scope.doctor.LoginEmail);
                    if (IfValidMail === false) {
                        $scope.divContainer = true;
                        $scope.LoginEmailNotValid = true;
                        $scope.FlagInvalid = true;
                        flagCheckDiv = true;
                    };
                };

                if (!validationService.isNotNullOrEmpty($scope.doctor.Iban)) { $scope.doctor.Iban = undefined; }
                if ($scope.doctor.Iban != undefined) {
                    var IbanValidBool = validationService.IBANvalidator($scope.doctor.Iban);

                    if (IbanValidBool === false) {
                        $scope.divContainer = true;
                        $scope.IBANinvalid = true;
                        $scope.FlagInvalid = true;
                    };
                };

                if ($scope.drCKGeneratePassword == '2') {
                    if ($scope.doctor.DefinePassword === "") { $scope.doctor.DefinePassword = undefined; };
                    if ($scope.doctor.inPassword === "") { $scope.doctor.inPassword = undefined; };
                    if ($scope.doctor.LoginEmail === "" || $scope.doctor.LoginEmail === null) { $scope.doctor.LoginEmail = undefined; }
                    if ($scope.doctor.LoginEmail !== undefined) {
                        if ($scope.doctor.DefinePassword === undefined || $scope.doctor.inPassword === undefined) {
                            $scope.divContainer = true;
                            $scope.passwordInvalidEmpty = true;
                            $scope.FlagInvalid = true;
                            flagCheckDiv = true;
                        };
                    };
                };

                if ($scope.doctor.DefinePassword === "") { $scope.doctor.DefinePassword = undefined; }
                if ($scope.doctor.DefinePassword != undefined) {
                    if ($scope.doctor.LoginEmail === "") { $scope.doctor.LoginEmail = undefined; }
                    if ($scope.doctor.LoginEmail !== undefined) {
                        var passwordValidation = validationService.ValidatePassword($scope.doctor.inPassword);

                        if (passwordValidation === false) {
                            $scope.divContainer = true;
                            $scope.passwordDontValidForm = true;
                            $scope.FlagInvalid = true;
                            flagCheckDiv = true;
                            if ($scope.doctor.DefinePassword != $scope.doctor.inPassword) {
                                $scope.passwordDontMAtch = true;
                                flagCheckDiv = true;
                            };
                        };

                        if ($scope.doctor.DefinePassword != $scope.doctor.inPassword) {
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
                //end of validations
            };

            $scope.ValidateEmailForLogin = function () {
                if ($scope.doctor.LoginEmail === "") { $scope.doctor.LoginEmail = undefined; };
                if ($scope.doctor.LoginEmail !== undefined) {

                    var validationParameter = new Object();
                    validationParameter.Type = 'doctor';
                    validationParameter.ContentToValidate = $scope.doctor.LoginEmail;

                    if ($scope.mode === 'edit' && !$scope.is_temp) {
                        validationParameter.ID = $routeParams.doctor_id;
                    };

                    doctorService.checkLoginMail(validationParameter, $scope.LoginMailOKSend, $scope.LoginMailNotOKSend);
                };
            };


            $scope.LoginMailOKSend = function (response) {
                if ($scope.FlagInvalid == false) {
                    DoctorReadyForSave();
                }
            };
            $scope.LoginMailNotOKSend = function (response) {

                $scope.divContainer = true;
                flagCheckDiv = true;
                $scope.LoginEmailExists = true;
                CheckAllValidations();
                $scope.FlagInvalid = true;
            };

            $scope.successFunction = function (response) {

                showMessagePopupSuccess();

            };

            $scope.errorFunction = function (response) {
                message = 'LABEL_SOMETHING_WENT_WRONG';
                alertsServices.ErrorMessage(message);
            };


            function showMessagePopupSuccess() {
                if ($scope.mode === 'edit') {
                    message = 'LABEL_CHANGES_SAVED';
                } else {
                    message = 'LABEL_DOCTOR_ADDED';
                };

                alertsServices.SuccessMessage(message);
                $scope.doctor = {};

            };

            $scope.FindPracticeBankAccountInfo = function () {
                if (!$scope.mode || $scope.mode !== 'add_from_practice') {
                    var practiceForSend = {};
                    if ($scope.doctor.IsUserPRacticeBank) {
                        HideAllMessages();
                        $scope.DrinAccountHolderDis = true;
                        $scope.IBANinvalid = false;
                        $scope.BICBankinvalid = false;
                        $scope.BICinvalid = false;
                        $scope.BankInvalid = false;
                        $scope.doctor.Iban = "";
                        $scope.doctor.Bic = "";
                        $scope.doctor.Bank = "";
                        $scope.doctor.AccountHolder = "";
                        $scope.DrinIbanDis = true;
                        $scope.DrinBicDis = true;
                        $scope.DrinBankDis = true;
                        if (!angular.isUndefined($scope.doctor.PracticeID)) {

                            practiceForSend.PracticeID = $scope.doctor.PracticeID;
                            doctorService.GetBankAccountInfoforPracticeID(practiceForSend, $scope.PracticeInfoFound, $scope.PracticeInfonotFound);
                        };
                    } else {
                        $scope.DrinAccountHolderDis = false;
                        $scope.DrinIbanDis = false;
                        $scope.DrinBicDis = false;
                        $scope.DrinBankDis = false;
                    };
                } else {
                    $scope.doctor.AccountHolder = $scope.practice_bank_details.OwnerText;
                    $scope.doctor.Bank = $scope.practice_bank_details.BankName;
                    $scope.doctor.Bic = $scope.practice_bank_details.BICCode;
                    $scope.doctor.Iban = $scope.practice_bank_details.IBAN;
                    $scope.DrinAccountHolderDis = $scope.doctor.IsUserPRacticeBank;
                    $scope.DrinIbanDis = $scope.doctor.IsUserPRacticeBank;
                    $scope.DrinBicDis = $scope.doctor.IsUserPRacticeBank;
                    $scope.DrinBankDis = $scope.doctor.IsUserPRacticeBank;
                };
            };

            $scope.FillCheckBoxFields = function (value) {
                $scope.showstarReq = false;
                if (!angular.isUndefined(value) && value !== '') {
                    practiceID = value.originalObject.HEC_MedicalPractiseID;
                    $scope.doctor.PracticeID = practiceID;
                };
                var practiceForSend = {};
                if ($scope.ChPracticeDisabled) {
                    $scope.ChPracticeDisabled = false;
                    $scope.doctor.IsUserPRacticeBank = false;
                }
                if ($scope.doctor.IsUserPRacticeBank == true) {
                    practiceForSend.PracticeID = practiceID;
                    $scope.doctor.Iban = "";
                    $scope.doctor.Bic = "";
                    $scope.doctor.Bank = "";
                    $scope.doctor.AccountHolder = "";
                    doctorService.GetBankAccountInfoforPracticeID(practiceForSend, $scope.PracticeInfoFound, $scope.PracticeInfonotFound);

                };
            };

            if ($scope.is_temp) {
                var interval = $interval(function () {
                    var element = angular.element('#inLANR')[0];
                    if (element) {
                        $interval.cancel(interval);
                        element.focus();
                    }
                }, 20, 100, false);
            } else {
                var interval = $interval(function () {
                    var element = angular.element('#ddSalutation_value')[0];
                    if (element) {
                        $interval.cancel(interval);
                        element.focus();
                    }
                }, 20, 100, false);
            }
            //end of doctor controller
        };
    });
});