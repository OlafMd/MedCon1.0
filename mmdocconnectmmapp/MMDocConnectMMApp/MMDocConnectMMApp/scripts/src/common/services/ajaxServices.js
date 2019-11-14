'use strict';
define(['angularAMD', 'blockUI'], function (angularAMD) {
    angularAMD.service('ajaxService', ['$http', 'blockUI', function ($http, blockUI) {

        this.AjaxPost = function (data, route, successFunction, errorFunction) {
            blockUI.start();
            $http.post(route, data).success(function (response, status, headers, config) {
                blockUI.stop();
                successFunction(response, status);
            }).error(function (response, status) {
                blockUI.stop();
                if (status == 401) {
                    window.location.replace('login.html');
                } else {
                    errorFunction(response);
                }
            });
        };

        this.AjaxGet = function (route, successFunction, errorFunction) {
            blockUI.start();
            $http({ method: 'GET', url: route }).success(function (response, status, headers, config) {
                blockUI.stop();
                successFunction(response, status);
            }).error(function (response, status) {
                blockUI.stop();
                if (status == 401) {
                    window.location.replace('login.html');
                } else {
                    errorFunction(response);
                }
            });

        };

        this.AjaxGetWithData = function (data, route, successFunction, errorFunction) {
            blockUI.start();
            $http({ method: 'GET', url: route, params: data }).success(function (response, status, headers, config) {
                blockUI.stop();
                successFunction(response, status);
            }).error(function (response, status) {
                blockUI.stop();
                if (status == 401) {
                    window.location.replace('login.html');
                } else {
                    errorFunction(response);
                }
            });
        };
    }]);
});