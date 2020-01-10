using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Web.Controllers;
using Web.Models;

namespace Tests.Controllers
{
    /// <summary>
    /// Summary description for OrderControllerTest
    /// </summary>
    [TestClass]
    public class OrderControllerTest
    {

        [TestMethod]
        public void HasAnyCompanies()
        {
            CompanyController controller = new CompanyController();
            IEnumerable<Company> companies = controller.GetCompanies();
            Assert.IsNotNull(companies);
            Assert.IsTrue(companies.GetEnumerator().MoveNext()); // at least one element
        }

        [TestMethod]
        public void GetOrders()
        {
            CompanyController controller = new CompanyController();
            IEnumerable<Company> companies = controller.GetCompanies();
            IEnumerator<Company> enumerator = companies.GetEnumerator();
            Assert.IsTrue(enumerator.MoveNext()); // at least one element
            Int32 companyId = enumerator.Current.Id;
            OrderController orderController = new OrderController();
            IEnumerable<Order> orders = orderController.GetOrders(companyId);
            Assert.IsNotNull(orders);
            Assert.IsTrue(orders.GetEnumerator().MoveNext()); // at least one Order
        }
    }
}
