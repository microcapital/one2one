/*global angular*/
(function () {
    'use strict';

    angular
        .module('oneTwoOneAdmin.dashboard', [])
        .config(['$stateProvider', function ($stateProvider) {
            $stateProvider.state('dashboard', {
                url: '/dashboard',
                templateUrl: "/admin/dashboard-tpl"
            });
        }]);
})();