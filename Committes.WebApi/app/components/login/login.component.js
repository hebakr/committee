(function () {

	"use strict";

	var app = angular.module('app');


	var loginCtrl = function ($rootScope, $location, Auth, $window) {
		/* jshint validthis:true */
		var vm = this;
		vm.title = 'LoginCtrl';

		vm.login = function (event) {
			event.preventDefault();
			var formData = "grant_type=password";
			formData += "&username=" + vm.username;
			formData += "&password=" + vm.password;

			Auth.login(formData, function (res) {
				//console.log(res);
				$window.localStorage.token = res.access_token;
				window.location = "/";
			}, function () {
				$rootScope.error = 'Invalid credentials.';
				vm.loginFailed = true;
			})
		}

	}
	loginCtrl.$inject = ['$rootScope', '$location', 'Auth', '$window'];
	app.component('login', {
		templateUrl: '/app/components/login/login.html',
		controller: loginCtrl,
		controllerAs: 'vm'
	});


})();