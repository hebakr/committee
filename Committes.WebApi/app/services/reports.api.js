(function () {
    'use strict';

    angular
        .module('app')
        .factory('reportsApi', jobs);

    jobs.$inject = ['$resource'];

    function jobs($resource) {
        return $resource('/api/reports/:id', { id: '@id' }, {
            locationsReport: {
                method: 'Get',
                url: '/api/reports/locationsReport'
            },
            hafzaReport: {
                method: 'Get',
                url: '/api/reports/hafzaReport'
            },
            statsReport: {
                method: 'Get',
                url: '/api/reports/StatsReport',
                isArray: true
            },
            deliveryReport: {
                method: 'Get',
                url: '/api/reports/deliveryReport',
                isArray: true
            },
            deliveryByDateReport: {
                method: 'Get',
                url: '/api/reports/deliveryByDateReport',
                isArray: true
            },
            typeReport: {
                method: 'Get',
                url: '/api/reports/typeReport',
                isArray: true
            },
            sectors: {
                method: 'Get',
                url: '/api/reports/GetSectors',
                isArray: true
            }

            

        });
    }
})();