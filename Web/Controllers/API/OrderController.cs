using System.Collections.Generic;
using System.Web.Http;

namespace Web.Controllers
{
    using Infrastructure;
    using Models;
    using Filters;
    using System.Web.Mvc;

    [OrderExceptionFilter]
    public class OrderController : ApiController
    {
        [HttpGet]
        public IEnumerable<Order> GetOrders(int id = 1)
        {
            var data = new OrderService();

            return data.GetOrdersForCompany(id);
        }
    }
}
