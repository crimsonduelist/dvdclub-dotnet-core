DvdClub.Domain              (was Core)
  ├── Entities/              Movie, Copy, Customer, Rental, ApplicationUser, ExtendedUser
  ├── Interfaces/            IMoviesService, IRentalsService, ICustomersService
  └── Enumeration/           Genre, State, MembershipType, etc.

DvdClub.Application         (was Common)
  ├── Services/              MoviesService, RentalsService, CustomersService
  ├── Interfaces/            IPaginationService  (moved from Infrastructure)
  └── Models/                PaginationModel, PaginationDto  (moved from Infrastructure)

DvdClub.Infrastructure      (unchanged name)
  └── Data/                  DvdClubDbContext, SeedData

DvdClub.Web                 (unchanged name)
  ├── Program.cs             entry point
  ├── RegisterServices.cs    DI registration (cleaned up, no Autofac)
  ├── Controllers/           (unchanged)
  ├── Areas/                 (unchanged)
  └── Views/                 (unchanged)

Dependency arrows:
  Web → Application → Domain
  Web → Infrastructure → Domain
