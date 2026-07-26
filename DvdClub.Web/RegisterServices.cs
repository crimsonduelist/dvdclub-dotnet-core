using Autofac;
using Autofac.Core;
using Autofac.Extensions.DependencyInjection;
using DvdClub.Application.Services;
using DvdClub.Domain.Entities;
using DvdClub.Domain.Interfaces;
using DvdClub.Infrastructure.Data;
using DvdClub.Web.Mappings;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace DvdClub.Web {
    public static class RegisterServices {
        public static void ConfigureServies(this WebApplicationBuilder builder) {
            builder.Services.AddControllersWithViews();

            builder.Services.AddTransient<IMoviesService, MoviesService>();
            builder.Services.AddTransient<IRentalsService, RentalsService>();
            builder.Services.AddTransient<ICustomersService, CustomersService>();
            builder.Services.AddTransient<IPaginationService, PaginationService>();

            ConfigurationManager configuration = builder.Configuration;
            builder.Services.AddDbContextPool<DvdClubDbContext>(options => {
                // SQLite for local dev — no server needed, DB file created automatically.
                // To use SQL Server: swap to UseSqlServer() and update the connection string in appsettings.json.
                // options.UseSqlServer(configuration.GetConnectionString("DvdClubDbContextConnectionString"));
                options.UseSqlite(configuration.GetConnectionString("DvdClubDbContextConnectionString"));
            });

            builder.Services.AddDefaultIdentity<ApplicationUser>(options => {
                options.SignIn.RequireConfirmedAccount = false;
                options.Password.RequireDigit = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 1;
            })
            .AddRoles<IdentityRole>()
            .AddEntityFrameworkStores<DvdClubDbContext>();

            builder.Services.ConfigureApplicationCookie(options => {
                options.LoginPath = "/Login/Login/Index";
                options.AccessDeniedPath = "/Shared/AccessDenied";
            });

            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


            /*builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory())
    .ConfigureContainer<ContainerBuilder>(builder => {
        builder.RegisterModule(new ContainerConfig());
    });*/


            //var container = ContainerConfig.Configure();








            /*builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

            builder.Host.ConfigureContainer<ContainerBuilder>(builder =>
            builder.RegisterModule(new ContainerConfig.Configure(ContainerBuilder builder) ));*/

            //builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder => {
            //    containerBuilder.RegisterType<MoviesService>()
            //    .As<IMoviesService>()
            //    .InstancePerRequest();
            //    containerBuilder.RegisterType<PaginationService>()
            //           .As<IPaginationService>()
            //           .InstancePerRequest();
            //    containerBuilder.RegisterType<DvdClubDbContext>()
            //        .InstancePerRequest();
            //});










            //var serviceCollection = new ServiceCollection();

            //// The Microsoft.Extensions.Logging package provides this one-liner
            //// to add logging services.
            //serviceCollection.AddLogging();

            //var containerBuilder = new ContainerBuilder();

            //// Once you've registered everything in the ServiceCollection, call
            //// Populate to bring those registrations into Autofac. This is
            //// just like a foreach over the list of things in the collection
            //// to add them to Autofac.
            //containerBuilder.Populate(serviceCollection);


            //// Make your Autofac registrations. Order is important!
            //// If you make them BEFORE you call Populate, then the
            //// registrations in the ServiceCollection will override Autofac
            //// registrations; if you make them AFTER Populate, the Autofac
            //// registrations will override. You can make registrations
            //// before or after Populate, however you choose.
            //containerBuilder.RegisterType<MoviesService>()
            //    .As<IMoviesService>()
            //    .InstancePerRequest();
            //containerBuilder.RegisterType<PaginationService>()
            //       .As<IPaginationService>()
            //       .InstancePerRequest();
            //containerBuilder.RegisterType<DvdClubDbContext>()
            //    .InstancePerRequest();


            //// Creating a new AutofacServiceProvider makes the container
            //// available to your app using the Microsoft IServiceProvider
            //// interface so you can use those abstractions rather than
            //// binding directly to Autofac.
            //var container = containerBuilder.Build();
            //var serviceProvider = new AutofacServiceProvider(container);
        }
    }
}
