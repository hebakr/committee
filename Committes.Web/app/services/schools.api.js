(function () {
    'use strict';

    angular
        .module('app')
        .factory('schoolsApi', schools);

    schools.$inject = ['$resource'];

    function schools($resource) {
        return $resource('/api/schools/:id', { id: '@id' }, {
            update: {
                method: 'PUT' // this method issues a PUT request
            },
            query: {
                method: 'get',
                isArray: false
            },
            findSchools: {
                method: 'post',
                url: '/api/schools/findSchools',
                isArray: true
            },
            save: {
                method: 'post',
                url: '/api/schools/post'
        }

        });
    }
})();