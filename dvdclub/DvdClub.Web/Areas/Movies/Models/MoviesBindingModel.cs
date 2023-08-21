using DvdClub.Core.Enumeration;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DvdClub.Web.Areas.Movies.Models {
    public class MoviesEditBindingModel {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Genre Genre { get; set; }

        public MoviesEditBindingModel() {
        }
        public MoviesEditBindingModel(int id) {
            this.Id = id;
        }
        public MoviesEditBindingModel(int id, string title, string description, Genre genre) {
            Title = title;
            Description = description;
            Genre = genre;
        }

    }
    public class MoviesCreateBindingModel {
        public string Title { get; set; }
        public string Description { get; set; }
        public Genre Genre { get; set; }
        //public List<Genre> Genres { get; set; }//todo ->CreateView

        public MoviesCreateBindingModel(string title, string description, Genre genre) {
            Title = title;
            Description = description;
            Genre = genre;
        }
        public MoviesCreateBindingModel() {
            //this.Genres = new List<Genre>();//todo ->CreateView
        }
    }
}