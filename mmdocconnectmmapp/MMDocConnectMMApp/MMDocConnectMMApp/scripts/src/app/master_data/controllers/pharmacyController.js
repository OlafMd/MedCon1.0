
"use strict";
define(['application-configuration'], function (app) {
    app.register.controller('pharmacyController', ['$scope', '$location', '$rootScope', 'pharmacyService', 'alertsServices', 'commonServices',
            function ($scope, $location, $rootScope, pharmacyService, alertsServices, commonServices) {

                $scope.pharmacies = [];

                var sort_parameter = new Object();
                sort_parameter.sortBy = "name";
                sort_parameter.isAsc = true;

                getPharmacy();
                function getPharmacy() {
                    pharmacyService.getPharmacies(sort_parameter, succesGetPharmacyFunction, errorFunction);
                }

                function succesGetPharmacyFunction(response) {
                    $scope.pharmacies = response;
                }

                function errorFunction(response) {
                    console.log(response);
                    alertsServices.ErrorMessage('LABEL_SOMETHING_WENT_WRONG');
                };


                $scope.deletePharmacy = function (pharmacy) {
                    $scope.pharmacyForDelete = pharmacy;
                    commonServices.getEmployeesForRightID({ isMaster: true }, deletePharmacy, errorFunction);
                }

                function deletePharmacy(response) {
                    var message = "LABEL_CONFIRM_REJECT_ORDER";
                    alertsServices.ConfirmPassword(response.employees, response.logged_in_user_email, confirmDeleteFunction, cancelDeleteFunction, message);
                }

                function confirmDeleteFunction(response) {
                    pharmacyService.deletePharmacy($scope.pharmacyForDelete.pharmacyID, succesDeleteFunction, errorFunction);
                }

                function cancelDeleteFunction(response) {
                    alertsServices.PopupClose();
                }

                function succesDeleteFunction(response) {
                    if (response) {
                        getPharmacy();
                    } else {
                        errorFunction(response);
                    }
                    $scope.pharmacyForDelete = undefined;
                }

                $scope.setTableHeaderClass = function (order_value) {
                    if (sort_parameter.isAsc && sort_parameter.sortBy == order_value)
                        return 'sorted_asc';
                    else if (!sort_parameter.isAsc && sort_parameter.sortBy == order_value)
                        return 'sorted_dsc'
                    else
                        return 'unsorted';
                };

                //#region Edit
                $scope.showPharmacyDirective = false;
                $scope.hidePharmacyButton = false;

                $scope.openFormAddPharmacy = function () {
                    $scope.showPharmacyDirective = true;
                    $scope.hidePharmacyButton = true;
                };

                $scope.editPharmacy = function (item) {
                    if ($scope.showPharmacyDirective) {
                        $scope.hidePharmacyButton = false;
                        $scope.showPharmacyDirective = false;
                    }
                    else {
                        $scope.editPharmacyID = item.pharmacyID;
                        $scope.fromEdit = item;
                        $scope.showEditPharmacyDirective = true;
                    }
                    return false;
                };

                $scope.$on('CloseForm', function (event, data) {
                    $scope.hidePharmacyButton = false;
                    $scope.showPharmacyDirective = false;
                    $scope.fromEdit = null;
                    $scope.showEditPharmacyDirective = false;
                    $scope.editPharmacyID = undefined;

                    getPharmacy();

                });
                //#endregion

                $scope.SortFunction = function (sortValue) {
                    if (sort_parameter.sortBy == sortValue) {
                        sort_parameter.isAsc = !sort_parameter.isAsc;
                    }
                    sort_parameter.sortBy = sortValue;
                    getPharmacy();
                };
            }]);

});
