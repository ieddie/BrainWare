function OrderService() { }

OrderService.prototype = {
    getOrders: function (id, successCallback, errorCallback) {
        $.ajax({
            'url': '/api/order/' + id,
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