/*global angular*/
(function () {
    'use strict';

    angular
        .module('oneTwoOneAdmin.paymentCashfree', [])
        .config(['$stateProvider',
            function ($stateProvider) {
                $stateProvider
                    .state('payments-cashfree-config', {
                        url: '/payments/cashfree/config',
                        templateUrl: 'modules/paymentcashfree/admin/cashfree/cashfree-config-form.html',
                        controller: 'CashfreeConfigFormCtrl as vm'
                    })
                ;
            }
        ]);
})();
