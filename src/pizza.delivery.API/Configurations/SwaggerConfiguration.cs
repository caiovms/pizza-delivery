using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using pizza.delivery.API.Swagger.Filters;
using pizza.delivery.API.Swagger.Options;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.IO;
using System.Reflection;

namespace pizza.delivery.API.Configurations
{
    public static class SwaggerConfiguration
    {
        public static void AddSwaggerConfiguration(this IServiceCollection services)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();
            services.AddSwaggerGen(options =>
            {
                options.DescribeAllParametersInCamelCase();
                options.OperationFilter<SwaggerDefaultValues>();

                var appPath = AppDomain.CurrentDomain.BaseDirectory;

                var entryAssembly = Assembly.GetEntryAssembly();
                var assemblyName = entryAssembly?.GetName();
                var appName = assemblyName?.Name;

                var filePath = Path.Combine(appPath, $"{appName ?? "pizza.delivery.API"}.xml");

                options.IncludeXmlComments(filePath);
            });
        }
    }
}