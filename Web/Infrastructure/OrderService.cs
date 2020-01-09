using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Infrastructure
{
    using System.Data;
    using Models;

    public class OrderService
    {
        public List<Order> GetOrdersForCompany(int CompanyId)
        {
            var orders = Database.GetOrderDetails();

            // create a dictinionary to be able to look up orders quickly
            Dictionary<Int32, Order> orderLookup = new Dictionary<int, Order>();
            foreach (var order in orders)
            {
                orderLookup.Add(order.OrderId, order);
            }

            var orderProducts = Database.GetOrderProducts();
            foreach (var orderproduct in orderProducts)
            {
                var order = orderLookup[orderproduct.OrderId];

                order.OrderProducts.Add(orderproduct);
                order.OrderTotal = order.OrderTotal + (orderproduct.Price * orderproduct.Quantity);
            }

            return orders;
        }
    }
}