(function () {
    'use strict';

    angular
        .module('app')
        .factory('jobsApi', jobs);

    jobs.$inject = ['$resource'];

    function jobs($resource) {
        return $resource('/api/jobs/:id', { id: '@id' }, {
            update: {
                method: 'PUT' // this method issues a PUT request
            }
        });
    }
})();