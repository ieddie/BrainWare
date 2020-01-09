function OrderService() { }

OrderService.prototype = {
    getOrders: function (successCallback, errorCallback) {
        $.ajax({
            'url': '/api/order/1',
            'type': 'GET',
            'success': function (data) {
                return successCallback(data);
            },
            'error': function (error) {
                errorCallback(error);
            }
        });
    }
};