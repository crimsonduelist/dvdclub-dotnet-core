# DVD Club (.NET Core)

A web-based DVD club management system built with ASP.NET Core 6 MVC. A rewrite of the original Java EE DVD Club application.


### Build & Run

```bash
# Quick start (deletes old DB, rebuilds, seeds data, runs on http://localhost:5052)
./build.sh
```
**Dependencies**
- .NET-6

### Database
Uses SQLite by default — no server needed, the .db file is created automatically on first run. The database is seeded with sample data (movies, customers, rentals, roles, and users). To reset, delete DvdClub.Web/dvdclub.db.

To use SQL Server instead, swap the provider in RegisterServices.cs (UseSqlite() → UseSqlServer()) and update the connection string in appsettings.json. You'll also need to swap the NuGet packages (Microsoft.EntityFrameworkCore.Sqlite → Microsoft.EntityFrameworkCore.SqlServer).

### Dependencies

- AutoMapper 12.0.0
- AutoMapper.Extensions.Microsoft.DependencyInjection 12.0.0
- Microsoft.AspNetCore.Identity.EntityFrameworkCore 6.0.10
- Microsoft.AspNetCore.Identity.UI 6.0.10
- Microsoft.EntityFrameworkCore 6.0.10
- Microsoft.EntityFrameworkCore.Design 6.0.10
- Microsoft.EntityFrameworkCore.Sqlite 6.0.10
- Microsoft.EntityFrameworkCore.SqlServer 6.0.10
- Microsoft.EntityFrameworkCore.Tools 6.0.10
- Microsoft.VisualStudio.Web.CodeGeneration.Design 6.0.10
- Microsoft.Web.LibraryManager.Build 2.1.175
- Bootstrap 5 (via LibMan)
- jQuery 3.5.1 (via LibMan)
- jQuery Unobtrusive Ajax 3.2.6 (via LibMan)
- jQuery Validation 1.17.0 (via LibMan)

### Default Accounts

| Username | Password | Role |
|----------|----------|------|
| admin | admin | Admin |
| user | user | Employee |
| nick | pass123 | Employee |
| maria | pass123 | Employee |

## Project Structure

Follows Clean Architecture conventions. Dependencies point inward — Domain has zero outward dependencies.

```
dvdclub-dotnet-core/
├── build.sh                    # Build & run script
├── dvdclub.sln                 # Solution file
├── mvcs.md                     # Architecture docs
├── DvdClub.Domain/             # INNERMOST — zero dependencies
│   ├── Entities/               Movie, Copy, Customer, Rental, ApplicationUser
│   ├── Interfaces/             IMoviesService, IRentalsService, ICustomersService
│   └── Enumeration/            Genre, State
├── DvdClub.Application/        # BUSINESS LOGIC — depends on Domain only
│   ├── Services/               MoviesService, RentalsService, CustomersService, PaginationService
│   ├── Interfaces/             IPaginationService
│   └── Models/                 PaginationModel, Dtos/PaginationDto
├── DvdClub.Infrastructure/     # DATA ACCESS — depends on Domain only
│   ├── Data/                   DvdClubDbContext, SeedData
│   └── Migrations/             EF Core migrations
└── DvdClub.Web/                # PRESENTATION — depends on Application + Infrastructure
    ├── Program.cs              Entry point, DI, middleware
    ├── RegisterServices.cs     DI registrations
    ├── Areas/                  MVC Areas (Movies, Rentals, Customers, Members, Login, Register, Public)
    ├── Views/                  Razor views + shared layouts
    ├── Mappings/               AutoMapper profiles
    ├── wwwroot/                Static files (css, js, lib/)
    └── libman.json             Frontend library config (bootstrap, jquery, etc.)
```

**Dependency arrows:**
```
Web ──────► Application ──────► Domain
  │                                    ▲
  └─────► Infrastructure ─────────────┘
```

## TODO

- **Cleanup Leftover code/deps** - Leftover from .netframework 4.x
- **REST API** — JWT-based API endpoints for all features (movies, rentals, customers, auth)
- **Custom Frontend** —  consuming the API
