(function () {
    'use strict';
    angular.module('mainModule').controller('404Controller', ['$scope', '$location','$rootScope', function ($scope, $location, $rootScope) {
        
        $scope.redirectToLogin = function () {
            window.location.replace('login.html');
        };

    }]);

})();