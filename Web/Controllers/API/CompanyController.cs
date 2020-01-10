using Filters;
using System.Collections.Generic;
using System.Web.Http;
using Web.Infrastructure;
using Web.Models;

namespace Web.Controllers
{
    [OrderExceptionFilter]
    public class CompanyController : ApiController
    {
        [HttpGet]
        public IEnumerable<Company> GetCompanies()
        {
            var data = new OrderService();

            return data.GetCompanies();
        }
    }
}
