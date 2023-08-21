using DvdClub.Core.Entities;
using DvdClub.Core.Enumeration;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DvdClub.Web.Areas.Rentals.Models {    //BindingModels
    public class RentalsCreateBindingModel {
        public string Comments { get; set; }//from rental
        //public IEnumerable<ExtendedUser> Emails { get; set; }
        public IEnumerable<Movie> MovieTitles { get; set; }
        

        public string UserId { get; set; }
        public int MovieId{ get; set; }


        public RentalsCreateBindingModel() {

        }

    }

    public class RentalsReturnBindingModel {
        public int Id;
        public string UserId;
        public string UserName;
        public State State;
        public int CopyId;
        public string MovieTitle;

        public RentalsReturnBindingModel() {
        }
        public RentalsReturnBindingModel(int id, string userId, State state, int copyId) {
            this.Id = id;
            this.UserId = userId;
            this.State = state;
            this.CopyId = copyId;
        }
        public RentalsReturnBindingModel(int id, string userId, State state, int copyId, string userName, string movieTitle) {
            this.Id = id;
            this.UserId = userId;
            this.UserName = userName;
            this.State = state;
            this.CopyId = copyId;
            this.MovieTitle = movieTitle;
        }
    }
}
