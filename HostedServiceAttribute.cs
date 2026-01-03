using System;

namespace ServiceRegistration
{
    /// <summary>
    /// Flags a service class for registration as hosted. Hosted services must implement IHostedService, or inherit from BackgroundService.
    /// Fore more information about hosted services see: https://learn.microsoft.com/en-us/aspnet/core/fundamentals/host/hosted-services
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class HostedServiceAttribute : Attribute
    {
        /// <summary>
        /// Flags a service class for registration as hosted. Hosted services must implement IHostedService, or inherit from BackgroundService.
        /// Equivalent to services.AddHostedService<TService>().
        /// Fore more information about hosted services see: https://learn.microsoft.com/en-us/aspnet/core/fundamentals/host/hosted-services
        /// </summary>
        public HostedServiceAttribute() { }
    }
}