//using Microsoft.EntityFrameworkCore;

//namespace pizza.delivery.Infrastructure.Data
//{
//    public class PizzaDeliveryReadonlyDbContext : DbContext
//    {
//        public PizzaDeliveryReadonlyDbContext(DbContextOptions<PizzaDeliveryReadonlyDbContext> options)
//            : base(options)
//        {
//            ChangeTracker.LazyLoadingEnabled = false;
//            ChangeTracker.AutoDetectChangesEnabled = false;
//            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
//        }

//        protected override void OnModelCreating(ModelBuilder builder)
//        {
//            builder.ApplyConfigurationsFromAssembly(typeof(PizzaDeliveryReadonlyDbContext).Assembly);
//        }
//    }
//}