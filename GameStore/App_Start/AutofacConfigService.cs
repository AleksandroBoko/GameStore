using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using GameStore.DataAccess.EntityModels;
using GameStore.DataAccess.Repositories;
using GameStore.DataAccess.Repositories.Implementation;
using GameStore.Domains.Domain;
using GameStore.Services.Services;
using GameStore.Services.Services.Implementation;
using System.Web.Http;
using System.Web.Mvc;
using System.Reflection;
using System.Data.Entity;

namespace GameStore.App_Start
{
    public class AutofacConfigService
    {
        public static IContainer Container;

        public static void Initialize(HttpConfiguration config)
        {
            Initialize(config, RegisterServices(new ContainerBuilder()));
        }

        public static void Initialize(HttpConfiguration config, IContainer container)
        {
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }

        private static IContainer RegisterServices(ContainerBuilder builder)
        {
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.RegisterControllers(Assembly.GetExecutingAssembly());

            builder.RegisterType<GenreRepository>()
                .As<IRepository<Genre>>()
                .InstancePerRequest();

            builder.RegisterType<StudioRepository>()
                .As<IRepository<Studio>>()
                .InstancePerRequest();

            builder.RegisterType<ProducerRepository>()
                .As<IRepository<Producer>>()
                .InstancePerRequest();

            builder.RegisterType<GameRepository>()
                .As<IRepository<Game>>()
                .InstancePerRequest();

            builder.RegisterType<GameStoreContext>()
                .As<DbContext>()
                .InstancePerRequest();

            builder.RegisterType<GenreServices>()
                .As<IService<GenreModel>>()
                .InstancePerRequest();

            builder.RegisterType<StudioServices>()
                .As<IService<StudioModel>>()
                .InstancePerRequest();

            builder.RegisterType<ProducerServices>()
                .As<IService<ProducerModel>>()
                .InstancePerRequest();

            builder.RegisterType<GameServices>()
                .As<IService<GameModel>>()
                .InstancePerRequest();

            builder.RegisterType<GameServices>()
                .As<IGameService>()
                .InstancePerRequest();

            builder.RegisterType<StudioServices>()
                .As<IStudioService>()
                .InstancePerRequest();

            builder.RegisterType<GenreServices>()
                .As<IGenreService>()
                .InstancePerRequest();

            builder.RegisterType<ProducerServices>()
                .As<IProducerService>()
                .InstancePerRequest();

            Container = builder.Build();

            return Container;
        }
    }
}
