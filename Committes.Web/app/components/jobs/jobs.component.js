(function () {

    "use strict";

    var app = angular.module('app');

    var jobsCtrl = function (jobsApi) {
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
            jobsApi.save(s, function () {
                reload();
            });
            vm.newItem = '';

        }

        vm.$onInit = function () {
            reload();
        }

        var reload = function () {
            vm.data = jobsApi.query();
        }

    }

    jobsCtrl.$inject = ['jobsApi'];
    app.component('jobs', {
        templateUrl: '/app/components/jobs/jobs.component.html',
        controller: jobsCtrl,
        controllerAs: 'vm'
        

    });

   
})();