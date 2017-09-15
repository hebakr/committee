(function () {

    "use strict";

    var app = angular.module('app');

    var hafzaReportCtrl = function (reportsApi) {
        var vm = this;

        vm.model = {};

        vm.$onInit = function () {
            loadData({ school: 0 });
        }

        vm.loadReport = function () {
            var params = { school: 0};
            if (vm.model.selectedSchool) {
                params.school = vm.model.selectedSchool.id;
                loadData(params);

            }

        }

        var loadData = function (params) {

            reportsApi.hafzaReport(params, function (response) {
                vm.data = response.school;
                vm.sectors = response.sectors;
            });
        }

    }

    hafzaReportCtrl.$inject = ['reportsApi'];
    app.component('havzaReport', {
        templateUrl: '/app/components/reports/hafzaReport.component.html',
        controller: hafzaReportCtrl,
        controllerAs: 'vm'
    });

   
})();