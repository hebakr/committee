(function () {

    "use strict";

    angular
        .module('app')
        .factory('progress', progress);

    progress.$inject = ['$scope', 'ngProgressFactory'];

    function progress($scope, ngProgressFactory) {
        var service = {
            start: start,
            stop: stop
        };

        return service;

        var start = function () {
            $scope.progressbar = ngProgressFactory.createInstance();
            $scope.progressbar.start();
        }

        var stop = function () {
            $scope.progressbar.complete();
        }

    }

})();