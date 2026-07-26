using DvdClub.Domain.Entities;
using DvdClub.Domain.Enumeration;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DvdClub.Web.Areas.Rentals.Models {
    public class RentalsCreateBindingModel {
        public string Comments { get; set; }
        public IEnumerable<Movie> MovieTitles { get; set; }
        public IEnumerable<Customer> Customers { get; set; }

        public int CustomerId { get; set; }
        public int MovieId { get; set; }

        public RentalsCreateBindingModel() {
        }
    }

    public class RentalsReturnBindingModel {
        public int Id;
        public State State;
        public int CopyId;
        public string MovieTitle;

        public RentalsReturnBindingModel() {
        }
        public RentalsReturnBindingModel(int id, State state, int copyId) {
            this.Id = id;
            this.State = state;
            this.CopyId = copyId;
        }
        public RentalsReturnBindingModel(int id, State state, int copyId, string movieTitle) {
            this.Id = id;
            this.State = state;
            this.CopyId = copyId;
            this.MovieTitle = movieTitle;
        }
    }
}
