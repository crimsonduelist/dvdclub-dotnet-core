using DvdClub.Core.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DvdClub.Core.Interfaces {
    public interface IRentalsService {
        IEnumerable<Rental> GetAll();
        //IEnumerable<Rental> GetAllRentalsByUserId(string id);//Identity
        IEnumerable<Rental> GetAllActive();
        //IEnumerable<Rental> GetRentalsByUser(string Email);
        Rental Get(int id);
        void Add(Rental krathsh);
        void Update(Rental krathsh);
        bool Return(int id);
        Copy GetCopyByMovieId(int id);
        //IEnumerable<ExtendedUser> GetEmails();
        //IEnumerable<SelectListItem> GetEmailsAsSelectListItems();//Identity
        IEnumerable<Movie> GetMovieTitles();
        //string GetUserIds(string userIdToBe);//Identity
        int GetAvailabilityByMovieId(int movieId);
        //string GetUserIdByName(string UserName);//Identity
    }
}
