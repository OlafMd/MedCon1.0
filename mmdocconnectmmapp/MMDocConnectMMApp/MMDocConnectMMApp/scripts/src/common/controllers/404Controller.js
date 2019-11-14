"use strict";
define(['angularAMD'], function (angularAMD) {
    angularAMD.controller('404Controller', ['$scope', '$location', function ($scope, $location) {

        $scope.redirectToDefaultPage = function () {       
            $location.url('/dashboard');
        };

    }]);

});