﻿(function() {
    angular
        .module('oneTwoOneAdmin.orders')
        .directive('orderWidget', mostSearchKeyword);

    function mostSearchKeyword() {
        var directive = {
            restrict: 'E',
            templateUrl: 'modules/orders/admin/order/order-widget.directive.html',
            scope: {
                status: '=',
                numRecords: '='
            },
            controller: ['orderService', 'translateService', OrderWidgetCtrl],
            controllerAs: 'vm',
            bindToController: true
        };

        return directive;
    }

    function OrderWidgetCtrl(orderService, translateService) {
        var vm = this;
        vm.translate = translateService;
        vm.orders = [];

        vm.$onInit = function () {
            orderService.getOrders(vm.status, vm.numRecords).then(function (result) {
                vm.orders = result.data;
            });
        };
    }
})();
