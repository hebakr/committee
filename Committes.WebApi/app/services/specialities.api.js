(function () {
    'use strict';

    angular
        .module('app')
        .factory('specialitiesApi', specialities);

    specialities.$inject = ['$resource'];

    function specialities($resource) {
        return $resource('/api/specialities/:id', { id: '@id' }, {
            update: {
                method: 'PUT' // this method issues a PUT request
            }
        });
    }
})();