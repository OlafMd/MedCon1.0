

define(['angularAMD', 'ajaxService'], function (angularAMD) {
    angularAMD.factory('authService', ['$rootScope', 'ajaxService', function ($rootScope, ajaxService) {

        var authServiceFactory = {};
        var _isLoggedIn = false;
        var _logoutUrl = "";



        var _initializeApplicationComplete = function (response) {
            _isLoggedIn = true;
        };

        var _initializeApplicationError = function (response) {
            _isLoggedIn = false;
            _logoutUrl = response.logoutUrl;
        };

        var _initializeApplication = function () {
            ajaxService.AjaxGet("/api/main/InitializeApplication", _initializeApplicationComplete, _initializeApplicationError);
        };

        authServiceFactory.initializeApplication = _initializeApplication;
        authServiceFactory.isLoggedIn = _isLoggedIn;
        authServiceFactory.logoutUrl = _logoutUrl;

        return authServiceFactory;

    }]);

});