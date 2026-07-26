using DvdClub.Domain.Entities;
using DvdClub.Domain.Enumeration;

namespace DvdClub.Domain.Interfaces {
    public interface IMoviesService {
        IEnumerable<Movie> GetAll();
        IEnumerable<Movie> GetAllByGenre(Genre genre);
        Movie Get(int id);
        void Add(Movie movie);
        void Update(Movie movie);
        void Delete(int id);
        int CalculateCopyAvailableCount(int id);
    }
}
