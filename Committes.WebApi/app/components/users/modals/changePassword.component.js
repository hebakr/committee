(function () {

    "use strict";

    var app = angular.module('app');

    // Change password  component
    var modalChangePasswordComponentCtrl = function (usersApi) {
        var vm = this;
        vm.model = {};
        vm.schoolObj = {};
        vm.passwordMatch = true;

        vm.ok = function () {

            usersApi.resetPass({ id: vm.model.id, userName: vm.model.userName, password: vm.model.password, confirmPassword: vm.model.confirmPassword }, function () {
                vm.close();

            });
        };

        vm.cancel = function () {
            vm.dismiss({ $value: 'cancel' });
        };

        vm.confirmPasswordChanged = function () {
            vm.passwordMatch = (vm.model.password === vm.model.confirmPassword);
        }

        vm.$onChanges = function () {
            if (vm.resolve.userToEdit) {
                vm.model = vm.resolve.userToEdit;

            }
        };
    }

    modalChangePasswordComponentCtrl.$inject = ['usersApi'];

    app.component('modalChangePasswordComponentCtrl', {
        templateUrl: '/app/components/users/changePassword.modal.component.html',
        bindings: {
            resolve: '<',
            close: '&',
            dismiss: '&'
        },
        controller: modalChangePasswordComponentCtrl,
        controllerAs: 'vm'
    });

})();