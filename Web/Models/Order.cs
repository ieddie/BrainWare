using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Models
{
    using System.Security.AccessControl;

    public class Order
    {
        public Int32 OrderId { get; set; }

        public string CompanyName { get; set; }

        public string Description { get; set; }

        public decimal OrderTotal { get; set; }

        public List<OrderProduct> OrderProducts { get; set; }

        public Order()
        {
            OrderProducts = new List<OrderProduct>();
        }

        public Order(string companyName, string description, int orderId)
        {
            CompanyName = companyName;
            Description = description;
            OrderId = orderId;
            OrderTotal = 0;
            OrderProducts = new List<OrderProduct>();
        }
    }

    public class OrderProduct
    {
        public Int32 OrderId { get; set; }

        public Int32 ProductId { get; set; }

        public Product Product { get; set; }
    
        public Int32 Quantity { get; set; }

        public decimal Price { get; set; }

        public OrderProduct() { }

        public OrderProduct(Int32 orderId, Int32 productId, decimal price, Int32 quatity, string productName, decimal originalProductPrice)
        {
            OrderId = orderId;
            ProductId = productId;
            Quantity = quatity;
            Price = price;
            Product = new Product() { Name = productName, Price = originalProductPrice };
        }
    }

    public class Product
    {
        public string Name { get; set; }

        public decimal Price { get; set; }
    }
}