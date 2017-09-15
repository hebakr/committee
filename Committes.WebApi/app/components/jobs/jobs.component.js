(function () {

    "use strict";

    var app = angular.module('app');

    var jobsCtrl = function (jobsApi) {
        var vm = this;
        vm.data = [];

        vm.itemToEdit = {};
        vm.currentEdit = {};
        vm.newItem = '';

        var reload = function () {
            jobsApi.query(function (response) {
                vm.data = response;
            });
        };

        vm.edit = function (item) {
            vm.currentEdit[item.id] = true;
            vm.itemToEdit = angular.copy(item);
        };

        vm.update = function(item) {
            item.title = vm.itemToEdit.title;
            item.$update(function() {
                vm.currentEdit[item.id] = false;
                reload();
            });

        };

        vm.cancelEdit = function(id) {
            vm.currentEdit[id] = false;
        };

        vm.delete = function(item) {
            if (confirm('برجاء تأكيد الحذف؟'))
                item.$delete(function() {
                    reload();
                });
        };

        vm.save = function() {
            var s = { title: vm.newItem };
            jobsApi.save(s,
                function() {
                    reload();
                });
            vm.newItem = '';

        };

        vm.$onInit = function() {
            reload();
        };

    }

    jobsCtrl.$inject = ['jobsApi'];
    app.component('jobs', {
        templateUrl: '/app/components/jobs/jobs.component.html',
        controller: jobsCtrl,
        controllerAs: 'vm'
        

    });
   
})();