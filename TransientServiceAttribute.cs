using System;

namespace ServiceRegistration
{
    /// <summary>
    /// Flags a service class for registration with transient lifetime.
    /// For more information about service lifetimes see: https://learn.microsoft.com/en-us/dotnet/core/extensions/dependency-injection#service-lifetimes
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class TransientServiceAttribute : Attribute
    {
        public Type? ServiceType { get; }

        /// <summary>
        /// Flags a service class for registration with transient lifetime. Equivalent to services.AddTransient<TService>().
        /// For more information about service lifetimes see: https://learn.microsoft.com/en-us/dotnet/core/extensions/dependency-injection#service-lifetimes
        /// </summary>
        public TransientServiceAttribute() { }

        /// <summary>
        /// Flags a service class for registration with transient lifetime. Equivalent to services.AddTransient<IService, TService>()
        /// For more information about service lifetimes see: https://learn.microsoft.com/en-us/dotnet/core/extensions/dependency-injection#service-lifetimes
        /// </summary>
        public TransientServiceAttribute(Type serviceType)
        {
            ServiceType = serviceType;
        }
    }
}