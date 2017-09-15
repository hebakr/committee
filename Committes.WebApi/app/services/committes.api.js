(function () {
    'use strict';

    angular
        .module('app')
        .factory('committesApi2', committes);

    committes.$inject = ['$resource'];

    function committes($resource) {
        return $resource('/api/Committees/:id', { id: '@id' }, {
            saveCommittee: {
                method: 'Post',
                url: '/api/Committees/SaveCommittee'
            },
            GetLatest: {
                method: 'Get',
                url: '/api/Committees/GetLatest',
                isArray: true

            },
            saveCommitteeMembers: {
                method: 'Post',
                url: '/api/Committees/saveCommitteeMembers'
            },

            getViewModel: {
                method: 'Post',
                url: '/api/Committees/LoadViewModel?id=:id'
            },
            getCommittee: {
                method: 'get',
                url: '/api/Committees/getCommittee?id=:id'
            },
            findCommittee: {
                method: 'get',
                url: '/api/Committees/findCommittee?code=:code'
            },
            findCommittees: {
                method: 'post',
                url: '/api/Committees/findCommittees'
            },
            saveInspector: {
                method: 'Post',
                url: '/api/Committees/SaveInspector',
                isArray: true
            },
            saveAssistance: {
                method: 'Post',
                url: '/api/Committees/SaveAssistance',
                isArray: true
            },
            saveLab: {
                method: 'Post',
                url: '/api/Committees/saveLab',
                isArray: true
            },
            removeLab: {
                method: 'get',
                url: '/api/Committees/removeLab'
            },
            saveDivision: {
                method: 'Post',
                url: '/api/Committees/saveDivision',
                isArray: true
            },
            removeDivision: {
                method: 'get',
                url: '/api/Committees/removeDivision'
            },
            saveExaminor: {
                method: 'Post',
                url: '/api/Committees/SaveExaminor',
                isArray: true
            },
            saveObserver: {
                method: 'Post',
                url: '/api/Committees/SaveObserver',
                isArray: true
            },
            validateNumber: {
                method: 'get',
                url: '/api/Committees/ValidateNumber',

            },
            getAppSettings: {
                method: 'get',
                url: '/api/Committees/AppSettings',

            },
            saveAppSettings: {
                method: 'post',
                url: '/api/Committees/AppSettings',

            },
            reOrderCommitteesNumbers: {
                method: 'post',
                url: '/api/Committees/reOrderCommitteesNumbers',

            },
            deleteCommittee: {
                method: 'post',
                url: '/api/Committees/DeleteCommittee',
            }

    });
    }
})();