using AutoMapper;
using DvdClub.Core.Entities;
using DvdClub.Core.Enumeration;
using DvdClub.Core.Interfaces;
using DvdClub.Infrastructure.Models;
using DvdClub.Infrastructure.Models.Dtos;
using DvdClub.Infrastructure.Services;
using DvdClub.Web.Areas.Movies.Models;
using Microsoft.AspNetCore.Mvc;

namespace dvdclub.Web.Areas.Movies.Controllers {
    [Area("Movies")]
    [Route("Movies/[controller]/[action]")]
    //[Authorize]
    public class MoviesController : Controller {
        private readonly IMoviesService db;
        private IPaginationService paginationService;
        //protected IMapper _mapper { get; set; }


        //constructor
        public MoviesController(IMoviesService db, IPaginationService paginationService/*, IMapper mapper*/) {
            this.db = db;
            this.paginationService = paginationService;
            //this._mapper = mapper;
        }

        // GET: Movies
        [HttpGet]
        public ActionResult Index(
            int? page,
            Genre? Genre,
            string searchString = ""
            ) {
            int pageSize = 3;//set the pageSize here

            var paginationDto = new PaginationDto(page, pageSize);

            var getPaginationModel = paginationService.GetPaginatedMoviesAsync(paginationDto, Genre.ToString(), searchString);


            var paginationModel = new PaginationModel<MovieIndexViewModel>(
                new List<MovieIndexViewModel>(),
                getPaginationModel.PageNum,
                getPaginationModel.PageSize,
                getPaginationModel.TotalItems,
                getPaginationModel.TotalPagesCount,
                getPaginationModel.Pages,
                getPaginationModel.SearchString,
                getPaginationModel.Genre
                );

            foreach( var movie in getPaginationModel.Items ) {
                paginationModel.Items.Add(new MovieIndexViewModel(
                    movie.Id,
                    movie.Title,
                    movie.Description,
                    movie.Genre,
                    movie.Copies)
                    );
            }

            return View(paginationModel);/*.Result.Items.Select(x=>x.)*/ /*.AsyncState*/

        }

        [HttpGet]
        public ActionResult Create() {
            return View(new MoviesCreateBindingModel() );

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MoviesCreateBindingModel model) {
            if( !ModelState.IsValid ) {
                return View();
            }
            //var movie = _mapper.Map(model, new Movie());
            var movie = new Movie(model.Title, model.Description, model.Genre);
            db.Add(movie);
            return RedirectToAction("Create");
        }

        [HttpGet]
        public ActionResult Edit(int id) {
            var movie = db.Get(id);
            var model = new MoviesEditBindingModel(movie.Id, movie.Title, movie.Description, movie.Genre);
            if( model != null ) {
                return View(model);
            }
            return NotFound();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(MoviesEditBindingModel model) {
            if( ModelState.IsValid ) {
                var movie = db.Get(model.Id);
                movie.Title = model.Title;
                movie.Description = model.Description;
                movie.Genre = model.Genre;

                db.Update(movie);
                return RedirectToAction("Edit", new { id = model.Id });
            }
            return View(model);
        }

    }//class
}//namespace
