(function () {
    'use strict';

    angular
        .module('app')
        .factory('usersApi', roles);

    roles.$inject = ['$resource'];

    function roles($resource) {
        return $resource('/api/users/:id', { id: '@id' }, {
            update: {
                method: 'PUT', // this method issues a PUT request
                url: '/api/users/put'

            },
            save: {
                method: 'POST', // this method issues a PUT request
                url: '/api/users/post'
            },
            query: {
                isArray: false
            },
            deleteUser: {
                method: 'delete',
                url: '/api/users/delete'
            },
            resetPass: {
                method: 'post',
                url: '/api/users/ResetPassword'

            }

        });
    }
})();