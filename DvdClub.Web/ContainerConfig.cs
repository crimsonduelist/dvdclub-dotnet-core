using Autofac;
using DvdClub.Common.Services;
using DvdClub.Core.Interfaces;
using DvdClub.Infrastructure.Data;
using DvdClub.Infrastructure.Services;
using System.Reflection;
using Module = Autofac.Module;

namespace dvdclub.Web {
    public  class ContainerConfig : Module {
        public static IContainer Configure(/*ContainerBuilder containerBuilder*/) {
            
            var containerBuilder = new ContainerBuilder();

            //register types here
            containerBuilder.RegisterType<MoviesService>()
                .As<IMoviesService>()
                .InstancePerRequest();
            containerBuilder.RegisterType<RentalsService>()
                .As<IRentalsService>()
                .InstancePerRequest();
            containerBuilder.RegisterType<PaginationService>()
                   .As<IPaginationService>()
                   .InstancePerRequest();
            containerBuilder.RegisterType<DvdClubDbContext>()
                .InstancePerRequest();
            //containerBuilder.RegisterAssemblyTypes(Assembly.Load(nameof(DvdClub.Common)))
            //    .Where(t => t.Namespace.Contains("Services"))
            //    .As(Assembly.Load(nameof(DvdClub.Core)) );

            return containerBuilder.Build();
        }
    }
}
