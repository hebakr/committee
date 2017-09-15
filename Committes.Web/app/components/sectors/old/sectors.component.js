(function (undefined) {

    "use strict";

    var app = angular.module('app');

    var sectorsCtrl = function (committesApi, sectorsApi) {
        var vm = this;
        vm.data = [];
        var id = 10;

        vm.itemToEdit = {};
        vm.currentEdit = {};
        vm.newItem = '';

        vm.edit = function (item) {
            vm.currentEdit[item.id] = true;
            vm.itemToEdit = angular.copy(item);
        }


        vm.update = function (item) {
            item.title = vm.itemToEdit.title;
            item.$update();
            vm.currentEdit[item.id] = false;
            reload();
        }
        vm.cancelEdit = function (id) {
            vm.currentEdit[id] = false;
        }

        vm.delete = function (item) {
            item.$delete(function () {
                reload();
            });
        }

        vm.save = function () {
            var s = { title: vm.newItem };
            sectorsApi.save(s, function () {
                reload();
            });
            vm.newItem = '';

            committesApi.addSector(vm.newItem);
        }

        vm.$onInit = function () {
            reload();
        }

        var reload = function () {
            vm.data = sectorsApi.query();
        }

    }

    sectorsCtrl.$inject = ['committesApi', 'sectorsApi'];
    app.component('sectors', {
        templateUrl: '/app/components/sectors/sectors.component.html',
        controller: sectorsCtrl,
        controllerAs: 'vm'
        

    });

   
})();