
define(['angularAMD', 'angular-route', 'angular-translate', 'doctorPageResources', 'patientPageResources', 'dashboardPageResources', 'globalResources', 'angular-datepicker',
    'ngDatefilter', 'offClick', 'blockUI', 'ngDialog', 'ngAnimate', 'addPracticeDirective', 'addDoctorDirective', 'angucomplete', 'addContractDirective', 'globalSearchDirective',
    'alertsServices', 'changePassController', 'commonServices', 'ajaxService', 'validationService', 'orderPageResources', 'treatmentPageResources', 'groupBy', 'ngFileUpload',
    'dropdownList', 'infiniteScroll', 'addUserDirective', 'sticky', 'medicationService', 'addMedicationDirective', 'medicationPageResources', 'contractService', 'gposDetailDirective',
    'ng-tags-input', 'coveredDrugsDirective', 'coveredDiagnosesDirective', 'coveredHipsDirective', 'participatingDoctorsDirective', 'dueDatesOverviewDirective', 'addGposDirective',
    'elipsisDirective', 'pharmacyService', 'addPharmacyDirective', 'timeInput'],
    function (angularAMD) {


        var app = angular.module('mainModule', ['ngRoute', 'pascalprecht.translate', 'blockUI', 'ngAnimate', 'infinite.scroll']);
        //app.value('backendServerUrl', 'api/Dashboard/

        app.service('htmlCacheBuster', ['$q', '$rootScope', function ($q, $rootScope) {
            var self = this;

            self.request = function (config) {
                // If the user isn't logged in yet, don't make any ajax calls to the server
                if (config.url.indexOf('scripts') !== -1) {
                    if (config.url.indexOf('.html') !== -1) {
                        config.url += '?v2.3.44';
                    }
                }

                return config;
            };
        }]);

        app.directive('ngRepeatFinished', function ($rootScope) {
            return {
                restrict: 'A',
                link: function (scope, element, attrs) {
                    if (scope.$last) {
                        setTimeout(function () { $rootScope.$broadcast('ngRepeatFinished'); });
                    }
                }
            };
        });

        /*******************************APP CONFIG******************************************/
        app.config(function ($routeProvider, $translateProvider, $httpProvider) {
            $httpProvider.interceptors.push('htmlCacheBuster');
            $translateProvider.translations('de', translationsDoctorDE);
            $translateProvider.translations('en', translationsDoctorEN);
            $translateProvider.translations('de', translationsDE);
            $translateProvider.translations('en', translationsEN);
            $translateProvider.translations('de', translationsOrderDE);
            $translateProvider.translations('en', translationsOrderEN);
            $translateProvider.translations('de', translationsTreatmentDE);
            $translateProvider.translations('en', translationsTreatmentEN);
            $translateProvider.translations('de', translationsDashboardDE);
            $translateProvider.translations('en', translationsDashboardEN);
            $translateProvider.translations('de', translationsPatientDE);
            $translateProvider.translations('en', translationsPatientEN);
            $translateProvider.translations('de', translationsMedicationDE);
            $translateProvider.translations('en', translationsMedicationEN);
            $translateProvider.preferredLanguage('de');
            $translateProvider.fallbackLanguage('en');

            $routeProvider
                .when("/", angularAMD.route({
                    templateUrl: 'scripts/src/app/dashboard/view/dashboard.html',
                    controller: 'dashboardController',
                    controllerUrl: 'scripts/src/app/dashboard/controllers/dashboardController.js'
                }))
                .when("/dashboard/", angularAMD.route({
                    templateUrl: 'scripts/src/app/dashboard/view/dashboard.html',
                    controller: 'dashboardController',
                    controllerUrl: 'scripts/src/app/dashboard/controllers/dashboardController.js'
                }))
                .when("/treatment/", angularAMD.route({
                    templateUrl: 'scripts/src/app/treatment/view/treatment.html',
                    controller: 'treatmentController',
                    controllerUrl: 'scripts/src/app/treatment/controllers/treatmentController.js'
                }))
                .when("/patient/", angularAMD.route({
                    templateUrl: 'scripts/src/app/patient/view/patient.html',
                    controller: 'patientController',
                    controllerUrl: 'scripts/src/app/patient/controllers/patientController.js'
                }))
                .when("/patient/patient_detail/:patient_id", angularAMD.route({
                    templateUrl: 'scripts/src/app/patient/view/patientDetailView.html',
                    controller: 'patientDetailViewController',
                    controllerUrl: 'scripts/src/app/patient/controllers/patientDetailViewController.js'
                }))
                .when("/order/", angularAMD.route({
                    templateUrl: 'scripts/src/app/order/view/order.html',
                    controller: 'orderController',
                    controllerUrl: 'scripts/src/app/order/controllers/orderController.js'
                }))
                .when("/doctor/", angularAMD.route({
                    templateUrl: 'scripts/src/app/doctor/view/doctor.html',
                    controller: 'doctorController',
                    controllerUrl: 'scripts/src/app/doctor/controllers/doctorController.js'
                }))
                 .when("/archive/", angularAMD.route({
                     templateUrl: 'scripts/src/app/archive/view/archive.html',
                     controller: 'archiveController',
                     controllerUrl: 'scripts/src/app/archive/controllers/archiveController.js'
                 }))
                  .when("/app_settings/", angularAMD.route({
                      templateUrl: 'scripts/src/app/settings/view/app_settings.html',
                      controller: 'appSettingsController',
                      controllerUrl: 'scripts/src/app/settings/controllers/appSettingsController.js'
                  }))
                .when("/employee/", angularAMD.route({
                    templateUrl: 'scripts/src/app/settings/view/employee.html',
                    controller: 'employeeController',
                    controllerUrl: 'scripts/src/app/settings/controllers/employeeController.js'
                }))
                .when("/my_account/", angularAMD.route({
                    templateUrl: 'scripts/src/app/settings/view/my_account.html',
                    controller: 'myAccountController',
                    controllerUrl: 'scripts/src/app/settings/controllers/myAccountController.js'
                }))
                  .when("/medication/", angularAMD.route({
                      templateUrl: 'scripts/src/app/master_data/view/medication.html',
                      controller: 'medicationController',
                      controllerUrl: 'scripts/src/app/master_data/controllers/medicationController.js'
                  }))
                  .when("/diagnoses/", angularAMD.route({
                      templateUrl: 'scripts/src/app/master_data/view/diagnoses.html',
                      controller: 'diagnosesController',
                      controllerUrl: 'scripts/src/app/master_data/controllers/diagnosesController.js'
                  }))
                  .when("/health_insurance/", angularAMD.route({
                      templateUrl: 'scripts/src/app/master_data/view/health_insurance.html',
                      controller: 'health_insuranceController',
                      controllerUrl: 'scripts/src/app/master_data/controllers/health_insuranceController.js'
                  }))
                  .when("/contract/", angularAMD.route({
                      templateUrl: 'scripts/src/app/master_data/view/contract.html',
                      controller: 'contractController',
                      controllerUrl: 'scripts/src/app/master_data/controllers/contractController.js'
                  }))
                 .when("/404", angularAMD.route({
                     templateUrl: 'scripts/src/common/view/404.html',
                     controller: '404Controller',
                     controllerUrl: 'scripts/src/common/controllers/404Controller.js'
                 }))
                .when("/doctor/doctor_detail/:doctor_id", angularAMD.route({
                    templateUrl: 'scripts/src/app/doctor/view/doctorDetailView.html',
                    controller: 'doctorDetailViewController',
                    controllerUrl: 'scripts/src/app/doctor/controllers/doctorDetailViewController.js'
                }))
                .when("/doctor/practice_detail/:practice_id", angularAMD.route({
                    templateUrl: 'scripts/src/app/doctor/view/practiceDetailView.html',
                    controller: 'practiceDetailViewController',
                    controllerUrl: 'scripts/src/app/doctor/controllers/practiceDetailViewController.js'
                }))
                .when("/contract/contract_detail/:contract_id", angularAMD.route({
                    templateUrl: 'scripts/src/app/master_data/view/contractDetailView.html',
                    controller: 'contractDetailViewController',
                    controllerUrl: 'scripts/src/app/master_data/controllers/contractDetailViewController.js'
                }))
                .when("/pharmacy", angularAMD.route({
                    templateUrl: 'scripts/src/app/master_data/view/pharmacy.html',
                    controller: 'pharmacyController',
                    controllerUrl: 'scripts/src/app/master_data/controllers/pharmacyController.js'
                }))
              .otherwise({ redirectTo: '/' })
        });

        /******************************************** SIGNALR FACTORY *********************************************/
        app.factory('backendHubProxy', ['$rootScope', function ($rootScope) {

            function backendFactory(serverUrl, hubName, groupName) {
                var connection = $.hubConnection(window.location.pathname.substring(0, window.location.pathname.lastIndexOf('/')) + '/signalr', { useDefaultPath: false });
                var proxy = connection.createHubProxy(hubName);
                proxy.on('updateNotifications', function (data) { });

                connection.start().done(function () {
                    proxy.invoke('joinGroup', groupName);
                });

                return {
                    on: function (eventName, callback) {
                        proxy.on(eventName, function (result) {
                            $rootScope.$apply(function () {
                                if (callback) {
                                    callback(result);
                                }
                            });
                        });
                    },
                    invoke: function (methodName, callback) {
                        proxy.invoke(methodName)
                        .done(function (result) {
                            $rootScope.$apply(function () {
                                if (callback) {
                                    callback(result);
                                }
                            });
                        });
                    }
                };
            };

            return backendFactory;
        }]);

        /*******************************APP RUN******************************************/
        app.run(function ($rootScope, ajaxService, blockUI, $timeout, ngDialog, $window) {

            $rootScope.isMaster = false;
            $rootScope.IsloggedIn = false;
            $rootScope.startTime = new Date();
            $rootScope.warning_message = "";

            // initialization of the application
            $rootScope.initializeApplication = function (successFunction, errorFunction) {
                blockUI.start();
                ajaxService.AjaxGet("api/main/InitializeApplication", successFunction, errorFunction);
                blockUI.stop();

            };

            $rootScope.initializeApplicationComplete = function (response) {
                $rootScope.IsloggedIn = true;
                $rootScope.user_name = response.name;
                $rootScope.isMaster = response.isMaster;
                $rootScope.loginEmail = response.loginEmail;

                if (!localStorage.loggedInSince) {
                    localStorage.loggedInSince = new Date().getTime();
                }

                $rootScope.startTime = new Date(parseInt(localStorage.loggedInSince));
                $rootScope.data[0].time = $rootScope.startTime;

                $rootScope.$broadcast('appliactionInitializationComplete', { loginEmail: response.loginEmail });
                updateDurations();
            };
            //not authentifiad popup
            function showMessagePopupError(msgAlert) {
                $rootScope.warning_message = msgAlert;
                ngDialog.open({
                    template: 'scripts/src/common/view/errorNoAppRights.html',
                    scope: $rootScope,
                    closeByDocument: false
                });
            }
            $rootScope.initializeApplicationError = function (response) {
                delete localStorage.loggedInSince;
                if (response.IsException)
                    showMessagePopupError(response.ReturnMessage[0]);
                else if (!response.IsAuthenicated && angular.isUndefinedOrNull(response.logoutUrl))
                    showMessagePopupError(response.ReturnMessage[0]);
                else
                    $window.location.replace(response.logoutUrl);

            };

            $rootScope.initializeApplication($rootScope.initializeApplicationComplete, $rootScope.initializeApplicationError);

            //set login time
            $rootScope.data = [
                     {
                         name: "Angemeldet seit ",
                         time: $rootScope.startTime,
                         duration: ''
                     },
            ];

            $rootScope.$on('AccountEdited', function (event, data) {
                $rootScope.initializeApplication($rootScope.initializeApplicationComplete, $rootScope.initializeApplicationError);
            });

            $rootScope.secondsToTime = function (secs) {
                var hours = Math.floor(secs / (60 * 60));

                var divisor_for_minutes = secs % (60 * 60);
                var minutes = Math.floor(divisor_for_minutes / 60);

                var divisor_for_seconds = divisor_for_minutes % 60;
                var seconds = Math.ceil(divisor_for_seconds);

                var obj = {
                    hours: hours,
                    minutes: minutes,
                    seconds: seconds
                };
                return obj;
            };

            function updateDurations() {
                for (var i = 0; i < $rootScope.data.length; i++) {
                    var tempDate = (new Date() - $rootScope.data[i].time) / 1000;
                    var date = $rootScope.secondsToTime(tempDate);
                    if (date.hours == 0) {
                        $rootScope.data[i].duration = date.minutes + " min";
                    }
                    else {
                        if (date.minutes < 0) {
                            $rootScope.data[i].duration = date.minutes = 0;
                        }
                        else {
                            $rootScope.data[i].duration = date.hours + "h" + " " + date.minutes + "min";
                        };
                    };
                };

                $timeout(updateDurations, 60000, true);
            };

            updateDurations();

            angular.isUndefinedOrNull = function (val) {
                return angular.isUndefined(val) || val === null
            };


            //logout
            $rootScope.logoutFromApp = function (successFunction, errorFunction) {
                ajaxService.AjaxGet("api/main/Logout", successFunction, errorFunction);
            };

            $rootScope.logout = function () {
                $rootScope.logoutFromApp($rootScope.logoutComplete, $rootScope.logoutError);
            };

            $rootScope.logoutComplete = function (response) {
                delete localStorage.loggedInSince;
                $window.location.replace(response.logoutUrl);
            };

            $rootScope.logoutError = function (response) {
                console.log(response);
            };
        });

        // TODO: move this into the run fn above
        /*******************************TAGS INPUT TEMPLATE CACHE******************************************/
        app.run(["$templateCache", function ($templateCache) {
            $templateCache.put('ngTagsInput/tags-input.html',
            "<div class=\"host\" tabindex=\"-1\" ng-click=\"eventHandlers.host.click()\" ti-transclude-append><div class=\"tags\" ng-class=\"{focused: hasFocus}\"><ul class=\"tag-list\"><li class=\"tag-item\" ng-repeat=\"tag in tagList.items track by track(tag)\" ng-class=\"{ selected: tag == tagList.selected }\" ng-click=\"eventHandlers.tag.click(tag)\"><ti-tag-item data=\"::tag\"></ti-tag-item></li></ul><input id={{listId}} class=\"input\" autocomplete=\"off\" ng-model=\"newTag.text\" ng-model-options=\"{getterSetter: true}\" ng-keydown=\"eventHandlers.input.keydown($event)\" ng-focus=\"eventHandlers.input.focus($event)\" ng-blur=\"eventHandlers.input.blur($event)\" ng-paste=\"eventHandlers.input.paste($event)\" ng-trim=\"false\" ng-class=\"{'invalid-tag': newTag.invalid}\" ng-disabled=\"disabled\" ti-bind-attrs=\"{type: options.type, placeholder: options.placeholder, tabindex: options.tabindex, spellcheck: options.spellcheck, id: autocompleteInputId}\" ti-autosize></div></div>"
          );

            $templateCache.put('ngTagsInput/tag-item.html',
              "<span ng-bind=\"$getDisplayText()\"></span> <a class=\"remove-button\" ng-click=\"$removeTag()\" ng-bind=\"::$$removeTagSymbol\"></a>"
            );

            $templateCache.put('ngTagsInput/auto-complete.html',
              "<div id={{suggestionListId}} class=\"autocomplete\" ng-show=\"suggestionList.visible\"><ul class=\"suggestion-list\"><li class=\"suggestion-item\" ng-repeat=\"item in suggestionList.items track by track(item)\" ng-class=\"{selected: item == suggestionList.selected}\" ng-click=\"addSuggestionByIndex($index)\" ng-mouseenter=\"suggestionList.select($index)\"><ti-autocomplete-match data=\"::item\"></ti-autocomplete-match></li></ul></div>"
            );

            $templateCache.put('ngTagsInput/auto-complete-match.html',
              "<span ng-bind-html=\"$highlight($getDisplayText())\"></span>"
            );
        }]);

        /*******************************INDEX CONTROLLER******************************************/
        var indexController = function ($scope, $rootScope, ajaxService, $location, blockUI, $timeout, backendHubProxy, ngDialog) {

            $scope.$on('appliactionInitializationComplete', function (event, data) {

                ajaxService.AjaxGet('api/main/GetNotifications', function (data, status, headers, config) {
                    $scope.doc_not = data.temporaryDoctorsTile.numberOfCases;
                    $scope.ord_not = data.drugOrdersTile.numberOfCases;
                    $scope.treat_not = data.errorCorrectionsTile.numberOfCases;
                });

                var notificationsDataHub = backendHubProxy('/signalr', 'notificationsHub', $rootScope.loginEmail);
                notificationsDataHub.on('updateNotifications', function (data) {
                    $scope.doc_not = data.temporaryDoctorsTile.numberOfCases;
                    $scope.ord_not = data.drugOrdersTile.numberOfCases;
                    $scope.treat_not = data.errorCorrectionsTile.numberOfCases;
                });

                notificationsDataHub.on('sessionExpired', function (data) {

                    $scope.title = 'LABEL_NOTICE';
                    $scope.message = 'LABEL_YOUR_SESSION_HAS_EXPIRED';
                    $scope.closePopup = function () {
                        window.location.replace(data.redirectTo);
                    };

                    ngDialog.open({
                        template: 'scripts/src/common/view/notificationPopupTemplate.html',
                        scope: $scope,
                        closeByDocument: false,
                        closeByEscape: false
                    });
                });

                notificationsDataHub.on('error', function error(response) {
                    console.log(response);
                });

                var dashboardDataHub = backendHubProxy('/signalr', 'notificationsHub', $rootScope.loginEmail);
                dashboardDataHub.on('updateDashboard', function (data) {
                    $rootScope.$broadcast('dashboardRefreshed', data);
                });

                dashboardDataHub.on('error', function error(response) {
                    console.log(response);
                });
            });

            $scope.areMoreOptionsVisible = false;
            $scope.isMasterDataVisible = false;

            $scope.masterDatavisible = function () {
                $scope.isMasterDataVisible = false;
            };

            $scope.moreOptionsVisible = function () {
                $scope.areMoreOptionsVisible = false;
            };

            $scope.showMoreOptions = function () {
                $scope.areMoreOptionsVisible = !$scope.areMoreOptionsVisible;
            };

            $scope.showMasterData = function () {
                $scope.isMasterDataVisible = !$scope.isMasterDataVisible;
            };

            $scope.hideMasterData = function () {
            };

            //when changing routes check if user is logged
            $scope.$on('$routeChangeStart', function (scope, next, current) {
                if ($rootScope.IsloggedIn == true) {
                    blockUI.start();
                    $scope.authenicateUser($location.path(), $scope.authenicateUserComplete, $scope.authenicateUserError);
                    blockUI.stop();
                };
            });

            $scope.$on('$routeChangeSuccess', function () {
                $scope.activeMenuItem = $location.$$url === '/' ? 'dashboard' : $location.$$url.split('/').length === 4 ? $location.$$url.split('/')[1] : $location.$$url.split('?')[0].substr(1);
                $scope.activeMenuItem = $scope.activeMenuItem.split('/')[0];
            });

            //user authentification
            $scope.authenicateUserComplete = function (response) {

            };

            $scope.authenicateUserError = function (response) {
                $scope.activeMenuItem = undefined;
                $location.url(response.logoutUrl);
            };
            $scope.authenicateUser = function (route, successFunction, errorFunction) {
                var authenication = new Object();
                authenication.route = route;
                ajaxService.AjaxGetWithData(authenication, "api/main/AuthenicateUser", successFunction, errorFunction);
            };

            // active menu item
            $scope.getClickMenuItem = function (item) {
                $scope.activeMenuItem = item;
            };

            $scope.setMenuItemClass = function (index) {
                if ($scope.activeMenuItem == index)
                    return "active";
            };

            angular.element('body').bind('DOMSubtreeModified', function (event) {
                setTimeout(calculateMaxHeight, 500);
            });
            $scope.setSelected = function (path) {
                if ($location.path().indexOf(path) > -1)
                    return "selected";
            };
            $(window).resize(calculateMaxHeight);

            function calculateMaxHeight() {
                if (angular.element('#wrapper')[0] !== undefined) {
                    var wrapper = angular.element('#wrapper');
                    var offset = window.innerHeight - wrapper.offset().top;

                    // TODO: this was set to offset - 4 px because of the treatment multi edit, needs to be refactored
                    angular.element('#wrapper').css('min-height', offset < 0 ? 0 : offset - 4 + 'px');
                    angular.element('#wrapper').css('max-height', offset < 0 ? 0 : offset - 4 + 'px');
                };
            };

            $scope.hideDropdown = function ($event) {
                if ($event.target.id !== 'showMoreOptions' && $event.target.id !== 'btnMasterData') {
                    setTimeout(function () {
                        $scope.isMasterDataVisible = false;
                        $scope.areMoreOptionsVisible = false;
                        $scope.$apply();
                    }, 150);
                }
            };

        };

        indexController.$inject = ['$scope', '$rootScope', 'ajaxService', '$location', 'blockUI', '$timeout', 'backendHubProxy', 'ngDialog'];
        app.controller('indexController', indexController);

        angularAMD.bootstrap(app);

        return app;
    });
