using Angular2Mvc.DataAccess;
using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace Angular2Mvc.App_Start
{
    public class IocConfig
    {

        public static void ConfigureContainer()
        {
            //IoC Container setup
            var builder = new ContainerBuilder();

            // Register dependencies in controllers
            builder.RegisterControllers(typeof(MvcApplication).Assembly); //Register MVC Controllers
            builder.RegisterApiControllers(typeof(MvcApplication).Assembly); //Register WebApi Controllers

            // Register dependencies in filter attributes
            builder.RegisterFilterProvider();

            // Register dependencies in custom views
            builder.RegisterSource(new ViewRegistrationSource());

            //Register DbContext
            builder.RegisterType<DbAccessContext>().AsSelf().InstancePerRequest();

            //Register all services
            var assembly = Assembly.GetExecutingAssembly();
            builder.RegisterAssemblyTypes(assembly)
                       .Where(t => t.Name.EndsWith("Service"))
                       .AsSelf()
                       .InstancePerRequest();

            var container = builder.Build();

            // Set MVC DI resolver to use our Autofac container
            System.Web.Mvc.DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            var config = System.Web.Http.GlobalConfiguration.Configuration;
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);

        }
    }
}