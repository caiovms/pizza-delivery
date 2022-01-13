using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Globalization;

namespace pizza.delivery.API.Configurations
{
    public static class RequestLocalizationConfiguration
    {
        public static void AddRequestLocalizationConfiguration(this IServiceCollection services)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            services.Configure<RequestLocalizationOptions>(options =>
            {
                options.DefaultRequestCulture = new RequestCulture(CultureInfo.InvariantCulture);
                options.SupportedCultures.Clear();
                options.SupportedUICultures.Clear();
            });
        }
    }
}