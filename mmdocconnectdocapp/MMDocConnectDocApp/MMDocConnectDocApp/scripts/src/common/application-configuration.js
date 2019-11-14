(function () {
    'use strict';
    var app = angular.module('mainModule', ['ngRoute', 'pascalprecht.translate', 'blockUI', 'ngAnimate', 'ui.bootstrap', 'ngDialog', 'angucomplete', 'angucompleteAc', '720kb.datepicker', 'infinite.scroll', 'templates']);

    app.directive('ngRepeatFinished', ['$rootScope', function ($rootScope) {
        return {
            restrict: 'A',
            link: function (scope, element, attrs) {
                if (scope.$last) {
                    setTimeout(function () { $rootScope.$broadcast('ngRepeatFinished'); });
                }
            }
        };
    }]);

    app.config(['$provide', function ($provide) {
        $provide.decorator('$locale', ['$delegate', function ($delegate) {
            var value = $delegate.DATETIME_FORMATS;
            value.MONTH = ['Januar', 'Februar', 'Marz', 'April', 'Mai', 'Juni', 'Juli', 'August', 'September', 'Oktober', 'November', 'Dezember'];
            value.SHORTDAY = ['So', 'Mo', 'Di', 'Mi', 'Do', 'Fr', 'Sa'];
            return $delegate;
        }]);
    }]);

    app.config(['$routeProvider', '$translateProvider', '$httpProvider', 'uibDatepickerConfig', 'uibDatepickerPopupConfig', '$uibTooltipProvider', 'blockUIConfig', function ($routeProvider, $translateProvider, $httpProvider, uibDatepickerConfig, uibDatepickerPopupConfig, $uibTooltipProvider, blockUIConfig) {
        blockUIConfig.delay = 100;
        blockUIConfig.autoBlock = false;

        $translateProvider.translations('de', translationsDE);
        $translateProvider.translations('en', translationsEN);
        $translateProvider.translations('de', translationsPatientDE);
        $translateProvider.translations('en', translationsPatientEN);
        $translateProvider.translations('de', translationsPlanningDE);
        $translateProvider.translations('en', translationsPlanningEN);
        $translateProvider.translations('de', translationsAftercareDE);
        $translateProvider.translations('en', translationsAftercareEN);
        $translateProvider.translations('de', translationsSettlementDE);
        $translateProvider.translations('en', translationsSettlementEN);
        $translateProvider.translations('de', translationsOctDE);
        $translateProvider.translations('en', translationsOctEN);
        $translateProvider.translations('de', translationsShoppingCartDE);
        $translateProvider.translations('en', translationsShoppingCartEN);
        $translateProvider.translations('de', translationsOrderDE);
        $translateProvider.translations('en', translationsOrderEN);

        $translateProvider.preferredLanguage('de');
        $translateProvider.fallbackLanguage('en');

        uibDatepickerConfig.startingDay = 1;
        uibDatepickerConfig.showWeeks = false;
        uibDatepickerConfig.formatDay = 'd';
        uibDatepickerPopupConfig.datepickerPopup = 'dd.MM.yyyy';
        uibDatepickerPopupConfig.onOpenFocus = false;
        uibDatepickerPopupConfig.appendToBody = true;
        uibDatepickerPopupConfig.datepickerTemplateUrl = 'scripts/src/common/view/uibTemplates/datepicker/datepicker.html';
        uibDatepickerPopupConfig.datepickerPopupTemplateUrl = 'scripts/src/common/view/uibTemplates/datepickerPopup/popup.html';
        $uibTooltipProvider.options({
            appendToBody: true
        });

        $routeProvider
            .when("/planning/", {
                templateUrl: 'scripts/src/app/planning/view/planning.html',
                controller: 'planningController',
                controllerUrl: 'scripts/src/app/planning/controllers/planningController.js',
                caseInsensitiveMatch: true
            })
            .when("/aftercare/", {
                templateUrl: 'scripts/src/app/aftercare/view/aftercare.html',
                controller: 'aftercareController',
                controllerUrl: 'src/app/aftercare/controllers/aftercareController',
                caseInsensitiveMatch: true
            })
            .when("/oct/", {
                templateUrl: 'scripts/src/app/oct/view/oct.html',
                controller: 'octController',
                controllerUrl: 'src/app/oct/controllers/octController',
                caseInsensitiveMatch: true
            })
            .when("/patient/", {
                templateUrl: 'scripts/src/app/patient/view/patient.html',
                controller: 'patientController',
                controllerUrl: 'scripts/src/app/patient/controllers/patientController.js',
                caseInsensitiveMatch: true
            })
                .when("/patient/patient_detail/:patient_id", {
                    templateUrl: 'scripts/src/app/patient/view/patientDetailView.html',
                    controller: 'patientDetailViewController',
                    controllerUrl: 'scripts/src/app/patient/controllers/patientDetailViewController.js',
                    caseInsensitiveMatch: true
                })
            .when("/settlement/", {
                templateUrl: 'scripts/src/app/settlement/view/settlement.html',
                controller: 'settlementController',
                controllerUrl: 'scripts/src/app/settlement/controllers/settlementController.js',
                caseInsensitiveMatch: true
            })
            .when("/receipt/", {
                templateUrl: 'scripts/src/app/receipt/view/receipt.html',
                controller: 'receiptController',
                controllerUrl: 'scripts/src/app/receipt/controllers/receiptController.js',
                caseInsensitiveMatch: true
            })
               .when("/praxis_account/:previous_page?", {
                   templateUrl: 'scripts/src/app/settings/view/praxis_account.html',
                   controller: 'praxisController',
                   controllerUrl: 'scripts/src/app/settings/controllers/praxisController.js',
                   caseInsensitiveMatch: true
               })
             .when("/my_account/:previous_page?", {
                 templateUrl: 'scripts/src/app/settings/view/my_account.html',
                 controller: 'my_accountController',
                 controllerUrl: 'scripts/src/app/settings/controllers/my_accountController.js',
                 caseInsensitiveMatch: true
             })
              .when("/404/", {
                  templateUrl: 'scripts/src/common/view/404.html',
                  controller: '404Controller',
                  controllerUrl: 'scripts/src/common/controllers/404Controller.js',
                  caseInsensitiveMatch: true
              })
              .when("/shoppingcart/", {
                  templateUrl: 'scripts/src/app/shoppingCart/view/shoppingCart.html',
                  controller: 'shoppingCartController',
                  controllerUrl: 'scripts/src/app/shoppingCart/controllers/shoppingCartController.js',
                  caseInsensitiveMatch: true
              })
              .when("/order/", {
                  templateUrl: 'scripts/src/app/orders/view/orders.html',
                  controller: 'ordersController',
                  controllerUrl: 'scripts/src/app/orders/controllers/ordersController.js',
                  caseInsensitiveMatch: true
              })
          .otherwise({ redirectTo: '/planning/' });
    }]);

    app.run(['$rootScope', 'ajaxService', 'blockUI', '$timeout', 'ngDialog', '$location', '$window', function ($rootScope, ajaxService, blockUI, $timeout, ngDialog, $location, $window) {
        $rootScope.startTime = new Date();
        $rootScope.isOpRole = false;
        $rootScope.isDoctor = false;
        $rootScope.empty_guid = '00000000-0000-0000-0000-000000000000';

        $rootScope.initializeApplication = function (successFunction, errorFunction) {
            blockUI.start();
            ajaxService.AjaxGet("api/main/InitializeApplication", successFunction, errorFunction);
            blockUI.stop();
        };

        $rootScope.initializeApplicationComplete = function (response) {
            $rootScope.IsloggedIn = true;
            $rootScope.user_name = response.name;
            $rootScope.isDoctor = response.isDoctor;
            $rootScope.canAddPreexaminations = response.canAddPreexaminations;
            $rootScope.id = response.id;

            if (response.isOpRole) {
                $rootScope.isOpRole = true;
                if ($location.path() === '/') {
                    $location.url('/planning');
                    $rootScope.activeMenuItem = "planning";
                }
            } else {
                if ($location.path() === '/') {
                    $rootScope.activeMenuItem = "aftercare";
                    $location.url('/aftercare');
                }
            };

            if (!localStorage.loggedInSince) {
                localStorage.loggedInSince = new Date().getTime();
            }

            $rootScope.startTime = new Date(parseInt(localStorage.loggedInSince));
            $rootScope.data[0].time = $rootScope.startTime;

            $rootScope.$broadcast('appliactionInitializationComplete', { loginEmail: response.loginEmail });

            updateDurations();
        };

        $rootScope.initializeApplicationError = function (response) {
            delete localStorage.loggedInSince;

            if (response.IsException)
                showMessagePopupError(response.ReturnMessage[0]);
            else if (!response.IsAuthenicated && (response.logoutUrl === undefined || response.logoutUrl === null || response.logoutUrl === ''))
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

        //not authentifiad popup
        function showMessagePopupError(msgAlert) {
            $rootScope.warning_message = msgAlert;
            ngDialog.open({
                template: 'scripts/src/common/view/errorNoAppRights.html',
                scope: $rootScope,
                closeByDocument: false
            });
        }

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
                } else {
                    if (date.minutes < 0) {
                        $rootScope.data[i].duration = date.minutes = 0;
                    } else {
                        $rootScope.data[i].duration = date.hours + "h" + " " + date.minutes + "min";
                    }
                }
            }

            $timeout(updateDurations, 60000, true);
        };
        updateDurations();


        //logout
        $rootScope.logoutFromApp = function (successFunction, errorFunction) {
            ajaxService.AjaxGet("api/main/Logout", successFunction, errorFunction);
        };

        $rootScope.logout = function () {
            $rootScope.logoutFromApp($rootScope.logoutComplete, $rootScope.logoutError);
        };

        $rootScope.redirectToHelp = function () {
            ajaxService.AjaxGet('api/main/RedirectToHelp', function (response) {
                window.open(response, '_blank');
            }, errorFunction);
        };

        $rootScope.logoutComplete = function (response) {
            delete localStorage.loggedInSince;
            window.location.replace(response.logoutUrl);
        };

        $rootScope.logoutError = function (response) {
            console.log('error on logout');
        };

        function errorFunction() {

        }

        // active menu item
        $rootScope.getClickMenuItem = function (item) {
            $rootScope.activeMenuItem = item;

            if (item == 'praxis_account' || item == 'my_account') {
                var current_page = $location.path().match(/[^\/]+/g);
                $location.url(item + '/' + current_page[current_page.length - 1]);
            }
        };

        $rootScope.setMenuItemClass = function (index) {
            if ($rootScope.activeMenuItem == index && $rootScope.activeMenuItem != "my_account" && $rootScope.activeMenuItem != "praxis_account")
                return "active";
            else if ($rootScope.activeMenuItem == index && ($rootScope.activeMenuItem == "my_account" || $rootScope.activeMenuItem == "praxis_account"))
                return "selected";
        };

        $rootScope.clickLogo = function () {
            if ($rootScope.isOpRole) {
                $rootScope.activeMenuItem = "planning";
                $location.url('/planning');
            } else {
                $rootScope.activeMenuItem = "aftercare";
                $location.url('/aftercare');
            }
        };
    }]);

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

    /*******************************INDEX CONTROLLER******************************************/
    var indexController = function ($scope, $rootScope, ajaxService, $location, blockUI, backendHubProxy, ngDialog) {

        function readCookie(name) {
            var nameEQ = name + "=";
            var ca = document.cookie.split(';');
            for (var i = 0; i < ca.length; i++) {
                var c = ca[i];
                while (c.charAt(0) == ' ') c = c.substring(1, c.length);
                if (c.indexOf(nameEQ) == 0) return c.substring(nameEQ.length, c.length);
            }
            return null;
        }

        $scope.$on('appliactionInitializationComplete', function (event, data) {
            var sessionToken = document.cookie.replace('%3d', '=').replace('%3d', '=').replace('%23', '#').split('bops=st=')[1].split('#ln')[0];
            var notificationsDataHub = backendHubProxy('/signalr', 'sessionHub', data.loginEmail);
            var bops = readCookie('bops').replace('st%3d', '').replace('st=', '').replace('%23ln%3d', '').replace('#ln=', '').slice(0, -2);
            var sessionDataHub = backendHubProxy('/signalr', 'sessionHub', bops);

            sessionDataHub.on('sessionExpired', function (data) {
                $scope.title = 'LABEL_NOTICE';
                $scope.warning_messages = [{ message: 'LABEL_YOUR_SESSION_HAS_EXPIRED' }];
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

            notificationsDataHub.on('updateNotifications', function (data) {
                $scope.sett_not = data.errorCorrectionsTile.numberOfCases;
                $scope.rec_not = data.paymentTile.numberOfCases;
                $scope.patient_nott = data.settlementTile.numberOfCases;
            });

            notificationsDataHub.on('error', function error(response) {
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

        //when changing routes check if user is logged
        $scope.$on('$routeChangeStart', function () {         
            $scope.authenicateUser($location.$$url, $scope.authenicateUserComplete, $scope.authenicateUserError);            
        });

        $scope.$on('$routeChangeSuccess', function () {
            if ($location.$$url === '/') {
                if ($rootScope.isOpRole) {
                    $location.url('/planning');
                } else {
                    $location.url('/aftercare');
                }
            }

            $scope.activeMenuItem = $location.$$url === '/' ? 'planning' : $location.$$url.split('/').length === 4 ? $location.$$url.split('/')[1] : $location.$$url.split('?')[0].substr(1);
            $scope.activeMenuItem = $scope.activeMenuItem.split('/')[0];
            ngDialog.close();
        });

        $scope.$on('AccountEdited', function (event, data) {
            if (!data.isPracticeLoggedIn) {
                if (data.name != undefined)
                    $scope.user_name = data.name;
            }
            else
                $scope.user_name = data.practice_name;
        });

        function getNotifications() {
            ajaxService.AjaxGet('api/main/GetNotifications', getNotificationsComplete, errorFunction);
        }

        getNotifications();

        function getNotificationsComplete(response) {
            $scope.sett_not = response.errorCorrectionsTile.numberOfCases;
            $scope.rec_not = response.paymentTile.numberOfCases;
            $scope.patient_nott = response.settlementTile.numberOfCases;
        };

        //user authentification
        $scope.authenicateUserComplete = function (response) {
            blockUI.stop();
        };

        $scope.authenicateUserError = function (response, status) {
            blockUI.stop();
            switch (status) {
                case 401:
                    $location.url('/login');
                    break;

                case 403:
                    if (response.IsOpRole) {
                        $location.url('/planning');
                    } else {
                        $location.url('/aftercare');
                    }

                    break;
            }
        };

        //not authentifiad popup
        function showMessagePopupError(msgAlert) {
            $rootScope.warning_message = 'LABEL_404';
            ngDialog.open({
                template: 'scripts/src/common/view/errorNoAppRights.html',
                scope: $rootScope,
                closeByDocument: false
            });
        }

        $scope.authenicateUser = function (route, successFunction, errorFunction) {
            blockUI.start();
            var authenication = new Object();
            authenication.route = route;
            ajaxService.AjaxGetWithData(authenication, "api/main/AuthenicateUser", successFunction, errorFunction);
        };

        function errorFunction(response) {
            console.log(response);
        };

        $scope.setMenuItemClass = function (index) {
            if ($scope.activeMenuItem !== undefined && $scope.activeMenuItem.indexOf(index) > -1)
                return "active";
        };

        angular.element('body').bind('DOMSubtreeModified', function (event) {
            setTimeout(calculateMaxHeight);
        });

        $scope.setSelected = function (path) {
            if ($location.path().indexOf(path) !== -1)
                return "selected";
        };
        $(window).resize(calculateMaxHeight);

        function calculateMaxHeight() {
            if (angular.element('#wrapper')[0] !== undefined) {
                var wrapper = angular.element('#wrapper');
                var offset = window.innerHeight - wrapper.offset().top;

                angular.element('#wrapper').css('min-height', offset < 0 ? 0 : offset + 'px');
                angular.element('#wrapper').css('max-height', offset < 0 ? 0 : offset + 'px');
            };
        };

        $scope.hideDropdown = function ($event) {
            if ($event.target.id !== 'showMoreOptions') {
                setTimeout(function () {
                    $scope.isMasterDataVisible = false;
                    $scope.areMoreOptionsVisible = false;
                    $scope.$apply();
                }, 150);
            }
        };

        if ($location.path() !== '/') {
            $scope.authenicateUser($location.path(), $scope.authenicateUserComplete, $scope.authenicateUserError);
        }
    };

    // extensions
    // todo: move to separate script!!
    Date.prototype.withoutTime = function () {
        var d = new Date(this);
        d.setHours(0, 0, 0, 0, 0);
        return d
    };

    Array.prototype.elementWithValue = function (ordinal, value, returnField) {
        for (var i = 0; i < this.length; i++) {
            if (this[i][ordinal] === value) {
                if (returnField) {
                    return this[i][returnField];
                } else {
                    return this[i];
                }
            }
        };

        return undefined;
    };

    indexController.$inject = ['$scope', '$rootScope', 'ajaxService', '$location', 'blockUI', 'backendHubProxy', 'ngDialog'];
    app.controller("indexController", indexController);
    $(document).ready(function () {
        angular.bootstrap(document, ['mainModule'], {
            strictDi: true
        });
    });

    return app;
})();
