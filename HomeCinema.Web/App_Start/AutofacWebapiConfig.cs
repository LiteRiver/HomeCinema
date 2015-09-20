using Autofac;
using Autofac.Integration.WebApi;
using HomeCinema.Data;
using HomeCinema.Data.Infrastructure;
using HomeCinema.Services;
using HomeCinema.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;

namespace HomeCinema.Web {
    public class AutofacWebapiConfig {
        public static IContainer Container;

        public static void Initialize(HttpConfiguration cfg) {
            Initialize(cfg, RegisterServices(new ContainerBuilder()));
        }

        public static void Initialize(HttpConfiguration cfg, IContainer container) {
            cfg.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }

        private static IContainer RegisterServices(ContainerBuilder builder) {
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            builder.RegisterType<HomeCinemaContext>().As<DbContext>().InstancePerRequest();
            builder.RegisterType<DbFactory>().As<IDbFactory>().InstancePerRequest();
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerRequest();
            builder.RegisterGeneric(typeof(Repository<>)).As(typeof(IRepository<>)).InstancePerRequest();

            builder.RegisterType<EncryptionService>().As<IEncryptionService>().InstancePerRequest();
            builder.RegisterType<MembershipService>().As<IMembershipService>().InstancePerRequest();

            Container = builder.Build();

            return Container;
        }
    }
}