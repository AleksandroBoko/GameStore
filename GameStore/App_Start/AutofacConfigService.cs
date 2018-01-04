﻿using Autofac;
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

            builder.Register(x => GenreRepository.GetInstance())
                .As<IRepository<Genre>>()
                .SingleInstance();

            var genreRepository = GenreRepository.GetInstance();
            builder.RegisterType<GenreServices>()
                .As<IService<GenreModel>>()
                .WithParameter("repository", genreRepository)
                .InstancePerRequest();

            Container = builder.Build();

            return Container;
        }
    }
}