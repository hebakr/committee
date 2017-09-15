(function () {
    'use strict';

    angular
        .module('app')
        .factory('workPlacesApi', workPlaces);

    workPlaces.$inject = ['$resource'];

    function workPlaces($resource) {
        return $resource('/api/workPlaces/:id', { id: '@id' }, {
            update: {
                method: 'PUT' // this method issues a PUT request
            }
        });
    }
})();