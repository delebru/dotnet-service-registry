using System;

namespace ServiceRegistration
{
    /// <summary>
    /// Flags a service class for registration with singleton lifetime.
    /// For more information about service lifetimes see: https://learn.microsoft.com/en-us/dotnet/core/extensions/dependency-injection#service-lifetimes
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class SingletonServiceAttribute : Attribute
    {
        public Type? ServiceType { get; }

        /// <summary>
        /// Flags a service class for registration with singleton lifetime. Equivalent to services.AddSingleton<TService>().
        /// For more information about service lifetimes see: https://learn.microsoft.com/en-us/dotnet/core/extensions/dependency-injection#service-lifetimes
        /// </summary>
        public SingletonServiceAttribute() { }

        /// <summary>
        /// Flags a service class for registration with singleton lifetime. Equivalent to services.AddSingleton<IService, TService>()
        /// For more information about service lifetimes see: https://learn.microsoft.com/en-us/dotnet/core/extensions/dependency-injection#service-lifetimes
        /// </summary>
        public SingletonServiceAttribute(Type serviceType)
        {
            ServiceType = serviceType;
        }
    }
}