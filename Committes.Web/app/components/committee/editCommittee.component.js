(function () {

    "use strict";

    var app = angular.module('app');

    var editCommitteeCtrl = function (committesApi2) {
        var vm = this;

        vm.model = {
            labEditor: {
                studentType: 'منتظم'
            }
        };

        vm.$routerOnActivate = function (next, previous) {
            var id = next.params.id;
            committesApi2.getViewModel({ id: id }, function (response) {
                vm.model = response;
            });

        }

        vm.updateCommitteType = function () {
            var s = _.filter(vm.model.committeeTypes, function (o) { return o.selected });
            var m = _.map(s, 'name');
            vm.model.committee.committeType = _.join(m, '+');
        }
        vm.updateLearningType = function () {
            var s = _.filter(vm.model.learningTypes, function (o) { return o.selected });
            var m = _.map(s, 'name');
            vm.model.committee.learningType = _.join(m, '+');
        }

        vm.submit = function () {
            vm.model.committee.learningManagementId = vm.model.selectedLM.id;

            committesApi2.saveCommittee(vm.model.committee, function (response) {
                alert('تم الحفظ');
            });
        }

        vm.checkNumber = function () {
            if (!vm.numberChanged || !vm.model.committee.number) return;

            vm.validating = true;
            committesApi2.validateNumber({ number: vm.model.committee.number, id: vm.model.committee.id }, function (response) {
                if (response.isValid)
                    vm.numberValid = 2;
                else
                    vm.numberValid = 1;

                vm.validating = false;

            });
        }

        vm.saveInspector = function () {
            committesApi2.saveInspector(
                {
                    committeeId: vm.model.committee.id,
                    member: vm.model.inspectorEditor
                }, function (response) {
                    vm.model.committee.inspectors = response;
                    console.log(response);
                    vm.model.inspectorEditor.name = '';
                    vm.model.inspectorEditor.startDate = '';
                    vm.model.inspectorEditor.endDate = '';
                    vm.model.inspectorEditor.evaluationDate = '';
                    vm.model.inspectorEditor = {};
            });
        }

        vm.editAssistance = function (item) {
            vm.model.assistanceEditor = angular.copy(item);
        }

        vm.editInspector = function (item) {
            vm.model.inspectorEditor = angular.copy(item);
        }

        vm.editExaminor = function (item) {
            vm.model.examinorEditor = angular.copy(item);
        }
        vm.saveAssistance = function () {
            committesApi2.saveAssistance(
                {
                    committeeId: vm.model.committee.id,
                    member: vm.model.assistanceEditor
                }, function (response) {
                    vm.model.committee.assistances = response;
                    vm.model.assistanceEditor.name = '';
                    vm.model.assistanceEditor.startDate = '';
                    vm.model.assistanceEditor.endDate = '';
                    vm.model.assistanceEditor.evaluationDate = '';
                    vm.model.assistanceEditor = {};
                });
        }

        vm.saveExaminor = function () {
            committesApi2.saveExaminor(
                {
                    committeeId: vm.model.committee.id,
                    member: vm.model.examinorEditor
                }, function (response) {
                    vm.model.committee.examinors = response;
                    vm.model.examinorEditor.name = '';
                    vm.model.examinorEditor.startDate = '';
                    vm.model.examinorEditor.endDate = '';
                    vm.model.examinorEditor.evaluationDate = '';
                    vm.model.examinorEditor = {};
                });

        };

        vm.saveLab = function () {
            committesApi2.saveLab(
                {
                    committeeId: vm.model.committee.id,
                    title: vm.model.labEditor.name,
                    studentCount: vm.model.labEditor.studentCount,
                    studentType: vm.model.labEditor.studentType,
                    examDate: vm.model.labEditor.examDate,
                    evalDate: vm.model.labEditor.evalDate
                }, function (response) {
                    vm.model.committee.labs = response;
                    vm.model.labEditor.name = '';
                    vm.model.labEditor.studentCount = '';
                    vm.model.labEditor.studentType = 'منتظم';
                    vm.model.labEditor.examDate = '';
                    vm.model.labEditor.evalDate = '';
                });
        };

        vm.removeLab = function (item) {
            committesApi2.removeLab({ labId: item.id, committeeId: vm.model.committee.id }, function () {
                _.remove(vm.model.committee.labs, function (n) {
                    return n.id === item.id;
                });
            });
        }

        vm.saveDivision = function () {
            committesApi2.saveDivision(
                {
                    committeeId: vm.model.committee.id,
                    title: vm.model.divisionEditor.name,
                    studentCount: vm.model.divisionEditor.studentCount
                }, function (response) {
                    vm.model.committee.divisions = response;
                    vm.model.divisionEditor.name = '';
                    vm.model.divisionEditor.studentCount = '';
                })
        };

        vm.removeDivision = function (item) {
            committesApi2.removeDivision({ divisionId: item.id, committeeId: vm.model.committee.id }, function () {
                //vm.model.committee.divisions.splice(item, 1);
                _.remove(vm.model.committee.divisions, function (n) {
                    return n.id === item.id;
                });
            });
        }
    }

    editCommitteeCtrl.$inject = ['committesApi2'];

    app.component('editCommittee', {
        templateUrl: '/app/components/committee/committeeEditor.html',
        controller: editCommitteeCtrl,
        controllerAs: 'vm'
    });

})();