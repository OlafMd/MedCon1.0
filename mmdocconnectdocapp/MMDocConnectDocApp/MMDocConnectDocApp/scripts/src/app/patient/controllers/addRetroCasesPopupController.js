
'use strict';
function addRetroCasesPopupController($scope, $filter, $routeParams, $rootScope, diagnosesService, drugsService, alertService, documentationOnlyService, ngDialog, patient, doctorsService) {

    var numberOfSteps = 4;
    var existingCases = [];

    if (patient) {
        $scope.patient_id = patient.id;
        $scope.patientName = patient.name;
    }

    if ($routeParams.patient_id) {
        $scope.patient_id = $routeParams.patient_id;
    }

    $scope.today = new Date();

    dataInit();
    getExistingData();
    getExistingCasesForPatient();
    getOpDoctors();
    getDiagnoses();
    getDrugs();

    function getExistingCasesForPatient() {
        documentationOnlyService.getExistingCasesForPatient($scope.patient_id, function (response) {
            existingCases = response;
        }, errorFunction);
    }

    function dataInit() {
        $scope.formHolder = {};
        initEyeData('left_eye');
        initEyeData('right_eye');
        $scope.currentStep = 1;
    }

    function initEyeData(eye) {
        $scope[eye] = {};
        $scope[eye].octs = [];
        $scope[eye].overview = [];
    }

    function isDate(str) {
        var date = new Date(str);
        return !isNaN(date.getTime());
    }

    $scope.$on('datepicker2:updated', function (event, data) {
        if (data == 'lefteyeLatestIvomDate') {
            $scope.latestIvomDataChanged('left_eye');
        } else if (data == 'righteyeLatestIvomDate') {
            $scope.latestIvomDataChanged('right_eye');
        }
    });

    $scope.latestIvomDataChanged = function (eye) {
        if (existingCases[eye]) {
            var eyeToUpdate = $scope[eye];
            var propertiesToMatch = ['date', 'drug_id', 'diagnose_id', 'doctor'];
            for (var i = 0; i < existingCases[eye].ops.length; i++) {
                var existingCase = existingCases[eye].ops[i];
                var matches = true;
                for (var j = 0; j < propertiesToMatch.length; j++) {
                    var property = propertiesToMatch[j];
                    if (isDate(existingCase[property])) {
                        existingCase[property] = new Date(existingCase[property]);
                        if (existingCase[property].getTime() != eyeToUpdate.latest_ivom[property].getTime()) {
                            matches = false;
                            break;
                        }
                    } else if (existingCase[property].id) {
                        if (existingCase[property].id != eyeToUpdate.latest_ivom[property].id) {
                            matches = false;
                            break;
                        }
                    } else {
                        if (existingCase[property] != eyeToUpdate.latest_ivom[property]) {
                            matches = false;
                            break;
                        }
                    }
                }

                eyeToUpdate.latest_ivom.is_regular_op = matches;
                if (matches) {
                    break;
                }
            }
        }
    };

    $scope.nextStep = function () {
        $scope.left_eye.validations = [];
        $scope.right_eye.validations = [];

        switch ($scope.currentStep) {
            case 1:
                if ($scope.formHolder.leftEyeIntro.$valid) {
                    $scope.left_eye.treatment_year_start_invalid = false;
                    $scope.left_eye.latest_ivom.invalid = false;
                    if ($scope.left_eye.treatment_year_start_date > $scope.today) {
                        $scope.left_eye.treatment_year_start_invalid = true;
                        $scope.left_eye.validations.push({ label: 'LABEL_TREATMENT_YEAR_IN_FUTURE', values: { date: $filter('date')(angular.copy($scope.left_eye.treatment_year_start_date), 'dd.MM.yyyy') } });
                    }
                    if ($scope.left_eye.latest_ivom.date > $scope.today) {
                        $scope.left_eye.latest_ivom.invalid = true;
                        $scope.left_eye.validations.push({ label: 'LABEL_LATEST_IVOM_IN_FUTURE', values: { date: $filter('date')(angular.copy($scope.left_eye.latest_ivom.date), 'dd.MM.yyyy') } });
                    }
                }

                if ($scope.formHolder.rightEyeIntro.$valid) {
                    $scope.right_eye.treatment_year_start_invalid = false;
                    $scope.right_eye.latest_ivom.invalid = false;
                    if ($scope.right_eye.treatment_year_start_date > $scope.today) {
                        $scope.right_eye.treatment_year_start_invalid = true;
                        $scope.right_eye.validations.push({ label: 'LABEL_TREATMENT_YEAR_IN_FUTURE', values: { date: $filter('date')(angular.copy($scope.right_eye.treatment_year_start_date), 'dd.MM.yyyy') } });
                    }
                    if ($scope.right_eye.latest_ivom.date > $scope.today) {
                        $scope.right_eye.latest_ivom.invalid = true;
                        $scope.right_eye.validations.push({ label: 'LABEL_LATEST_IVOM_IN_FUTURE', values: { date: $filter('date')(angular.copy($scope.right_eye.latest_ivom.date), 'dd.MM.yyyy') } });
                    }
                }

                if (($scope.formHolder.leftEyeIntro.$valid && $scope.left_eye.validations.length) || ($scope.formHolder.rightEyeIntro.$valid && $scope.right_eye.validations.length)) {
                    return false;
                }

                initDataObject('left_eye', $scope.formHolder.leftEyeIntro);
                initDataObject('right_eye', $scope.formHolder.rightEyeIntro);
                $scope.number_of_octs = $scope.left_eye.octs.length + $scope.right_eye.octs.length;
                if (!$scope.left_eye.treatment_year_start_date) {
                    $scope.earlier_treatment_year_start_date = $scope.right_eye.treatment_year_start_date;
                } else if (!$scope.right_eye.treatment_year_start_date) {
                    $scope.earlier_treatment_year_start_date = $scope.left_eye.treatment_year_start_date;
                } else {
                    $scope.earlier_treatment_year_start_date = $scope.left_eye.treatment_year_start_date > $scope.right_eye.treatment_year_start_date ? $scope.right_eye.treatment_year_start_date : $scope.left_eye.treatment_year_start_date;
                }
                $scope.earlier_treatment_year_start_date = $filter('date')($scope.earlier_treatment_year_start_date, 'dd.MM.yyyy');
                break;

            case 2:
                if (!$scope.left_eye.disable) {
                    for (var i = 0; i < $scope.left_eye.octs.length; i++) {
                        $scope.left_eye.octs[i].dateInvalid = false;
                        if ($scope.left_eye.octs[i].date > $scope.today) {
                            $scope.left_eye.octs[i].dateInvalid = true;
                            $scope.left_eye.validations.push({ label: 'LABEL_OCT_DATE_IN_FUTURE', values: { date: $filter('date')(angular.copy($scope.left_eye.octs[i].date), 'dd.MM.yyyy') } });
                        }
                    }
                }

                if (!$scope.right_eye.disable) {
                    for (var i = 0; i < $scope.right_eye.octs.length; i++) {
                        $scope.right_eye.octs[i].dateInvalid = false;
                        if ($scope.right_eye.octs[i].date > $scope.today) {
                            $scope.right_eye.octs[i].dateInvalid = true;
                            $scope.right_eye.validations.push({ label: 'LABEL_OCT_DATE_IN_FUTURE', values: { date: $filter('date')(angular.copy($scope.right_eye.octs[i].date), 'dd.MM.yyyy') } });
                        }
                    }
                }

                if ((!$scope.left_eye.disable && $scope.left_eye.validations.length) || (!$scope.right_eye.disable && $scope.right_eye.validations.length)) {
                    return false;
                }
                break;
            case 3:
                if (!$scope.left_eye.disable && $scope.formHolder.leftEyeIvoms.$valid) {
                    $scope.addOps('left_eye');
                }

                if (!$scope.right_eye.disable && $scope.formHolder.rightEyeIvoms.$valid) {
                    $scope.addOps('right_eye');
                }

                makeOverviewData('left_eye');
                makeOverviewData('right_eye');
                break;
        }

        $scope.currentStep++;
    };

    function makeOverviewData(eye) {
        if (!$scope[eye].disable) {
            var octs = $scope[eye].octs.map(function (obj) {
                return {
                    date: obj.date,
                    type: 'oct',
                    doctor: obj.doctor,
                    diagnose_id: null,
                    drug_id: null
                }
            });

            var ops = $scope[eye].ops.map(function (obj) {
                return {
                    date: obj.date,
                    type: 'op',
                    doctor: obj.doctor,
                    diagnose_id: obj.diagnose_id,
                    drug_id: obj.drug_id
                }
            });

            $scope[eye].overview = octs.concat(ops);
        }
    }

    $scope.getDateString = function (date) {
        return $filter('date')(date, 'dd.MM.yyyy');
    };

    function initDataObject(eye, form) {
        if (form.$valid) {
            $scope[eye].octs = makeOctsArray(angular.copy($scope[eye].octs), $scope[eye].oct_number);
            if (!$scope[eye].ops || !$scope[eye].ops.length) {
                $scope[eye].ops = new Array($scope[eye].latest_ivom);
            }

            for (var i = 0, length = $scope[eye].ops.length; i < length; i++) {
                var is_last_op = i == length - 1;
                if (is_last_op) {
                    if (!angular.equals($scope[eye].latest_ivom, $scope[eye].ops[i])) {
                        angular.copy($scope[eye].latest_ivom, $scope[eye].ops[i]);
                    }
                }

                $scope[eye].ops[i].read_only = is_last_op;
            }

            $scope[eye].disable = false;
        } else {
            $scope[eye].disable = true;
        }
    }

    $scope.finish = function () {
        var parameter = {
            patient_id: $scope.patient_id,
            left_eye: $scope.left_eye,
            right_eye: $scope.right_eye
        };

        documentationOnlyService.saveData(parameter, function () {
            alertService.RenderSuccessMessage('LABEL_DOCUMENTATION_ONLY_CASES_SAVED');
            ngDialog.close();
            dataInit();
            $rootScope.$broadcast('retro-cases:saved');
        }, errorFunction);
    };

    $scope.prevStep = function () {
        $scope.currentStep--;
    };

    $scope.isCurrentStep = function (step) {
        return $scope.currentStep == step;
    };

    $scope.hasPrevStep = function () {
        return $scope.currentStep > 1;
    };

    $scope.hasNextStep = function () {
        return $scope.currentStep < numberOfSteps;
    };

    $scope.nextDisable = function (step) {
        switch (step) {
            case 1:
                return $scope.formHolder.leftEyeIntro && $scope.formHolder.leftEyeIntro.$invalid && $scope.formHolder.rightEyeIntro.$invalid;
            case 2:
                return $scope.formHolder.leftEyeOcts && ((!$scope.left_eye.disable && $scope.formHolder.leftEyeOcts.$invalid) || (!$scope.right_eye.disable && $scope.formHolder.rightEyeOcts.$invalid));
        }
    };

    $scope.cancel = function () {
        ngDialog.close();
        dataInit();
    };

    $scope.addOps = function (eye) {
        $scope[eye].validations = [];
        $scope[eye].ivom.invalid = false;
        if ((eye == "left_eye" && $scope.formHolder.leftEyeIvoms.$valid) || (eye == "right_eye" && $scope.formHolder.rightEyeIvoms.$valid)) {
            var opLaterThanLatest = false;
            var opOnLatestDayExists = false;
            var latestOp = $filter('orderBy')($scope[eye].ops, 'date')[$scope[eye].ops.length - 1];
            var dateEntered = $scope[eye].ivom.date;
            if (latestOp.date <= dateEntered) {
                $scope[eye].ivom.invalid = true;
                $scope[eye].validations.push({ label: 'LABEL_LATEST_IVOM_EXISTS', values: { date: $filter('date')(dateEntered, 'dd.MM.yyyy') } });
                return false;
            }

            $scope[eye].ops.push($scope[eye].ivom);
            $scope[eye].ivom = {};
        }
    };

    $scope.removeOps = function (eye, id) {
        var ops = $scope[eye].ops;
        for (var i = 0 ; i < ops.length; i++) {
            if (ops[i].id === id) {
                ops.splice(i, 1);
                break;
            }
        }
    };

    $scope.getDiagnoseName = function (item, eye) {
        var diagnose_id = item.diagnose_id;
        if (!diagnose_id) {
            diagnose_id = $scope[eye].ops[0].diagnose_id;
        }

        var diagnose = $scope.all_diagnoses.elementWithValue('id', diagnose_id, 'display_name');
        return diagnose;
    };

    $scope.getDrugName = function (id) {
        return $scope.all_drugs.elementWithValue('id', id, 'display_name');
    };

    function getExistingData() {
        documentationOnlyService.getExistingData($scope.patient_id, function (response) {
            if (response.left_eye) {
                $scope.left_eye = response.left_eye;
                $scope.left_eye.treatment_year_start_date = new Date($scope.left_eye.treatment_year_start_date);
                if ($scope.left_eye.latest_ivom) {
                    $scope.left_eye.latest_ivom.date = new Date($scope.left_eye.latest_ivom.date);
                }
                if ($scope.left_eye.octs.length) {
                    $scope.left_eye.oct_number = $scope.left_eye.octs.length;
                }

                adjustDates($scope.left_eye.ops, 'date');
                adjustDates($scope.left_eye.octs, 'date');
            } else {
                initEyeData('left_eye');
            }

            if (response.right_eye) {
                $scope.right_eye = response.right_eye;
                $scope.right_eye.treatment_year_start_date = new Date($scope.right_eye.treatment_year_start_date);
                if ($scope.right_eye.latest_ivom) {
                    $scope.right_eye.latest_ivom.date = new Date($scope.right_eye.latest_ivom.date);
                }
                if ($scope.right_eye.octs.length) {
                    $scope.right_eye.oct_number = $scope.right_eye.octs.length;
                }

                adjustDates($scope.right_eye.ops, 'date');
                adjustDates($scope.right_eye.octs, 'date');
            } else {
                initEyeData('right_eye');
            }
        }, errorFunction);
    }

    function adjustDates(collection, dateOrdinal) {
        for (var i = 0; i < collection.length; i++) {
            var item = collection[i];
            item[dateOrdinal] = new Date(item[dateOrdinal]);
        }
    }

    // get OP doctors
    function getOpDoctors() {
        doctorsService.getDoctorsInPractice().then(function (response) {
            $scope.opDoctors = response;
        });
    }

    // get diagnoses
    function getDiagnoses() {
        diagnosesService.getPatientDiagnoses($scope.patient_id).then(function (response) {
            $scope.all_diagnoses = response;
            if ($scope.all_diagnoses.map(function (item) { return item.id; }).indexOf($scope.diagnose_id) === -1)
                $scope.diagnose_id = undefined;
        }, errorFunction);
    }

    // get drugs
    function getDrugs() {
        drugsService.getAll().then(function (response) {
            $scope.all_drugs = response;
        }, errorFunction);
    }

    function makeOctsArray(array, numOfElements) {
        var octsArray = $filter('orderBy')(array, 'date');
        if (array.length > numOfElements) {
            octsArray.splice(numOfElements, array.length - numOfElements);
        } else {
            for (var i = array.length; i < numOfElements; i++) {
                octsArray.push({ id: new Date().getTime() + "" + Math.random(), date: "", doctor_id: "" });
            }
        }

        return octsArray;
    }

    function errorFunction(response) {
        console.log(response);
        alertService.RenderErrorMessage('LABEL_SOMETHING_WENT_WRONG');
    }

}