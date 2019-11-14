(function () {
    'use strict';
    angular.module('mainModule').controller('patientDetailViewController',
        ['$scope', '$filter', '$routeParams', 'patientService', 'alertService', '$timeout', '$rootScope',
        'planningService', 'settlementServices', 'ordersService', 'validationService', 'ngDialog',
        'aftercareService', 'octService', 'commonServices', '$interval', 'documentationOnlyService', 'doctorsService', 'pharmacyService', 'practiceSettingsService',
        function ($scope, $filter, $routeParams, patientService, alertService, $timeout, $rootScope, planningService, settlementServices, ordersService, validationService, ngDialog, aftercareService, octService, commonServices, $interval,
            documentationOnlyService, doctorsService, pharmacyService, practiceSettingsService) {

            $scope.showCaseDirective = false;
            $scope.patient_detail = [];
            $scope.disableParticipationConsentbtn = false;
            $scope.isIssueDateHIgherOrEqualToContractStartDate = true;
            $scope.isIssueDateValid = true;
            $scope.contractList = {};
            $scope.participation_consent = {};
            $scope.ValidFrom = $filter('date')(new Date(), 'dd.MM.yyyy');
            $scope.showMessageContainer = false;
            $scope.show_datepicker_id = undefined;
            //#patient detail view data
            $scope.sort_by = "date";
            $scope.ascending = false;
            $scope.patientDetailViewList = [];
            $scope.scroll_down_params = new Object();
            $scope.scroll_down_params.infiniteScrollStep = 100;
            $scope.scroll_down_params.infiniteScrollStartIndex = 0;
            $scope.isScrollDisabled = false;
            $scope.is_scroll = false;
            $scope.execute_scroll = false;
            $scope.today = $filter('date')(new Date(), 'MM.dd.yyyy');
            $rootScope.$broadcast("StickyReset");
            $scope.octDoctorEdit = {};
            getPatientDetails();

            var emptyGuid = '00000000-0000-0000-0000-000000000000';
            var nonePharmacy = { 'display_name': "LABEL_NON_COOPERATTING_PHARMACY", 'id': emptyGuid };
            $scope.pharmacies = [];

            getCanWizardBeStarted();

            function patientDetailsComplete(response) {
                $scope.patient_detail = response.patient;
                $scope.is_wizard_button_visible = response.patient.health_insurance_provider.toLowerCase().indexOf('barmer') > -1;
                $scope.contractList = response.contract_list;

                if (response.contract_list.length === 0)
                    $scope.disableParticipationConsentbtn = true;

                $scope.patient_data = new Object();
                $scope.patient_data.display_name = response.patient.name + ' (' + response.patient.birthday + ')';
                $scope.patient_data.id = $routeParams.patient_id;

                $scope.execute_scroll = false;
                $scope.scroll_down_params.infiniteScrollStartIndex = $scope.scroll_down_params.infiniteScrollStartIndex + $scope.scroll_down_params.infiniteScrollStep;

                $scope.isScrollDisabled = response.patient_details_list.length < $scope.scroll_down_params.infiniteScrollStep;

                for (var i = 0; i < response.patient_details_list.length; i++) {
                    var item = response.patient_details_list[i];
                    if (item.detail_type == 'fee_waiver') {
                        var lastDayInYear = $filter('date')(new Date(new Date(item.date).getFullYear(), 11, 31, 0, 0, 0, 0), 'dd.MM.yyyy');
                        item.diagnose_or_medication = 'LABEL_FEE_WAIVER_ACTIVE_UNTIL';
                        item.last_day_in_year = lastDayInYear;
                    }
                }

                if ($scope.is_scroll)
                    $scope.patientDetailViewList = $scope.patientDetailViewList.concat(response.patient_details_list);
                else {
                    $scope.patientDetailViewList = response.patient_details_list;
                };

            };

            // ---------------------------------------------------------- PHARMACY -------------------------------------------------------------

            $scope.checkSelectedPharmacy = function () {
                $scope.order_to_submit.isNewPharmacy = false;
                if ($scope.order_to_submit.default_pharmacy == undefined || $scope.order_to_submit.default_pharmacy == undefined == null || $scope.order_to_submit.default_pharmacy == emptyGuid) {
                    $scope.order_to_submit.isNewPharmacy = true;
                }
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

                $scope.pharmacies.push(nonePharmacy);
                if ($scope.default_pharmacy_id != null) {
                    var pharmacyFound = false;
                    angular.forEach($scope.pharmacies, function (item) {
                        if (item.id == $scope.default_pharmacy_id) {
                            $scope.order_to_submit.default_pharmacy = item.id;
                            pharmacyFound = true;
                        }
                    })

                    if (!pharmacyFound)
                        $scope.order_to_submit.default_pharmacy = emptyGuid;
                } else {
                    $scope.order_to_submit.default_pharmacy = $scope.pharmacies[0].id;
                }

                $scope.order_to_submit.isNewPharmacy = false;
                if ($scope.order_to_submit.default_pharmacy == emptyGuid) {
                    $scope.order_to_submit.isNewPharmacy = true;
                }
            }

            $scope.$on('retro-cases:saved', reloadData);

            $scope.getOrderStatus = function (item) {
                if (item.detail_type === 'order') {
                    return "";
                } else if (item.detail_type === "op") {
                    if (item.order_status === "")
                        return "LABEL_NOT_ORDERED";
                    else
                        return item.order_status;
                } else {
                    return item.order_status;
                };
            };

            $scope.getPreviousOrderStatus = function (item) {
                return item.previous_order_status;
            };

            $scope.isOrderCancelled = function (item) {
                return item.detail_type === 'order' && item.order_status === 'MO6';
            };

            $scope.isTreatmentOrderCancelled = function (item) {
                return item.order_status === 'MO6' && item.detail_type === 'op';
            };

            function patientDetailsError(response) {
                $scope.execute_scroll = false;
                alertService.RenderErrorMessage('LABEL_SOMETHING_WENT_WRONG');
                console.log(response);

                if ($scope.patientDetailViewList) {
                    for (var i = 0; i < $scope.patientDetailViewList.length; i++) {
                        $scope.patientDetailViewList[i].aftercare_date_string = undefined;
                    }
                }
            };

            function getPatientDetails() {
                if ($scope.execute_scroll) return;
                $scope.execute_scroll = true;

                var patient = new Object();
                patient.ID = $routeParams.patient_id;
                patient.isAsc = $scope.ascending;
                patient.start_row_index = $scope.scroll_down_params.infiniteScrollStartIndex;
                patient.sort_by = $scope.sort_by;
                patientService.getPatientDetails(patient, patientDetailsComplete, patientDetailsError);
            };

            $scope.redirectBackOnePage = function () {
                window.history.back();
            };

            $scope.OpenFormAddPatient = function () {
                $scope.showPatientDirective = !$scope.showPatientDirective;
                $scope.showAddNewCaseButton = false;
                $scope.showParticipationConsentForm = false;
                $scope.show_edit_participation_form = false;
                $scope.show_edit_case_form = false;
                $scope.show_settlement_edit_case_form = false;
            };

            $scope.$on('CloseForm', reloadData);
            function reloadData(event, data) {
                $scope.showCaseDirective = false;
                $scope.showParticipationConsentForm = false;
                $scope.showPatientFeeWaiver = false;
                $scope.show_edit_participation_form = false;
                $scope.show_edit_case_form = false;
                $scope.show_settlement_edit_case_form = false;
                $scope.showPatientDirective = false;
                $scope.scroll_down_params.infiniteScrollStartIndex = 0;
                $scope.is_scroll = false;
                $scope.isScrollDisabled = true;
                $rootScope.$broadcast("StickyReset");
                getPatientDetails();
                $scope.edit_case_id = undefined;
                $scope.edit_id = undefined;
                $scope.edit_participation_id = undefined;
                $scope.show_edit_order_form_id = undefined;
            }

            $scope.getPatientID = function () {
                return $routeParams.patient_id;
            };

            //# Forms ################################################//

            $scope.ToggleFormAddParticipationConsent = function () {
                if (!$scope.disableParticipationConsentbtn) {
                    $scope.showCaseDirective = false;
                    $scope.showParticipationConsentForm = !$scope.showParticipationConsentForm;
                    $scope.show_edit_participation_form = false;
                    $scope.show_edit_case_form = false;
                    $scope.show_settlement_edit_case_form = false;
                };
            };

            $scope.toggleAddNewCaseForm = function () {
                $scope.showCaseDirective = true;
                $scope.showParticipationConsentForm = false;
                $scope.showPatientFeeWaiver = false;
                $scope.show_edit_participation_form = false;
                $scope.show_edit_case_form = false;
                $scope.show_settlement_edit_case_form = false;
            };

            $scope.toggleFormPatientFeeWaiver = function () {
                $scope.showCaseDirective = false;
                $scope.showPatientFeeWaiver = true;
                $scope.showParticipationConsentForm = false;
                $scope.show_edit_participation_form = false;
                $scope.show_edit_case_form = false;
                $scope.show_settlement_edit_case_form = false;
            };

            $scope.allFormsClosed = function () {
                return !$scope.showCaseDirective && !$scope.showPatientFeeWaiver && !$scope.showParticipationConsentForm && !$scope.showPatientDirective;
            }

            //#Patient detail view table #######################################//

            $scope.getStatus = function (item) {
                if (item.detail_type !== "order")
                    return item.status;
                else
                    return item.order_status;
            }

            $scope.setTableHeaderClass = function (order_value) {
                if ($scope.ascending && $scope.sort_by == order_value)
                    return 'sorted_asc';
                else if (!$scope.ascending && $scope.sort_by == order_value)
                    return 'sorted_dsc'
                else
                    return 'unsorted';
            };

            $scope.orderTable = function (order_value) {
                $scope.isScrollDisabled = true;
                $scope.is_scroll = false;
                $scope.scroll_down_params.infiniteScrollStartIndex = 0;
                $scope.patientDetailViewList.length = 0;
                $scope.sort_by = order_value;
                $scope.ascending = !$scope.ascending;

                $rootScope.$broadcast("StickyReset");
                getPatientDetails();
            };

            $scope.loadMore = function () {
                if ($scope.execute_scroll) return;
                $scope.is_scroll = true;
                getPatientDetails();
            };

            $scope.showEditButton = function (item) {
                switch (item.detail_type) {
                    case "fee_waiver":
                        return false;

                    case "participation":
                        return true;
                    case "oct":
                        // todo: update
                        return item.status == "FS6";
                    case "ac":
                        if (item.status == "FS0")
                            return false;
                        else if (item.is_edit_button_visible)
                            return true;
                        else
                            return false;
                    case "order":
                        if (!item.is_edit_button_visible || item.order_status === 'MO9' || item.order_status === 'MO6')
                            return false;
                        else
                            return true;
                        //if (item.order_status === 'MO0' || item.order_status === 'MO8')
                        //    return true;          
                        //else
                        //    return false;
                    case "op":
                        if (item.status == "FS0" || item.status === 'OP3')
                            return true;
                        else if (item.is_edit_button_visible)
                            return true;
                        else
                            return false;
                    default:
                        return true;
                }
            }

            $scope.remoteUrlRequestFn = function (str) {
                var search_criteria = str !== undefined && str !== null ? str : ''
                var patient_id = $routeParams.patient_id;
                var oct_date = $filter('date')(new Date(), 'dd.MM.yyyy');
                return { search_criteria: search_criteria, patient_id: patient_id, date: oct_date };
            };


            // ---------------------------------- REJECTION ------------------------------------
            $scope.showRejectButton = function (item) {
                if (item.detail_type !== 'oct') {
                    return false;
                }

                return item.status.toLowerCase().indexOf('fs') === -1 && item.status !== 'OCT4';
            };

            $scope.rejectCase = function (oct) {
                $scope.oct_to_reject = oct;
                alertService.ConfirmPassword($scope, $scope.confirmOctReject, $scope.cancelSubmitOct, 'LABEL_PLEASE_ENTER_PASSWORD_TO_REJECT_OCT', $scope.oct_to_reject.treatment_doctor_id);
            };

            $scope.confirmOctReject = function () {
                octService.rejectOct({ id: $scope.oct_to_reject.id }, rejectionSuccessful, errorFunction);
            };

            function rejectionSuccessful() {
                alertService.RenderSuccessMessage('LABEL_OCT_REJECTION_SUCCESSFUL');
                $scope.oct_to_reject = undefined;
                $scope.scroll_down_params.infiniteScrollStartIndex = 0;
                $scope.isScrollDisabled = true;
                $scope.is_scroll = false;
                $rootScope.$broadcast("StickyReset");
                getPatientDetails();
            }

            $scope.showCancelButton = function (item) {
                if (item.status === 'FS13') {
                    return false;
                }

                switch (item.detail_type) {
                    case "participation":
                        return false;
                        break;
                    case "oct":
                        if (item.status.indexOf('OCT') != -1) {
                            return false;
                        }

                        if (item.status == "FS8" || item.status == "FS11" || item.status === "FS13")
                            return false;
                        else
                            return true;
                    case "ac":
                        if (item.status == "FS0" || item.status == "AC1" || item.status == 'AC3')
                            return false;
                        else if (item.status == "FS8" || item.status == "FS11" || item.status == "AC4")
                            return false;
                        else
                            return true;
                        break;
                    case "order":
                        if (item.order_status !== 'MO6' && item.order_status !== 'MO9' && item.order_status !== 'MO10' && !item.cancel_disabled)
                            return true;
                        else
                            return false;
                        break;
                    case "op":
                        if (item.status == "OP4")
                            return false;
                        else if (item.status == "FS8" || item.status == "FS11")
                            return false;
                        else
                            return true;
                        break;
                    default:
                        return true;
                        break;
                }
            };

            $scope.checkItemStatus = function (item) {
                if (item.status !== 'FS0' && item.status != 'AC1' && item.status != 'FS6' && item.status !== 'OCT1' && item.status != 'OCT3' && item.status !== 'OCT5' && item.status !== 'OP3' && item.status !== 'AC3')
                    return false;

                if (item.status === 'OP4') {
                    return false;
                } else if (item.status_treatment === '' && item.order_status === 'MO6') {
                    return false;
                };

                if ((item.order_status === 'MO6' || item.order_status === 'MO9') && item.detail_type == "order") {
                    return false;
                }

                return true;
            };

            $scope.getBorderClassName = function (item) {
                if (item.detail_type !== "order") {
                    switch (item.status) {
                        case ('FS1'): return '';
                        case ('FS2'): return 'yellow-border';
                        case ('FS4'): return 'yellow-border';
                        case ('FS6'): return 'red-border';
                        case ('FS7'): return 'green-border';
                        case ('FS8'): return 'gray-border';
                        case ('FS9'): return 'red-border';
                        case ('FS12'): return 'green-border';
                        case ('LABEL_PARTICIPATION_ACTIVE'): return 'green-border';
                        case ('LABEL_PARTICIPATION_NOT_ACTIVE'): return 'red-border';
                        case ('LABEL_PARTICIPATION_NOT_YET_ACTIVE'): return 'red-border';
                        case 'AC3': return 'red-border';
                        case 'AC4': return 'gray-border';
                        case 'OP3': return 'red-border';
                        case 'OCT3': return 'red-border';
                    };
                } else {
                    switch (item.order_status) {
                        case 'MO1': return 'yellow-border';
                        case 'MO2': return 'green-border';
                        case 'MO3': return '';
                        case 'MO4': return 'red-border';
                        case 'MO6': return 'red-border';
                        case 'MO8': return 'red-border';
                    };
                }
            };

            $scope.checkDate = function (item) {
                if (item.detail_type === 'oct' || item.detail_type === 'order') {
                    return true;
                }

                var date = new Date(item.date);
                var today_date = new Date();

                if (date > today_date) {
                    return false;
                } else {
                    return true;
                }
            };

            // Edit oct doctor
            $scope.editOctDoctor = function (isLeftEye) {
                var eye = isLeftEye ? $scope.patient_detail.left_eye : $scope.patient_detail.right_eye;
                if (!eye.can_change_doctor) {
                    documentationOnlyService.showExistingAutoGeneratedIvomMessage($routeParams.patient_id, $scope);
                    return;
                }

                $scope.variableView = true;
                $scope.isSamePractice = true;
                $scope.isLeftEye = isLeftEye;
                $scope.hideDisclaimer = true;
                $scope.changeOctDoctorLabel = 'BUTTON_EDIT_OCT_DOCTOR';
                $scope.octDoctor = {};

                $scope.octDoctorNotSelected = function () {
                    return !$scope.octDoctor.id;
                };

                $scope.selectOctDoctor = function (selectedObject) {
                    $scope.octDoctor.id = selectedObject && selectedObject.originalObject ? selectedObject.originalObject.id : undefined;
                    if ($scope.octDoctor.id) {
                        patientService.checkIsSameOctDoctor({
                            oct_doctor_id: $scope.octDoctor.id,
                            patient_id: $routeParams.patient_id,
                            is_left_eye: $scope.isLeftEye,
                            treatment_date: $filter('date')(new Date(), 'dd.MM.yyyy')
                        }, function (response) {
                            $scope.isSamePractice = response.is_same;
                            if (!response.is_same) {
                                $scope.changeOctDoctorLabel = 'BUTTON_WITHDRAW_OCTS';
                            } else {
                                $scope.changeOctDoctorLabel = 'BUTTON_EDIT_OCT_DOCTOR';
                            }

                            $scope.oct_doctor_name = response.name;
                            $scope.current_oct_count = response.current_octs;
                            $scope.max_octs = response.max_octs;
                            $scope.latest_oct_date = response.latest_oct_date;
                        }, errorFunction);
                    }
                };

                alertService.showOctDoctorChangedPopup($scope).then(function (parameter) {
                    if (parameter.withdraw_oct && $scope.isSamePractice) {
                        parameter.withdraw_oct = false;
                    }

                    parameter.patient_id = $routeParams.patient_id;
                    parameter.is_left_eye = $scope.isLeftEye;
                    parameter.oct_doctor_id = $scope.octDoctor.id;

                    patientService.editOctDoctor(parameter, function () {
                        $scope.octDoctor = {};
                        $scope.isLeftEye = undefined;

                        alertService.RenderSuccessMessage('LABEL_OCT_DOCTOR_UPDATED');
                        $scope.scroll_down_params.infiniteScrollStartIndex = 0;
                        $scope.is_scroll = false;
                        $scope.isScrollDisabled = true;
                        $rootScope.$broadcast("StickyReset");
                        getPatientDetails();
                    }, errorFunction);
                });

            };

            $scope.cancelOctDoctorChange = function () {
                $scope.octDoctorEdit = {};
            };

            $scope.selectLeftEyeOctDoctor = function (selectedObject) {
                $scope.octDoctorEdit.leftEyeOctDoctorId = selectedObject.originalObject !== undefined ? selectedObject.originalObject.id : undefined;
            };

            $scope.selectRightEyeOctDoctor = function (selectedObject) {
                $scope.octDoctorEdit.rightEyeOctDoctorId = selectedObject.originalObject !== undefined ? selectedObject.originalObject.id : undefined;
            };



            //Edit ############################################################//

            $scope.showEditTreatmentForm = function (item) {
                return $scope.show_settlement_edit_case_form && item.case_id === $scope.edit_case_id && $rootScope.isOpRole && item.detail_type === 'op' && item.status != "FS0" && item.status != "OP1" && item.status != "OP3" && item.id === $scope.edit_id;
            };

            $scope.showAftercareForm = function (item) {
                return $scope.show_settlement_edit_case_form && item.case_id === $scope.edit_case_id && item.detail_type !== 'op' && item.id === $scope.edit_id;
            };

            $scope.isAcEditable = function (item) {
                return item.status !== 'FS6' ? item.is_edit_button_visible : !item.is_aftercare_performed;
            };

            $scope.showEditOctForm = function (item) {
                return $scope.show_settlement_edit_case_form && item.detail_type === 'oct' && item.id === $scope.edit_id;
            };

            $scope.openEditForm = function (item) {
                if (item.detail_type === "op") {
                    if (item.status === "FS0" || item.status === 'OP3' || item.status === 'OP1')
                        $scope.openCaseEditForm(item);
                    else
                        $scope.openSettlementCaseEditForm(item);
                }
                else if (item.detail_type === "ac" && item.status !== "FS0") {
                    $scope.openSettlementCaseEditForm(item);
                }
                else if (item.detail_type === "order") {
                    if (item.order_status === 'MO0' || item.order_status === 'MO8') {
                        $scope.openOrderEditForm(item);
                    } else {
                        if (item.localisation == "-") {
                            $scope.openEligibleOrderEditForm(item);

                        } else {
                            $scope.openOrderEditForm(item);
                        }
                    }
                } else if (item.detail_type === "participation") {
                    $scope.openEditParticipationConsentForm(item);
                } else if (item.detail_type === 'oct') {
                    $scope.show_settlement_edit_case_form = true;
                    $scope.edit_id = item.id;
                    item.first_name = $scope.patient_detail.name.split(' ')[0];
                    item.last_name = $scope.patient_detail.name.split(' ')[1];
                    item.birthday = $scope.patient_detail.birthday;
                    item.surgery_date_string = item.date_string;
                    item.localization = item.localisation;
                }
            };

            $scope.openEligibleOrderEditForm = function (item) {
                $scope.showCaseDirective = false;
                $scope.showParticipationConsentForm = false;
                $scope.show_edit_participation_form = false;
                $scope.show_settlement_edit_case_form = false;
                $scope.show_edit_order_form_id = false;

                $scope.show_edit_case_form = true;
                $scope.edit_case_id = item.id;
            }

            $scope.openOrderEditForm = function (item) {
                $scope.showCaseDirective = false;
                $scope.showParticipationConsentForm = false;
                $scope.show_edit_participation_form = false;
                $scope.show_edit_case_form = false;
                $scope.show_settlement_edit_case_form = false;

                $scope.show_edit_order_form_id = item.order_id;
            }

            $scope.openSettlementCaseEditForm = function (item) {
                $scope.showCaseDirective = false;
                $scope.showParticipationConsentForm = false;
                $scope.show_edit_participation_form = false;
                $scope.show_edit_case_form = false;
                $scope.show_settlement_edit_case_form = !$scope.show_settlement_edit_case_form;
                $scope.edit_case_id = item.case_id;
                $scope.edit_id = item.id;
                $scope.show_edit_order_form_id = false;
            };


            $scope.openCaseEditForm = function (item) {
                $scope.showCaseDirective = false;
                $scope.showParticipationConsentForm = false;
                $scope.show_edit_participation_form = false;
                $scope.show_edit_case_form = !$scope.show_edit_case_form;
                $scope.show_settlement_edit_case_form = false;
                $scope.edit_case_id = item.id;
                $scope.show_edit_order_form_id = false;
                if (item.detail_type == 'order') {
                    $scope.edit_id = item.id;
                }
            };


            $scope.getContractIDComplete = function (response) {

                $scope.showParticipationConsentForm = false;
                $scope.showCaseDirective = false;
                $scope.show_settlement_edit_case_form = false;
                $scope.show_edit_case_form = false;
                $scope.show_edit_participation_form = !$scope.showParticipationConsentForm;
                $scope.selected_contract_id = response;
            };


            $scope.openEditParticipationConsentForm = function (item) {

                $scope.participation_date = new Date(item.date);
                $scope.edit_participation_id = item.id;
                $scope.show_edit_order_form_id = false;
                var object = new Object();
                object.participationID = item.id;
                patientService.Get_contractID(object, $scope.getContractIDComplete, errorFunction);
            };



            //Cancel ##########################################################//
            function cleanScope() {
                delete $scope.credentials_not_verified;
                delete $scope.doctors;
                delete $scope.confirmation;

            };

            $scope.cancelCaseCancel = function () {
                cleanScope();
                ngDialog.close();
            };

            $scope.cancelCase = function (item) {
                if (item.detail_type == "op" || item.detail_type == "ac" || item.detail_type == "oct") {
                    if (item.status != "FS0" && item.status !== 'OP3') {
                        $scope.cancelNotOpenCase(item);
                    } else if ((item.status === "FS0" || item.status === 'OP3') && item.detail_type === "op") {
                        $scope.cancelOPenTreatmentCase(item);
                    };
                } else if (item.detail_type === "order") {
                    $scope.cancelOPenTreatmentCase(item);
                } else if (item.detail_type == 'fee_waiver') {
                    patientService.deletePatientFeeWaiver({ id: item.id }, function () {
                        alertService.RenderSuccessMessage('LABEL_FEE_WAIVER_DELETED');
                        $rootScope.$broadcast('CloseForm');
                    }, errorFunction);
                };
            };

            function cancelCaseComplete(response) {
                alertService.RenderSuccessMessage($scope.cancel_popup.message);
                $scope.scroll_down_params.infiniteScrollStartIndex = 0;
                $scope.isScrollDisabled = true;
                $scope.is_scroll = false;
                $rootScope.$broadcast("StickyReset");
                getPatientDetails();
            };

            $scope.cancelCancelCase = function () {
                $scope.case_id = undefined;
                ngDialog.close();
            };

            $scope.confirmCancelCase = function () {
                var case_param = new Object();
                case_param.case_id = $scope.case_id;
                if ($scope.case_cancellation.both) {
                    case_param.cancel_drug_order = true;
                    case_param.cancel_treatment = true;
                    $scope.cancel_popup.message = $scope.is_orders_drug && $scope.is_treatment ? 'LABEL_MESSAGE_CANCEL_BOTH' : $scope.is_orders_drug ? 'LABEL_MESSAGE_CANCEL_ORDER' : 'LABEL_MESSAGE_CANCEL_TREATMENT';
                } else {
                    case_param.cancel_drug_order = true;
                    case_param.cancel_treatment = false;
                    $scope.cancel_popup.message = 'LABEL_MESSAGE_CANCEL_ORDER';
                };

                planningService.cancelCase(case_param, cancelCaseComplete, errorFunction);
                ngDialog.close();
            };



            function getCaseDetailsComplete(response) {
                $scope.cancel_popup = new Object();
                $scope.is_orders_drug = response.is_orders_drug;
                $scope.is_treatment = response.is_treatment_form_open;

                $scope.cancel_popup.title = response.is_orders_drug && response.is_treatment_form_open ? 'LABEL_TITLE_CANCEL_BOTH' : response.is_orders_drug ? 'LABEL_TITLE_CANCEL_ORDER' : 'LABEL_TITLE_CANCEL_TREATMENT';
                $scope.cancel_popup.content = response.is_orders_drug && response.is_treatment_form_open ? 'LABEL_CONTENT_CANCEL_BOTH' : response.is_orders_drug ? 'LABEL_CONTENT_CANCEL_ORDER' : 'LABEL_CONTENT_CANCEL_TREATMENT';
                $scope.cancel_popup.message = 'LABEL_MESSAGE_CANCEL_TREATMENT';
                $scope.cancel_popup.show_radio_buttons = response.is_orders_drug && response.is_treatment_form_open;
                $scope.case_id = response.case_id;

                $scope.case_cancellation = new Object();
                if ($scope.cancel_popup.show_radio_buttons) {
                    $scope.case_cancellation.both = true;
                } else {
                    if (response.is_orders_drug && response.is_treatment_form_open) {
                        $scope.case_cancellation.both = true;
                    } else {
                        $scope.case_cancellation.order_only = response.is_orders_drug;
                        $scope.case_cancellation.both = response.is_treatment_form_open;
                    };
                };

                ngDialog.open({
                    template: 'scripts/src/app/planning/view/cancelCasePopupTemplate.html',
                    scope: $scope,
                    closeByDocument: false
                });
            };

            $scope.isSubmitButtonDisabled = function (item) {
                if (item.detail_type === "op")
                    return item.aftercare_name === '-' || item.treatment_doctor_name === '-';
                else
                    return true;
            };

            $scope.changeMessage = function () {
                $scope.cancel_popup.content = $scope.case_cancellation.both ? 'LABEL_CONTENT_CANCEL_BOTH' : 'LABEL_CONTENT_CANCEL_ORDER';
            };


            $scope.cancelOPenTreatmentCase = function (item) {
                var case_param = new Object();
                case_param.case_id = item.case_id;

                planningService.getCaseHasOctPending({ case_id: item.case_id }, function (response) {
                    if (response) {
                        alertService.RenderNotificationMessage([{ message: 'LABEL_PENDING_OCT_WONT_BE_AUTOMATICALLY_CANCELLED' }], $scope, function () {
                            ngDialog.close();
                            planningService.getCaseDetails(case_param, getCaseDetailsComplete, errorFunction);
                        });
                    } else {
                        planningService.getCaseDetails(case_param, getCaseDetailsComplete, errorFunction);
                    }
                }, errorFunction);
            };

            $scope.cancelNotOpenCase = function (item) {
                $scope.selected_caseId = item.case_id;
                $scope.selected_type = item.detail_type;
                $scope.actionId = item.id;

                if (item.detail_type == "ac")
                    $scope.disable_doctor_select = item.aftercare_doctor_practice_id;
                else
                    $scope.disable_doctor_select = item.treatment_doctor_id;
                doctorsService.getDoctorsInPractice().then(function (response) {
                    $scope.doctors = response;
                    $scope.confirmation = new Object();
                    $scope.confirmation.doctor = new Object();
                    $scope.confirmation.doctor.id = $scope.disable_doctor_select;

                    ngDialog.open({
                        template: 'scripts/src/app/settlement/view/cancelCasePopup.html',
                        scope: $scope,
                        closeByDocument: false
                    });

                    commonServices.focusElement('#reasonForCancelation');
                });
            };

            $scope.CancelCaseError = function (response) {
                console.log(response);
                alertService.RenderErrorMessage('LABEL_SOMETHING_WENT_WRONG');
                cleanScope();
            };
            $scope.CancelCaseSuccess = function (response) {
                alertService.RenderSuccessMessage($scope.selected_type === 'op' ? 'LABEL_TREATMENT_CASE_CANCELLED' : $scope.selected_type === 'ac' ? 'LABEL_AFTERCARE_CASE_CANCELLED' : 'LABEL_OCT_CASE_CANCELLED');
                cleanScope();
                $scope.scroll_down_params.infiniteScrollStartIndex = 0;
                $scope.isScrollDisabled = true;
                $scope.is_scroll = false;
                $rootScope.$broadcast("StickyReset");
                getPatientDetails();

            };
            $scope.passwordSettlementVerified = function (response) {
                $scope.credentials_not_verified = false;
                ngDialog.close();
                var case_param = new Object();
                case_param.case_id = $scope.selected_caseId;
                case_param.planned_action_id = $scope.actionId;
                case_param.authorizing_doctor_id = $scope.confirmation.doctor.id;
                case_param.reasonForCancelation = $scope.confirmation.reasonForCancelation;
                case_param.caseType = $scope.selected_type;
                settlementServices.CancelCase(case_param, $scope.CancelCaseSuccess, $scope.CancelCaseError);
            };
            $scope.passwordSettlementNotVerified = function (response) {
                $scope.credentials_not_verified = true;
            };
            $scope.verifyPasswordSettlement = function () {
                settlementServices.verifyPassword($scope.confirmation, $scope.passwordSettlementVerified, $scope.passwordSettlementNotVerified);
            };


            //#Aftercare ######################################################//
            $scope.purgeDate = function ($event, item) {
                var relatedTarget = $event.relatedTarget || $event.originalEvent.explicitOriginalTarget || document.activeElement;

                if (relatedTarget === null || relatedTarget.id !== 'btnSubmitCase') {
                    if (relatedTarget !== null && relatedTarget.className.indexOf('_720') > -1) {
                        var el = angular.element('.aftercare-datepicker_' + item.id);
                        angular.element('.aftercare-datepicker_' + item.id).focus();
                    } else {
                        if (!item.had_aftercare_performed_date_saved)
                            item.aftercare_date_string = '';
                    };
                }
            };

            $scope.setClass = function () {
                $('.aftercare-list-item').css("overflow", "visible");
            };

            $scope.renderDatepicker = function (id) {
                $scope.show_datepicker_id = id;
                $timeout(function () { angular.element('#aftercarePerformedDate_' + id)[0].focus() }, 0, false);
            };

            //#Submit case functions ##########################################//

            $scope.isSubmitButtonDisabled = function (item) {
                return item.aftercare_doctor_practice_id == "00000000-0000-0000-0000-000000000000";
            };

            function errorFunction(response) {
                console.log(response);
                alertService.RenderErrorMessage('LABEL_SOMETHING_WENT_WRONG');
            };
            //#region Submit order
            getDoctors();
            function getDoctors() {
                doctorsService.getDoctorsInPractice().then(function (response) {
                    $scope.doctors = response;
                }, errorFunction);
            }

            $scope.submitOrder = function (order) {
                submit([order.id]);
            };

            function submit(ids) {
                $scope.order_to_submit = {};

                if (ids.length === 1) {
                    ordersService.getOrderComment({ order_id: ids[0] }, function (response) {
                        $scope.order_to_submit.comment = response;
                    }, errorFunction);
                }

                practiceSettingsService.getPracticeSettings().then(function (settings) {
                    getPharmacies();
                    if (settings) {
                        $scope.order_to_submit.street = settings.address;
                        $scope.order_to_submit.city = settings.town;
                        $scope.order_to_submit.number = settings.No;
                        $scope.order_to_submit.zip = settings.Zip;
                        $scope.order_to_submit.order_ids = ids;
                        $scope.order_to_submit.receiver = settings.name;
                        $scope.default_pharmacy_id = settings.DefaultPharmacy;
                    }

                    $scope.order_to_submit.delivery_date_from = settings.DeliveryDateFrom;
                    $scope.order_to_submit.delivery_date_to = settings.DeliveryDateTo;

                    for (var i = 0; i < $scope.doctors.length; i++) {
                        var doctor = $scope.doctors[i];
                        if (doctor.id === $rootScope.id) {
                            $scope.order_to_submit.doctor_id = doctor.id;
                            break;
                        }
                    }

                    ngDialog.open({
                        template: 'scripts/src/app/shoppingCart/view/confirmOrderPopup.html',
                        scope: $scope,
                        closeByDocument: false,
                        closeByEscape: false
                    });

                    commonServices.focusElement('#dpDeliveryDate');
                }, errorFunction);
            }

            $scope.passwordConfirmationCancel = function () {
                resetOrderToSubmit();
                ngDialog.close();
            };

            $scope.verifyPassword = function () {
                $scope.submitClicked = true;
                $scope.deliveryDateInvalid = false;
                if (!validationService.isValidDate($scope.order_to_submit.delivery_date)) {
                    $scope.deliveryDateInvalid = true;
                    commonServices.focusElement('#dpDeliveryDate');
                    return;
                }

                if ($scope.order_to_submit.isNewPharmacy) {
                    $scope.credentials_not_verified = false;
                    ngDialog.close();
                    confirmOrderSubmit();
                } else {
                    ordersService.verifyPassword({
                        doctor: { id: $scope.order_to_submit.doctor_id },
                        password: $scope.order_to_submit.password
                    }, function (response) {
                        $scope.credentials_not_verified = false;
                        ngDialog.close();
                        confirmOrderSubmit();
                    }, function () {
                        $scope.credentials_not_verified = true;
                    });
                }
            };

            function confirmOrderSubmit() {
                ordersService.submitOrder($scope.order_to_submit, function (response) {
                    commonServices.download(response);
                    resetOrderToSubmit();
                    alertService.RenderSuccessMessage('LABEL_ORDERS_SUBMITTED');
                    $scope.scroll_down_params.infiniteScrollStartIndex = 0;
                    $scope.isScrollDisabled = true;
                    $scope.is_scroll = false;
                    $rootScope.$broadcast("StickyReset");
                    getPatientDetails();
                }, errorFunction);
            }

            function resetOrderToSubmit() {
                $scope.order_to_submit = undefined;
            }
            //#endregion

            $scope.submitCase = function (item) {
                $scope.id_to_submit = item.case_id;
                $scope.planned_action_id_to_submit = item.id;

                if (item.detail_type === "op" || item.detail_type === 'oct') {
                    $scope.treatment_doctor_id = item.treatment_doctor_id;
                } else {
                    $scope.treatment_doctor_id = item.aftercare_doctor_practice_id;
                    $scope.aftercare_date_string = item.aftercare_date_string;
                }

                $scope.case_to_submit = item;
                $scope.case_to_submit_status = item.status;

                if (!$scope.isSubmitButtonDisabled($scope.case_to_submit)) {
                    var param = new Object();
                    param.case_id = $scope.case_to_submit.case_id;
                    param.id = $scope.case_to_submit.treatment_doctor_id;
                    param.secondary_id = $scope.case_to_submit.aftercare_doctor_practice_id;
                    param.tertiary_id = $scope.case_to_submit.patient_id;
                    param.date_string = $filter('date')($scope.case_to_submit.date, 'dd.MM.yyyy');
                    param.diagnose_id = $scope.case_to_submit.diagnose_id;
                    param.drug_id = $scope.case_to_submit.drug_id;
                    param.date = $filter('date')($scope.case_to_submit.date, 'dd.MM.yyyy');

                    if ((item.detail_type === "op" || item.detail_type === "ac") && item.status == "FS6") {
                        param.case_id = item.case_id;
                        param.flag = item.detail_type === 'op';
                        $scope.is_treatment = param.flag;
                        $scope.date_of_performed_action = $scope.case_to_submit.date;
                        settlementServices.validateConsents(param, validateConsentsComplete, errorFunction);
                    }
                    else if (item.detail_type === "op" && item.status != "FS6") {
                        planningService.validateConsents(param, validateConsentsComplete, errorFunction);
                    } else if (item.detail_type === 'oct') {
                        var param = {};
                        $scope.is_oct = true;
                        param.id = $scope.case_to_submit.id;
                        param.secondary_id = $scope.case_to_submit.case_id;
                        param.date = item.status !== 'FS6' ? $scope.case_to_submit.aftercare_date_string : $scope.case_to_submit.date_string;
                        param.flag = item.status === 'FS6';

                        octService.validateConsents(param, validateConsentsComplete, errorFunction);
                    }
                    else {
                        aftercareService.validateConsents(param, validateConsentsComplete, errorFunction);
                    }
                }
            };

            function validateConsentsComplete(response) {
                if (response.length === 0) {
                    $scope.case_id = $scope.id_to_submit;
                    var message = $scope.is_oct ? 'LABEL_PLEASE_ENTER_PASSWORD_TO_SUBMIT_OCT' : 'LABEL_PLEASE_ENTER_PASSWORD_TO_SUBMIT_CASE';
                    var parameters = new Object();

                    if ($scope.is_oct) {
                        checkExistingOCTs();
                    } else {
                        if ($scope.case_to_submit.detail_type == "ac") {
                            parameters.ids_to_submit = [$scope.case_to_submit.case_id];
                            parameters.date_string = $scope.case_to_submit.aftercare_date_string || $scope.case_to_submit.date_string;;

                            aftercareService.checkIfAlreadyExistAftercare(parameters, function (response) {
                                if (response.number_of_invalid_cases == 0) {
                                    alertService.ConfirmPassword($scope, $scope.confirmSubmitCase, $scope.cancelSubmitCase, message, $scope.treatment_doctor_id, $scope.is_oct);
                                } else {
                                    alertService.RenderNotificationMessage([{ message: 'LABEL_AFTERCARE_ALREADY_EXIST' }], $scope, function () {
                                        ngDialog.close();
                                    });
                                }
                            }, errorFunction);

                        } else {
                            var parameters = new Object();
                            parameters.ids_to_submit = [$scope.case_id];

                            planningService.checkIfAlreadyExistAnyTreatment(parameters, function (response) {
                                if (response.number_of_invalid_cases == 0) {
                                    alertService.ConfirmPassword($scope, $scope.confirmSubmitCase, $scope.cancelSubmitCase, message, $scope.treatment_doctor_id, $scope.is_oct);
                                } else {
                                    alertService.RenderNotificationMessage([{ message: 'LABEL_TREATMENT_ALREADY_EXIST' }], $scope, function () {
                                        ngDialog.close();
                                    });
                                }
                            }, errorFunction)
                        }
                    }
                } else {
                    if (!response[0].is_warning_message) {
                        alertService.RenderNotificationMessage(response, $scope);
                    } else {
                        alertService.RenderConfirmationDialog('LABEL_WARNING', response[0], 'BUTTON_SUBMIT', 'LABEL_CANCEL', checkExistingOCTs, cancelSubmitOctWithouitConsent);
                    }
                };
            }

            function cancelSubmitOctWithouitConsent(response) {
                ngDialog.close();
            }

            function checkExistingOCTs() {
                var parameters = new Object();
                parameters.oct_ids = [$scope.case_to_submit.id];
                parameters.date_of_performed_action = $scope.case_to_submit.aftercare_date_string || $scope.case_to_submit.date_string;
                parameters.is_resubmit = $scope.case_to_submit.status === 'FS6';

                octService.checkIfAlreadyExistOCT(parameters, function (response) {
                    if (response.number_of_invalid_cases == 0) {
                        alertService.ConfirmPassword($scope, $scope.confirmSubmitCase, $scope.cancelSubmitCase, 'LABEL_PLEASE_ENTER_PASSWORD_TO_SUBMIT_OCT', $scope.treatment_doctor_id, true);
                    } else {
                        alertService.RenderNotificationMessage([{ message: 'LABEL_OCT_ALREADY_EXIST' }], $scope, function () {
                            ngDialog.close();
                        });
                    }
                }, errorFunction)
            }

            $scope.confirmSubmitCase = function (doctor_id) {
                var case_param = new Object();
                case_param.case_id = $scope.case_id;
                case_param.authorizing_doctor_id = doctor_id;
                if ($scope.case_to_submit.detail_type === "op" && $scope.case_to_submit_status !== "FS6") {
                    planningService.submitCase(case_param, submitCaseComplete, errorFunction);
                } else if (($scope.case_to_submit.detail_type === "op" || $scope.case_to_submit.detail_type === "ac") && $scope.case_to_submit_status === "FS6") {
                    case_param.datetime_of_performed_action = $scope.date_of_performed_action;
                    case_param.is_treatment = $scope.is_treatment;
                    case_param.planned_action_id = $scope.planned_action_id_to_submit;
                    settlementServices.submitCase(case_param, submitCaseComplete, errorFunction);
                } else if ($scope.case_to_submit.detail_type === 'oct') {
                    var oct_param = {
                        oct_ids: [$scope.case_to_submit.id],
                        date_of_performed_action: $scope.case_to_submit.status === 'FS6' ? $scope.case_to_submit.date_string : $scope.case_to_submit.aftercare_date_string,
                        authorizing_doctor_id: doctor_id,
                        is_resubmit: $scope.case_to_submit.status === 'FS6'
                    };

                    octService.SubmitOct(oct_param, submitCaseComplete, errorFunction);
                } else {
                    case_param.date_of_performed_action = $scope.aftercare_date_string;
                    aftercareService.submitAftercare(case_param, submitCaseComplete, errorFunction);
                }
            };

            $scope.cancelSubmitCase = function () {
                $scope.case_id = undefined;
            };

            function submitCaseComplete(response) {
                if (response) {
                    commonServices.download(response.reportUrl || response);
                }

                $scope.is_oct = false;

                alertService.RenderSuccessMessage('LABEL_CASE_SUBMITTED');
                $scope.scroll_down_params.infiniteScrollStartIndex = 0;
                $scope.isScrollDisabled = true;
                $scope.is_scroll = false;
                $rootScope.$broadcast("StickyReset");
                getPatientDetails();
            }

            // wizard

            function getCanWizardBeStarted() {
                planningService.getIsPatientHipOnAnOctContract($routeParams.patient_id, function (response) {
                    $scope.is_patient_on_an_oct_contract = response;

                    if (response) {
                        if (commonServices.open_wizard_for_patient == $routeParams.patient_id) {
                            var interval = $interval(function () {
                                var button = angular.element('#btnAddRetroCases')[0];
                                if (button && button.clientHeight) {
                                    button.click();
                                    $interval.cancel(interval);

                                    delete commonServices.open_wizard_for_patient;
                                }
                            }, 10, 100);
                        }
                    }
                }, errorFunction);
            }

            //#Helper function ################################################//

            $scope.formatDate = function (item) {
                var newDate = new Date(item.date);
                if (item.detail_type === 'oct') {
                    return '01.01.0001';
                }

                return $filter('date')(newDate, 'MM.dd.yyyy');
            };


            $scope.$on('ngDialog.opened', function (event, data) {
                var input = angular.element('#reasonForCancelation')[0];
                if (input)
                    input.focus();
            });

            $scope.setClass = function () {
                $('.patients-list-item').css('overflow', 'visible');
            };

            // ------------------------------------------------------------- DELETE AUTO GENERATED IVOM ------------------------------------------------------------
            $scope.deleteCase = function (item) {
                patientService.deleteCase({ case_id: item.case_id }, function (response) {
                    alertService.RenderSuccessMessage('LABEL_DOCUMENTATION_CASE_DELETED');
                    $scope.scroll_down_params.infiniteScrollStartIndex = 0;
                    $scope.isScrollDisabled = true;
                    $scope.is_scroll = false;
                    $rootScope.$broadcast("StickyReset");
                    getPatientDetails();
                }, errorFunction);
            };

            // ------------------------------------------------------------------ DOWNLOAD REPORT ------------------------------------------------------------------

            $scope.isDownloadVisible = function (item) {

                if (item.detail_type !== 'op' && item.detail_type !== 'ac' && item.detail_type !== 'preexamination' && item.detail_type !== 'oct' && item.detail_type !== 'order')
                    return false;

                if ((item.status.substring(0, 2) !== 'FS' || item.status === 'FS0') && item.detail_type !== 'order')
                    return false;

                if (item.detail_type === 'order') {
                    return item.order_status === 'MO10';
                } else {
                    return item.status !== 'FS8' && item.status !== 'FS6';
                }
            };

            $scope.downloadReport = function (caseData) {
                $scope.caseData = caseData;
                if (caseData.detail_type === 'order') {
                    $scope.isOrderReport = true;
                    ordersService.getOrderReportURL(caseData.id, reportDownloaded, errorFunction);
                } else {
                    $scope.isOrderReport = false
                    var parameter = { CaseParameters: [{ CaseID: caseData.id, IsTreatment: caseData.detail_type === 'op' }] };
                    settlementServices.downloadSubmissionReport(parameter, reportDownloaded, errorFunction);
                }
            };

            function reportDownloaded(response) {
                commonServices.download(response);
                if (!$scope.isOrderReport) {
                    $scope.caseData.if_settlement_is_report_downloaded = true;
                }
            };
        }]);
})();
