(function () {

    "use strict";

    var app = angular.module('app');

    var statsReportCtrl = function (reportsApi) {
        var vm = this;

        vm.model = {};

        vm.$onInit = function () {
            loadData();
        }

        vm.loadReport = function () {
            loadData(params);
        }

        var loadData = function () {
            reportsApi.statsReport(function (response) {
                vm.data = response;
            });
        }

    }

    statsReportCtrl.$inject = ['reportsApi'];
    app.component('statsReport', {
        templateUrl: '/app/components/reports/statsReport.component.html',
        controller: statsReportCtrl,
        controllerAs: 'vm'
    });

   
})();