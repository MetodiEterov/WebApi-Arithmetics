using System.Web.Http;

using EntitiesLayer;

using RepositoryLayer;

using ServiceLayer;

using Unity;
using Unity.Lifetime;

using WebApiLayer.Models;

namespace WebApiLayer
{
    /// <summary>
    /// WebApiConfig class
    /// </summary>
    public static class WebApiConfig
    {
        /// <summary>
        /// Register static method
        /// </summary>
        /// <param name="config"></param>
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
