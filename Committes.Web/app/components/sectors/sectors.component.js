(function () {

    "use strict";

    var app = angular.module('app');

    var sectorsCtrl = function (sectorsApi) {
        var vm = this;

        vm.newSector = '';
        vm.newGov = '';
        vm.newLM = '';
        vm.itemToEdit = {};
        vm.currentEdit = {};
        vm.currentGovEdit = {};
        vm.govToEdit = {};
        vm.currentLMEdit = {};
        vm.lmToEdit = {};

        vm.data = [];

        vm.addSector = function () {
            sectorsApi.save({ title: vm.newSector }, function (s) {
                vm.data.push(s);
                vm.newSector = '';
            });
        }

        vm.delete = function (item) {
            item.$delete(function () {
                reload();
            });
        }

        vm.edit = function (item) {
            vm.currentEdit[item.id] = true;
            vm.itemToEdit = angular.copy(item);
        }

        vm.cancelEdit = function (id) {
            vm.currentEdit[id] = false;
        }

        vm.update = function (item) {
            item.title = vm.itemToEdit.title;
            item.$update(function () {
                reload();
                vm.currentEdit[item.id] = false;
                vm.itemToEdit = {};

            });
        }

        vm.addGovernrate = function (sector) {
            sectorsApi.saveGov({ title: sector.newGov, sectorId: sector.id }, function (g) {
                sector.governrates.push(g);
                sector.newGov = '';
            });
        }

        vm.editGov = function (item) {
            vm.currentGovEdit[item.id] = true;
            vm.govToEdit = angular.copy(item);
        }

        vm.cancelGovEdit = function (id) {
            vm.currentGovEdit[id] = false;
        }

        vm.updateGov = function (gov) {
            gov.title = vm.govToEdit.title;
            sectorsApi.updateGov(gov, function () {
                vm.currentGovEdit[gov.id] = false;
                vm.govToEdit = {};
            });
        }

        vm.deleteGov = function (gov, sector) {
            sectorsApi.deleteGov({ id: gov.id }, function () {
                sector.governrates = _.filter(sector.governrates, function (o) { return o.id != gov.id; });
            })
        }

        vm.addLM = function (gov) {

            sectorsApi.saveLM({ title: gov.newLM, governrateId: gov.id }, function (lm) {
                if (!gov.learningManagements)
                    gov.learningManagements = [];

                gov.learningManagements.push(lm);
                gov.newLM = '';
            });

        }

        vm.editLM = function (item) {
            vm.currentLMEdit[item.id] = true;
            vm.lmToEdit = angular.copy(item);
        }

        vm.cancelLMEdit = function (id) {
            vm.currentLMEdit[id] = false;
        }

        vm.updateLM = function (lm) {
            lm.title = vm.lmToEdit.title;
            sectorsApi.updateLM(lm, function () {
                vm.currentLMEdit[lm.id] = false;
                vm.lmToEdit = {};
            });
        }

        vm.deleteLM = function (lm, gov) {
            sectorsApi.deleteLM({ id: lm.id }, function () {
                gov.learningManagements = _.filter(gov.learningManagements, function (o) { return o.id != lm.id; });
            })
        }


        vm.$onInit = function () {
            reload();
        }

        var reload = function () {
            vm.data = sectorsApi.query();
        }

    }


    sectorsCtrl.$inject = ['sectorsApi'];
    app.component('sectors', {
        templateUrl: '/app/components/sectors/sectors.component.html',
        controller: sectorsCtrl,
        controllerAs: 'vm'
        

    });

   
})();