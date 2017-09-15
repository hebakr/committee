(function () {
    'use strict';


    function committesApi($resource) {
        var service = {
            sectors: getSectors,
            addSector: addSector,
            getGovernrates: getGovernrates
        };

        return service;

        function getSectors($resource) {
            return $resource('/api/Sectors/:id', { id: '@Id' }, {
                update: {
                    method: 'PUT' // this method issues a PUT request
                }
            });
        }

        function getGovernrates() {
            return [
                { id: 1, name: 'القاهرة', sectorId: 2, sectorName: 'الوجه البحرى' },
                { id: 2, name: 'الإسكندرية', sectorId: 4, sectorName: 'الواحات' },
                { id: 3, name: 'المنيا', sectorId: 1, sectorName: 'الوجه القبلى' },
                { id: 4, name: 'المنصورة', sectorId: 3, sectorName: 'قطاع القناة' },
            ];
        }

        function addSector(name) {
            //TODO: implement this
        }
    }


    angular
        .module('app')
        .factory('committesApi', committesApi);

    committesApi.$inject = ['$resource'];

})();