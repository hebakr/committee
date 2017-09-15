(function () {

    "use strict";

    var app = angular.module('app');

    var viewCommitteeCtrl = function (committesApi2) {
        var vm = this;

        vm.model = {};

        vm.$routerOnActivate = function (next, previous) {
            var id = next.params.id;

            committesApi2.getCommittee({ id: id }, function (response) {
                vm.model = response;
            });

        }


    }

    viewCommitteeCtrl.$inject = ['committesApi2'];

    app.component('viewCommittee', {
        templateUrl: '/app/components/committee/viewCommittee.html',
        controller: viewCommitteeCtrl,
        controllerAs: 'vm',
        bindings: {
            $router: '<'
        }
    });

})();