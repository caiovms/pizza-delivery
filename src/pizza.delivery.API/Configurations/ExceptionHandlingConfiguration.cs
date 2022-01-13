using Microsoft.Extensions.DependencyInjection;
using pizza.delivery.API.GlobalExceptionHandling;
using System;

namespace pizza.delivery.API.Configurations
{
    public static class ExceptionHandlingConfiguration
    {
        public static void AddExceptionHandlingConfiguration(this IServiceCollection services)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            services.AddTransient<IExceptionHandler, ExceptionHandler>();
        }
    }
}
