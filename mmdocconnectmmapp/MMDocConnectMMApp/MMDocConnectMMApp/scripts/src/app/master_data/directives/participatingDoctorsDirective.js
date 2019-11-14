define(['angularAMD'], function (angularAMD) {
    angularAMD.directive('participatingDoctorsDirective', function () {
        return {

            templateUrl: 'scripts/src/app/master_data/view/contract_templates/participatingDoctorsTemplate.html',
            scope: {
                mode: '='
            },
            replace: true,
            restrict: 'E',
            controller: participatingDoctorsController
        };
        function participatingDoctorsController($scope, $rootScope, $translate, contractService, validationService, ngDialog, $timeout, $routeParams, $location, alertsServices, $filter, $interval) {

            // --------------------------------------------------------- VARIABLES --------------------------------------------------------

            var ascending = true;
            var sort_by = 'sortable_name';
            $scope.doctors = [];
            $scope.canAddDoctors = false;
            $scope.consentStartDateNotEntered = true;

            // ----------------------------------------------------------- INIT -----------------------------------------------------------

            $scope.initializeController = function () {
                contractService.authenicateUser($location.path(), $scope.authenicateUserComplete, $scope.authenicateUserError);
            };

            $scope.authenicateUserComplete = function (response) {
                if (!contractService.isNotUndefined(contractService.getContract().participating_doctors))
                    contractService.getContract().participating_doctors = [];

                $scope.doctors = contractService.getContract().participating_doctors;
                $scope.minimumConsentDate = $filter('date')(parseDate(contractService.getContract().contract_valid_from), 'MM.dd.yyyy');
                $scope.maximumConsentDate = $filter('date')(parseDate(contractService.getContract().contract_valid_through), 'MM.dd.yyyy');
                $scope.today = $filter('date')(new Date(), 'MM.dd.yyyy');
            };

            // ---------------------------------------------------------- SAVE  -----------------------------------------------------------

            $scope.addDoctor = function (selectedObject) {
                $scope.doctor_to_add = selectedObject !== undefined ? selectedObject.originalObject : undefined;

                if ($scope.doctor_to_add === undefined) {
                    $scope.showErrorMessageContainer = undefined;
                };
            };

            $scope.addDoctorToList = addDoctorToList;

            function addDoctorToList() {
                if (!verifyContractStartDate())
                    return false;

                var consentDateValid = true;

                if (!$scope.consentStartDateEntered()) {
                    consentDateValid = false;
                    $scope.consentStartDateInvalid = true;
                };

                if (!validationService.isValidDate($scope.consent_date)) {
                    $scope.consentStartDateInvalid = true;
                    $scope.showErrorMessageContainer = true;
                    angular.element('#consentStartDate')[0].focus();
                    return false;
                };

                var consentStartDate = parseDate($scope.consent_date);
                var contractStartDate = parseDate(contractService.getContract().contract_valid_from);

                if (consentStartDate < contractStartDate) {
                    $scope.consentStartDateNotInContractValidityTimespan = true;
                    consentDateValid = false;
                };

                if (consentDateValid) {
                    if (contractService.isNotUndefined(contractService.getContract().contract_valid_through) && validationService.isValidDate(contractService.getContract().contract_valid_through)) {
                        var contractEndDate = parseDate(contractService.getContract().contract_valid_through);
                        if (consentStartDate > contractEndDate) {
                            $scope.consentStartDateNotInContractValidityTimespan = true;
                            consentDateValid = false;
                        };
                    };
                };

                if (!consentDateValid) {
                    $scope.showErrorMessageContainer = true;
                    angular.element('#consentStartDate')[0].focus();
                    return false;
                };

                if ($scope.doctor_to_add !== undefined) {
                    var contractEndDate = contractService.isNotUndefined(contractService.getContract().contract_valid_through) ? parseDate(contractService.getContract().contract_valid_through) : new Date(2099, 01, 01);

                    var existing_doctors_assignments = $.grep($scope.doctors, function (doctor) {
                        var existing_consent_end_date = new Date(doctor.consent_end_date_datetime);
                        var existing_consent_start_date = new Date(doctor.consent_start_date_datetime);

                        return doctor.doctor_id === $scope.doctor_to_add.doctor_id &&
                              (existing_consent_end_date > consentStartDate || existing_consent_end_date.getFullYear() === 1) &&
                              (existing_consent_start_date <= consentStartDate || existing_consent_start_date < contractEndDate) ||
                              (existing_consent_end_date.getFullYear() === 1 && contractEndDate === new Date(2099, 01, 01))
                    });

                    if (existing_doctors_assignments.length === 0) {
                        $scope.doctor_to_add.is_consent_active = true;
                        $scope.doctor_to_add.consent_date = $scope.consent_date;
                        $scope.doctor_to_add.consent_start_date = $scope.consent_date;
                        $scope.doctor_to_add.consent_start_date_datetime = $filter('date')(parseDate($scope.consent_date), 'yyyy-MM-ddTHH:mm:ssZ');
                        $scope.doctor_to_add.consent_end_date = contractService.isNotUndefined(contractService.getContract().contract_valid_through) ? contractService.getContract().contract_valid_through : '∞';
                        $scope.doctor_to_add.consent_end_date_datetime = contractService.isNotUndefined(contractService.getContract().contract_valid_through) ? $filter('date')(parseDate(contractService.getContract().contract_valid_through), 'yyyy-MM-ddTHH:mm:ssZ') : $filter('date')(new Date(1, 1, 1), 'yyyy-MM-ddTHH:mm:ssZ');
                        $scope.doctor_to_add.id = Math.random();

                        $scope.doctors.push($scope.doctor_to_add);
                        $scope.doctors = $filter('orderBy')($scope.doctors, sort_by, !ascending);
                        contractService.getContract().participating_doctors = $scope.doctors;
                        $scope.doctor_to_add = undefined;
                        $rootScope.$broadcast('angucomplete-alt:clearInput');
                        $scope.consent_date = undefined;
                    } else {
                        $scope.overlaps = [];
                        var ctr_name = contractService.getContract().contract_name;
                        for (var i = 0; i < existing_doctors_assignments.length; i++) {
                            $scope.overlaps.push({
                                consentContractName: ctr_name,
                                consentValidFrom: existing_doctors_assignments[i].consent_start_date,
                                consentValidThrough: existing_doctors_assignments[i].consent_end_date
                            });
                        };
                        angular.element('#consentStartDate')[0].focus();
                        $scope.showErrorMessageContainer = true;
                    };
                };
            };

            // ---------------------------------------------------------- REMOVE ----------------------------------------------------------

            $scope.removeDoctor = function (item) {
                if (!verifyContractStartDate())
                    return false;

                $scope.doctor_to_remove = item;
                $scope.consent_date = undefined;

                contractService.getConsentStartDate({ contract_id: $routeParams.contract_id, doctor_id: item.doctor_id }, continueDoctorRemoval, errorFunction);
            };

            function continueDoctorRemoval(response) {
                if (new Date(response).getFullYear() !== 1) {
                    $scope.maximumEndDate = undefined;
                    if (contractService.isNotUndefined(contractService.getContract().contract_valid_through) && validationService.isValidDate(contractService.getContract().contract_valid_through))
                        $scope.maximumEndDate = parseDate(contractService.getContract().contract_valid_through);

                    $scope.minimumConsentDateForRemoval = response;
                    $scope.content = {
                        message: 'LABEL_REMOVE_DATA_FROM_CONTRACT_CONTENT',
                        doctorData: $scope.doctor_to_remove.expanded_name,
                        minimumConsentDate: $filter('date')(response, 'MM.dd.yyyy'),
                        maximumEndDate: $scope.maximumEndDate === undefined ? $scope.today : $scope.maximumEndDate > new Date() ? $scope.today : $filter('date')($scope.maximumEndDate, 'MM.dd.yyyy')
                    };

                    ngDialog.open({
                        template: 'scripts/src/app/master_data/view/contract_templates/confirmRemoveParticipatingDoctorPopupTemplate.html',
                        scope: $scope,
                        closeByDocument: false
                    });

                    var interval = $interval(function () {
                        var element = angular.element('#popupConsentEndDate')[0];
                        if (element) {
                            $interval.cancel(interval);
                            element.focus();
                        }
                    }, 20, 100, false);
                } else {
                    alertsServices.RenderConfirmationDialog('LABEL_REMOVE_DRUG_TITLE', { message: 'LABEL_REMOVE_DATA_FROM_CONTRACT_CONTENT', eligible: $scope.doctor_to_remove.name }, 'BUTTON_YES', 'BUTTON_NO', removeDoctorWithoutConsent, dummyFunction);
                };
            };

            $scope.confirmRemoveDoctor = function () {
                $scope.content.popupConsentEndDateAboveMinimum = false;
                $scope.content.popupShowErrorMessageContainer = false;
                $scope.content.popupConsentDateInvalid = false;
                if (contractService.isNotUndefined($scope.content.consent_date) && validationService.isValidDate($scope.content.consent_date)) {
                    var maxEndDate = $scope.maximumEndDate > new Date() ? new Date() : $scope.maximumEndDate;
                    if (new Date($scope.minimumConsentDateForRemoval) > parseDate($scope.content.consent_date) || parseDate($scope.content.consent_date) > maxEndDate) {
                        $scope.content.popupConsentEndDateAboveMinimum = true;
                        $scope.content.popupShowErrorMessageContainer = true;
                        $timeout(function () { angular.element('#popupConsentEndDate')[0].focus(); }, 0, false);
                        $scope.content.consentTimeframe = $filter('date')($scope.minimumConsentDateForRemoval, 'dd.MM.yyyy') + ' - ' + $filter('date')(maxEndDate, 'dd.MM.yyyy');
                        return false;
                    };

                    for (var i = 0; i < $scope.doctors.length; i++) {
                        if ($scope.doctors[i].id === $scope.doctor_to_remove.id) {
                            $scope.doctors[i].is_participating = false;
                            $scope.doctors[i].is_consent_active = false;
                            $scope.doctors[i].consent_date = $scope.content.consent_date;
                            $scope.doctors[i].consent_end_date = $scope.content.consent_date;
                            $scope.doctors[i].consent_end_date_datetime = $filter('date')(parseDate($scope.content.consent_date), 'yyyy-MM-ddTHH:mm:ssZ');

                            break;
                        };
                    };

                    contractService.getContract().participating_doctors = $scope.doctors;
                    ngDialog.close();
                    $scope.content = undefined;
                } else {
                    $scope.content.popupShowErrorMessageContainer = true;
                    $scope.content.popupConsentDateInvalid = true;
                    $timeout(function () { angular.element('#popupConsentEndDate')[0].focus(); }, 0, false);
                };
            };

            $scope.cancelRemoveDoctorFromContract = function () {
                ngDialog.close();
                $scope.content = undefined;
            };

            function removeDoctorWithoutConsent() {
                var index = -1;
                for (var i = 0; i < $scope.doctors.length; i++) {
                    if ($scope.doctors[i].doctor_id === $scope.doctor_to_remove.doctor_id) {
                        index = i;
                        break;
                    };
                };

                $scope.doctors.splice(index, 1);
                contractService.getContract().participating_doctors = $scope.doctors;

            };

            // ------------------------------------------------------ ERROR FUNCTIONS -----------------------------------------------------

            $scope.authenicateUserError = function (response) {
                $rootScope.activeMenuItem = null;
                $window.location.replace(response.logoutUrl);
            };

            function errorFunction(response) {
                console.log(response);
                alertsServices.ErrorMessage('LABEL_SOMETHING_WENT_WRONG');
            };

            // ----------------------------------------------------------- UTIL -----------------------------------------------------------

            $scope.setTableHeaderClass = function (order_value) {
                if (ascending && sort_by == order_value)
                    return 'sorted_asc';
                else if (!ascending && sort_by == order_value)
                    return 'sorted_dsc'
                else
                    return 'unsorted';
            };

            $scope.SortFunction = function (sort_value) {
                if (sort_by == sort_value) {
                    ascending = !ascending;
                };

                sort_by = sort_value;

                $scope.doctors = $filter('orderBy')($scope.doctors, sort_value, !ascending);
            };

            $scope.remoteUrlRequestFn = function (str) {
                return { search_criteria: str };
            };

            $timeout(function () {
                var elem = angular.element('#inDoctorName_value');
                elem.bind('keydown', function (event) {
                    if (event.which === 13) {
                        addDoctorToList();
                    };
                });

                angular.element('#consentStartDate')[0].focus();
            }, 200, false);

            function updateConsentValidDates() {
                $scope.minimumConsentDate = $filter('date')(parseDate(contractService.getContract().contract_valid_from), 'MM.dd.yyyy');
                $scope.maximumConsentDate = $filter('date')(parseDate(contractService.getContract().contract_valid_through), 'MM.dd.yyyy');
            };

            function parseDate(date) {
                if (date !== undefined) {
                    var parts = date.split(".");
                    var day = parseInt(parts[0], 10);
                    var month = parseInt(parts[1], 10);
                    var year = parseInt(parts[2], 10);

                    return new Date(year, month - 1, day, 0, 0, 0);
                } else {
                    return false;
                };
            };

            $scope.setClass = function () {
                angular.element('.gray-content-holder').css('overflow', 'visible');
            };

            // --------------------------------------------------------- WATCHERS ---------------------------------------------------------

            $scope.$watch('$parent.contract', updateConsentValidDates, true);

            $scope.consentStartDateEntered = function () {
                $scope.consentStartDateNotEntered = $scope.consentStartDateInvalid = !contractService.isNotUndefined($scope.consent_date);
                $scope.showErrorMessageContainer = $scope.consentStartDateInvalid;
                return !$scope.consentStartDateInvalid;
            };

            $scope.consentEndDateEmpty = function () {
                return !contractService.isNotUndefined($scope.content.consent_date);
            };

            function verifyContractStartDate() {
                $scope.consentStartDateInvalid = false;
                $scope.showErrorMessageContainer = false;
                $scope.consentStartDateNotInContractValidityTimespan = false;

                $scope.overlaps = undefined;
                if (!contractService.isNotUndefined(contractService.getContract().contract_valid_from)) {
                    $rootScope.$broadcast('contractValidationError', { validationFailed: 'contractStartDateNotEntered' });
                    return false;
                };

                if (!validationService.isValidDate(contractService.getContract().contract_valid_from)) {
                    $rootScope.$broadcast('contractValidationError', { validationFailed: 'contractStartDateNotValid' });
                    return false;
                };

                $rootScope.$broadcast('contractValidationError', { validationFailed: 'clearValidations' });
                return true;
            };

            function dummyFunction() { };

            // ----------------------------------------------------------- WATCHERS -------------------------------------------------------

            $scope.$on('contractUpdated', function () {
                $scope.doctors = contractService.getContract().participating_doctors;
            });

            // ----------------------------------------------------------- END ------------------------------------------------------------
        };
    });
});