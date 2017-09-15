(function () {

    "use strict";

    var app = angular.module('app');

    var createCommitteeCtrl = function (committesApi2) {
        var vm = this;

        vm.model = {};

        vm.$onInit = function () {
            committesApi2.getViewModel({ id: 0 }, function (response) {
                vm.model = response;

                vm.model.committee.committeType = "أصلى";
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

        vm.submit = function (Addnew) {
            vm.model.committee.schoolId = vm.model.selectedSchool.id;

            committesApi2.saveCommittee(vm.model.committee, function (response) {
                if (Addnew)
                    vm.$router.navigate(['CreateCommittee'])
                else
                    vm.$router.navigate(['EditCommittee', { id: response.id, fromNew: true }])
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


    }

    createCommitteeCtrl.$inject = ['committesApi2'];

    app.component('createCommittee', {
        templateUrl: '/app/components/committee/committeeEditor.html',
        $canActivate: function () {
            return true;
        },
        controller: createCommitteeCtrl,
        controllerAs: 'vm',
        bindings: {
            $router: '<'
        }
    });

})();