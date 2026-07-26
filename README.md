# DVD Club (.NET Core)

A web-based DVD club management system built with ASP.NET Core 6 MVC. A rewrite of the original Java EE DVD Club application.

## Features

- Movie catalog browsing with search and genre filtering (auto-filters via AJAX, no page reload)
- DVD rental tracking (create, return, view active rentals)
- Customer management (list, view, create, edit)
- Role-based access control (Anonymous, Employee, Admin)
- ASP.NET Core Identity for authentication and user management
- Area-based organization (Movies, Rentals, Customers, Members, Login, Register)

## Roles

| Role | Access |
|------|--------|
| Anonymous | Home, Movies (browse, search, filter), Login |
| Employee | Above + Rentals (view, create, return), Customers (list, view) |
| Admin | Above + Movies Create/Edit, Customers CRUD, Members, Register new users |

## Tech Stack

- ASP.NET Core 6 (MVC)
- ASP.NET Core Identity (authentication, roles, cookie-based)
- Entity Framework Core 6 (SQLite)
- jQuery Unobtrusive AJAX (partial page updates on movies page - search/filter)
- Bootstrap (UI)
- AutoMapper (entity ↔ DTO mapping)

## Setup

### Dependencies
- Autofac.Extensions.DependencyInjection 8.0.0
- AutoMapper 12.0.0
- AutoMapper.Extensions.Microsoft.DependencyInjection 12.0.0
- Microsoft.AspNetCore.Identity.EntityFrameworkCore 6.0.10
- Microsoft.AspNetCore.Identity.UI 6.0.10
- Microsoft.AspNetCore.Mvc.ViewFeatures 2.2.0
- Microsoft.EntityFrameworkCore 6.0.10
- Microsoft.EntityFrameworkCore.Design 6.0.10
- Microsoft.EntityFrameworkCore.Sqlite 6.0.10
- Microsoft.EntityFrameworkCore.SqlServer 6.0.10
- Microsoft.EntityFrameworkCore.Tools 6.0.10
- Microsoft.Extensions.Identity.Stores 6.0.10
- Microsoft.VisualStudio.Web.CodeGeneration.Design 6.0.10
- Serilog 2.12.0
- Bootstrap 5
- jQuery 3.7.1
- jQuery Unobtrusive Ajax 3.2.6


### Build & Run

```bash
# Quick start (deletes old DB, rebuilds, seeds data, runs on http://localhost:5052)
./build.sh
```

### Database

Uses SQLite by default — no server needed, the `.db` file is created automatically on first run. The database is seeded with sample data (movies, customers, rentals, roles, and users). To reset, delete `DvdClub.Web/dvdclub.db`.

To use SQL Server instead, swap the provider in `RegisterServices.cs` (`UseSqlite()` → `UseSqlServer()`) and update the connection string in `appsettings.json`. You'll also need to swap the NuGet packages (`Microsoft.EntityFrameworkCore.Sqlite` → `Microsoft.EntityFrameworkCore.SqlServer`).

### Default Accounts

| Username | Password | Role |
|----------|----------|------|
| admin | admin | Admin |
| user | user | Employee |
| nick | pass123 | Employee |
| maria | pass123 | Employee |

## Project Structure

Follows [Clean Architecture](https://jasontaylor.dev/clean-architecture-getting-started/) conventions. Dependencies point inward — Domain has zero outward dependencies.

```
DvdClub.Domain/              ← Innermost layer, zero dependencies
  Entities/                  Movie, Copy, Customer, Rental, ApplicationUser
  Interfaces/                IMoviesService, IRentalsService, ICustomersService
  Enumeration/               Genre, State

DvdClub.Application/         ← Business logic (depends on Domain only)
  Services/                  MoviesService, RentalsService, CustomersService, PaginationService
  Interfaces/                IPaginationService
  Models/                    PaginationModel, Dtos/PaginationDto

DvdClub.Infrastructure/      ← Data access (depends on Domain only)
  Data/                      DvdClubDbContext, SeedData

DvdClub.Web/                 ← Presentation layer (depends on Application + Infrastructure)
  Program.cs                 Entry point, DI wiring, middleware pipeline
  RegisterServices.cs        Service/DI registration
  Areas/                     MVC Areas (Movies, Rentals, Customers, Members, Login, Register)
  Views/                     Razor views, shared layouts
  Mappings/                  AutoMapper profiles
  wwwroot/                   Static files (CSS, JS, images)
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
