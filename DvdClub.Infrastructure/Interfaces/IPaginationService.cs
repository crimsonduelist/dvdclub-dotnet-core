using DvdClub.Core.Entities;
using DvdClub.Infrastructure.Models;
using DvdClub.Infrastructure.Models.Dtos;

namespace DvdClub.Infrastructure.Services {
    public interface IPaginationService {
        /* Task<*/
        PaginationModel<Movie>/*> */GetPaginatedMoviesAsync(PaginationDto pagination, string genre, string searchString);
    }
}
