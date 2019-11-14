"use strict";
define(['application-configuration'], function (app) {
    app.register.controller('contractController', ['$scope', '$location', 'contractService', 'alertsServices',
        function ($scope, $location, contractService, alertsServices) {

            // ----------------------------------------------------- VARIABLES ------------------------------------------------------

            var ascending = true;
            var sort_by = "contract_name";
            $scope.contracts = [];

            // -------------------------------------------------------- INIT --------------------------------------------------------


            $scope.initializeController = function () {
                contractService.authenicateUser($location.path(), $scope.authenicateUserComplete, $scope.authenicateUserError);
            };

            // ------------------------------------------------- USER AUTHENTICATION -------------------------------------------------

            $scope.authenicateUserComplete = function (response) {
                getContracts();
            };

            // ---------------------------------------------------- DATA RETRIEVAL ---------------------------------------------------

            function getContracts() {
                contractService.getAllContracts({ 'sort_by': sort_by, 'ascending': ascending }, getAllContractsComplete, errorFunction);
            };

            function getAllContractsComplete(response) {
                $scope.contracts = response;
            };

            // ---------------------------------------------------- COPY CONTRACT ----------------------------------------------------

            $scope.copyContract = function (item) {
                $scope.contractIDtoCopy = item.contract_id;
                alertsServices.RenderConfirmationDialog('LABEL_COPY_CONTRACT_TITLE', { message: 'LABEL_COPY_CONTRACT_CONTENT', eligible: item.contract_name }, 'BUTTON_YES', 'BUTTON_NO', copyContract, cancelCopyContract);
            };

            function copyContract() {
                contractService.copyContract({ contract_id: $scope.contractIDtoCopy }, copyContractComplete, errorFunction);
            }

            function copyContractComplete() {
                alertsServices.SuccessMessage('LABEL_CONTRACT_COPIED');
                getContracts();
            };

            function cancelCopyContract() { };

            // --------------------------------------------------- ERROR FUNCTIONS ---------------------------------------------------

            $scope.authenicateUserError = function (response) {
                $rootScope.activeMenuItem = null;
                $window.location.replace(response.logoutUrl);
            };

            function errorFunction(response) {
                console.log(response);
                alertsServices.ErrorMessage('LABEL_SOMETHING_WENT_WRONG');
            };

            // -------------------------------------------------------- UTIL --------------------------------------------------------

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
                getContracts();
            };

            $scope.redirect = function (id) {
                $location.url('/contract/contract_detail/' + id);
            };

            // -------------------------------------------------------- END ---------------------------------------------------------
        }]);
});