using DvdClub.Domain.Entities;
using DvdClub.Domain.Interfaces;
using DvdClub.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace DvdClub.Application.Services {
    public class CustomersService : ICustomersService {
        private DvdClubDbContext db;

        public CustomersService(DvdClubDbContext db) {
            this.db = db;
        }

        public IEnumerable<Customer> GetAll() {
            return db.Customers.ToList();
        }

        public Customer Get(int id) {
            return db.Customers.FirstOrDefault(c => c.Id == id);
        }

        public void Add(Customer customer) {
            db.Customers.Add(customer);
            db.SaveChanges();
        }

        public void Update(Customer customer) {
            var entry = db.Entry(customer);
            entry.State = EntityState.Modified;
            db.SaveChanges();
        }

        public void Delete(int id) {
            var customer = db.Customers.Find(id);
            db.Customers.Remove(customer);
            db.SaveChanges();
        }
    }
}
