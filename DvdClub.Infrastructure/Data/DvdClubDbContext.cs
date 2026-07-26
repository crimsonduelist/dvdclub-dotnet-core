using DvdClub.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DvdClub.Infrastructure.Data {
    public class DvdClubDbContext : IdentityDbContext<ApplicationUser> {
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Rental> Rentals { get; set; }
        public DbSet<Copy> Copies { get; set; }
        public DbSet<Customer> Customers { get; set; }

        public DvdClubDbContext(DbContextOptions<DvdClubDbContext> options) : base(options) {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);

            var rental = modelBuilder.Entity<Rental>();
            rental.HasKey(x => x.Id);
        }
    }
}
