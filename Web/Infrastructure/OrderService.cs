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
        public List<Order> GetOrdersForCompany(int companyId)
        {
            List<Order> orders = null;

            var ds = Database.GetOrders(companyId);
            if (ds != null && ds.Tables.Count == 2 && ds.Tables[0].Rows.Count > 0)
            {
                // create a dictinionary to be able to look up orders quickly
                Dictionary<Int32, Order> orderLookup = new Dictionary<Int32, Order>();
                foreach (DataRow order in ds.Tables[0].Rows)
                {
                    var orderRecord = new Order(order[1].ToString(), Convert.ToInt32(order[0]));
                    orderLookup.Add(orderRecord.OrderId, orderRecord);
                }

                foreach (DataRow row in ds.Tables[1].Rows)
                {
                    var orderProduct = new OrderProduct(Convert.ToInt32(row[1]), Convert.ToInt32(row[2]), Convert.ToDecimal(row[0]),
                        Convert.ToInt32(row[3]), row[4].ToString(), Convert.ToDecimal(row[5]));


                    var order = orderLookup[orderProduct.OrderId];

                    order.OrderProducts.Add(orderProduct);
                    order.OrderTotal = order.OrderTotal + (orderProduct.Price * orderProduct.Quantity);
                }
                orders = orderLookup.Values.ToList();
            }
            else
            {
                orders = new List<Order>();
            }

            return orders;
        }

        public List<Company> GetCompanies()
        {
            return Database.GetCompanies();
        }
    }
}