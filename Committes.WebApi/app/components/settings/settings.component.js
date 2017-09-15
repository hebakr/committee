(function () {

    "use strict";

    var app = angular.module('app');

    var settingsCtrl = function (committesApi2) {
        var vm = this;

        vm.save = function () {
            committesApi2.saveAppSettings(vm.data, function () {
                vm.dataSaved = true;
            });
        }

        vm.reorder = function () {
            if (confirm('سوف يتم إعادة ترقيم جميع اللجان المسجلة ، برجاء التأكيد؟'))
                committesApi2.reOrderCommitteesNumbers(vm.data, function () {
                    vm.dataReordered = true;
                });
        }

        vm.$onInit = function () {
            committesApi2.getAppSettings(function (response) {
                vm.data = response;
            });
        }

    }

    settingsCtrl.$inject = ['committesApi2'];
    app.component('settings', {
        templateUrl: '/app/components/settings/settings.component.html',
        controller: settingsCtrl,
        controllerAs: 'vm'
    });

   
})();