(function () {
    "use strict";

    var app = angular.module('app')

    app.component('appNav', {
        templateUrl: '/app/components/appNav.component.html',
        $routeConfig: [
            { path: '/home', component: 'appHome', name: 'Home' },
            { path: '/sectors', component: 'sectors', name: 'Sectors' },
            { path: '/jobs', component: 'jobs', name: 'Jobs' },
            { path: '/roles', component: 'roles', name: 'Roles' },
            { path: '/workPlaces', component: 'workPlaces', name: 'WorkPlaces' },
            { path: '/settings', component: 'settings', name: 'Settings' },
            { path: '/specialities', component: 'specialities', name: 'Specialities' },
            { path: '/committee/list', component: 'committeesList', name: 'CommitteesList' },
            { path: '/committee/new', component: 'createCommittee', name: 'CreateCommittee' },
            { path: '/committee/define', component: 'defineCommitteeMembers', name: 'DefineCommitteeMembers' },
            { path: '/committee/:id/edit', component: 'editCommittee', name: 'EditCommittee' },
            { path: '/committee/:id/members', component: 'membersCommittee', name: 'MembersCommittee' },
            { path: '/committee/:id/view', component: 'viewCommittee', name: 'ViewCommittee' },
            { path: '/**', redirectTo: ['Home'] }
        ]
    });
})();