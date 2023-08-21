using DvdClub.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace DvdClub.Infrastructure.Data {
    public class DvdClubDbContext : DbContext/*IdentityDbContext<ExtendedUser>*/
    {
        public DbSet<Movie> Movies { get; set; }//-virtual?
        public DbSet<Rental> Rentals { get; set; }
        public DbSet<Copy> Copies { get; set; }

        
        public DvdClubDbContext(DbContextOptions<DvdClubDbContext> options) : base(options) {
            /**/
            //Database.SetInitializer<DvdClubDbContext>(null); //Remove default initializer
            /**/
            //Database.EnsureCreated 
                //BETTER NOT -COULD ALSO ADD WITH THIS BUT WHAT IF I WANT TO DELETE THE ADMIN
            
            //Configuration.ProxyCreationEnabled = false;
            //Configuration.LazyLoadingEnabled = false;
        }



        //public DbSet<UserLogin> UserLogins { get; set; }
        //public DbSet<UserClaim> UserClaims { get; set; }
        //public DbSet<UserRole> UserRoles { get; set; }

        //// ... your custom DbSets
        //public DbSet<RoleOperation> RoleOperations { get; set; }

        /*not yet using*/
        /*public DvdClubDbContext() : base("name=DvdClubDbContext") {
            Database.SetInitializer<DvdClubDbContext>(null);*//* Remove default initializer*//*
            //Configuration.ProxyCreationEnabled = false;
            //Configuration.LazyLoadingEnabled = false;
        }*/
        /*not yet using*/

        /*public static DvdClubDbContext Create() {
            return new DvdClubDbContext();
        }*/

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            //modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            var rental = modelBuilder.Entity<Rental>();
            //could do the Roles+1Admin initialization here with efcore

            rental.HasKey(x => x.Id);

            /*not yet using User -cuz Identity*/
            //var user = modelBuilder.Entity<ExtendedUser>();
            //user.Property(x => x.Id).IsRequired().HasMaxLength(256)
            //    .HasColumnAnnotation("Index", new IndexAnnotation(
            //        new IndexAttribute("FullNameIndex")));
            //user.HasMany(x => x.Rentals).WithRequired().HasForeignKey(x => x.UserId);

            /**/

        }
    }
}
