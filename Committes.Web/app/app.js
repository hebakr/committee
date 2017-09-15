(function () {
    'use strict';

    var app = angular.module('app', [
        // Angular modules 
        'ngComponentRouter',
        'ngResource',

        // Custom modules 

        // 3rd Party Modules
        , 'ui.bootstrap',
        
    ]);

    app.value('$routerRootComponent', 'appNav');

    app.component('appHome', {
        template: '<h2>الصفحة الرئيسية</h1>'
    });


    app.directive('loading',   ['$http' ,function ($http)
    {
        return {
            restrict: 'A',
            template: '<div ng-show="showEl"><div ng-transclude></div></div>',
            transclude: true,
            replace: true,
            link: function (scope, elm, attrs)
            {
                scope.isLoading = function () {
                    return $http.pendingRequests.length > 0;
                };

                scope.$watch(scope.isLoading, function (v)
                {
                    if (v)
                        scope.showEl = true;
                    else
                        scope.showEl = false;
                });
            }
        };
    }]);


})();