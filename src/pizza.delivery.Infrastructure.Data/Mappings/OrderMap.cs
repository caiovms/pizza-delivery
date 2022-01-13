using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using pizza.delivery.Domain.Models;

namespace pizza.delivery.Infrastructure.Data.Mappings
{
    public class OrderMap : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            // Primary Key
            builder.HasKey(x => x.Id);

            // Properties
            builder.Property(x => x.Id)
                   .ValueGeneratedOnAdd()
                   .IsRequired();

            builder.Property(x => x.ClientId)
                    .IsRequired();

            builder.Property(x => x.Description)
                   .HasMaxLength(250);

            builder.Property(x => x.Date)
                   .IsRequired();

            // Table & Column Mappings
            builder.ToTable("Orders");
            builder.Property(x => x.Id).HasColumnName("Id");
            builder.Property(x => x.ClientId).HasColumnName("ClientId");
            builder.Property(x => x.Description).HasColumnName("Description");
            builder.Property(x => x.Date).HasColumnName("Date");

            // Relationships
            builder.HasOne<Client>(x => x.Client)
                   .WithMany(x => x.Orders)
                   .HasForeignKey(x => x.ClientId)
                   .IsRequired();

            // Ignores

            // Indexes
        }
    }
}