using System.Web.Http;

using EntitiesLayer;

using RepositoryLayer;

using ServiceLayer;

using Unity;
using Unity.Lifetime;

using WebApiLayer.Models;

namespace WebApiLayer
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            var container = new UnityContainer();
            container.RegisterType<IMathWebClient, MathWebClient>(new HierarchicalLifetimeManager());
            container.RegisterType<ILoggerManager, LoggerManager>(new HierarchicalLifetimeManager());
            config.DependencyResolver = new UnityResolver(container);

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
