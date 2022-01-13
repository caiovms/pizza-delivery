using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using pizza.delivery.API.Attributes;
using pizza.delivery.Infrastructure.Serialization;
using System;
using System.Reflection;

namespace pizza.delivery.API.Configurations
{
    public static class MvcConfiguration
    {
        public static void AddMvcConfiguration(this IServiceCollection services)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            services.Configure<ApiBehaviorOptions>(options =>
                    {
                        options.SuppressInferBindingSourcesForParameters = true;
                    })
                    .AddMvc(options =>
                    {
                        options.Filters.Add<ValidationFilterAttribute>();
                    })
                    .AddFluentValidation(options =>
                    {
                        options.RegisterValidatorsFromAssembly(Assembly.Load("pizza.delivery.Application"));
                    })
                    .AddJsonOptions(options =>
                    {
                        var defaultOptions = GlobalSerialization.DefaultOptions;
                        {
                            options.JsonSerializerOptions.ReferenceHandler = defaultOptions.ReferenceHandler;
                            options.JsonSerializerOptions.PropertyNamingPolicy = defaultOptions.PropertyNamingPolicy;
                            options.JsonSerializerOptions.DefaultIgnoreCondition = defaultOptions.DefaultIgnoreCondition;
                        }
                    });
        }
    }
}
