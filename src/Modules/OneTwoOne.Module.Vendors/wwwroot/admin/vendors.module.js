﻿/*global angular*/
(function () {
    'use strict';

    angular
        .module('oneTwoOneAdmin.vendors', [])
        .config(['$stateProvider', function ($stateProvider) {
            $stateProvider.state('vendors', {
                url: '/vendors',
                templateUrl: "modules/vendors/admin/vendors/vendor-list.html",
                controller: 'VendorListCtrl as vm'
            })
            .state('vendor-create', {
                url: '/vendors/create',
                templateUrl: "modules/vendors/admin/vendors/vendor-form.html",
                controller: 'VendorFormCtrl as vm'
            })
            .state('vendor-edit', {
                url: '/vendors/edit/:id',
                templateUrl: 'modules/vendors/admin/vendors/vendor-form.html',
                controller: 'VendorFormCtrl as vm'
            });
        }]);
})();