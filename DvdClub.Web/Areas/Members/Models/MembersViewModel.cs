using DvdClub.Domain.Entities;

namespace DvdClub.Web.Areas.Members.Models {
    public class MembersIndexViewModel {
        public IEnumerable<ApplicationUser> Users { get; set; }

        public MembersIndexViewModel(IEnumerable<ApplicationUser> users) {
            this.Users = users;
        }
    }
}
