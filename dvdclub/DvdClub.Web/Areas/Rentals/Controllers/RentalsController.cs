using AutoMapper;
using DvdClub.Core.Entities;
using DvdClub.Core.Interfaces;
using DvdClub.Web.Areas.Rentals.Models;
using Microsoft.AspNetCore.Mvc;

namespace DvdClub.Web.Areas.Rentals {
    //[Authorize(Roles = "admin")]//??
    [Area("Rentals")]
    [Route("Rentals/[controller]/[action]")]
    public class RentalsController : Controller {
        private readonly IRentalsService db;
        protected IMapper _mapper { get; set; }
        //private readonly ILoggingService _logger;

        //constructor
        public RentalsController(IRentalsService db, /*ILoggingService logger,*/ IMapper mapper) {
            this.db = db;
            //this._logger = logger;
            this._mapper = mapper;
        }

        // GET: 
        //[Authorize(Roles = "admin")]
        [HttpGet]
        public ActionResult Index() {
            var rentals = db.GetAll();
            var model = new RentalsViewModel(rentals);
            return View(model);
        }
        //[Authorize(Roles = "admin")]
        [HttpGet]
        public ActionResult ActiveRentals() {
            var rentals = db.GetAllActive();
            var model = new RentalsViewModel(rentals);
            //Log.Information("Hello, Serilog!");
            //Log.Information("The time is {Now}", DateTime.Now);
            return View(model);
        }

        //[Authorize(Roles = "user")]//??
        /*Identity*/
        //[HttpGet]
        //public ActionResult RentalsByUserId(string id) {
        //    var rental = db.GetAllRentalsByUserId(id);
        //    var model = new RentalsViewModel(rental);
        //    return View(model);
        //}

        //[Authorize(Roles = "admin")]
        /*[HttpGet]
        public ActionResult Create(int? movieId, string userId = null) {*//*optional parameter -could have more to differentiate between views*//* //THEY ARE NOT CASE SENSITIVE i.e. addressbar
            var emailsList = db.GetEmails();
            var movieTitlesList = db.GetMovieTitles();

            var model = new RentalsCreateBindingModel();
            model.Emails = emailsList;
            model.MovieTitles = movieTitlesList;

            return View(model);

        }*/
        //[Authorize(Roles = "admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RentalsCreateBindingModel rentalmodel) {//same method for both
            var copyId = db.GetCopyByMovieId(rentalmodel.MovieId);
            //try catch here - exception from service - thrown if no available copies
            if( copyId != null ) {//0
                var model = _mapper.Map<Rental>(rentalmodel);
                model.CopyId = copyId.Id;
                db.Add(model);
                return RedirectToAction("Create", new { movieId = rentalmodel.MovieId, userId = rentalmodel.UserId });
            }

            //ModelState.AddModelError(nameof(rentalmodel.MovieTitle), "No Available Copies Left For This Movie");

            return RedirectToAction("Create", new { movieId = rentalmodel.MovieId, userId = rentalmodel.UserId });

        }

        [HttpPost]
        public JsonResult Return(int id) {
            var returned = db.Return(id);
            if( !returned ) {//!returned
                //_logger.Writer.Debug("ajax passed controller error with id: {id}", id);
                return Json(new { message = "The Following Copy Has Already Been Returned" });
            }
            else {
                //_logger.Writer.Debug("ajax passed controller error with id: {id}", id);
                return Json(new { message = "Returned Successfully" });
            }
        }

    }
}