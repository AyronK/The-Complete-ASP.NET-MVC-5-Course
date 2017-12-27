using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        List<Customer> Customers = new List<Customer>()
        {
            new Customer() {Id = 1, Name = "John Smith"},
            new Customer() {Id = 2, Name = "Mary Williams"}
        };

        // GET: Customers
        public ActionResult Index()
        {
            var model = Customers;
            return View(model);
        }

        public ActionResult Details(int id)
        {
            var model = Customers.FirstOrDefault(p => p.Id == id);
            if (model != null)
            {
                return View(model);
            }
            else
            {
                return HttpNotFound();
            }
        }
    }
}