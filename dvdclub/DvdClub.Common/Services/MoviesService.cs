using DvdClub.Core.Entities;
using DvdClub.Core.Enumeration;
using DvdClub.Core.Interfaces;
using DvdClub.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace DvdClub.Common.Services {
    public class MoviesService : IMoviesService {
        private /*readonly*/ DvdClubDbContext db;

        public MoviesService(DvdClubDbContext db) {
            this.db = db;
        }

        public IEnumerable<Movie> GetAll() {
            return db.Movies.Include(x => x.Copies);
        }
        public IEnumerable<Movie> GetAllByGenre(Genre genre) {
            /*return db.Movies;//.orderby...*/
            return from movie in db.Movies
                   where movie.Genre == genre
                   select movie;
        }
        public Movie Get(int id) {
            return db.Movies.FirstOrDefault(movie => movie.Id == id);
        }

        /*insert*/
        public void Add(Movie movie) {
            for( int i = 0; i < 3; i++ ) {
                var cp = new Copy();//add to constructor so I dont ahve to create it?
                cp.Availability = true; cp.Movie = movie;
                movie.Copies.Add(cp);/*add to collection/list etc*/
            }
            db.Movies.Add(movie);
            db.SaveChanges();//persist
        }

        public void Update(Movie movie) {
            var entry = db.Entry(movie); //track entry instead of above
            entry.State = EntityState.Modified;
            db.SaveChanges();//persist
        }

        public void Delete(int id) {
            var movie = db.Movies.Find(id);
            db.Movies.Remove(movie);
            db.SaveChanges();//persist
        }

        public int CalculateCopyAvailableCount(int id) {
            return db.Copies.Count(t => t.Movie.Id == id && t.Availability != false);
        }


    }
}
