(function () {
    "use strict";

    var app = angular.module('app');

    var usersCtrl = function (usersApi, $uibModal) {
        var vm = this;
        vm.data = [];

        vm.itemToEdit = {};

        vm.delete = function (item) {
            usersApi.deleteUser({ id: item.id }, function () {
                reload();
            })
        }

        vm.save = function () {
            var s = { title: vm.newItem };
            usersApi.save(s, function () {
                reload();
            });
            vm.newItem = '';

        }

        vm.$onInit = function () {
            reload();
        }

        var reload = function () {
            usersApi.query(function (response) {
                vm.data = response.users;
            });
        }

        vm.openDialogForCreate = function () {
            var modalInstance = $uibModal.open({
                animation: true,
                backdrop: 'static',
                component: 'modalUserComponentCtrl'

            });

            modalInstance.result.then(function () {
                reload();
            }, function () {

            });
        }

        vm.openDialogForEdit = function (user) {
            var modalInstance = $uibModal.open({
                animation: true,
                backdrop: 'static',
                component: 'modalEditUserComponentCtrl',
                resolve: {
                    userToEdit: function () {
                        return angular.copy(user);
                    }
                }
            });

            modalInstance.result.then(function () {
                reload();
            }, function () {

            });
        }

        vm.openDialogForChangePassword = function (user) {
            var modalInstance = $uibModal.open({
                animation: true,
                backdrop: 'static',
                component: 'modalChangePasswordComponentCtrl',
                resolve: {
                    userToEdit: function () {
                        return angular.copy(user);
                    },
                }
            });

            modalInstance.result.then(function () {
                reload();
            }, function () {

            });
        }
    }

    usersCtrl.$inject = ['usersApi', '$uibModal'];
    app.component('users', {
        templateUrl: '/app/components/users/users.component.html',
        controller: usersCtrl,
        controllerAs: 'vm'
    });

})();