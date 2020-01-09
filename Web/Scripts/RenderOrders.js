function displayOrders(data) {
    var $orderList = $('<ul/>');
    $.each(data,
        function (i) {
            var $li = $('<li/>').text(this.Description + ' (Total: $' + this.OrderTotal + ')')
                .appendTo($orderList);

            var $productList = $('<ul/>');

            $.each(this.OrderProducts, function (j) {
                var $li2 = $('<li/>').text(this.Product.Name + ' (' + this.Quantity + ' @@ $' + this.Price + '/ea)')
                    .appendTo($productList);
            });

            $productList.appendTo($li);
        });

    $('#orders').append($orderList);
}

function displayError(error) {
    console.log(error);
    $('#orders').text('Order list is not available at this time');
}