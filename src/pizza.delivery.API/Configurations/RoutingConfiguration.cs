using Microsoft.Extensions.DependencyInjection;
using System;

namespace pizza.delivery.API.Configurations
{
    public static class RoutingConfiguration
    {
        public static void AddRoutingConfiguration(this IServiceCollection services)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            services.AddRouting(options =>
            {
                options.LowercaseUrls = true;
                options.LowercaseQueryStrings = true;
            });
        }
    }
}