using DvdClub.Core.Entities;
using DvdClub.Core.Enumeration;

namespace DvdClub.Core.Interfaces {
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
