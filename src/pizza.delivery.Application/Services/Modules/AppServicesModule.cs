using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using pizza.delivery.Application.Services.Interfaces;
using pizza.delivery.Infrastructure.DependencyInjection;

namespace pizza.delivery.Application.Services.Modules
{
    public class AppServicesModule : IModuleRegistry
    {
        public string ModuleName => nameof(AppServicesModule);

        public void Registry(IServiceCollection services, IConfiguration configuration = null, ILoggerFactory loggerFactory = null, IHostEnvironment hostEnvironment = null)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            services.AddTransient<IOrderAppService, OrderAppService>();
        }
    }
}