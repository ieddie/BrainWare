using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    using Infrastructure;

    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var comanies = new CompanyController().GetCompanies();
            return View(comanies.Select(c => new SelectListItem() { Value = c.Id.ToString(), Text = c.Name }));
        }


    }
}
