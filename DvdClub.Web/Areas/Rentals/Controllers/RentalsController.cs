using DvdClub.Domain.Entities;
using DvdClub.Domain.Interfaces;
using DvdClub.Web.Areas.Rentals.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DvdClub.Web.Areas.Rentals {
    [Area("Rentals")]
    [Route("Rentals/[controller]/[action]")]
    [Authorize]
    public class RentalsController : Controller {
        private readonly IRentalsService db;
        private readonly ICustomersService customersDb;

        public RentalsController(IRentalsService db, ICustomersService customersDb) {
            this.db = db;
            this.customersDb = customersDb;
        }

        [HttpGet]
        public ActionResult Index() {
            var rentals = db.GetAll();
            var model = new RentalsViewModel(rentals);
            return View(model);
        }

        [HttpGet]
        public ActionResult ActiveRentals() {
            var rentals = db.GetAllActive();
            var model = new RentalsViewModel(rentals);
            return View(model);
        }

        [HttpGet]
        public ActionResult Create(int? movieId, int? customerId) {
            var movieTitlesList = db.GetMovieTitles();
            var customers = customersDb.GetAll();

            var model = new RentalsCreateBindingModel();
            model.MovieTitles = movieTitlesList;
            model.Customers = customers;

            if (movieId.HasValue) {
                model.MovieId = movieId.Value;
            }
            if (customerId.HasValue) {
                model.CustomerId = customerId.Value;
            }

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RentalsCreateBindingModel rentalmodel) {
            var copyId = db.GetCopyByMovieId(rentalmodel.MovieId);
            if (copyId != null) {
                var rental = new Rental();
                rental.CopyId = copyId.Id;
                rental.CustomerId = rentalmodel.CustomerId;
                rental.Comments = rentalmodel.Comments;
                db.Add(rental);
                return RedirectToAction("Create", new { movieId = rentalmodel.MovieId, customerId = rentalmodel.CustomerId });
            }

            return RedirectToAction("Create", new { movieId = rentalmodel.MovieId, customerId = rentalmodel.CustomerId });
        }

        [HttpPost]
        public JsonResult Return(int id) {
            var returned = db.Return(id);
            if (!returned) {
                return Json(new { message = "The Following Copy Has Already Been Returned" });
            }
            else {
                return Json(new { message = "Returned Successfully" });
            }
        }
    }
}
