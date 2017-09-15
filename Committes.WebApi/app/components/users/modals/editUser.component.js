(function () {

    "use strict";

    var app = angular.module('app');

    // Edit user component
    var modalEditUserComponentCtrl = function (usersApi) {
        var vm = this;
        vm.model = {};
        vm.schoolObj = {};

        vm.ok = function () {
            if (vm.model.id)
                usersApi.update(vm.model, function () {
                    vm.close();
                });

        };

        vm.cancel = function () {
            vm.dismiss({ $value: 'cancel' });
        };

        vm.$onChanges = function () {
            vm.roles = vm.resolve.roles;

            if (vm.resolve.userToEdit) {
                vm.model = vm.resolve.userToEdit;

            }
        };
    }

    modalEditUserComponentCtrl.$inject = ['usersApi'];

    app.component('modalEditUserComponentCtrl', {
        templateUrl: '/app/components/users/edit.users.modal.component.html',
        bindings: {
            resolve: '<',
            close: '&',
            dismiss: '&'
        },
        controller: modalEditUserComponentCtrl,
        controllerAs: 'vm'
    });

})();