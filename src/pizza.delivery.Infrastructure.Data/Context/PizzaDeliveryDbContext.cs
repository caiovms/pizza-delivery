using Microsoft.EntityFrameworkCore;
using pizza.delivery.Domain.Models;
using pizza.delivery.Infrastructure.Data.Mappings;
using System;

namespace pizza.delivery.Infrastructure.Data
{
    public class PizzaDeliveryDbContext : DbContext
    {
        public PizzaDeliveryDbContext(DbContextOptions<PizzaDeliveryDbContext> options) : base(options)
        {
        }

        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Order> Orders{ get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new ClientMap());
            builder.ApplyConfiguration(new OrderMap());
        }
    }
}