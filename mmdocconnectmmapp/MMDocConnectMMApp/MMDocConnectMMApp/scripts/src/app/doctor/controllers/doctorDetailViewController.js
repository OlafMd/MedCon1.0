/// <reference path="doctorController.js" />
"use strict";
define(['application-configuration', 'doctorService'], function (app) {
    app.register.controller('doctorDetailViewController', ['$scope', '$location', '$routeParams', 'doctorService', 'validationService', '$filter', '$rootScope', '$timeout',
        function ($scope, $location, $routeParams, doctorService, validationService, $filter, $rootScope, $timeout) {

            $scope.doctor_detail = [];
            $scope.showDoctorDirective = false;
            $scope.EditContractItem = false;
            var isASC = false;
            $scope.frKey = "";
            $scope.sndKey = "";

            $scope.isNotNullOrEmpty = validationService.isNotNullOrEmpty;

            $scope.initializeController = function () {
                doctorService.authenicateUser($location.path(), $scope.authenicateUserComplete, $scope.authenicateUserError);
            };

            $scope.authenicateUserComplete = function (response) {
                $scope.getDoctorDetails();
            };

            $scope.authenicateUserError = function (response) {
                $rootScope.activeMenuItem = null;
                $window.location.replace(response.logoutUrl);
            };

            $scope.doctorDetailsComplete = function (response) {
                $scope.doctor_detail = response.doctor;
                if (response.doctor.account_deactivated === true) {
                    $scope.SetVisibility = true;
                }
            };

            $scope.doctorDetailsError = function (response) {
                console.log(response);
            };

            $scope.getDoctorDetails = function () {
                var doctor = new Object();
                doctor.ID = $routeParams.doctor_id;
                doctorService.getDoctorDetails(doctor, $scope.doctorDetailsComplete, $scope.doctorDetailsError);
            };


            $scope.redirectBackOnePage = function () {
                window.history.go(-1);
            };

            $scope.ContractsFound = function (response) {
                if (response.length == 0) {
                    $scope.SetVisibility = true;
                }

            };

            $scope.ContractsNotFound = function (response) {


            };


            doctorService.getContractsForDropDown($scope.ContractsFound, $scope.ContractsNotFound);

            $scope.DocContractsFound = function (response) {
                for (i = 0; i < response.Contracts.length; i++) {
                    var dateCheck = new Date(response.Contracts[i].ValidThrough);
                    var yearForTo = dateCheck.getFullYear();
                    if (yearForTo === 1) {
                        response.Contracts[i].ValidThrough = "∞";
                    }
                }
                $scope.ContractsList = response.Contracts;
                $scope.SortFunction("ContractName");
                isASC = false;

            };

            $scope.DocContractsNotFound = function (response) {
            };

            var objDoc = new Object();
            objDoc.DocId = $routeParams.doctor_id;
            doctorService.getDoctorContract(objDoc, $scope.DocContractsFound, $scope.DocContractsNotFound);

            $scope.OpenFormAddContract = function (editContract) {

                $scope.getDoctorDetails();

                if ($scope.showAddContractDirective || $scope.showDoctorDirective || $scope.showDoctorDirective || $scope.showEditContractDirective) {
                    $scope.showDoctorDirective = false;
                    $scope.showDoctorDirectiveButton = true;
                    $scope.hideButtonAddContract = false;
                    $scope.showAddContractDirective = false;
                    $scope.showEditContractDirective = false;
                }
                else if (editContract != 'add') {
                    $scope.CloseContractForm = false;
                    editContract.DocId = $routeParams.doctor_id;
                    $scope.fromEdit = editContract;
                    $scope.showEditContractDirective = true;
                    $scope.editContractID = editContract.DoctorAssignment;
                    $scope.editContractAssignment = editContract.DoctorAssignment;
                }
                else {
                    $scope.CloseContractForm = true;
                    $scope.fromEdit = null;
                    $scope.showAddContractDirective = !$scope.showAddContractDirective;
                    $scope.hideButtonAddContract = $scope.showAddContractDirective;
                    $scope.showDoctorDirective = false;
                    $scope.showDoctorDirectiveButton = true;

                }

                return false;
            };

            $scope.OpenFormEditDoctor = function () {
                if ($scope.showAddContractDirective || $scope.showEditContractDirective || $scope.showEditContractDirective) {
                    $scope.showDoctorDirective = false;
                    $scope.showDoctorDirectiveButton = true;
                    $scope.hideButtonAddContract = false;
                    $scope.showAddContractDirective = false;
                    $scope.showEditContractDirective = false;
                }
                else {
                    $scope.showDoctorDirective = !$scope.showDoctorDirective;
                    $scope.showAddContractDirective = false;
                    $scope.hideButtonAddContract = false;
                }
                return false;
            };



            $scope.SortFunction = function (item) {
                isASC = !isASC;
                if (isASC) {
                    $scope.frKey = item;
                    $scope.sndKey = "ValidFrom";

                }
                else {
                    $scope.frKey = '-' + item;
                    $scope.sndKey = '-' + "ValidFrom";

                } $scope.classContract = 'unsorted';
            };

            $scope.setClass = function (item) {
                if (isASC && $scope.frKey == item)

                    return 'sorted_asc';
                else if (!isASC && $scope.frKey == '-' + item)
                    return 'sorted_dsc';
                else
                    return 'unsorted';

            }
            $scope.$on('CloseForm', function (event, data) {
                if (data[0] === "CloseContract") {
                    $scope.showAddContractDirective = false;
                    $scope.showEditContractDirective = false;
                    $scope.hideButtonAddContract = false;
                    $scope.editContractID = 0;
                    doctorService.getDoctorContract(objDoc, $scope.DocContractsFound, $scope.DocContractsNotFound);
                };

                if (data[0] === "CloseDoctor") {
                    $scope.showDoctorDirective = false;
                    $scope.showDoctorDirectiveButton = true;

                    $scope.getDoctorDetails();
                };
            });

            $timeout(function () { angular.element('#btnEditDoctor')[0].focus(); }, 1000, false);

        }]);

});