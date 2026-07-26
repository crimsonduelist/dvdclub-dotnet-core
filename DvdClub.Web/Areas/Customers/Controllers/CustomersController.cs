using DvdClub.Domain.Entities;
using DvdClub.Domain.Interfaces;
using DvdClub.Web.Areas.Customers.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DvdClub.Web.Areas.Customers.Controllers {
    [Area("Customers")]
    [Route("Customers/[controller]/[action]")]
    [Authorize]
    public class CustomersController : Controller {
        private readonly ICustomersService db;

        public CustomersController(ICustomersService db) {
            this.db = db;
        }

        [HttpGet]
        public ActionResult Index() {
            var customers = db.GetAll();
            var model = new CustomersIndexViewModel(customers);
            return View(model);
        }

        [HttpGet]
        public ActionResult Details(int id) {
            var customer = db.Get(id);
            if (customer == null) {
                return NotFound();
            }
            var model = new CustomerDetailsViewModel(customer);
            return View(model);
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult Create() {
            return View("CustomerForm", new CustomerFormViewModel());
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int id) {
            var customer = db.Get(id);
            if (customer == null) {
                return NotFound();
            }
            var model = new CustomerFormViewModel(customer);
            return View("CustomerForm", model);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public ActionResult Save(CustomerFormViewModel model) {
            if (!ModelState.IsValid) {
                return View("CustomerForm", model);
            }

            if (model.Id == 0) {
                var customer = new Customer(model.Name, model.Email, model.Phone, model.MembershipType);
                db.Add(customer);
            } else {
                var customer = db.Get(model.Id);
                customer.Name = model.Name;
                customer.Email = model.Email;
                customer.Phone = model.Phone;
                customer.MembershipType = model.MembershipType;
                db.Update(customer);
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id) {
            db.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
