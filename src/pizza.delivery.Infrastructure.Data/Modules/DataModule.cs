using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using pizza.delivery.Infrastructure.Data.Interfaces;
using pizza.delivery.Infrastructure.Data.Repositories;
using pizza.delivery.Infrastructure.DependencyInjection;
using System;

namespace pizza.delivery.Infrastructure.Data.Modules
{
    public  class DataModule : IModuleRegistry
    {
        public string ModuleName => nameof(DataModule);

        public void Registry(IServiceCollection services, IConfiguration configuration = null, ILoggerFactory loggerFactory = null, IHostEnvironment hostEnvironment = null)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            services.AddTransient<IClientRepository, ClientRepository>();
            services.AddTransient<IOrderRepository, OrderRepository>();
            services.AddDbContext<PizzaDeliveryDbContext>(opt => opt.UseInMemoryDatabase("PizzaDeliveryDb"));
        }
    }
}