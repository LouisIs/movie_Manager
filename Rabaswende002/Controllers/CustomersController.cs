 using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Rabaswende002.Models;
using System.Data.Entity;
using Rabaswende002.ViewModel;

namespace Rabaswende002.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext _context;
        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }


        // index page


        
        public ViewResult Index()
        {
            // 333
            // no more usefull because of the api took his jobe
            //     var customers = _context.Customer.Include(c => c.MembershipType).ToList();
            //      return View(customers);
            return View();
        }


        // detaill page
        public ActionResult Details(int id)
        {
            var customer = _context.Customer.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);
            if (customer == null)
                return HttpNotFound();

            return View(customer);
        }


        public ActionResult New()
        {
            var membershipTypes = _context.membershipTypes.ToList();
            var viewmodel = new NewcustomerViewModel
            {
                MembershipTypes = membershipTypes,
                Customer = new Customer()
                
            };
            return View("CustomerForm", viewmodel);        
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                var viewNodel = new NewcustomerViewModel
                {
                    Customer = customer,
                    MembershipTypes = _context.membershipTypes.ToList()
                };

                return View("CustomerForm", viewNodel);
            }
                if (customer.Id == 0)
                    _context.Customer.Add(customer);

                else
                {
                    var customerinDb = _context.Customer.Single(c => c.Id == customer.Id);
                    customerinDb.Name = customer.Name;
                    customerinDb.Birthdate = customer.Birthdate;
                    customerinDb.IsSubscribToNewsLetter = customer.IsSubscribToNewsLetter;
                    customerinDb.MembershipTypeId = customer.MembershipTypeId;


                }

                _context.SaveChanges();
                return RedirectToAction("Index", "Customers");
            
            }






        public ActionResult Edit(int id)
        {
            var customer = _context.Customer.SingleOrDefault(c => c.Id == id);
            if (customer == null)
               return HttpNotFound();

            var viewModel = new NewcustomerViewModel
            {
                Customer = customer,
                MembershipTypes = _context.membershipTypes.ToList()
            };
            return View("CustomerForm", viewModel);
        }

    }
}