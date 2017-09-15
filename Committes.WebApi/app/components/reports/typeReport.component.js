(function () {

    "use strict";

    var app = angular.module('app');

    var typeReportCtrl = function (reportsApi) {
        var vm = this;

        vm.model = {};

        vm.$onInit = function () {
            loadSectors();
        }

        vm.loadReport = function () {
            var params = { sector: 0, governrate: 0, lm: 0 };
            if (vm.selectedSector)
                params.sector = vm.selectedSector.id;

            if (vm.selectedGov)
                params.governrate = vm.selectedGov.id;

            if (vm.selectedGov)
                params.governrate = vm.selectedGov.id;

            if (vm.model.selectedLM) {
                params.lm = vm.model.selectedLM.id;
            }

            loadData(params);

        }

        var loadData = function (params) {
            reportsApi.typeReport(params, function (response) {
                vm.data = response;
            });
        }

        var loadSectors = function () {
            reportsApi.sectors(function (response) {
                vm.sectors = response;
            });
        }
    }

    typeReportCtrl.$inject = ['reportsApi'];
    app.component('typeReport', {
        templateUrl: '/app/components/reports/typeReport.component.html',
        controller: typeReportCtrl,
        controllerAs: 'vm'
    });

})();