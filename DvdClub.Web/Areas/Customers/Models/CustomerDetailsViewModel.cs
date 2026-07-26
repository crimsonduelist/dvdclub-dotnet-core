using DvdClub.Domain.Entities;

namespace DvdClub.Web.Areas.Customers.Models {
    public class CustomerDetailsViewModel {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public MembershipType MembershipType { get; set; }

        public CustomerDetailsViewModel() { }

        public CustomerDetailsViewModel(Customer customer) {
            Id = customer.Id;
            Name = customer.Name;
            Email = customer.Email;
            Phone = customer.Phone;
            MembershipType = customer.MembershipType;
        }
    }
}
