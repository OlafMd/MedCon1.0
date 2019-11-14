(function () {
    'use strict';
    angular.module('mainModule').directive('addCaseDirective', function () {

        return {
            templateUrl: 'scripts/src/app/planning/view/addCasetemplate.html',
            scope: {
                mode: '=',
                id: '=',
                type: '=',
                actionId: '=',
                status: '=',
                isAcEditable: '=',
                patient: '=',
                itemType: '='
            },
            replace: true,
            restrict: 'E',
            controller: ['$scope', '$rootScope', '$translate', 'alertService', 'ngDialog', 'planningService', '$filter', '$routeParams', '$timeout', 'settlementServices',
                '$q', 'validationService', 'commonServices', 'documentationOnlyService', 'practiceSettingsService', 'doctorsService', 'casesService', 'diagnosesService',
                'drugsService', 'ordersService', 'praxisService', 'pharmacyService', '$interval', '$location',
                addCaseController]
        };

        function addCaseController($scope, $rootScope, $translate, alertService, ngDialog, planningService, $filter, $routeParams, $timeout, settlementServices, $q, validationService, commonServices, documentationOnlyService,
            practiceSettingsService, doctorsService, casesService, diagnosesService, drugsService, ordersService, praxisService, pharmacyService, $interval, $location) {

            // ----------------------------------------------------------------------------------- VARIABLES ------------------------------------------------------------------------------------
            var empty_guid = '00000000-0000-0000-0000-000000000000';

            $scope.case = new Object();
            $scope.order_to_submit = new Object();
            $scope.opDoctors = [];
            var old_localization_is_left_eye = undefined;

            var default_shipping_date_offset = 0;
            var oct_doctor = {};

            if (!$scope.mode) {
                $scope.case.treatment_date = $filter('date')(new Date(), 'dd.MM.yyyy');
                $scope.case.order_status = "";
                $scope.case.case_id = empty_guid;
                checkPatientFeeWaiver();
            };
            var octDoctorManuallySelected = false;

            $scope.ValidFrom = $filter('date')(new Date(), 'MM.dd.yyyy');
            $scope.is_treatment_disabled = true;
            $scope.today = $scope.type === 'settlement' ? $scope.ValidFrom : '12.31.2099';
            $scope.treatment_button_label = 'LABEL_ADD_TREATMENT';
            $scope.what_to_focus = '#inPatientName_value';

            var first_run = undefined;

            if ($scope.mode)
                first_run = true;

            getPracticeDefaultSettings();
            getCanShowOrderMessage();

            $scope.showOrderMessage = true;
            function getCanShowOrderMessage() {
                planningService.canShowOrderMessage(function (response) {
                    $scope.showOrderMessage = response
                }, errorFunction);
            }

            doctorsService.getDoctorsInPractice().then(getOPDoctorsComplete);

            if ($scope.mode) {
                var case_param = new Object();
                case_param.case_id = $scope.id;
                planningService.getCaseDetails(case_param, getCaseDetailsComplete, errorFunction);
            };

            if ($scope.type === 'patient') {
                $scope.case.patient_id = $scope.patient.id;
                var interval = $interval(function () {
                    var element = angular.element('#inPatientName_value');
                    if (element && element[0] && element[0].clientHeight) {
                        element.val($scope.patient.display_name);
                        $interval.cancel(interval);
                    }
                }, 100, 20, false);
            };

            // -------------------------------------------------------------------------------- GET DATA FROM DB --------------------------------------------------------------------------------
            getIsPatientHipOnAnOctContract();
            getAllDrugs();
            if ($scope.type === 'settlement') {
                $scope.order_button_disabled = true;
                settlementServices.getFS6CommentForDoctor({ id: $scope.id, secondary_id: $scope.actionId }, getFS6CommentForDoctorComplete, errorFunction);
                $scope.show_error = $scope.status === 'FS6';
            };

            function getCaseDetailsComplete(response) {
                angular.element('#inPatientName_value').val(response.patient_display_name);
                $scope.case.patient_id = response.patient_id;
                $scope.case.drug_id = response.drug_id;
                $scope.case.is_orders_drug = response.is_orders_drug;
                $scope.previous_order_state = response.is_orders_drug;
                $scope.order_button_disabled = $scope.order_button_disabled === undefined ? response.is_orders_drug && !response.can_cancel_order : $scope.order_button_disabled;
                $scope.case.is_patient_fee_waived = $scope.case.is_orders_drug ? response.is_patient_fee_waived : false;
                $scope.case.is_send_invoice_to_practice = $scope.case.is_orders_drug ? response.is_send_invoice_to_practice : false;
                $scope.case.is_label_only = $scope.case.is_orders_drug ? response.is_label_only : false;
                $scope.case.case_id = response.case_id;
                $scope.case.treatment_date = $filter('date')(response.treatment_date, 'dd.MM.yyyy');
                $scope.case.order_comment = response.order_comment;
                $scope.case.order_status = response.order_status;

                var yyyy = $scope.case.treatment_date.substr(6, 4);
                var mm = $scope.case.treatment_date.substr(3, 2);
                var dd = $scope.case.treatment_date.substr(0, 2);
                var treatment_date = new Date(parseInt(yyyy), parseInt(mm) - 1, parseInt(dd));

                $scope.treatment_in_the_past = treatment_date < new Date().setHours(0, 0, 0, 0);

                $scope.ValidThrough = $filter('date')(treatment_date, 'MM.dd.yyyy');

                $scope.case.diagnose_id = response.diagnose_id;
                $scope.case.treatment_doctor_id = response.treatment_doctor_id;
                oct_doctor.id = response.oct_doctor_id;
                oct_doctor.name = response.oct_doctor_display_name;
                checkPatientFeeWaiver();

                if (response.is_treatment_form_open) {
                    $scope.ToggleFormTreatment();
                    $scope.case.is_left_eye = response.is_left_eye;
                    old_localization_is_left_eye = response.is_left_eye;

                    $scope.case.aftercare_doctor_practice = {
                        id: response.aftercare_doctor_practice_id,
                        display_name: response.aftercare_display_name
                    };
                };

                $scope.is_edit_only_order = $scope.mode != undefined && $scope.case.diagnose_id == empty_guid;

                if (($location.path().indexOf('patient_detail') > -1 || $location.path().indexOf('order') > -1) && $scope.itemType == "order") {
                    $scope.is_edit_submitted_only_order = !$scope.order_button_disabled && $scope.case.case_id && $scope.case.case_id != empty_guid && $scope.case.diagnose_id == empty_guid;
                    $scope.is_exist_treatment_with_order = $scope.case.is_orders_drug && $scope.case.case_id && $scope.case.case_id != empty_guid && $scope.case.diagnose_id != empty_guid;
                }
            };

            function getAllDiagnosesComplete(response) {
                $scope.all_diagnoses = response;
                if (!$scope.mode && !$scope.case.diagnose_id)
                    $scope.case.diagnose_id = undefined;

                commonServices.focusElement('#selDiagnose_value');
            };

            function getAllDiagnosesPatientChangedComplete(response) {
                $scope.all_diagnoses = response;
                if (response.map(function (item) { return item.id; }).indexOf($scope.case.diagnose_id) === -1)
                    $scope.case.diagnose_id = undefined;
            };

            function getPracticeDefaultSettings() {
                practiceSettingsService.getPracticeSettings().then(getPracticeDefaultSettingsComplete);
            };

            function getPracticeDefaultSettingsComplete(settings) {
                $scope.isQuickOrderActive = settings.IsQuickOrderActive;
                $scope.labelOnlyVisible = settings.IsOnlyLabelRequired;

                if ($scope.case.is_orders_drug === undefined)
                    $scope.case.is_orders_drug = settings.IsOrderDrugs;

                if ($scope.previous_order_state === undefined) {
                    $scope.previous_order_state = settings.IsOrderDrugs;
                };

                $scope.drugs_delivery_date_offset = settings.default_shipping_date_offset;

                getAllDrugs();
                if ($scope.isQuickOrderActive) {

                    $scope.order_to_submit.street = settings.address;
                    $scope.order_to_submit.city = settings.town;
                    $scope.order_to_submit.number = settings.No;
                    $scope.order_to_submit.zip = settings.Zip;
                    $scope.order_to_submit.receiver = settings.name;
                    $scope.order_to_submit.default_pharmacy = settings.DefaultPharmacy;

                    $scope.order_to_submit.delivery_date = $filter('date')(new Date(), "dd.MM.yyyy");
                    $scope.order_to_submit.delivery_date_from = settings.DeliveryDateFrom;
                    $scope.order_to_submit.delivery_date_to = settings.DeliveryDateTo;

                    default_shipping_date_offset = settings.default_shipping_date_offset;

                    getDoctors();
                }
            };

            function getAllDrugs() {
                drugsService.getAll().then(getAllDrugsComplete);
            };

            function getAllDrugsComplete(response) {
                $scope.all_drugs = response;
                if (!$scope.mode) {
                    $scope.case.drug_id = undefined;
                }
            };

            function getOPDoctorsComplete(response) {
                $scope.opDoctors = response;
                if ($scope.type !== 'settlement')
                    $scope.opDoctors.unshift({ id: empty_guid, display_name: 'LABEL_EMPTY' });

                if (!$scope.mode && !$scope.case.treatment_doctor_id) {
                    $scope.case.treatment_doctor_id = $scope.opDoctors[0].id;
                }

                setOpDoctorAsOctDoctor();
            };

            function getFS6CommentForDoctorComplete(response) {
                $scope.comment = response;
                $scope.show_error = response !== '' && response !== undefined && response !== null;
            };

            function getPreviousCaseDataComplete(response) {
                // todo: remove lines starting with ;;;
                ;;; console.log('Previous case:');
                ;;; console.log(response);
                $scope.case.diagnose_id = response.diagnose_id !== empty_guid ? response.diagnose_id : undefined;
                $scope.case.is_left_eye = response.is_confirmed ? response.is_left_eye : undefined;
                $scope.case.is_confirmed = true;
                $scope.case.treatment_doctor_id = response.treatment_doctor_id;
                $scope.case.aftercare_doctor_practice = {
                    id: response.aftercare_doctor_practice_id,
                    display_name: response.aftercare_display_name
                };

                angular.element('#inACDoctorName_value').val(response.aftercare_display_name);

                $scope.case.oct_doctor_id = response.oct_doctor_id;
                angular.element('#inOctDoctorName_value').val(response.oct_doctor_display_name);

                oct_doctor.id = response.oct_doctor_id;
                oct_doctor.name = response.oct_doctor_display_name;
                octDoctorManuallySelected = !!response.oct_doctor_display_name;

                setOpDoctorAsOctDoctor();
            };

            // -------------------------------------------------------------------------------- ADD NEW PATIENT --------------------------------------------------------------------------------

            $scope.addNewPatient = function () {
                ngDialog.open({
                    template: '<add-patient-directive mode="\'add_from_case\'" template-url="scripts/src/app/patient/view/addPatientFromCasetemplate.html"></add-patient-directive>',
                    plain: true,
                    closeByDocument: false
                });
            };

            $scope.editPatient = function (id) {
                var template = '<add-patient-directive mode="\'edit\'" operation="\'edit_from_case\'" id="patient_id" template-url="scripts/src/app/patient/view/addPatientFromCasetemplate.html" treatment-date="case_treatment_date"></add-patient-directive>';
                template = template.replace('patient_id', '\'' + id + '\'');
                template = template.replace('case_treatment_date', '\'' + $scope.case.treatment_date + '\'');

                ngDialog.open({
                    template: template,
                    plain: true,
                    closeByDocument: false
                });
            };

            $scope.$on('NewPatientAdded', function (event, new_patient) {
                $scope.case.patient_id = new_patient.id;
                var elem = angular.element('#inPatientName_value');
                elem.val(new_patient.display_name);
                commonServices.focusElement('#inPatientName_value');
                $scope.showPatientNameStarReq = false;
                ngDialog.close();
                getIsPatientHipOnAnOctContract();
            });

            // -------------------------------------------------------------------------------- ADD NEW AFTERCARE DOCTOR --------------------------------------------------------------------------------

            $scope.addNewAftercareDoctor = function () {
                ngDialog.open({
                    template: '<add-temporary-aftercare-directive></add-temporary-aftercare-directive>',
                    plain: true,
                    closeByDocument: false
                });
            };

            // ---------------------------------------------------------------------- QUICK ORDER ---------------------------------------------------------------------------
            function openQuickOrder() {
                praxisService.checkIfAutentificationNeeded(
                function (response) {
                    $scope.isAutentificationNeeded = response;
                    if (!$scope.isAutentificationNeeded && ($scope.passwordIsRequired || $scope.isCreateAndSubmitTreatment)) {
                        $scope.isAutentificationNeeded = $scope.passwordIsRequired || $scope.isCreateAndSubmitTreatment;
                    }

                    var treatment_date = $filter('date')($scope.case.treatment_date, "dd.MM.yyyy");
                    var delivery_date = createDateTime(treatment_date);
                    delivery_date.setDate(delivery_date.getDate() - parseInt(default_shipping_date_offset));

                    if (delivery_date >= new Date()) {
                        $scope.order_to_submit.delivery_date = $filter('date')(delivery_date, "dd.MM.yyyy");
                    } else {
                        $scope.order_to_submit.delivery_date = $filter('date')(new Date(), "dd.MM.yyyy");
                    }

                    ngDialog.open({
                        template: 'scripts/src/app/planning/view/quickOrderPopup.html',
                        scope: $scope
                    });
                    $scope.isQuickPopupOpen = true;

                }, errorFunction);
            }

            function getDoctors() {
                doctorsService.getDoctorsInPractice().then(function (response) {
                    $scope.doctors = response;
                    for (var i = 0; i < $scope.doctors.length; i++) {
                        var doctor = $scope.doctors[i];
                        if (doctor.id === $rootScope.id) {
                            $scope.order_to_submit.doctor_id = doctor.id;
                            break;
                        }
                    }

                    getPharmacies();
                });
            }

            function getPharmacies() {
                pharmacyService.getPharmacies().then(getPharmaciesComplete);
            }

            function getPharmaciesComplete(response) {
                $scope.pharmacies = response.map(function (x) {
                    return {
                        'display_name': x.pharmacyName, 'id': x.pharmacyID
                    };
                });

                if ($scope.order_to_submit.default_pharmacy != empty_guid) {
                    angular.forEach($scope.pharmacies, function (item) {
                        if (item.id == $scope.order_to_submit.default_pharmacy) {
                            $scope.default_pharamacy_name = item.display_name;
                        }
                    })
                }
            }

            $scope.cancelSubmitOrder = function () {
                ngDialog.close();
                $scope.isQuickPopupOpen = false;
            };

            $scope.submitOrder = function () {
                if ($scope.isAutentificationNeeded) {
                    ordersService.verifyPassword({
                        doctor: { id: $scope.order_to_submit.doctor_id },
                        password: $scope.order_to_submit.password
                    }, function (response) {
                        $scope.credentials_not_verified = false;
                        $scope.isSubmitOrder = true;
                        createNewCase()
                    }, function () {
                        $scope.credentials_not_verified = true;
                    });
                } else {
                    $scope.credentials_not_verified = false;
                    $scope.isSubmitOrder = true;
                    createNewCase()
                }
            }

            $scope.addOrderToShoppingCart = function () {
                $scope.isSubmitOrder = false;
                createNewCase();
            }


            $scope.verifyPassword = function () {
                $scope.submitClicked = true;

            };

            // -------------------------------------------------------------------------------- SAVE CASE --------------------------------------------------------------------------------
            $scope.createAndSubmitCase = function () {
                $scope.isCreateAndSubmitTreatment = true;
                if (!$scope.isQuickPopupOpen) {
                    alertService.ConfirmPassword($scope, confirmCreateAndSubmitCase, cancelCreateAndSubmitCase, 'LABEL_PLEASE_ENTER_PASSWORD_TO_SUBMIT_CASE', $scope.case.treatment_doctor_id);
                }
            }

            function confirmCreateAndSubmitCase(doctor_id) {
                $scope.order_to_submit.doctor_id = doctor_id;
                $scope.submitCreatedCase = true;
                $scope.createCase();
            }

            function cancelCreateAndSubmitCase() {
                $scope.isCreateAndSubmitTreatment = false;
                ngDialog.close();
            }

            $scope.createCase = function () {
                var is_treatment_date_valid = validationService.isValidDate($scope.case.treatment_date);
                $scope.case.submit_created_case = $scope.submitCreatedCase;

                if (!is_treatment_date_valid) {
                    $scope.case.treatment_date = '';
                    return;
                };

                if ($scope.case.aftercare_doctor_practice) {
                    $scope.case.aftercare_doctor_practice_id = $scope.case.aftercare_doctor_practice.id;
                }

                if ($scope.type === 'settlement') {
                    var yyyy = $scope.case.treatment_date.substr(6, 4);
                    var mm = $scope.case.treatment_date.substr(3, 2) - 1;
                    var dd = $scope.case.treatment_date.substr(0, 2);

                    if (new Date(parseInt(yyyy), parseInt(mm), parseInt(dd)) > new Date().setHours(0, 0, 0, 0)) {
                        if ($scope.type === 'settlement') {
                            alertService.RenderNotificationMessage([{ message: 'LABEL_TREATMENT_DATE_IN_FUTURE' }], $scope, closeNotificationPopup);

                        };
                        $scope.case.treatment_date = '';
                        return;
                    };

                    var param = new Object();
                    param.case_id = $scope.case.case_id;
                    param.id = $scope.case.treatment_doctor_id;
                    param.secondary_id = $scope.case.aftercare_doctor_practice.id;
                    param.tertiary_id = $scope.case.patient_id;
                    param.date_string = $scope.case.treatment_date;
                    param.date = $scope.case.treatment_date;
                    param.diagnose_id = $scope.case.diagnose_id;
                    param.drug_id = $scope.case.drug_id;
                    param.is_left_eye = $scope.case.is_left_eye;

                    planningService.validateConsents(param, validateConsentsComplete, errorFunction);


                } else {
                    if ($scope.type != "patient" && $scope.type != "order" && $scope.isQuickOrderActive && $scope.case.is_orders_drug == true) {
                        planningService.getWillOrderBeCancelled($scope.case,
                            function (response) {
                                $scope.passwordIsRequired = response;

                                if ($scope.case.order_status == "" || $scope.case.order_status == "MO0" || $scope.passwordIsRequired) {
                                    openQuickOrder();
                                } else {
                                    createNewCase();
                                }
                            }, errorFunction);
                    } else {
                        if ($scope.mode && old_localization_is_left_eye != $scope.case.is_left_eye) {
                            planningService.canSaveCaseAfterChangeLocalization($scope.case, function (response) {
                                if (!response) {
                                    alertService.RenderNotificationMessage([{ message: 'LABEL_CANCEL_OCT_FIRST' }], $scope, function () {
                                        ngDialog.close();
                                    });
                                } else {
                                    createNewCase();
                                }
                            }, errorFunction)
                        } else {
                            createNewCase();
                        }
                    }

                };
            };

            function closeNotificationPopup() {
                ngDialog.close();
                $scope.case.treatment_date = '';
                angular.element('#treatmentDate')[0].focus();

            };

            function createNewCase() {
                var yyyy = parseInt($scope.case.treatment_date.substr(6, 4));
                var mm = parseInt($scope.case.treatment_date.substr(3, 2)) - 1;
                var dd = parseInt($scope.case.treatment_date.substr(0, 2));

                var treatment_date = new Date(yyyy, mm, dd);

                $scope.case.treatment_date = $filter('date')(new Date(yyyy, mm, dd), 'dd.MM.yyyy');
                $scope.case.min_delivery_date = new Date(treatment_date.getTime() - $scope.drugs_delivery_date_offset * 24 * 60 * 60 * 1000);

                yyyy = parseInt($scope.case.treatment_date.substr(6, 4));
                mm = parseInt($scope.case.treatment_date.substr(3, 2)) - 1;
                dd = parseInt($scope.case.treatment_date.substr(0, 2));
                treatment_date = new Date(yyyy, mm, dd);

                $scope.case.delivery_date = new Date(treatment_date.getTime() - $scope.drugs_delivery_date_offset * 24 * 60 * 60 * 1000);
                $scope.case.delivery_date = $scope.case.delivery_date < new Date() ? $filter('date')(new Date(), 'dd.MM.yyyy') : $scope.case.delivery_date;
                $scope.case.planned_action_id = $scope.actionId !== undefined ? $scope.actionId : 0;

                if ($scope.showTreatment) {
                    planningService.getMissingIvomCaseExists({
                        patient_id: $scope.case.patient_id,
                        is_left_eye: $scope.case.is_left_eye
                    }, function (response) {
                        if (response) {
                            documentationOnlyService.showExistingAutoGeneratedIvomMessage($scope.case.patient_id, $scope);
                        } else {
                            checkDrugOrder();
                        }
                    }, errorFunction);
                } else {
                    checkDrugOrder();
                }
            };

            function checkDrugOrder() {
                if (!$scope.isQuickPopupOpen) {
                    planningService.getWillOrderBeCancelled($scope.case, function (response) {
                        if (response && !$scope.isSubmitOrder) {
                            alertService.ConfirmPassword($scope, checkOct, undefined, 'LABEL_PLEASE_ENTER_PASSWORD_TO_CHANGE_ORDER', $rootScope.isDoctor ? $rootScope.id : undefined);
                        } else {
                            checkOct();
                        }
                    }, errorFunction);
                } else {
                    checkOct();
                }
            }

            function checkOct() {
                $scope.case.is_quick_order = $scope.isSubmitOrder;
                $scope.case.submited_by_doctor_id = $scope.order_to_submit.doctor_id;

                if (!$scope.case.oct_doctor_id || $scope.case.oct_doctor_id == $scope.opDoctors[0].id) {
                    return checkAndSaveCase();
                }

                planningService.checkIsSameOctDoctor({
                    oct_doctor_id: $scope.case.oct_doctor_id,
                    patient_id: $scope.case.patient_id,
                    is_left_eye: $scope.case.is_left_eye,
                    treatment_date: $scope.case.treatment_date
                }, function (response) {
                    if (response.is_same) {
                        $scope.case.submit_oct_until_date = null;
                        $scope.case.withdraw_oct = false;

                        checkAndSaveCase();
                    } else {
                        $scope.oct_doctor_name = response.name;
                        $scope.current_oct_count = response.current_octs;
                        $scope.max_octs = response.max_octs;
                        $scope.latest_oct_date = response.latest_oct_date;
                        alertService.showOctDoctorChangedPopup($scope).then(function (parameter) {
                            $scope.case.withdraw_oct = true;
                            if (!parameter.withdraw_oct) {
                                $scope.case.submit_oct_until_date = parameter.oct_withdrawal_date;
                            }
                            checkAndSaveCase();
                        });
                    }
                }, errorFunction);
            }


            function checkAndSaveCase() {
                if (!$scope.type || $scope.type == "patient") {
                    planningService.checkIfAlreadyExistTreatment($scope.case, function (response) {
                        if (!response) {
                            if ($scope.case.oct_doctor_id) {
                                return planningService.createCase($scope.case, checkIfOCTCanBeSubmitted, errorFunction);
                            } else {
                                createCaseComplete();
                            }

                            return planningService.createCase($scope.case, checkIfOCTCanBeSubmitted, errorFunction);
                        } else {
                            alertService.RenderNotificationMessage([{ message: 'LABEL_TREATMENT_ALREADY_EXIST' }], $scope, function () {
                                ngDialog.close();
                            });
                        }
                    }, errorFunction)
                } else {

                    if ($scope.case.oct_doctor_id) {
                        return planningService.createCase($scope.case, checkIfOCTCanBeSubmitted, errorFunction);
                    } else {
                        createCaseComplete();
                    }

                    return planningService.createCase($scope.case, checkIfOCTCanBeSubmitted, errorFunction);
                }
            }

            function checkIfOCTCanBeSubmitted(case_id) {
                $scope.case.case_id = case_id;
                if ($scope.mode || !$scope.case.oct_doctor_id) {
                    createCaseComplete();
                } else {
                    planningService.checkIfOCTCanBeSubmitted($scope.case, createCaseComplete, errorFunction);
                }
            }

            function createCaseComplete(responseCaseComplete) {
                var message = '';
                var showBanner = true;
                var showOctMessage = !$scope.mode && responseCaseComplete && !responseCaseComplete.can_submit && responseCaseComplete.oct_exist_for_case;
                var is_treatment_saved = $scope.case.is_orders_drug && $scope.case.diagnose_id !== 0 && $scope.case.diagnose_id;

                //Prepare message
                if ($scope.mode) {
                    message = 'LABEL_CHANGES_SAVED';
                } else {
                    if ($scope.case.is_orders_drug && !is_treatment_saved) {
                        if ($scope.isSubmitOrder) {
                            message = 'ORDER_CONFIRMED';
                        } else {
                            message = 'ORDER_PLACED';
                        }
                    } else {
                        message = 'OP1';
                    };

                    if (is_treatment_saved) {
                        if ($scope.isSubmitOrder) {
                            message = 'TREATMENT_PLANNED_AND_ORDER_CONFIRMED';
                        } else {
                            message = 'TREATMENT_PLANNED_AND_ORDER_PLACED';
                        }
                    };
                };

                //Show order visability message and oct message if needed
                if (!$scope.mode && !$scope.isSubmitOrder && $scope.showOrderMessage) {
                    if ($scope.case.is_orders_drug && !is_treatment_saved) {   //if only order saved
                        showBanner = false;
                        showOctMessage = false;
                        ngDialog.close();
                        alertService.RenderNotificationMessage([{ message: 'LABEL_SUMITTED_ORDER_MESSAGE' }], $scope, function (response) {
                            if (response) {
                                planningService.saveOrderMessageVisability(function () {
                                    ngDialog.close();
                                    if (!$scope.mode && responseCaseComplete && !responseCaseComplete.can_submit && responseCaseComplete.oct_exist_for_case) {
                                        alertService.RenderNotificationMessage([{ message: 'LABEL_SETTLEMENT_NOT_POSSIBLE', date: responseCaseComplete.message }], $scope, function () {
                                            ngDialog.close();
                                            alertService.RenderSuccessMessage(message);
                                            $rootScope.$broadcast('CloseForm', { form: 'CloseCase', reload: true });
                                        });
                                    } else {
                                        alertService.RenderSuccessMessage(message);
                                    }
                                }, errorFunction)
                            }
                            $rootScope.$broadcast('CloseForm', { form: 'CloseCase', reload: true });
                        }, { 'show_checkbox': true });
                    } else if (is_treatment_saved) {    //if treatment and order saved
                        showBanner = false;
                        showOctMessage = false;
                        ngDialog.close();
                        alertService.RenderNotificationMessage([{ message: 'LABEL_SUMITTED_ORDER_MESSAGE' }], $scope, function (response) {
                            if (response) {
                                planningService.saveOrderMessageVisability(function () {
                                    ngDialog.close();
                                    if (!$scope.mode && responseCaseComplete && !responseCaseComplete.can_submit && responseCaseComplete.oct_exist_for_case) {
                                        alertService.RenderNotificationMessage([{ message: 'LABEL_SETTLEMENT_NOT_POSSIBLE', date: responseCaseComplete.message }], $scope, function () {
                                            ngDialog.close();
                                            alertService.RenderSuccessMessage(message);
                                            $rootScope.$broadcast('CloseForm', { form: 'CloseCase', reload: true });
                                        });
                                    } else {
                                        alertService.RenderSuccessMessage(message);
                                    }

                                }, errorFunction)
                            }
                            $rootScope.$broadcast('CloseForm', { form: 'CloseCase', reload: true });
                        }, { 'show_checkbox': true });
                    };
                }

                //show oct message
                if (showOctMessage) {
                    showBanner = false;

                    alertService.RenderNotificationMessage([{ message: 'LABEL_SETTLEMENT_NOT_POSSIBLE', date: responseCaseComplete.message }], $scope, function () {
                        ngDialog.close();
                        alertService.RenderSuccessMessage(message);
                        $rootScope.$broadcast('CloseForm', { form: 'CloseCase', reload: true });
                    });
                }

                //Show success message
                if (showBanner) {
                    alertService.RenderSuccessMessage(message);
                    $rootScope.$broadcast('CloseForm', { form: 'CloseCase', reload: true });
                }

                $scope.isSubmitOrder = undefined;
                $scope.isQuickPopupOpen = false;
                $scope.submitCreatedCase = false;
                $scope.isCreateAndSubmitTreatment = false;
            };

            function validateConsentsComplete(response) {
                if (response.length === 0)
                    createNewCase();
                else
                    alertService.RenderNotificationMessage(response, $scope);
            };

            // ----------------------------------------------------------------------------- PARTICIPATION CONSENT -----------------------------------------------------------------------------

            $scope.addNewParticipationConsent = function () {
                planningService.getContractList($scope.case.patient_id, getContractListComplete, errorFunction);
            };

            function getContractListComplete(response) {
                $scope.contractList = response;

                ngDialog.open({
                    template: '<add-participation-consent-directive contract-list="$parent.contractList" id="$parent.case.patient_id" is-popup="true"></add-participation-consent-directive>',
                    plain: true,
                    scope: $scope,
                    closeByDocument: false
                });
            };

            // ------------------------------------------------------------------------------ TREATMENT ELIGIBILITY --------------------------------------------------------------------------------

            $scope.verifyTreatmentEligibility = function () {
                $scope.is_treatment_disabled = $scope.case.drug_id === undefined || $scope.case.drug_id === empty_guid || $scope.case.patient_id === undefined;

                if ($scope.case.drug_id !== undefined && $scope.case.drug_id !== empty_guid && $scope.case.patient_id !== undefined) {
                    var param = new Object();
                    param.drug_id = $scope.case.drug_id;
                    param.patient_id = $scope.case.patient_id;
                    param.treatment_date = $scope.case.treatment_date;
                    param.is_resubmit = $scope.type === 'settlement';
                    planningService.verifyTreatmentEligibility(param, verifyTreatmentEligibilityComplete, errorFunction);
                };
            };

            function verifyTreatmentEligibilityComplete(response) {
                $scope.show_consent_link = false;
                $scope.is_treatment_disabled = false;
                $scope.treatment_eligiblity_message = undefined;

                if (first_run) {
                    $timeout(function () {
                        first_run = undefined;
                    }, 1000, false);
                } else {
                    angular.element($scope.what_to_focus)[0].focus();
                };


                if (!response.eligible) {
                    $scope.treatment_button_label = 'LABEL_ADD_TREATMENT';
                    $scope.is_treatment_disabled = true;
                    switch (response.reason) {
                        case 'drug': $scope.treatment_button_label = 'LABEL_DRUG_NOT_VALID';
                            $scope.showTreatment = false; break;
                        case 'hip': $scope.treatment_button_label = 'LABEL_HIP_DOESNT_PARTICIPATE';
                            $scope.showTreatment = false; break;
                        case 'consent': $scope.treatment_button_label = 'LABEL_NO_PATIENT_CONSENT'; $scope.show_consent_link = true;
                            $scope.showTreatment = false; break;
                        case 'doctors': $scope.treatment_button_label = 'LABEL_NO_DOCTOR_CONTRACT';
                            $scope.showTreatment = false; break;
                        case 'date': $scope.treatment_button_label = 'LABEL_NO_PATIENT_CONSENT';
                            $scope.showTreatment = false; break;
                        case 'insurance_number': $scope.treatment_button_label = 'LABEL_ERROR_NEW_KVR_VALIDATION';
                            $scope.showTreatment = false; break;
                        default:
                            $scope.is_treatment_disabled = false;
                            break;
                    };

                    if (response.reason.indexOf('LABEL') > -1) {
                        $scope.treatment_eligiblity_message = response.reason;
                        if ($scope.type !== 'settlement') {
                            $scope.show_consent_link = true;
                        }
                    }
                } else {
                    $scope.treatment_button_label = 'LABEL_ADD_TREATMENT';
                };
            };

            $scope.$watch('case.patient_id', function () { $scope.what_to_focus = '#inPatientName_value'; $scope.verifyTreatmentEligibility(); });

            $scope.verifyTreatmentEligibilityForDrug = function () {
                $scope.what_to_focus = '#selDrug_value';
                $scope.verifyTreatmentEligibility();
            };

            // -------------------------------------------------------------------------------- ERROR FUNCTIONS --------------------------------------------------------------------------------

            function createCaseError(response) {
                console.log(response);
                alertService.RenderErrorMessage('LABEL_SOMETHING_WENT_WRONG');
                $rootScope.$broadcast('CloseForm', { form: 'CloseCase' });
            };

            function errorFunction(response) {
                console.log(response);
                alertService.RenderErrorMessage('LABEL_SOMETHING_WENT_WRONG');
                $scope.submitCreatedCase = false;
            };

            // ----------------------------------------------- UTIL ----------------------------------------------------------------

            $scope.canSubmitTreatment = function () {
                if ($scope.case.treatment_date.length === 10) {
                    var yyyy = $scope.case.treatment_date.substr(6, 4);
                    var mm = $scope.case.treatment_date.substr(3, 2) - 1;
                    var dd = $scope.case.treatment_date.substr(0, 2);

                    var treamtment_date_valid = new Date(parseInt(yyyy), parseInt(mm), parseInt(dd)) <= new Date().setHours(0, 0, 0, 0);
                    var op_doc_valid = $scope.case.treatment_doctor_id && $scope.case.treatment_doctor_id != empty_guid;
                    var ac_doc_valid = $scope.case.aftercare_doctor_practice && $scope.case.aftercare_doctor_practice.id && $scope.case.aftercare_doctor_practice.id != empty_guid;
                    var diagnosis_valid = $scope.case.diagnose_id && $scope.case.diagnose_id != empty_guid

                    return treamtment_date_valid && op_doc_valid && ac_doc_valid;
                } else {
                    return false;
                }
            };

            $scope.canShowSaveAndSubmitButton = function () {
                return ($scope.type == "patient" || $scope.type == "order") && $scope.is_edit_submitted_only_order
            }

            $scope.opDoctorSelected = function () {
                setOpDoctorAsOctDoctor();
            };

            function createDateTime(date) { //From format "dd.MM.yyyy"
                var yyyy = parseInt(date.substr(6, 4));
                var mm = parseInt(date.substr(3, 2)) - 1;
                var dd = parseInt(date.substr(0, 2));

                return new Date(yyyy, mm, dd);
            }

            function setOpDoctorAsOctDoctor() {
                if ($scope.opDoctors.length) {
                    if ($scope.case.treatment_doctor_id !== $scope.opDoctors[0].id && $scope.isOctVisible && !octDoctorManuallySelected) {
                        $scope.case.oct_doctor_id = $scope.case.treatment_doctor_id;
                        for (var i = 0; i < $scope.opDoctors.length; i++) {
                            var doctor = $scope.opDoctors[i];
                            if (doctor.id == $scope.case.oct_doctor_id) {
                                $timeout(function () {
                                    angular.element('#inOctDoctorName_value').val(doctor.display_name);
                                }, 0, false);
                                break;
                            }
                        }
                    }
                }
            }

            $scope.selectPatient = function (selectedObject) {
                $scope.case.patient_id = selectedObject && selectedObject.originalObject ? selectedObject.originalObject.id : undefined;
                $scope.showPatientNameStarReq = selectedObject === undefined || selectedObject.originalObject === undefined;

                if ($scope.showTreatment) {
                    $scope.ToggleFormTreatment();
                }

                if ($scope.case.patient_id) {
                    $scope.isOctVisible = selectedObject.originalObject.hipParticipatesOnOctContract;
                    diagnosesService.getPatientDiagnoses($scope.case.patient_id).then(getAllDiagnosesPatientChangedComplete);
                    checkPatientFeeWaiver();
                };
            };

            function checkPatientFeeWaiver() {
                var patient_id = $scope.case.patient_id || $routeParams.patient_id;
                if (patient_id && $scope.case.treatment_date) {
                    planningService.getIsPatientFeeWaived({ patient_id: patient_id, date: $scope.case.treatment_date }, function (response) {
                        if (!$scope.mode) {
                            $scope.case.is_patient_fee_waived = false;
                        }

                        if ($scope.case.is_orders_drug && !$scope.order_button_disabled && !$scope.treatment_in_the_past) {
                            if (response) {
                                $scope.case.is_patient_fee_waived = response;
                            }
                        }
                    }, errorFunction);
                }
            }

            if (!$scope.mode) { $scope.showPatientNameStarReq = true; };

            $scope.remoteUrlRequestFn = function (str) {
                var search_criteria = str !== undefined && str !== null ? str : ''
                var patient_id = $scope.case.patient_id;
                var oct_date = $scope.case.treatment_date;
                return { search_criteria: search_criteria, patient_id: patient_id, date: oct_date };
            };

            $scope.setOrderDrug = function () {
                if (!$scope.case.is_orders_drug) {
                    if ($scope.mode) {
                        alertService.RenderConfirmationDialog('LABEL_WARNING', { message: 'LABEL_CANCEL_DRUG_ORDER_POPUP' }, 'BUTTON_YES', 'BUTTON_NO', confirmSetOrderDrug, cancelSetOrderDrug);
                    } else {
                        confirmSetOrderDrug();
                    };
                };
            };

            function confirmSetOrderDrug() {
                $scope.case.is_patient_fee_waived = false;
                $scope.case.is_send_invoice_to_practice = false;
                $scope.case.is_label_only = false;
            };

            function cancelSetOrderDrug() {
                $scope.case.is_orders_drug = true;
            };

            $scope.closeCaseForm = function (reload) {
                if ($scope.isQuickPopupOpen) {
                    return;
                }
                $rootScope.$broadcast('CloseForm', { form: 'CloseCase', reload: reload });
            };

            $scope.$on('CloseForm', function (event, data) {
                ngDialog.close();
                if (data.form === 'participationConsent') {
                    $scope.verifyTreatmentEligibility();
                };
            });

            $scope.ToggleFormTreatment = function () {
                $scope.showTreatment = !$scope.showTreatment;
                if ($scope.showTreatment) {
                    getIsPatientHipOnAnOctContract().then(function () {
                        if ($scope.case.patient_id !== undefined && ($scope.case.diagnose_id == undefined || $scope.case.diagnose_id == '00000000-0000-0000-0000-000000000000')) {
                            var param = new Object();
                            param.patient_id = $scope.case.patient_id;
                            casesService.getLatestPatientCase($scope.case.patient_id).then(getPreviousCaseDataComplete);
                        }
                        diagnosesService.getPatientDiagnoses($scope.case.patient_id).then(getAllDiagnosesComplete);

                        $scope.case.is_confirmed = true;
                        var interval = $interval(function () {
                            var element = angular.element('#inOctDoctorName_value');
                            if (element && element[0] && element[0].clientHeight) {
                                $scope.case.oct_doctor_id = oct_doctor.id;
                                element.val(oct_doctor.name);
                                octDoctorManuallySelected = !!oct_doctor.name;
                                $interval.cancel(interval);
                            }
                        }, 10, 100);
                    });
                } else {
                    $scope.case.is_left_eye = undefined;
                    $scope.case.diagnose_id = undefined;
                    $scope.case.op_doctor_id = undefined;
                    $scope.case.treatment_doctor_id = $scope.opDoctors[0].id;
                    $scope.case.oct_doctor_id = null;
                    $scope.case.aftercare_doctor_practice = {};
                    angular.element('#inACDoctorName_value').val('');
                };
            };

            $scope.isStatusError = function () {
                return $scope.status === 'FS6' || $scope.type !== 'settlement';
            };

            $scope.isACEditable = function () {
                return $scope.type === 'settlement' ? $scope.isAcEditable : true;
            };

            $scope.showDrugStarReq = function () { return $scope.case.drug_id === empty_guid || $scope.case.drug_id === undefined || $scope.case.drug_id === '' || $scope.case.drug_id === null; };
            $scope.showDiagnoseStarReq = function () { return $scope.case.diagnose_id === undefined; };

            $scope.fieldsNotValidated = function () {
                var treatment_status = $scope.showTreatment ? $scope.case.diagnose_id === undefined || $scope.case.is_left_eye === undefined || !$scope.case.is_confirmed : false;

                return $scope.case.patient_id === undefined ||
                       treatment_status ||
                       ($scope.case.drug_id === empty_guid || $scope.case.drug_id === undefined || $scope.case.drug_id === '' || $scope.case.drug_id === null) ||
                       !$scope.case.is_orders_drug && !$scope.showTreatment ||
                       $scope.delivery_time_invalid ||
                       $scope.acDocReqStar();
            };

            $scope.acDocReqStar = function () {
                return $scope.type === 'settlement' ? $scope.case.aftercare_doctor_practice === undefined : false;
            };

            $scope.setClass = function () { };

            $scope.showInvoiceStarReq = function () { return $scope.case.is_orders_drug ? !$scope.case.is_send_invoice_to_practice : false; };

            $scope.showLokalizationStarReq = function () { return $scope.case.is_left_eye === undefined; };

            $scope.selectedTreatmentDate = function () {
                $scope.what_to_focus = '#treatmentDate';
                if ($scope.case.treatment_date.length === 10) {
                    var yyyy = $scope.case.treatment_date.substr(6, 4);
                    var mm = $scope.case.treatment_date.substr(3, 2) - 1;
                    var dd = $scope.case.treatment_date.substr(0, 2);
                    $scope.treatment_in_the_past = new Date(parseInt(yyyy), parseInt(mm), parseInt(dd)) < new Date().setHours(0, 0, 0, 0);
                    if ($scope.type !== 'settlement')
                        $scope.case.is_orders_drug = $scope.treatment_in_the_past ? false : $scope.previous_order_state;

                    if (new Date(parseInt(yyyy), parseInt(mm), parseInt(dd)))
                        $scope.verifyTreatmentEligibility();

                    checkPatientFeeWaiver();
                };
            };

            angular.element('#rbLeftEye').bind('keydown', function (event) {
                if (event.which === 9 && !event.shiftKey) {
                    event.preventDefault();
                    angular.element('#rbRightEye')[0].focus();
                };
            });

            angular.element('#rbRightEye').bind('keydown', function (event) {
                if (event.which === 9 && event.shiftKey) {
                    event.preventDefault();
                    angular.element('#rbLeftEye')[0].focus();
                };
            });

            angular.element('#selDiagnose').bind('keydown', function (event) {
                if (event.which === 9 && !event.shiftKey) {
                    event.preventDefault();
                    angular.element('#rbLeftEye')[0].focus();
                };
            });

            if ($scope.type === 'patient') {
                commonServices.focusElement('#treatmentDate');
            } else {
                commonServices.focusElement('#inPatientName_value');
            };

            // ---------------------------------------------------------------------- OCT -------------------------------------------------------------------

            $scope.isOCTEditable = function () {
                return $scope.type !== 'settlement';
            };

            $scope.selectOct = function (selectedObject) {
                $scope.case.oct_doctor_id = selectedObject.originalObject !== undefined ? selectedObject.originalObject.id : undefined;
                octDoctorManuallySelected = true;
            };

            function getIsPatientHipOnAnOctContract() {
                var deferred = $q.defer();

                if ($scope.case.patient_id) {
                    planningService.getIsPatientHipOnAnOctContract($scope.case.patient_id, function (response) {
                        $scope.isOctVisible = response;
                        deferred.resolve();
                    }, errorFunction);
                }

                return deferred.promise;
            }
            // ------------------------------------------------------------------ DIRECTIVE END -------------------------------------------------------------
        };
    });
})();
