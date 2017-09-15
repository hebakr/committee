(function () {
    'use strict';

    angular
        .module('app')
        .factory('rolesApi', roles);

    roles.$inject = ['$resource'];

    function roles($resource) {
        return $resource('/api/roles/:id', { id: '@id' }, {
            update: {
                method: 'PUT' // this method issues a PUT request
            }
        });
    }
})();