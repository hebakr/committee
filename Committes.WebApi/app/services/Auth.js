(function () {
    'use strict';
    angular
        .module('app')
        .factory('Auth', Auth);

    Auth.$inject = ['$http', '$window'];

    function Auth($http, $window) {
        function urlBase64Decode(str) {
            var output = str.replace('-', '+').replace('_', '/');
            switch (output.length % 4) {
                case 0:
                    break;
                case 2:
                    output += '==';
                    break;
                case 3:
                    output += '=';
                    break;
                default:
                    throw 'Illegal base64url string!';
            }
            return window.atob(output);
        }


        return {
            login: function (data, success, error) {
                $http.defaults.headers.post['Content-Type'] = 'application/x-www-form-urlencoded';
                $http.post('/token', data).success(success).error(error)
            },
            logout: function (success) {
                delete $window.localStorage.token;
                success();
            }
        };

    }
})();