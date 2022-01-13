using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using pizza.delivery.Domain.Services.Interfaces;
using pizza.delivery.Infrastructure.DependencyInjection;
using System;

namespace pizza.delivery.Domain.Services.Modules
{
    public class ServicesModule : IModuleRegistry
    {
        public string ModuleName => nameof(ServicesModule);

        public void Registry(IServiceCollection services, IConfiguration configuration = null, ILoggerFactory loggerFactory = null, IHostEnvironment hostEnvironment = null)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            services.AddTransient<IClientService, ClientService>();
            services.AddTransient<IOrderService, OrderService>();
        }
    }
}
