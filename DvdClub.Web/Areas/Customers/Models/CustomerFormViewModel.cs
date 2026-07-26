using DvdClub.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace DvdClub.Web.Areas.Customers.Models {
    public class CustomerFormViewModel {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [Phone]
        public string Phone { get; set; }

        [Display(Name = "Membership Type")]
        public MembershipType MembershipType { get; set; }

        public CustomerFormViewModel() { }

        public CustomerFormViewModel(Customer customer) {
            Id = customer.Id;
            Name = customer.Name;
            Email = customer.Email;
            Phone = customer.Phone;
            MembershipType = customer.MembershipType;
        }
    }
}
