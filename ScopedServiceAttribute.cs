using System;

namespace ServiceRegistration
{
    /// <summary>
    /// Flags a service class for registration with scoped lifetime.
    /// For more information about service lifetimes see: https://learn.microsoft.com/en-us/dotnet/core/extensions/dependency-injection#service-lifetimes
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class ScopedServiceAttribute : Attribute
    {
        public Type? ServiceType { get; }

        /// <summary>
        /// Flags a service class for registration with scoped lifetime. Equivalent to services.AddScoped<TService>().
        /// For more information about service lifetimes see: https://learn.microsoft.com/en-us/dotnet/core/extensions/dependency-injection#service-lifetimes
        /// </summary>
        public ScopedServiceAttribute() { }

        /// <summary>
        /// Flags a service class for registration with scoped lifetime. Equivalent to services.AddScoped<IService, TService>()
        /// For more information about service lifetimes see: https://learn.microsoft.com/en-us/dotnet/core/extensions/dependency-injection#service-lifetimes
        /// </summary>
        public ScopedServiceAttribute(Type serviceType)
        {
            ServiceType = serviceType;
        }
    }
}