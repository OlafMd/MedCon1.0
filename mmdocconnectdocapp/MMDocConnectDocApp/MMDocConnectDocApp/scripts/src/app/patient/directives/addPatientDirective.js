(function () {
    'use strict';

    angular.module('mainModule').directive('addPatientDirective',
        function () {

            return {
                templateUrl: function (element, attrs) { return attrs.templateUrl; },
                scope: {
                    mode: "=mode",
                    operation: '=',
                    id: '=',
                    treatmentDate: '='
                },
                replace: true,
                restrict: 'E',
                controller: ['$scope', '$rootScope', 'patientService', 'alertService', 'ngDialog', '$filter', 'validationService', 'commonServices', '$routeParams', '$http', addPatientController]
            };

            function addPatientController($scope, $rootScope, patientService, alertService, ngDialog, $filter, validationService, commonServices, $routeParams, $http) {

                $scope.sexList = [
                    { code: '0', name: 'männlich' },
                    { code: '1', name: 'weiblich' },
                    { code: '2', name: 'ohne Angabe' }
                ];

                $scope.title_label = $scope.operation !== undefined ? 'LABEL_EDIT_PATIENT' : 'LABEL_ADD_NEW_PATIENT';

                $scope.showstarReq = true;
                $scope.showMessageContainer = false;
                $scope.isHealthInsuranceNumberValid = true;
                $scope.isDateValid = true;
                $scope.isIssueDateValid = true;
                $scope.isinsurance_statusCodeValid = true;
                $scope.patient = new Object();
                $scope.showParticipationConsentForm = false;
                $scope.isIssueDateHIgherOrEqualToContractStartDate = true;
                $scope.contractList = [];
                $scope.disableParticipationConsentbtn = true;
                $scope.isBirthdayValid = true;
                $scope.insurance_status_type = 3;
                $scope.is_singel_insurance_status_type = true;
                $scope.oldValueIST = null;
                $scope.patient.health_insurance_provider = undefined;
                var previousHIP = new Object();
                var previousContract = new Object();
                var previousIssueDate = '';

                $scope.initalDataFound = function (response) {
                    if ($scope.mode === 'edit') {
                        $scope.contractList = response.ContractList;
                        $scope.patient.first_name = response.PatientData.first_name;
                        $scope.patient.last_name = response.PatientData.last_name;
                        $scope.patient.bithday = response.PatientData.birthday;
                        $scope.patient.sex = response.PatientData.sex;
                        $scope.patient.external_id = response.PatientData.external_id;
                        $scope.showstarReq = false;
                        $scope.patient.id = response.PatientData.id;
                        if (!response.PatientData.is_privately_insured) {
                            previousHIP.is_privately_insured = false;
                            previousHIP.ik_number = response.PatientData.health_insurance_provider.secondary_display_name;
                            angular.element("#inhealth_insurance_provider_value").val(response.PatientData.health_insurance_provider.display_name);
                            $scope.patient.health_insurance_provider = response.PatientData.health_insurance_provider;
                            $scope.patient.insurance_id = response.PatientData.insurance_id;

                            var insuranceStatus = response.PatientData.insurance_status.replace(/ /g, '');

                            if (insuranceStatus.length == 2 || insuranceStatus.length == 1 || insuranceStatus.length == 3) {
                                $scope.insurance_status_type = 1;
                            } else {
                                $scope.insurance_status_type = 2;
                            };

                            $scope.oldValueIST = insuranceStatus;
                            $scope.patient.insurance_status = insuranceStatus;
                        } else {
                            $scope.patient.is_privately_insured = true;
                            previousHIP.is_privately_insured = true;
                        };

                        if (response.PatientData.hasParticipationConsent) {
                            $scope.disableParticipationConsentbtn = false;
                            $scope.patient.participation_id = response.PatientData.participation_id;
                            $scope.patient.issue_date = response.PatientData.participation_consent_date;
                            if ($scope.operation === undefined || checkIfConsentDateCoversTreatment($scope.treatmentDate)) {
                                $scope.showParticipationConsentForm = true;

                                for (var i = 0; i < response.ContractList.length; i++) {
                                    if (response.ContractList[i].id === response.PatientData.contract_id) {
                                        $scope.patient.contract = response.ContractList[i];
                                        break;
                                    }
                                };
                                $scope.ValidFrom = $filter('date')(new Date($scope.patient.contract.ValidFrom), 'MM.dd.yyyy');
                            } else {
                                $scope.patient.issue_date = undefined;
                                $scope.patient.contract = undefined;
                            };
                        };
                    };

                    $scope.disableParticipationConsentbtn = response.ContractList.length === 0;
                };

                function checkIfConsentDateCoversTreatment(date) {
                    var yyyy = date.substr(6, 4);
                    var mm = date.substr(3, 2);
                    var dd = date.substr(0, 2);
                    var treatment_date = new Date(parseInt(yyyy), parseInt(mm) - 1, parseInt(dd));

                    yyyy = $scope.patient.issue_date.substr(6, 4);
                    mm = $scope.patient.issue_date.substr(3, 2);
                    dd = $scope.patient.issue_date.substr(0, 2);
                    var issue_date = new Date(parseInt(yyyy), parseInt(mm) - 1, parseInt(dd));

                    return treatment_date >= issue_date;
                };

                $scope.initalDataError = function (response) {
                    console.log(response);
                    alertService.RenderErrorMessage("LABEL_SOMETHING_WENT_WRONG");
                };

                if ($scope.mode === 'edit') {
                    var parameter = new Object();
                    parameter.patientID = $routeParams.patient_id !== undefined ? $routeParams.patient_id : $scope.id;
                    patientService.getPatientEditInitalData(parameter, $scope.initalDataFound, $scope.initalDataError);
                }

                $scope.closePatientForm = function () {
                    $scope.patient = {};
                    $rootScope.$broadcast('CloseForm', ["ClosePatient"]);
                };

                $scope.doesArrayContainChar = function (arrValues, element) {
                    return (arrValues.indexOf(element) > -1)
                };

                $scope.KVNRSuccess = function (response) {
                    if (response)
                        $scope.isHealthInsuranceNumberValid = true;
                    else {
                        $scope.isHealthInsuranceNumberValid = /^\d+$/.test($scope.patient.insurance_id.toString());
                    };

                    $scope.showMessageContainer = !$scope.isHealthInsuranceNumberValid;
                };

                $scope.KVNRError = function (response) {
                    console.log(response);
                    alertService.RenderErrorMessage("LABEL_SOMETHING_WENT_WRONG");
                };

                // ---------------------------------------------------------------- VALIDATION ---------------------------------------------------------------------------

                //Insurance number validations***********************************START
                $scope.validateinsurance_statusCode = function (code) {
                    var matchFirst = ["1", "4", "6", "7", "8", "9", "d", "f", "a", "c", "s", "p", "e", "n", "m", "x", "k", "l"];
                    if (code.length == 2) {
                        var charArray = code.split("");

                        if (!$scope.doesArrayContainChar(matchFirst, charArray[1].toLowerCase())) {
                            return false;
                        }
                        if (!(/[135]/.test(charArray[0]))) {
                            return false;
                        }

                        $scope.patient.insurance_status = charArray[0] + "000" + charArray[1];
                        return true;
                    } else if (code.length != 5) {
                        return false;
                    } else {
                        var charArray = code.split("");

                        if (!$scope.doesArrayContainChar(matchFirst, charArray[4].toLowerCase())) {
                            return false;
                        }
                        if (!(/[135][0-8][0-9][0-9]/.test(charArray[0] + charArray[1] + charArray[2] + charArray[3]))) {
                            return false;
                        }
                        return true;
                    }
                };
                $scope.validateinsurance_statusCode_2Characters_Old = function (code) {
                    var matchFirst = ["1", "4", "6", "7", "8", "9", "d", "f", "a", "c", "s", "p", "e", "n", "m", "x", "k", "l"];
                    var charArray = code.split("");

                    if (!$scope.doesArrayContainChar(matchFirst, charArray[1].toLowerCase())) {
                        return false;
                    }
                    if (!(/[135]/.test(charArray[0]))) {
                        return false;
                    }
                    return true;
                };
                $scope.validateinsurance_statusCode_2Characters_New = function (code) {
                    var charArray = code.split("");

                    if (!(/[4678]/.test(charArray[1]))) {
                        return false;
                    }
                    if (!(/[135]/.test(charArray[0]))) {
                        return false;
                    }
                    return true;
                };
                $scope.validateinsurance_statusCode_1Characters_New = function (code) {
                    var charArray = code.split("");
                    if (!(/[135]/.test(code))) {
                        return false;
                    }
                    return true;
                };
                $scope.validateinsurance_statusCode_3Characters_New = function (code) {
                    var charArray = code.split("");

                    if (!(/[4678]/.test(charArray[1]))) {
                        return false;
                    }
                    if (!(/[135]/.test(charArray[0]))) {
                        return false;
                    }
                    if (!(/[123456]/.test(charArray[2]))) {
                        return false;
                    }
                    return true;
                };

                //Insurance number validations***********************************END

                $scope.ValidationHelpFunction = function () {
                    //**Validation of patient insurance number***************
                    //popUp
                    if ($scope.patient.insurance_status != undefined) {
                        var insuranceStatus = $scope.patient.insurance_status.replace(/ /g, '');

                        if (insuranceStatus.length == 2) {
                            var isTheSameValue = $scope.oldValueIST != null ? $scope.oldValueIST == insuranceStatus : true;
                            var isOldValid = $scope.validateinsurance_statusCode_2Characters_Old(insuranceStatus);
                            var isNewValid = $scope.validateinsurance_statusCode_2Characters_New(insuranceStatus);

                            if ($scope.insurance_status_type == 3 && isOldValid && isNewValid) {
                                $scope.is_singel_insurance_status_type = false;
                                $scope.isinsurance_statusCodeValid = false;
                                $scope.showMessageContainer = true;
                                alertService.RenderWarningMessage_withRadioButtons("LABEL_WARNING", "LABEL_INSURANCE_STATUS_BOTH", "BUTTON_CONFIRM_NORMALCASE", "BUTTON_BACK", $scope);
                            }
                            else if ($scope.insurance_status_type != 3 && isOldValid && isNewValid) {

                                if (isTheSameValue) {
                                    $scope.is_singel_insurance_status_type = false;
                                    if ($scope.insurance_status_type == 2) {
                                        $scope.isinsurance_statusCodeValid = $scope.validateinsurance_statusCode(insuranceStatus);
                                    } else if ($scope.insurance_status_type == 1) {
                                        $scope.isinsurance_statusCodeValid = $scope.validateinsurance_statusCode_2Characters_New(insuranceStatus);
                                    };
                                } else {
                                    $scope.is_singel_insurance_status_type = false;
                                    $scope.isinsurance_statusCodeValid = false;
                                    $scope.showMessageContainer = true;
                                    alertService.RenderWarningMessage_withRadioButtons("LABEL_WARNING", "LABEL_INSURANCE_STATUS_BOTH", "BUTTON_CONFIRM_NORMALCASE", "BUTTON_BACK", $scope);
                                };
                            }
                            else if (!isOldValid && isNewValid) {
                                $scope.is_singel_insurance_status_type = true;
                                $scope.isinsurance_statusCodeValid = true;
                                $scope.showMessageContainer = false;
                            } else if (isOldValid && !isNewValid) {
                                $scope.is_singel_insurance_status_type = true;
                                $scope.isinsurance_statusCodeValid = $scope.validateinsurance_statusCode(insuranceStatus);
                            }
                            else if (!isOldValid && !isNewValid) {
                                $scope.is_singel_insurance_status_type = true;
                                $scope.isinsurance_statusCodeValid = false;
                                $scope.showMessageContainer = true;
                            }
                        } else if (insuranceStatus.length == 1) {
                            $scope.is_singel_insurance_status_type = true;
                            $scope.isinsurance_statusCodeValid = $scope.validateinsurance_statusCode_1Characters_New(insuranceStatus);
                        } else if (insuranceStatus.length == 3) {
                            $scope.is_singel_insurance_status_type = true;
                            $scope.isinsurance_statusCodeValid = $scope.validateinsurance_statusCode_3Characters_New(insuranceStatus);
                        }
                        else {
                            $scope.is_singel_insurance_status_type = true;
                            $scope.isinsurance_statusCodeValid = $scope.validateinsurance_statusCode(insuranceStatus);
                        }
                    } else if ($scope.patient.insurance_status == undefined) {
                        $scope.is_singel_insurance_status_type = true;
                        $scope.isinsurance_statusCodeValid = true;
                        $scope.showMessageContainer = false;
                    } else {
                        $scope.is_singel_insurance_status_type = true;
                        $scope.isinsurance_statusCodeValid = false;
                        $scope.showMessageContainer = true;
                    }

                    $scope.isDateValid = $scope.patientForm.dpbithday.$viewValue != undefined ? _isDateValid($scope.patientForm.dpbithday.$viewValue) : true;

                    if ($scope.isDateValid)
                        $scope.isBirthdayValid = validationService.isDateHigherThenTodayDate_string($scope.patientForm.dpbithday.$viewValue);

                    if ($scope.patient.issue_date === undefined || $scope.patient.issue_date === "")
                        $scope.isIssueDateValid = true;
                    else {
                        $scope.isIssueDateValid = _isDateValid($scope.patientForm.dpIssue_date.$viewValue);

                        if ($scope.isIssueDateValid) {
                            var dateFrom = new Date(parseInt($scope.patient.issue_date.substring(6)), parseInt($scope.patient.issue_date.substring(3, 5)) - 1, parseInt($scope.patient.issue_date.substring(0, 2)));
                            var contractFrom = new Date($scope.patient.contract.ValidFrom);
                            var contractTo = new Date($scope.patient.contract.ValidTo);
                            var isContractValidIndefinite = contractTo.getFullYear() === 1;
                            var consentDateValidComparedToValidThroughDate = isContractValidIndefinite ? true : dateFrom.withoutTime() < contractTo;
                            $scope.isIssueDateHIgherOrEqualToContractStartDate = dateFrom.withoutTime() >= contractFrom.withoutTime() && consentDateValidComparedToValidThroughDate;
                        } else {
                            $scope.isIssueDateHIgherOrEqualToContractStartDate = true;
                        };
                    };


                    $scope.showMessageContainer = $scope.showMessageContainer || !$scope.isIssueDateValid || !$scope.isIssueDateHIgherOrEqualToContractStartDate || !$scope.isBirthdayValid || !$scope.isDateValid || !$scope.isinsurance_statusCodeValid || !$scope.isHealthInsuranceNumberValid;
                    if ($scope.isinsurance_statusCodeValid == true && $scope.isHealthInsuranceNumberValid == true && $scope.isDateValid == true && $scope.isIssueDateValid == true && $scope.isIssueDateHIgherOrEqualToContractStartDate == true && $scope.isBirthdayValid == true) {
                        $scope.showMessageContainer = false;
                        return true;
                    } else if ($scope.patient.contract !== undefined) {
                        $scope.contractValidFromStr = $filter('date')(new Date($scope.patient.contract.ValidFrom), 'dd.MM.yyyy');
                        $scope.contractValidToStr = new Date($scope.patient.contract.ValidTo).getFullYear() === 1 ? '∞' : $filter('date')(new Date($scope.patient.contract.ValidTo), 'dd.MM.yyyy');
                        $scope.showMessageContainer = true;
                        return false;
                    };
                };

                $scope.validateForm = function () {
                    if ($scope.patient.insurance_id != undefined && $scope.patient.insurance_id.toString().length >= 6 && $scope.patient.insurance_id.toString().length <= 12) {
                        var object = new Object();
                        object.insuranceNumber = $scope.patient.insurance_id.toString();
                        $http({ method: 'GET', url: "api/patient/CheckNewKVNRValidation", params: object }).success(function (response, status, headers, config) {
                            if (response) {
                                $scope.isHealthInsuranceNumberValid = true;
                                $scope.showMessageContainer = false;
                                return $scope.ValidationHelpFunction();
                            } else {
                                // if kvnr validation becomes optional again, uncomment these lines and remove the ones below 
                                //$scope.isHealthInsuranceNumberValid = /^\d+$/.test($scope.patient.insurance_id.toString());
                                //return $scope.ValidationHelpFunction();
                                
                                $scope.isHealthInsuranceNumberValid = false;
                                $scope.showMessageContainer = true;
                            }
                        }).error(function (response) {
                            $scope.isHealthInsuranceNumberValid = false;
                            $scope.showMessageContainer = true;
                            return $scope.ValidationHelpFunction();
                        });
                    }
                    else if ($scope.patient.insurance_id === undefined) {
                        $scope.isHealthInsuranceNumberValid = true;
                        return $scope.ValidationHelpFunction();
                    }
                    else {
                        $scope.isHealthInsuranceNumberValid = false;
                        $scope.showMessageContainer = true;
                        return $scope.ValidationHelpFunction();
                    }
                };

                $scope.successSavePatientFunction = function (response) {
                    $scope.patient.id = response;
                    if ($scope.mode === 'edit')
                        alertService.RenderSuccessMessage("LABEL_PATIENT_EDITED").then(newPatientCreated);
                    else
                        alertService.RenderSuccessMessage("LABEL_SAVED_NEW_PATIENT").then(newPatientCreated);

                    $rootScope.$broadcast('CloseForm', ["ClosePatient"]);
                };

                function newPatientCreated() {
                    var new_patient = new Object();
                    new_patient.name = $scope.patient.first_name + ' ' + $scope.patient.last_name;
                    new_patient.display_name = new_patient.name + " (" + $filter('date')($scope.patient.bithday, 'dd.MM.yyyy') + ")";
                    new_patient.id = $scope.patient.id;
                    $rootScope.$broadcast('NewPatientAdded', new_patient);
                }

                $scope.errorSavePatientFunction = function (response) {
                    alertService.RenderErrorMessage("LABEL_CANT_SAVE");
                };

                $scope.savePatient = function () {
                    $scope.patient.hip_changed = $scope.hipChanged;
                    patientService.savePatient($scope.patient, $scope.successSavePatientFunction, $scope.errorSavePatientFunction);
                };

                $scope.successHINumber = function (response) {
                    var insuranceStatus = $scope.patient.insurance_status.replace(/ /g, '');
                    if ((response.healthInsuranceCheck.isValid && insuranceStatus.length != 3) || (response.healthInsuranceCheck.isValid && $scope.is_singel_insurance_status_type == true && insuranceStatus.length == 3)) {
                        $scope.savePatient();
                    } else {
                        if (insuranceStatus.length != 3 || ($scope.is_singel_insurance_status_type == true && insuranceStatus.length == 3))
                            alertService.RenderWarningMessage("LABEL_WARNING", response.healthInsuranceCheck.warning_messages, "BUTTON_YES", "BUTTON_NO", $scope);
                    }
                };

                $scope.errorHINumber = function (response) {
                    alertService.RenderErrorMessage("LABEL_CANT_SAVE");
                };

                $scope.submitPatientForm = function () {
                    $scope.hipChanged = false;
                    if (previousHIP.is_privately_insured) {
                        $scope.hipChanged = previousHIP.is_privately_insured !== $scope.patient.is_privately_insured;
                    } else {
                        if ($scope.patient.health_insurance_provider === undefined)
                            $scope.hipChanged = true;
                        else
                            $scope.hipChanged = previousHIP.ik_number !== $scope.patient.health_insurance_provider.secondary_display_name;
                    };

                    if ($scope.hipChanged && $routeParams.patient_id !== undefined)
                        patientService.canChangeHIP({ patientID: $routeParams.patient_id }, $scope.continueFormSubmit, errorFunction);
                    else
                        $scope.continueFormSubmit(true);
                };

                $scope.continueFormSubmit = function (isSubmissible) {
                    if (isSubmissible) {
                        if (!$scope.patient.is_privately_insured) {
                            if ($scope.patient.insurance_id !== undefined && $scope.patient.insurance_id.toString().length >= 6 && $scope.patient.insurance_id.toString().length <= 12) {
                                var object = new Object();
                                object.insuranceNumber = $scope.patient.insurance_id.toString();
                                $http({ method: 'GET', url: "api/patient/CheckNewKVNRValidation", params: object }).success(function (response, status, headers, config) {
                                    if (response) {
                                        $scope.isHealthInsuranceNumberValid = true;
                                        $scope.showMessageContainer = false;
                                        isValidForm($scope.ValidationHelpFunction())
                                    } else {
                                        // if kvnr validation becomes optional again, uncomment these lines and remove the ones below 
                                        //$scope.isHealthInsuranceNumberValid = /^\d+$/.test($scope.patient.insurance_id.toString());
                                        //isValidForm($scope.ValidationHelpFunction())

                                        $scope.isHealthInsuranceNumberValid = false;
                                        $scope.showMessageContainer = true;
                                    }
                                }).error(function (response) {
                                    $scope.isHealthInsuranceNumberValid = false;
                                    $scope.showMessageContainer = true;
                                    isValidForm($scope.ValidationHelpFunction())
                                });
                            }
                            else if ($scope.patient.insurance_id == undefined) {
                                $scope.isHealthInsuranceNumberValid = true;
                                $scope.showMessageContainer = false;
                                isValidForm($scope.ValidationHelpFunction())
                            }
                            else {
                                $scope.isHealthInsuranceNumberValid = false;
                                $scope.showMessageContainer = true;
                                isValidForm($scope.ValidationHelpFunction())
                            }
                        } else {
                            $scope.savePatient();
                        };
                    } else {
                        alertService.RenderNotificationMessage([{ message: 'LABEL_HIP_CANT_BE_CHANGED_OPEN_CASES_EXIST' }], $scope, undefined, {
                            url: '/planning/?filter=' + $scope.patient.first_name + '_' + $scope.patient.last_name,
                            message: 'LABEL_VIEW_ALL_PLANNED_IVOMS'
                        });
                    };
                };

                function isValidForm(isValid) {
                    if (isValid) {
                        var isOldValidationPHIS = false;
                        if ($scope.insurance_status_type == 1)
                            isOldValidationPHIS = false;
                        else if ($scope.insurance_status_type == 2)
                            isOldValidationPHIS = true;
                        else {
                            if ($scope.validateinsurance_statusCode($scope.patient.insurance_status.replace(/ /g, '')))
                                isOldValidationPHIS = true;
                            else
                                isOldValidationPHIS = false;
                        }
                        patientService.checkIfHINumberIsUnique($scope.patient.id, $scope.patient.insurance_id, $scope.patient.first_name, $scope.patient.last_name, $scope.patient.bithday, $scope.patient.insurance_status, $scope.patient.sex, isOldValidationPHIS, $scope.successHINumber, $scope.errorHINumber);
                    }
                };


                $scope.SetClass = function () {
                    $('.gray-content-holder').css('overflow', 'visible');
                };

                $scope.SelectHIP = function (selectedObject) {
                    if ($scope.patient.contract !== undefined && !angular.equals($scope.patient.contract, previousContract)) {
                        angular.copy($scope.patient.contract, previousContract);
                    };

                    if ($scope.patient.issue_date !== undefined)
                        previousIssueDate = $scope.patient.issue_date;

                    if (selectedObject !== undefined && selectedObject !== null && selectedObject.originalObject !== undefined) {
                        $scope.patient.health_insurance_provider = selectedObject.originalObject;
                        $scope.showstarReq = selectedObject.originalObject === undefined;
                        patientService.getContractsWhereHIPisParticipating({ ik_number: $scope.patient.health_insurance_provider.secondary_display_name }, getContractsWhereHIPisParticipatingComplete, errorFunction);
                    } else {
                        $scope.showstarReq = true;
                        $scope.contractList = [];
                        $scope.patient.issue_date = undefined;
                        $scope.patient.contract = undefined;
                        $scope.patient.health_insurance_provider = undefined;
                    };
                };

                $scope.deleteInsuranceData = function () {
                    if ($scope.patient.is_privately_insured) {
                        $scope.patient.insurance_id = undefined;
                        $scope.patient.insurance_status = undefined;
                        $scope.patient.health_insurance_provider = undefined;
                        $scope.disableParticipationConsentbtn = true;
                        $scope.showstarReq = true;
                        $scope.showParticipationConsentForm = false;
                        $scope.patient.issue_date = undefined;
                        $scope.patient.contract = undefined;

                        $rootScope.$broadcast('angucomplete-alt:clearInput');
                    };
                };

                function getContractsWhereHIPisParticipatingComplete(response) {
                    $scope.contractList = response;
                    var hipParticipates = $scope.patient.contract !== undefined && $scope.patient.contract !== null ? response.map(function (ctr) {
                        return ctr.id
                    }).indexOf($scope.patient.contract.id) > -1 : true;
                    $scope.disableParticipationConsentbtn = response.length === 0;

                    if (!hipParticipates) {
                        $scope.patient.issue_date = undefined;
                        $scope.patient.contract = undefined;
                        $scope.showParticipationConsentForm = false;
                    } else {
                        $scope.patient.issue_date = previousIssueDate;
                        $scope.patient.contract = previousContract;
                    };

                    if ($scope.disableParticipationConsentbtn) {
                        $scope.patient.issue_date = undefined;
                        $scope.patient.contract = undefined;
                        $scope.showParticipationConsentForm = false;
                    };
                };

                function errorFunction(response) {
                    console.log(response);
                    alertService.RenderErrorMessage('LABEL_SOMETHING_WENT_WRONG');
                };

                $scope.yes_warning_function = function () {
                    ngDialog.close();
                    $scope.savePatient();
                };

                $scope.quit_function = function () {
                    ngDialog.close();
                    $scope.insurance_status_type = 3
                    $scope.oldValueIST = null;
                };
                $scope.confirm_function = function () {
                    ngDialog.close();
                    $scope.oldValueIST = $scope.patient.insurance_status.replace(/ /g, '');
                    $scope.submitPatientForm();
                };

                //Participation consent----------------------------------------
                $scope.ToggleFormAddParticipationConsent = function () {
                    if (!$scope.disableParticipationConsentbtn) {
                        $scope.showParticipationConsentForm = !$scope.showParticipationConsentForm;
                        $scope.patient.issue_date = "";
                        $scope.patient.contract = null;
                        $scope.isIssueDateValid = true;
                        $scope.isIssueDateHIgherOrEqualToContractStartDate = true;
                        if ($scope.showParticipationConsentForm) {
                            commonServices.focusElement('#dpIssue_date');
                        }

                        if ($scope.validateForm())
                            $scope.showMessageContainer = false;
                    };
                };

                $scope.selectedContract = function () {
                    if ($scope.patient.contract !== undefined && $scope.patient.contract !== null) {
                        $scope.ValidFrom = $filter('date')(new Date($scope.patient.contract.ValidFrom), 'MM.dd.yyyy');
                        $scope.patient.issue_date = $scope.patient.issue_date === undefined || $scope.patient.issue_date === '' || $scope.patient.issue_date === null ? $filter('date')(new Date(), 'dd.MM.yyyy') : $scope.patient.issue_date;
                    };
                };

                //helper function ---------------------------------------------
                function _isDateValid(inputDate) {
                    if (inputDate.length == 10) {
                        var characterInput = inputDate.charAt(2);
                        var characterInput2 = inputDate.charAt(4);

                        var day = inputDate.substring(0, 2);
                        var month = inputDate.substring(3, 5);
                        var yearInp = inputDate.substring(6, 10);

                        var str = (day + '.' + month + '.' + yearInp);
                        return validationService.isValidDate(str);
                    }
                    else {
                        return false;
                    }
                }

                $scope.is_mode = function (mode) {
                    return $scope.mode === mode;
                };

                $scope.closePatientFromCaseForm = function () {
                    ngDialog.close();
                };

                function findObjectInArrayByKey(Array, key) {
                    for (var i = 0; i < Array.length; i++) {
                        if (Array[i].id == key)
                            return Array[i];
                    }
                };

                $scope.closePatientFromCaseForm = ngDialog.close;

                $scope.remoteUrlRequestFn = function (str) {
                    return { search_criteria: str !== undefined && str !== null ? str : '' };
                };

                commonServices.focusElement('#infirst_name');
            };
        });
})();