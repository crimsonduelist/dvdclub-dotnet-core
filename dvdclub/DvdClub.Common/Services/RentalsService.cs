using DvdClub.Core.Entities;
using DvdClub.Core.Enumeration;
using DvdClub.Core.Interfaces;

using DvdClub.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;


namespace DvdClub.Common.Services {
    //[Authorize(Roles = "admin")]
    public class RentalsService : IRentalsService {
        private /*readonly*/ DvdClubDbContext db;

        public RentalsService(DvdClubDbContext db) {
            this.db = db;
        }

        public IEnumerable<Rental> GetAll() {
            var rentals = db.Rentals.Include(r => r.Copy.Movie);
            /*Identity*/
            //rentals = rentals.Include(r => r.User);
            return rentals;
        }
        public IEnumerable<Rental> GetAllActive() {//to keep in mind -excluding the additional dates -type would change no need now
            var rentals = db.Rentals
                .Where(r => r.State == State.ACTIVE)
                .Include(r => r.Copy.Movie);
            /*Identity*/
            //rentals = rentals
            //    .Include(r => r.User)
            //    .OrderBy(r => r.DateRented);
            return rentals;

        }
        /*Identity*/
        //public IEnumerable<Rental> GetAllRentalsByUserId(string id) {
        //    return db.Rentals.Where(r => r.UserId == id);
        //}

        public Rental Get(int id) {
            return db.Rentals.Where(r => r.Id == id)
                .Include(r => r.Copy.Movie).FirstOrDefault();
            /*Identity*/
            //.Include(r => r.User).FirstOrDefault();
        }

        public void Add(Rental rental) {
            rental.DateRented = DateTime.Now;
            rental.ExpectedReturnDate = (rental.DateRented).AddDays(7);
            rental.State = State.ACTIVE;
            db.Rentals.Add(rental);
            SetCopyUnavailable(rental.CopyId);
            db.SaveChanges();
        }
        public void SetCopyUnavailable(int Id) {
            var c = db.Copies.Where(x => x.Id == Id).FirstOrDefault();
            c.Availability = false;
        }

        public void Update(Rental rental) {
            var entry = db.Entry(rental); //track entry instead of above
            entry.State = EntityState.Modified;
            db.SaveChanges();//persist
        }

        public bool Return(int id) {
            var rental = Get(id);
            if( rental.State != State.ACTIVE ) {
                return false;
            }
            else {
                rental.State = State.RETURNED;
                var entry = db.Entry(rental);
                rental.ActualReturnDate = DateTime.Now;
                SetCopyAvailable(rental.CopyId);
                entry.State = EntityState.Modified;
                db.SaveChanges();//persist
                return true;
            }

        }

        public void SetCopyAvailable(int Id) {
            var c = db.Copies.Where(x => x.Id == Id).FirstOrDefault();
            c.Availability = true;
        }

        public Copy GetCopyByMovieId(int id) {
            return db.Copies.Where(
                copy => copy.Availability != false
                && copy.Movie.Id == id)
                .FirstOrDefault();
            //should set to var in case it s null? THEN return
        }
        /* x3 Identity*/
        /*public List<string> GetUsers() {
            var users = (from u in db.Users select u.Id).ToList();
            return users;
        }
        public IEnumerable<ExtendedUser> GetEmails() {
            var users = db.Users.ToList();
            return users;
        }

        public IEnumerable<SelectListItem> GetEmailsAsSelectListItems() {
            var users = db.Users.Select(
                u => new SelectListItem() {
                    Value = u.Email,
                    Text = u.Email
                }
                );
            return users;
        }*/

        public IEnumerable<Movie> GetMovieTitles() {
            var movieTitles = db.Movies.ToList();
            return movieTitles;
        }

        /*Identity*/
        /*public string GetUserIds(string userIdToBe) {
            return db.Users.Where(u => u.UserName == userIdToBe).Select(u => u.Id).FirstOrDefault();
        }*/

        public int GetAvailabilityByMovieId(int movieId) {
            return db.Copies.
            Where(c => c.MovieId == movieId &&
                c.Availability != false)
                .Select(c => c.Id)
                .FirstOrDefault();
        }
        public int GetMovieIdByTitle(string MovieTitle) {
            return db.Movies.Where(m => m.Title == MovieTitle).Select(m => m.Id).FirstOrDefault();
        }
        /*Identity*/
        /*public string GetUserIdByName(string UserName) {
            return db.Users.Where(u => u.UserName == UserName).Select(u => u.Id).FirstOrDefault();
        }*/


    }
}
