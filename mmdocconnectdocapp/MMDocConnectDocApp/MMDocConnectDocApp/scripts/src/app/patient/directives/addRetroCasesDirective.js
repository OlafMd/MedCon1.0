(function () {
    'use strict';

    angular.module('mainModule').directive('addRetroCasesDirective', ['ngDialog', 'documentationOnlyService', function (ngDialog, documentationOnlyService) {

        return {
            restrict: 'A',
            link: addRetroCasesController
        };

        function addRetroCasesController($scope, element, attrs) {
            element.on('click', function () {
                documentationOnlyService.openWizard({ name: attrs.addRetroCasesPatientName }, $scope);
            });
        }
    }]);
})();
