(function () {

    "use strict";

    var app = angular.module('app');

    var homeCtrl = function (committesApi2) {
        var vm = this;
        vm.data = [];

        vm.model = {};

        vm.$onInit = function () {
            loadData();
        }

        var loadData = function () {
            committesApi2.GetLatest(function (response) {
                vm.data = response;
            });
        }

    };


    homeCtrl.$inject = ['committesApi2'];

    app.component('homePage', {
        templateUrl: '/app/components/home/home.component.html',
        controllerAs: 'vm',
        controller: homeCtrl
    });
})();
