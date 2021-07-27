using System;
using System.Collections.Generic;
using System.Web.Http.Dependencies;

using Unity;

namespace WebApiLayer.Models
{
    /// <summary>
    /// The UnityResolver class contains the resolver logic
    /// </summary>
    public class UnityResolver : IDependencyResolver
    {
        protected IUnityContainer container;

        public UnityResolver(IUnityContainer container)
        {
            this.container = container ?? throw new ArgumentNullException(nameof(container));
        }

        /// <summary>
        /// GetService method
        /// </summary>
        /// <param name="serviceType"></param>
        /// <returns></returns>
        public object GetService(Type serviceType)
        {
            try
            {
                return container.Resolve(serviceType);
            }
            catch (ResolutionFailedException exception)
            {
                throw new InvalidOperationException(
                    $"Unable to resolve service for type {serviceType}.",
                    exception);
            }
        }

        /// <summary>
        /// GetServices method
        /// </summary>
        /// <param name="serviceType"></param>
        /// <returns></returns>
        public IEnumerable<object> GetServices(Type serviceType)
        {
            try
            {
                return container.ResolveAll(serviceType);
            }
            catch (ResolutionFailedException exception)
            {
                throw new InvalidOperationException(
                    $"Unable to resolve service for type {serviceType}.",
                    exception);
            }
        }

        /// <summary>
        /// BeginScope method
        /// </summary>
        /// <returns></returns>
        public IDependencyScope BeginScope()
        {
            var child = container.CreateChildContainer();
            return new UnityResolver(child);
        }

        /// <summary>
        /// Dispose method
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
        }

        /// <summary>
        /// Dispose virtual method
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing)
        {
            container.Dispose();
        }
    }
}
