(function () {

    "use strict";

    var app = angular.module('app');

    var locationsReportCtrl = function (reportsApi) {
        var vm = this;

        vm.model = {};

        vm.$onInit = function () {
            loadData({ governrate: 0, sector: 0 });
        }

        vm.loadReport = function () {
            var params = { governrate: 0, sector: 0 };
            if (vm.model.selectedGov)
                params.governrate = vm.model.selectedGov.id;

            if (vm.model.selectedSector)
                params.sector = vm.model.selectedSector.id;

            loadData(params);
        }

        var loadData = function (params) {
            reportsApi.locationsReport(params, function (response) {
                vm.data = response.committees;
                vm.sectors = response.sectors;
            });
        }

    }

    locationsReportCtrl.$inject = ['reportsApi'];
    app.component('locationsReport', {
        templateUrl: '/app/components/reports/locationsReport.component.html',
        controller: locationsReportCtrl,
        controllerAs: 'vm'
    });

   
})();