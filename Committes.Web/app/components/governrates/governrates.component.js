(function (undefined) {

    "use strict";

    var app = angular.module('app');

    var governratesCtrl = function (committesApi) {
        var vm = this;

        vm.data = [];
        vm.sectors = [];
        var id = 10;

        vm.itemToEdit = {};
        vm.currentEdit = {};
        vm.newItem = '';

        vm.edit = function (item) {
            vm.currentEdit[item.id] = true;
            vm.itemToEdit = angular.copy(item);
        }

        vm.update = function (item) {
            item.name = vm.itemToEdit.name;
            vm.currentEdit[item.id] = false;
        }


        vm.cancelEdit = function (id) {
            vm.currentEdit[id] = false;
        }

        vm.delete = function (item) {
            _.remove(vm.data, { 'id': item.id });
        }

        vm.save = function () {
            vm.data.push({ id: id++, name: vm.newItem });
            vm.newItem = '';

            //committesApi.addSector(vm.newItem);
        }

        vm.$onInit = function () {
            vm.data = committesApi.getGovernrates();
            //vm.sectors = committesApi.getSectors();
        }

    }

    governratesCtrl.$inject = ['committesApi'];

    app.component('governrates', {
        templateUrl: '/app/components/governrates/governrates.component.html',
        controller: governratesCtrl,
        controllerAs: 'vm'
    });

})();