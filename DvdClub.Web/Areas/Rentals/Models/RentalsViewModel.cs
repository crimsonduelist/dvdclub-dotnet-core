using DvdClub.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DvdClub.Web.Areas.Rentals.Models {
    public class RentalsViewModel {
        public IEnumerable<Rental> Rentals { get; set; }

        //ctor
        public RentalsViewModel(IEnumerable<Rental> rentals) {
            this.Rentals = rentals;
        }public RentalsViewModel() {
        }
    }
}