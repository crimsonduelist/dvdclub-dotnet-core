# DVD Club (.NET Core)

A web-based DVD club management system built with ASP.NET Core 6 MVC. A rewrite of the original Java EE DVD Club application.

## Features

- Movie catalog management (CRUD operations)
- Member management
- DVD rental tracking (create, return, view active rentals)
- Area-based organization (Movies, Rentals, Members, Public)
- AutoMapper for object mapping
- Entity Framework Core with SQL Server

## Tech Stack

- ASP.NET Core 6 (MVC)
- Entity Framework Core 6 (SQL Server)
- AutoMapper
- Serilog (logging)

## Setup

### Prerequisites

- .NET 6 SDK
- SQL Server

### Database

1. Update connection string in `DvdClub.Web/appsettings.json`
2. Run EF Core migrations:
   ```bash
   dotnet ef database update --project DvdClub.Infrastructure
   ```

### Build & Run

```bash
dotnet run --project DvdClub.Web
```

## Project Structure

```
DvdClub.Core/           # Entities, interfaces, enums
DvdClub.Common/         # Shared services
DvdClub.Infrastructure/ # DbContext, migrations, services
DvdClub.Web/            # MVC web app (Areas: Movies, Rentals, Members, Public)
```
