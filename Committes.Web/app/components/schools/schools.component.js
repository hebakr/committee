(function () {

    "use strict";

    var app = angular.module('app');

    var schoolsCtrl = function (schoolsApi, $uibModal) {
        var vm = this;
        vm.data = [];
        vm.sectors = [];
        vm.search = false;


        vm.model = {};

        vm.$onInit = function () {
            reload();
        }

        var reload = function () {
            schoolsApi.query(function (response) {
                vm.data = response.data;
                vm.sectors = response.sectors;
            });
        }

        vm.search = function () {
            var sector = (vm.model.selectedSector) ? vm.model.selectedSector : 0;
            var governrate = (vm.model.selectedGov) ? vm.model.selectedGov : 0;

            schoolsApi.findSchools(
                {
                    sector: sector,
                    governrate: governrate,
                    number: vm.model.committeeNumber
                }, function (response) {
                    vm.data = response;
                    vm.search = true;
                });
        }

        vm.openDialog = function () {
            var modalInstance = $uibModal.open({
                animation: true,
                backdrop: 'static',
                component: 'modalComponent',
                resolve: {
                    sectors: function () {
                        return vm.sectors;
                    }
                }
            });

            modalInstance.result.then(function () {
                reload();
            }, function () {
                
            });
        }

        vm.openDialogForEdit = function (school) {
            var modalInstance = $uibModal.open({
                animation: true,
                backdrop: 'static',
                component: 'modalComponent',
                resolve: {
                    sectors: function () {
                        return vm.sectors;
                    },
                    schoolToEdit: function () {
                        return angular.copy(school);
                    }
                }
            });

            modalInstance.result.then(function () {
                reload();
            }, function () {

            });
        }

    }

    schoolsCtrl.$inject = ['schoolsApi', '$uibModal'];

    app.component('schools', {
        templateUrl: '/app/components/schools/schools.component.html',
        controller: schoolsCtrl,
        controllerAs: 'vm'
    });

    var modalComponentCtrl = function (schoolsApi) {
        var vm = this;
        vm.model = {};
        vm.schoolObj = {};

        vm.ok = function () {
            vm.schoolObj = {
                id: vm.model.id,
                name: vm.model.name,
                phone: vm.model.phone,
                number: vm.model.number,
                address: vm.model.address,
                learningManagementId: vm.model.selectedLM.id
            };

            schoolsApi.save(vm.schoolObj, function () {
                vm.close();
            });

        };

        vm.cancel = function () {
            vm.dismiss({ $value: 'cancel' });
        };

        vm.$onChanges = function () {
            if (vm.resolve.schoolToEdit) {
                vm.model = vm.resolve.schoolToEdit;
                vm.model.selectedLM = vm.resolve.schoolToEdit.learningManagement;
                vm.model.selectedGov = vm.resolve.schoolToEdit.learningManagement.governrate;
                vm.model.selectedSector = vm.resolve.schoolToEdit.learningManagement.governrate.sector;

            }
        };
    }

    modalComponentCtrl.$inject = ['schoolsApi'];

    app.component('modalComponent', {
        templateUrl: '/app/components/schools/schools.modal.component.html',
        bindings: {
            resolve: '<',
            close: '&',
            dismiss: '&'
        },

        controller: modalComponentCtrl,
        controllerAs: 'vm'
    })

   
})();