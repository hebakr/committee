(function () {
    'use strict';

    angular
        .module('app')
        .factory('sectorsApi', sectors);

    sectors.$inject = ['$resource'];

    function sectors($resource) {
        return $resource('/api/Sectors/:id', { id: '@id' }, {
            'delete': {
                method: 'DELETE', // this method issues a PUT request,
                url: '/api/sectors/delete/:id'
            },
            update: {
                method: 'PUT', // this method issues a PUT request,
                url: '/api/sectors/put'
            },
            save: {
                method: 'POST', // this method issues a PUT request,
                url: '/api/sectors/post'
            },
            saveGov: {
                method: 'Post',
                url: '/api/sectors/AddGovernrate'
            },
            updateGov: {
                method: 'Post',
                url: '/api/sectors/UpdateGovernrate'
            },
            deleteGov: {
                method: 'Delete',
                url: '/api/sectors/DeleteGovernrate/:id'
            },
            saveLM: {
                method: 'Post',
                url: '/api/sectors/AddLM'
            },
            updateLM: {
                method: 'Post',
                url: '/api/sectors/UpdateLM'
            },
            deleteLM: {
                method: 'Delete',
                url: '/api/sectors/DeleteLM/:id'
            }


        });
    }
})();