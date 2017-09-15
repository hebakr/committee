(function () {

    "use strict";

    var app = angular.module('app');

    // Create user component
    var modalUserComponentCtrl = function (usersApi) {
        var vm = this;
        vm.model = {};
        vm.schoolObj = {};
        vm.passwordMatch = true;

        vm.confirmPasswordChanged = function () {
            vm.passwordMatch = (vm.model.password === vm.model.confirmPassword);
        }

        vm.ok = function () {
            usersApi.save(vm.model, function () {
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

    modalUserComponentCtrl.$inject = ['usersApi'];

    app.component('modalUserComponentCtrl', {
        templateUrl: '/app/components/users/users.modal.component.html',
        bindings: {
            resolve: '<',
            close: '&',
            dismiss: '&'
        },
        controller: modalUserComponentCtrl,
        controllerAs: 'vm'
    });

})();