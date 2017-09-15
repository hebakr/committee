(function () {

    "use strict";

    var app = angular.module('app');

    var committeesListCtrl = function (committesApi2) {
        var vm = this;
        vm.data = [];

        vm.model = {};

        vm.$onInit = function () {
            loadData();
        }

        var loadData = function () {
            committesApi2.query(function (response) {
                vm.data = response;
            });
        }

        vm.search = function () {
            committesApi2.findCommittees({ name: vm.model.name, number: vm.model.number }, function (response) {
                vm.data = response.data;
            });
        }

        vm.remove = function (item) {
            if (confirm('سوف يتم حذف بيانات هذه اللجنة تمام ، برجاء التأكيد \n برجاء ملاحظة ان هذه العملية لايمكن الرجوع عنها')) {
                committesApi2.deleteCommittee({ id: item.id }, function () {
                    loadData();
                });
            }
        }
    }

    committeesListCtrl.$inject = ['committesApi2'];

    app.component('committeesList', {
        templateUrl: '/app/components/committee/committeesList.component.html',
        controller: committeesListCtrl,
        controllerAs: 'vm'
    });

})();