
"use strict";

define(['application-configuration', 'alertsServices', 'dashboardService', 'validationService', 'commonServices'], function (app) {
    app.register.controller('dashboardController', ['$scope', '$rootScope', '$translate', 'ngDialog', 'alertsServices', 'Upload', '$filter', 'dashboardService', '$location', '$window', '$timeout', 'validationService', 'commonServices',
        function ($scope, $rootScope, $translate, ngDialog, alertsServices, Upload, $filter, dashboardService, $location, $window, $timeout, validationService, commonServices) {

            // -------------------------------------------------------------- VARIABLES ---------------------------------------------------------------

            $scope.NoCaseForSettlement = false;
            $scope.NoOrdersForExport = false;
            $scope.NoOrdersForCompleteReport = false;
            $scope.NoPositiveResponse = false;
            $scope.NoPaymentItems = false;
            $scope.orders = {};
            $scope.positiveResponse = {};
            $scope.negativeResponse = null;
            var numberForchange = 0;
            var numberOfImported = 0;
            $scope.payment = { changeStatus: true };
            var ordersForShipping = {};
            $scope.pageLoaded = false;
            $scope.submitClicked = false;
            $scope.today = $filter('date')(new Date(), 'MM.dd.yyyy');
            $scope.settlement = {};

            // ----------------------------------------------------------------- INIT -----------------------------------------------------------------

            $scope.initializeController = function () {
                dashboardService.authenicateUser($location.path(), getTilesInformation, authenicateUserError);
            };

            $scope.authenicateUserComplete = function (response) {
                $timeout(function () {
                    if ($scope.tileInfo === undefined)
                        getTilesInformation();
                }, 2500);
            };

            function getTilesInfoComplete(response) {
                $scope.tileInfo = response;
            };

            $scope.$on('dashboardRefreshed', function (event, data) {
                if ($scope.tileInfo !== undefined) {
                    var ordinals = ['settlementUpdated', 'responseUpdated', 'paymentUpdated', 'errorCorrectionsUpdated', 'casesOnHoldUpdated', 'ordersUpdated', 'completeReportUpdated', 'temporaryDoctorsUpdated'];
                    $scope.settlementUpdated = !$scope.settlementUpdated ? $scope.tileInfo.settlementTile.numberOfCases !== data.settlementTile.numberOfCases : $scope.settlementUpdated;
                    $scope.responseUpdated = !$scope.responseUpdated ? $scope.tileInfo.responseTile.numberOfCases !== data.responseTile.numberOfCases : $scope.responseUpdated;
                    $scope.paymentUpdated = !$scope.paymentUpdated ? $scope.tileInfo.paymentTile.numberOfCases !== data.paymentTile.numberOfCases : $scope.paymentUpdated;
                    $scope.errorCorrectionsUpdated = !$scope.errorCorrectionsUpdated ? $scope.tileInfo.errorCorrectionsTile.numberOfCases !== data.errorCorrectionsTile.numberOfCases : $scope.errorCorrectionsUpdated;
                    $scope.casesOnHoldUpdated = !$scope.casesOnHoldUpdated ? $scope.tileInfo.casesOnHoldTile.numberOfCases !== data.casesOnHoldTile.numberOfCases : $scope.casesOnHoldUpdated;
                    $scope.ordersUpdated = !$scope.ordersUpdated ? $scope.tileInfo.drugOrdersTile.numberOfCases !== data.drugOrdersTile.numberOfCases : $scope.ordersUpdated;
                    $scope.completeReportUpdated = !$scope.completeReportUpdated ? $scope.tileInfo.completeReportTile.numberOfCases !== data.completeReportTile.numberOfCases : $scope.completeReportUpdated;
                    $scope.temporaryDoctorsUpdated = !$scope.temporaryDoctorsUpdated ? $scope.tileInfo.temporaryDoctorsTile.numberOfCases !== data.temporaryDoctorsTile.numberOfCases : $scope.temporaryDoctorsUpdated;

                    $(document).mousemove(function () {
                        setTimeout(function () {
                            for (var i = 0; i < ordinals.length; i++)
                                $scope[ordinals[i]] = undefined;

                            $scope.$digest();
                        }, 2000);
                    });
                };

                $scope.tileInfo = data;
            });

            function getTilesInformation() {
                dashboardService.getTilesInfo({ loginEmail: $rootScope.loginEmail }, getTilesInfoComplete, errorFunction);
            };

            // ----------------------------------------------------------- ERROR FUNCTIONS -------------------------------------------------------------

            function authenicateUserError(response) {
                $rootScope.activeMenuItem = null;
                $window.location.replace(response.logoutUrl);
            };

            function errorFunction(response) {
                console.log(response);
                alertsServices.ErrorMessage('LABEL_SOMETHING_WENT_WRONG');
            };

            function errorCasesForSubmit(response) {
                $scope.caseAmount = ": 0" + " €";
                $scope.caseCount = ": 0";
                $scope.caseOldestDate = ": -";
            };

            function errorCasesForPositiveResponse(response) {
                $scope.caseAmount = ": 0" + " €";
                $scope.caseCount = ": 0";
                $scope.caseOldestDate = ": -";
            };


            function errorCasesForReport(response) {
                $scope.numberOfCasesOp = ": 0";
                $scope.numberOfCasesAc = ": 0";
            };

            function errorCasesForPayment(response) {
                $scope.caseAmountPayment = ": 0" + " €";
                $scope.caseCountPayment = ": 0";
                $scope.caseOldestDatePayment = ": -";
            };

            function cancelPositiveResponseConfirmed(response) {
                alertsServices.ErrorMessage('LABEL_INVALID_FORM_FILE');
            };
            // ------------------------------------------------------------ COMPLETE REPORT -----------------------------------------------------------

            $scope.GenerateDownloadAndDownloadIt = function () {
                alert("Olafs neue List: GenerateDownloadAndDownloadIt"); 
                    dashboardService.createReportAndDownloadItAok(succesReportAndDownload, errorFunction);
            }

            $scope.GenerateDownloadAndDownloadItAok = function () {
				alert("Olafs neue List: GenerateDownloadAndDownloadItAok");
                dashboardService.createReportAndDownloadItAok(succesReportAndDownload, errorFunction);
            }

            $scope.GenerateDownloadAndDownloadItNonAok = function () {
                alert("Olafs neue List: GenerateDownloadAndDownloadItNonAok");
                dashboardService.createReportAndDownloadItNonAok(succesReportAndDownload, errorFunction);
            }

            function succesReportAndDownload(response) {
                var save = document.createElement('a');
                save.href = response;
                save.download = response;
                if (navigator.appVersion.toString().indexOf('.NET') > 0) {
                    $timeout(function () {
                        window.location = save;
                    }, 500, false);
                } else {
                    $timeout(function () {
                        var event = document.createEvent("MouseEvents");
                        event.initMouseEvent(
                                "click", true, false, window, 0, 0, 0, 0, 0
                                , false, false, false, false, 0, null
                        );
                        save.dispatchEvent(event);
                    }, 500, false);
                };
            };

            // -------------------------------------------------------------- FS1 -> FS2 ---------------------------------------------------------------

            $scope.settlementCase = function () {
                if ($scope.tileInfo.settlementTile.numberOfCases != 0) {
                    $scope.settlement.date = $filter('date')(new Date(), 'dd.MM.yyyy');
                    ngDialog.open({
                        template: 'scripts/src/app/dashboard/view/settlementConfirmationPopup.html',
                        scope: $scope,
                        closeByDocument: false
                    });

                    commonServices.focusElement('#dpSettlementDate');
                } else {
                    alertsServices.InformationMessage('LABEL_NO_AVAILABLE_ITEMS');
                };
            };

            function CreateReportAndChangeStatusToFs2Complete(response) {
                alertsServices.SuccessMessage('LABEL_CASES_STATUS_CHANGED');
                getTilesInformation();
            };

            $scope.confirm = function () {
            }

            $scope.confirmSettlementConfirmationPopup = function () {
                $scope.settlementDateInvalid = false;
                if (!validationService.isValidDate($scope.settlement.date)) {
                    $scope.settlementDateInvalid = true;
                    return;
                }

                var dateParts = $scope.settlement.date.split('.');
                var settlementDate = new Date(parseInt(dateParts[2]), parseInt(dateParts[1]) - 1, parseInt(dateParts[0]));
                if (settlementDate.getTime() > new Date().getTime()) {
                    $scope.settlementDateInvalid = true;
                    return;
                }

                ngDialog.close();

                dashboardService.CreateReportAndChangeStatusToFs2(settlementDate, CreateReportAndChangeStatusToFs2Complete, errorFunction);
            };


            // --------------------------------------------------- HIP RESPONSE ( FS2 -> FS4/FS5 ) -----------------------------------------------------

            $scope.$watch('filesPositiveResponse', function () {
                $scope.uploadPositiveResponse($scope.filesPositiveResponse);
            });

            $scope.uploadPositiveResponse = function (files) {
                if (files && files.length) {
                    for (var i = 0; i < files.length; i++) {
                        var file = files[i];
                        var filespl = file.name.split('.');
                        if (filespl[filespl.length - 1].toLowerCase() === "xlsx" || filespl[filespl.length - 1].toLowerCase() === "xls" || filespl[filespl.length - 1].toLowerCase() === "txt" || filespl[filespl.length - 1].toLowerCase() === "edi") {
                            dashboardService.PositiveResponse(file, succesPositiveResponse, errorFunction);
                        } else {
                            var message = 'LABEL_INVALID_FORM_FILE';
                            alertsServices.ErrorMessage(message);
                        };
                    };
                };
            };

            function succesPositiveResponse(response) {
                $scope.positiveResponse = response.PositiveModel.positiveModelL;
                $scope.negativeResponse = response.NegativeModel;
                var NumberofCasesThatCanNotBeChanged = response.NonEligibleStatuses;
                var NumberForChangeXls = response.TotalCases;
                numberForchange = NumberofCasesThatCanNotBeChanged;
                numberOfImported = NumberForChangeXls;
                if (NumberofCasesThatCanNotBeChanged != 0) {
                    var message = new Object();
                    message.message = 'LABEL_NON_ELIGIBLE_STATUSES';
                    message.eligible = NumberofCasesThatCanNotBeChanged;
                    message.total = NumberForChangeXls;
                    var title = 'LABEL_WARNING';
                    if (response.isPositiveResponce)
                        if (message.total - message.eligible == 0) {
                            alertsServices.RenderNotificationMessageRedHeader([{ message: 'LABEL_NO_ITEMS_FOR_EDIT' }], $scope);
                        } else
                            alertsServices.RenderConfirmationDialog(title, message, 'BUTTON_CONFIRML', 'BUTTON_CANCEL', confirmPostivieResponse, dummyFunction);
                    else {
                        if (message.total - message.eligible == 0) {
                            alertsServices.RenderNotificationMessageRedHeader([{ message: 'LABEL_NO_ITEMS_FOR_EDIT' }], $scope);
                        } else
                            alertsServices.RenderConfirmationDialog(title, message, 'BUTTON_CONFIRML', 'BUTTON_CANCEL', confirmNegativeResponse, dummyFunction);
                    }

                }
                else if (NumberofCasesThatCanNotBeChanged == 0 && NumberForChangeXls == 0) {
                    var message = 'LABEL_INVALID_FORM_FILE';
                    alertsServices.ErrorMessage(message);
                } else {

                    if (response.isPositiveResponce)
                        dashboardService.positiveResponseConfirm($scope.positiveResponse, succesPositiveResponseConfirmed, cancelPositiveResponseConfirmed);
                    else
                        dashboardService.negativeResponseConfirm($scope.negativeResponse, succesNegativeResponseConfirmed, errorFunction);

                };
            };

            function confirmNegativeResponse() {
                dashboardService.negativeResponseConfirm($scope.negativeResponse, succesNegativeResponseConfirmed, errorFunction);
            };

            function confirmPostivieResponse() {

                if (numberForchange != 0 && numberForchange === numberOfImported) {
                    var message = 'LABEL_INVALID_NO_OF_CASES';
                    alertsServices.SuccessMessage(message);
                    getTilesInformation();
                } else {
                    dashboardService.positiveResponseConfirm($scope.positiveResponse, succesPositiveResponseConfirmed, cancelPositiveResponseConfirmed);
                };
            };

            function succesPositiveResponseConfirmed(response) {
                alertsServices.SuccessMessage('LABEL_POSITIVE_RESPONSE');
                getTilesInformation();
            };

            function succesNegativeResponseConfirmed(response) {
                alertsServices.SuccessMessage('LABEL_NEGATIVE_RESPONSE');
                getTilesInformation();
            };

            // -------------------------------------------------------------- FS4 -> FS7 --------------------------------------------------------------

            $scope.ChangeCasesPayment = function () {
                if ($scope.tileInfo.paymentTile.numberOfCases != 0) {
                    $scope.payment.date = $filter('date')(new Date(), 'dd.MM.yyyy');
                    ngDialog.open({
                        template: 'scripts/src/app/dashboard/view/paymentConfirmationPopup.html',
                        scope: $scope,
                        closeByDocument: false
                    });

                    commonServices.focusElement('#dpPaymentDate');
                } else {
                    alertsServices.InformationMessage('LABEL_NO_AVAILABLE_ITEMS');
                };
            };

            $scope.cancelPaymentConfirmationPopup = function () {
                $scope.payment = { changeStatus: true };
                ngDialog.close();
            };

            $scope.cancelSettlementConfirmationPopup = function () {
                ngDialog.close();
            };

            $scope.confirmPaymentConfirmationPopup = function () {
                $scope.paymentDateInvalid = false;
                if (!validationService.isValidDate($scope.payment.date)) {
                    $scope.paymentDateInvalid = true;
                    return;
                }

                var dateParts = $scope.payment.date.split('.');
                var paymentDate = new Date(parseInt(dateParts[2]), parseInt(dateParts[1]) - 1, parseInt(dateParts[0]));
                if (paymentDate.getTime() > new Date().getTime()) {
                    $scope.paymentDateInvalid = true;
                    return;
                }

                var payment = {
                    paymentStatusChange: $scope.payment.changeStatus,
                    date: $scope.payment.date
                };

                ngDialog.close();
                $scope.payment.changeStatus = true;

                dashboardService.ChangeCasesPayment(payment, succesChangeCasesPayment, errorFunction);
            };

            function succesChangeCasesPayment(response) {
                if (response)
                    var message = 'LABEL_CASES_PAYMENT_CHANGED_STATUS';
                else
                    var message = 'LABEL_REPORT_CREATED';

                alertsServices.SuccessMessage(message);
                getTilesInformation();
            };

            // -------------------------------------------------------------- Complete orders report --------------------------------------------------------------

            $scope.createCompleteOrdersReport = function () {
                if ($scope.tileInfo.completeOrdersReportTile.numberOfCases != 0)
                    dashboardService.createCompleteOrdersReport(createCompleteOrdersReportComplete, errorFunction);
                else
                    alertsServices.InformationMessage('LABEL_NO_AVAILABLE_ITEMS');
            };

            function createCompleteOrdersReportComplete(response) {
                alertsServices.SuccessMessage('LABEL_COMPLETE_ORDER_REPORT_CREATED');
                getTilesInformation();

                if (response) {
                    var save = document.createElement('a');
                    save.href = response;
                    save.download = response;
                    if (navigator.appVersion.toString().indexOf('.NET') > 0) {
                        $timeout(function () {
                            window.location = save;
                        }, 500, false);
                    } else {
                        $timeout(function () {
                            var event = document.createEvent("MouseEvents");
                            event.initMouseEvent(
                                    "click", true, false, window, 0, 0, 0, 0, 0
                                    , false, false, false, false, 0, null
                            );
                            save.dispatchEvent(event);
                        }, 500, false);
                    };
                }

            };

            // -------------------------------------------------------------- MO1 -> MO2 --------------------------------------------------------------

            $scope.AcceptOrders = function () {
                if ($scope.tileInfo.drugOrdersTile.numberOfCases != 0)
                    dashboardService.changeAllOrderStatus(changeAllOrderStatusComplete, errorFunction);
                else
                    alertsServices.InformationMessage('LABEL_NO_AVAILABLE_ITEMS');
            };

            function changeAllOrderStatusComplete(response) {
                alertsServices.SuccessMessage('LABEL_POPUP_STERIBASE');
                getTilesInformation();

                if (response) {
                    var save = document.createElement('a');
                    save.href = response;
                    save.download = response;
                    if (navigator.appVersion.toString().indexOf('.NET') > 0) {
                        $timeout(function () {
                            window.location = save;
                        }, 500, false);
                    } else {
                        $timeout(function () {
                            var event = document.createEvent("MouseEvents");
                            event.initMouseEvent(
                                    "click", true, false, window, 0, 0, 0, 0, 0
                                    , false, false, false, false, 0, null
                            );
                            save.dispatchEvent(event);
                        }, 500, false);
                    };
                }

            };

            // -------------------------------------------------------------- MO2 -> MO3 --------------------------------------------------------------

            $scope.$watch('filesShipOrders', function () {
                $scope.uploadShipOrders($scope.filesShipOrders);
            });

            $scope.uploadShipOrders = function (files) {
                if (files && files.length) {
                    for (var i = 0; i < files.length; i++) {
                        var file = files[i];
                        var filespl = file.name.split('.');
                        if (filespl[filespl.length - 1] === "xlsx".toLowerCase() || filespl[filespl.length - 1] === "xls".toLowerCase())
                            dashboardService.ordersFromXls(file, ordersFromXlsComplete, errorFunction);
                        else {
                            var message = 'LABEL_INVALID_FORM_FILE';
                            alertsServices.ErrorMessage(message);
                        }
                    }
                }
            };

            function ordersFromXlsComplete(response) {
                ordersForShipping = response.OrdersChangeInfoApi.orderForChange;
                var NumberForChangeXls = response.OrdersChangeInfoApi.NumberChangeXls;
                var NumberForChange = response.OrdersChangeInfoApi.NumberChange;
                numberForchange = NumberForChange;
                numberOfImported = NumberForChangeXls;
                if (numberForchange - numberOfImported == 0) {
                    alertsServices.RenderNotificationMessageRedHeader([{ message: 'LABEL_NO_ITEMS_FOR_EDIT' }], $scope);
                }
                else if (NumberForChange != 0) {
                    alertsServices.RenderConfirmationDialog('LABEL_WARNING', { message: 'LABEL_ORDERS_SHIPPING_POPUP', eligible: NumberForChange, total: NumberForChangeXls }, 'BUTTON_CONFIRML', 'BUTTON_CANCEL', confirmOrderChange, dummyFunction);
                } else if (NumberForChange == 0 && NumberForChangeXls == 0) {
                    alertsServices.ErrorMessage('LABEL_SOMETHING_WENT_WRONG');
                } else {
                    dashboardService.changeOrders(ordersForShipping, succesOrdersInMo3, errorFunction);
                };
            };

            function confirmOrderChange() {
                if (numberForchange != 0 && numberForchange === numberOfImported) {
                    alertsServices.SuccessMessage('LABEL_INVALID_NO_OF_CASES');
                    getTilesInformation();
                } else {
                    dashboardService.changeOrders(ordersForShipping, succesOrdersInMo3, errorFunction);
                };
            };

            function succesOrdersInMo3(response) {
                alertsServices.SuccessMessage('MO3');
                getTilesInformation();
            };

            // ----------------------------------------------------------------- UTIL -----------------------------------------------------------------

            $scope.setMenuItemClass = function (index) {
                if ($scope.activeMenuItem == index)
                    return "active";
            };

            function dummyFunction() { };

            function isNotUndefinedOrNull(data) {
                return data !== undefined && data !== null;
            };

            $timeout(function () { $scope.pageLoaded = true; }, 0, false);

            $scope.$on('$routeChangeStart', function (scope, next, current) {
                $scope.pageLoaded = false;
            });

            // ----------------------------------------------------------------- END -------------------------------------------------------------------
        }]);
});
