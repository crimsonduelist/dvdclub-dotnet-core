using Autofac;
using Autofac.Core;
using Autofac.Extensions.DependencyInjection;
using DvdClub.Common.Services;
using DvdClub.Core.Interfaces;
using DvdClub.Infrastructure.Data;
using DvdClub.Infrastructure.Services;
using DvdClub.Web.Mappings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace dvdclub.Web {
    public static class RegisterServices {
        public static void ConfigureServies(this WebApplicationBuilder builder) {
            builder.Services.AddControllersWithViews();

            /*Non Autofac Configuration*/

            builder.Services.AddTransient<IMoviesService, MoviesService>();
            builder.Services.AddTransient<IRentalsService, RentalsService>();
            builder.Services.AddTransient<IPaginationService, PaginationService>();

            ConfigurationManager configuration = builder.Configuration;
            builder.Services.AddDbContextPool<DvdClubDbContext>(options => {
                options.UseSqlServer(configuration.GetConnectionString("DvdClubDbContextConnectionString"));
            });

            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            /*Non Autofac Configuration*/


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
