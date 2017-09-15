(function () {
    'use strict';
     
    var app = angular.module('app', [
        // Angular modules 
        'ngComponentRouter',
        'ngResource'

        // Custom modules 

        // 3rd Party Modules
        , 'ui.bootstrap'
        
    ]);

    app.value('$routerRootComponent', 'appNav');

    app.directive('loading', ['$http', function ($http) {
        return {
            restrict: 'A',
            template: '<div ng-show="showEl"><div ng-transclude></div></div>',
            transclude: true,
            replace: true,
            link: function (scope, elm, attrs) {
                scope.isLoading = function () {
                    return $http.pendingRequests.length > 0;
                };

                scope.$watch(scope.isLoading, function (v) {
                    if (v)
                        scope.showEl = true;
                    else
                        scope.showEl = false;
                });
            }
        };
    }]);

    app.config([
        '$httpProvider', function($httpProvider) {
            $httpProvider.interceptors.push([
                '$q', '$location', '$window', function($q, $location, $window) {
                    return {
                        'request': function(config) {
                            //console.log('request intercept');
                            config.headers = config.headers || {};
                            config.headers.Authorization = 'X-Basic'
                            if ($window.localStorage.token) {
                                config.headers.Authorization = 'Bearer ' + $window.localStorage.token;
                            }
                            return config;
                        },
                        'responseError': function(response) {
                            if (response.status === 401 || response.status === 403) {
                                //config.headers.Authorization = 'x-Basic';
                                delete $window.localStorage.token;
                                $location.path('/login');
                            }
                            return $q.reject(response);
                        }
                    };
                }
            ]);
        }
    ]);

})();

