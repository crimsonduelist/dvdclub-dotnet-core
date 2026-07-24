using AutoMapper;
using DvdClub.Core.Entities;
using DvdClub.Web.Areas.Movies.Models;

namespace DvdClub.Web.Mappings.Profile {
    public class MovieProfile : AutoMapper.Profile {
        public MovieProfile() {
            CreateMap<MoviesCreateBindingModel, Movie>(MemberList.None).ReverseMap();
        }
    }
}