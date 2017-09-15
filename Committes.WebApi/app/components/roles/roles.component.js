(function () {

    "use strict";

    var app = angular.module('app');

    var rolesCtrl = function (rolesApi) {
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
            item.$update(function () {
                vm.currentEdit[item.id] = false;
                reload();
            });
        }

        vm.cancelEdit = function (id) {
            vm.currentEdit[id] = false;
        }

        vm.delete = function (item) {
            if (confirm('برجاء تأكيد الحذف؟'))
                item.$delete(function () {
                    reload();
                });
        }

        vm.save = function () {
            var s = { title: vm.newItem };
            rolesApi.save(s, function () {
                reload();
            });
            vm.newItem = '';

        }

        vm.$onInit = function () {
            reload();
        }

        var reload = function () {
            rolesApi.query(function (response) {
                vm.data = response;
            });
        }

    }

    rolesCtrl.$inject = ['rolesApi'];
    app.component('roles', {
        templateUrl: '/app/components/roles/roles.component.html',
        controller: rolesCtrl,
        controllerAs: 'vm'
    });

   
})();