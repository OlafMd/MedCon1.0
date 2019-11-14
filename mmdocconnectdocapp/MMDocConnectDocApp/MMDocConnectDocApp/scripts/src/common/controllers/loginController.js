(function () {
    'use strict';
    angular.module('app', [])
    .controller('loginController', ['$scope', '$location', '$http', '$timeout', LoginController]);

    function LoginController($scope, $location, $http, $timeout) {

        // ----------------------------------------------------------- LOGIN -----------------------------------------------------------
        var isFirstLoad = true;
        $scope.javascriptEnabled = navigator.cookieEnabled;
        $scope.deletePasswordForFirstLoad = function () {
            if (!isFirstLoad)
                return;

            isFirstLoad = false;
            $timeout(function () {
                angular.element('#password')[0].value = " ";
                angular.element('#password')[0].value = "";
            }, 150);
        }

        $scope.login = function () {
            delete localStorage.loggedInSince;
            $http.post('api/login/LogIn', { username: $scope.username, password: $scope.password }).success(function (response, status, headers, config) {
                loginSuccessful(response);
            }).error(function (response) {
                loginError(response);
            });
        };

        function loginSuccessful(response) {
            var redirectUrl = response.redirectUrl;
            $http.get('api/settings/RestartGracePeriodForLoggedUser').success(function (response, status, headers, config) {
                window.location.replace(redirectUrl);
            });
        };

        function loginError(response) {
            $scope.loginUnsuccessful = true;
            $scope.loginMessage = response ? response.ReturnMessage[0] : 'Irgendwas ist schiefgegangen.';
        };

        // ----------------------------------------------------------- UTIL -----------------------------------------------------------

        function isNullOrEmpty(data) {
            return data === undefined || data === '' || data === null;
        };

        angular.element('#email')[0].focus();
    };
})();