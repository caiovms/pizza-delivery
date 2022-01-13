using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using pizza.delivery.API.Configurations;
using pizza.delivery.API.Middlewares;
using pizza.delivery.Infrastructure.Data;
using System;

namespace pizza.delivery.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();
            services.AddExceptionHandlingConfiguration();
            services.AddRequestLocalizationConfiguration();
            services.AddVersioningConfiguration();
            services.AddRoutingConfiguration();
            services.AddMvcConfiguration();
            services.AddCompressionConfiguration();
            services.AddAutoMapperConfiguration();
            services.AddSwaggerConfiguration();
            services.AddModulesConfiguration(Configuration);
            services.AddDatabaseDeveloperPageExceptionFilter();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IApiVersionDescriptionProvider provider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseCors(builder =>
            {
                builder.AllowAnyOrigin();
                builder.AllowAnyMethod();
                builder.AllowAnyHeader();
            });

            app.UseMiddleware<ExceptionHandlerMiddleware>();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                foreach (var description in provider.ApiVersionDescriptions)
                {
                    options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json", $"API {description.GroupName.ToUpperInvariant()}");
                }
            });

            SeedDatabase(app);
        }

        private static void SeedDatabase(IApplicationBuilder app)
        {
            var context = app.ApplicationServices.GetService<PizzaDeliveryDbContext>();

            var client = new Domain.Models.Client
            {
                Name = "Caio Vinícius Meneses Silva",
                Email = "caio_vms@outlook.com",
                Phone = "+5579999080228"
            };
            context.Clients.Add(client);

            var client2 = new Domain.Models.Client
            {
                Name = "Mark Robert",
                Email = "mark_rbt@outlook.com",
                Phone = "+5581999085555"
            };
            context.Clients.Add(client2);

            var order = new Domain.Models.Order
            {
                ClientId = 1,
                Date = DateTime.Now,
                Description = "Pizza Calabresa"
            };
            context.Orders.Add(order);

            var order2 = new Domain.Models.Order
            {
                ClientId = 2,
                Date = DateTime.Now,
                Description = "Pizza Bacon"
            };
            context.Orders.Add(order2);

            context.SaveChanges();
        }
    }
}
