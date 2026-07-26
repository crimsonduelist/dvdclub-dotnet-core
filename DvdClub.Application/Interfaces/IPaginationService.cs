using DvdClub.Domain.Entities;
using DvdClub.Application.Models;
using DvdClub.Application.Models.Dtos;

namespace DvdClub.Application.Services {
    public interface IPaginationService {
        /* Task<*/
        PaginationModel<Movie>/*> */GetPaginatedMoviesAsync(PaginationDto pagination, string genre, string searchString);
    }
}
