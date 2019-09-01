/*global angular*/
(function () {
    angular
        .module('oneTwoOneAdmin.payments')
        .factory('paymentService', ['$http', paymentService]);

    function paymentService($http) {
        var service = {
            getPaymentsByOrder: getPaymentsByOrder
        };
        return service;

        function getPaymentsByOrder(orderId) {
            return $http.get('api/orders/' + orderId + '/payments');
        }
    }
})();
