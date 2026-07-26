using DvdClub.Domain.Entities;

namespace DvdClub.Domain.Interfaces {
    public interface ICustomersService {
        IEnumerable<Customer> GetAll();
        Customer Get(int id);
        void Add(Customer customer);
        void Update(Customer customer);
        void Delete(int id);
    }
}
