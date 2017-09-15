(function () {
    "use strict";

    var app = angular.module('app');

    var appNavCtrl = function ($window, Auth) {
        var vm = this;

        vm.isAuthorized = $window.localStorage.token;

        vm.logout = function () {
            Auth.logout(function () {
                window.location = "/";
            });
        }

        vm.resetMenu = function () {
            vm.menu1 = true;
            vm.menu2 = true;
            vm.navCollapsed = true;
        }
    }

    appNavCtrl.$inject = ['$window', 'Auth'];

    app.component('appNav', {
        templateUrl: '/app/components/appNav.component.html',
        $routeConfig: [
            { path: "/home", component: 'homePage', name: 'HomePage' },
            { path: "/login", component: 'login', name: 'Login' },
            { path: '/sectors', component: 'sectors', name: 'Sectors' },
            { path: '/jobs', component: 'jobs', name: 'Jobs' },
            { path: '/users', component: 'users', name: 'Users' },
            { path: '/roles', component: 'roles', name: 'Roles' },
            { path: '/settings', component: 'settings', name: 'Settings' },
            { path: '/specialities', component: 'specialities', name: 'Specialities' },
            { path: '/committee/list', component: 'committeesList', name: 'CommitteesList' },
            { path: '/committee/new', component: 'createCommittee', name: 'CreateCommittee' },
            { path: '/committee/define', component: 'defineCommitteeMembers', name: 'DefineCommitteeMembers' },
            { path: '/committee/:id/edit', component: 'editCommittee', name: 'EditCommittee' },
            { path: '/committee/:id/members', component: 'membersCommittee', name: 'MembersCommittee' },
            { path: '/committee/:id/view', component: 'viewCommittee', name: 'ViewCommittee' },
            { path: '/reports/locations', component: 'locationsReport', name: 'Reports.Locations' },
            { path: '/reports/stats', component: 'statsReport', name: 'Reports.Stats' },
            { path: '/reports/hafza', component: 'havzaReport', name: 'Reports.Hafza' },
            { path: '/reports/delivery', component: 'deliveryReport', name: 'Reports.Delivery' },
            { path: '/reports/deliveryByDateReport', component: 'deliveryByDateReport', name: 'Reports.DeliveryByDateReport' },
            { path: '/reports/type', component: 'typeReport', name: 'Reports.Type' },
            { path: '/**', redirectTo: ['HomePage'] }
        ],
        controller: appNavCtrl,
        controllerAs: 'vm'
    });
})();