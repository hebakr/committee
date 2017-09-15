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
        vm.currentSchoolEdit = {};
        vm.schoolToEdit = {};

        vm.data = [];

        vm.addSector = function () {
            sectorsApi.save({ title: vm.newSector }, function (s) {
                vm.data.push(s);
                vm.newSector = '';
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
                if (!sector.governrates)
                    sector.governrates = [];
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
            if (confirm('برجاء تأكيد الحذف؟'))
                sectorsApi.deleteGov({ id: gov.id }, function () {
                sector.governrates = _.filter(sector.governrates, function (o) { return o.id !== gov.id; });
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
            if (confirm('برجاء تأكيد الحذف؟'))
                sectorsApi.deleteLM({ id: lm.id }, function () {
                    gov.learningManagements = _.filter(gov.learningManagements, function (o) { return o.id !== lm.id; });
                });
        }

        vm.addSchool = function (lm) {

            sectorsApi.saveSchool({ title: lm.newSchool, learningManagementId: lm.id }, function (school) {
                if (!lm.schools)
                    lm.schools = [];

                lm.schools.push(school);
                lm.newSchool = '';
            });

        }

        vm.editSchool = function (item) {
            vm.currentSchoolEdit[item.id] = true;
            vm.schoolToEdit = angular.copy(item);
        }

        vm.cancelSchoolEdit = function (id) {
            vm.currentSchoolEdit[id] = false;
        }

        vm.updateSchool = function (school) {
            school.title = vm.schoolToEdit.title;
            sectorsApi.updateSchool(school, function () {
                vm.currentSchoolEdit[school.id] = false;
                vm.schoolToEdit = {};
            });
        }

        vm.deleteSchool = function (school, lm) {
            if (confirm('برجاء تأكيد الحذف؟'))
                sectorsApi.deleteSchool({ id: school.id }, function () {
                    lm.schools = _.filter(lm.schools, function (o) { return o.id !== school.id; });
                });
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