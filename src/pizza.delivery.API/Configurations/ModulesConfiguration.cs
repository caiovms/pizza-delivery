using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using pizza.delivery.Application.Services.Modules;
using pizza.delivery.Domain.Services.Modules;
using pizza.delivery.Infrastructure.Data.Modules;
using pizza.delivery.Infrastructure.DependencyInjection;
using System;

namespace pizza.delivery.API.Configurations
{
    public static class ModulesConfiguration
    {
        public static void AddModulesConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            if (configuration == null)
            {
                throw new ArgumentNullException(nameof(configuration));
            }

            IModuleCollection moduleCollection = new ModuleCollection();

            moduleCollection.AddModule<AppServicesModule>()
                            .AddModule<ServicesModule>()
                            .AddModule<DataModule>()
                            .Registry(services, configuration);
        }
    }
}