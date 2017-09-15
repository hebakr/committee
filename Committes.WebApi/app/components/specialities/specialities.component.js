(function () {

    "use strict";

    var app = angular.module('app');

    var specialitiesCtrl = function (specialitiesApi) {
        var vm = this;
        vm.data = [];
        var id = 0;

        vm.itemToEdit = {};
        vm.currentEdit = {};
        vm.newItem = '';

        vm.$onInit = function () {
            reload();
        }

        var reload = function () {
            specialitiesApi.query(function (response) {
                vm.data = response;
            });
        }

        vm.delete = function (item) {
            if (confirm('برجاء تأكيد الحذف؟'))
                item.$delete(function () {
                    reload();
                });
        }

        vm.edit = function (item) {
            vm.currentEdit[item.id] = true;
            vm.itemToEdit = angular.copy(item);
        }


        vm.update = function (item) {
            item.name = vm.itemToEdit.name;
            item.$update(function () {
                vm.currentEdit[item.id] = false;
                reload();
            });
        }

        vm.cancelEdit = function (id) {
            vm.currentEdit[id] = false;
        }

        vm.save = function () {
            var s = { name: vm.newItem };
            specialitiesApi.save(s, function () {
                reload();
            });
            vm.newItem = '';

        }

    }

    specialitiesCtrl.$inject = ['specialitiesApi'];
    app.component('specialities', {
        templateUrl: '/app/components/specialities/specialities.component.html',
        controller: specialitiesCtrl,
        controllerAs: 'vm'
        

    });

   
})();