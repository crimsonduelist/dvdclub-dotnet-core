using System.ComponentModel.DataAnnotations;

namespace DvdClub.Domain.Entities {
    public class Customer {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public MembershipType MembershipType { get; set; }

        public ICollection<Rental> Rentals { get; set; }

        public Customer() {
            Rentals = new List<Rental>();
        }

        public Customer(string name, string email, string phone, MembershipType membershipType) {
            Name = name;
            Email = email;
            Phone = phone;
            MembershipType = membershipType;
            Rentals = new List<Rental>();
        }
    }

    public enum MembershipType {
        Regular = 0,
        Premium = 1
    }
}
