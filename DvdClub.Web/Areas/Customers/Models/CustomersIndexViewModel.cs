using DvdClub.Domain.Entities;

namespace DvdClub.Web.Areas.Customers.Models {
    public class CustomersIndexViewModel {
        public IEnumerable<Customer> Customers { get; set; }

        public CustomersIndexViewModel(IEnumerable<Customer> customers) {
            Customers = customers;
        }
    }
}
