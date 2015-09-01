using DataManagerContract;
using DataAccess;
using EntityTypes;
using DBSource;
using Microsoft.Practices.Unity;
using ProductStore.Resolver;
using DataManager;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;

namespace WebApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var container = new UnityContainer();
            container.RegisterType<IGroupContract, GroupDataManager>(new HierarchicalLifetimeManager());
            container.RegisterType<IUserContract, UserDataManager>(new HierarchicalLifetimeManager());
            container.RegisterType<IStoryContract, StoryDataManager>(new HierarchicalLifetimeManager());
            container.RegisterType<IGroupRepository, GroupRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IUserRepository, UserRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IStoryRepository, StoryRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<DbContext, EFDataContext>(new HierarchicalLifetimeManager());
            config.DependencyResolver = new UnityResolver(container);
            config.EnableCors();
            // Web API routes
            config.MapHttpAttributeRoutes();
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            var appXmlType = config.Formatters.XmlFormatter.SupportedMediaTypes.FirstOrDefault(t => t.MediaType == "application/xml");
            config.Formatters.XmlFormatter.SupportedMediaTypes.Remove(appXmlType);
        }
    }
}
