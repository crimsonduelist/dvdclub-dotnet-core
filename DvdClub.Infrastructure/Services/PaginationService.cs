using DvdClub.Core.Entities;
using DvdClub.Core.Interfaces;
using DvdClub.Infrastructure.Models;
using DvdClub.Infrastructure.Models.Dtos;

namespace DvdClub.Infrastructure.Services {
    public class PaginationService : IPaginationService {
        private readonly IMoviesService db;
        public PaginationService(IMoviesService db) {
            this.db = db;
        }


        public PaginationModel<Movie> GetPaginatedMoviesAsync(PaginationDto paginationDto, string genre, string searchString) {
            var moviesQuery = db.GetAll().OrderByDescending(x => x.Title).AsQueryable();

            if( !string.IsNullOrEmpty(genre) ) {
                moviesQuery = moviesQuery.Where(m => m.Genre.ToString() == genre);
            }
            if( !string.IsNullOrEmpty(searchString) ) {
                moviesQuery = moviesQuery.Where(s => s.Title.Contains(searchString));
                //paginationDto.CurrentPage = 1;//dont need this?
            }

            var moviesCount = moviesQuery
                .Count();
            var totalPagesCount = (int)Math.Ceiling((double)moviesCount / paginationDto.PageSize);/*Why -(double) is used as a way of accessing Ceiling() -Ceiling is used to round up to the nearest greatest i.e. 2.9 -> 3 2.1 -> also 3*/
            var pages = new List<int>();
            for( int i = 1; i <= totalPagesCount; i++ ) {
                pages.Add(i);
            }

            switch( paginationDto.CurrentPage ) {
                case int n when(paginationDto.CurrentPage > totalPagesCount):
                    paginationDto.CurrentPage = totalPagesCount;
                    break;

            }

            var toSkip = (paginationDto.CurrentPage - 1) * paginationDto.PageSize;
            moviesQuery = moviesQuery
                    .Skip(toSkip)
                    .Take(paginationDto.PageSize);

            var movies = moviesQuery.
                ToList();





            return new PaginationModel<Movie>(movies, paginationDto.CurrentPage, paginationDto.PageSize, moviesCount, totalPagesCount, pages, searchString, genre);
        }
    }
}
