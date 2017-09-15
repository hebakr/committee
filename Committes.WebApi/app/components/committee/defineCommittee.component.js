(function () {

    "use strict";

    var app = angular.module('app');

    var defineCommitteeCtrl = function (committesApi2) {
        var vm = this;

        vm.model = {};

        vm.search = function () {
            if (vm.committeNumber) {
                committesApi2.findCommittee({ code: vm.committeNumber }, function (response) {
                    var id = response.id;

                    vm.$router.navigate(['MembersCommittee', { id: id }])
                }, function () {
                    alert('رقم اللجنة غير موجود');
                });

            }
        }

    }

    defineCommitteeCtrl.$inject = ['committesApi2'];

    app.component('defineCommitteeMembers', {
        templateUrl: '/app/components/committee/defineCommitteeMembers.html',
        $canActivate: function () {
            return true;
        },
        controller: defineCommitteeCtrl,
        controllerAs: 'vm',
        bindings: {
            $router: '<'
        }

    });

})();