using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Customers
        public ActionResult Index()
        {
            var customers = _context.Customers.Include(c => c.MembershipType).ToList();
            return View(customers);
        }

        public ActionResult CustomerForm()
        {
            var viewModel = new CustomerFormViewModel()
            {
                Customer = new Customer(),
                MembershipTypes = _context.MembershipTypes.ToList()
            };
            return View(viewModel);
        }

        public ActionResult Details(int id)
        {
            var model = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);
            if (model is null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new CustomerFormViewModel()
                {
                    Customer = customer,
                    MembershipTypes = _context.MembershipTypes.ToList()
                };
                return View(nameof(CustomerForm), viewModel);
            }

            _context.Customers.Add(customer);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(Customer customer)
        {
            if (customer.Id != 0)
            {
                if (!ModelState.IsValid)
                {
                    var viewModel = new CustomerFormViewModel()
                    {
                        Customer = customer,
                        MembershipTypes = _context.MembershipTypes.ToList()
                    };
                    return View(nameof(CustomerForm), viewModel);
                }

                var customerInDB = _context.Customers.Single(c => c.Id == customer.Id);

                customerInDB.Name = customer.Name;
                customerInDB.Birthday = customer.Birthday;
                customerInDB.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
                customerInDB.MembershipTypeId = customer.MembershipTypeId;

                _context.SaveChanges();
            }
            else
            {
                return new HttpStatusCodeResult(500);
            }

            return RedirectToAction(nameof(Index));
        }

        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer is null)
            {
                return HttpNotFound();
            }

            var viewModel = new CustomerFormViewModel()
            {
                Customer = customer,
                MembershipTypes = _context.MembershipTypes.ToList()
            };
            return View(nameof(CustomerForm), viewModel);
        }
    }
}