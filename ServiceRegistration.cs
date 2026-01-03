using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;

namespace ServiceRegistration
{
    /// <summary>
    /// Service registration extensions for automatic registration based on service lifetime attributes.
    /// For more information see: https://github.com/delebru/dotnet-service-registry
    /// </summary>
    public static class ServiceRegistration
    {
        /// <summary>
        /// Registers all services in the provided assembly based on their service lifetime attributes. 
        /// Usually "builder.Services.AddAppServices(System.Reflection.Assembly.GetExecutingAssembly());"
        /// For more information see: https://github.com/delebru/dotnet-service-registry
        /// </summary>
        public static void AddAppServices(this IServiceCollection services, Assembly assembly)
        {
            var assemblyTypes = assembly.GetTypes();

            // Register hosted services
            {
                foreach (var hostedServiceType in assemblyTypes.GetTypesWithAttribute(typeof(HostedServiceAttribute)))
                {                    
                    services.TryAddEnumerable(ServiceDescriptor.Singleton(typeof(IHostedService), hostedServiceType));
                }
            }
            
            // Register scoped services
            {
                foreach (var scopedServiceType in assemblyTypes.GetTypesWithAttribute(typeof(ScopedServiceAttribute)))
                {
                    if (scopedServiceType.GetCustomAttribute<ScopedServiceAttribute>()?.ServiceType is Type serviceType)
                    {
                        services.AddScoped(serviceType, scopedServiceType);
                    }
                    else
                    {
                        services.AddScoped(scopedServiceType);
                    }
                }
            }

            // Register singleton services
            {
                foreach (var singletonServiceType in assemblyTypes.GetTypesWithAttribute(typeof(SingletonServiceAttribute)))
                {
                    if (singletonServiceType.GetCustomAttribute<SingletonServiceAttribute>()?.ServiceType is Type serviceType)
                    {
                        services.AddSingleton(serviceType, singletonServiceType);
                    }
                    else
                    {
                        services.AddSingleton(singletonServiceType);
                    }
                }
            }


            // Register transient services
            {
                foreach (var transientServiceType in assemblyTypes.GetTypesWithAttribute(typeof(TransientServiceAttribute)))
                {
                    if (transientServiceType.GetCustomAttribute<TransientServiceAttribute>()?.ServiceType is Type serviceType)
                    {
                        services.AddTransient(serviceType, transientServiceType);
                    }
                    else
                    {
                        services.AddTransient(transientServiceType);
                    }
                }
            }
        }

        private static IEnumerable<Type> GetTypesWithAttribute(this Type[] types, Type attributeType)
            => types.Where(x => x.GetCustomAttributes(attributeType, true).Length > 0);
    }
}