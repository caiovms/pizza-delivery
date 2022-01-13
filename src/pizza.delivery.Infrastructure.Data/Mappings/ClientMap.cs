using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using pizza.delivery.Domain.Models;

namespace pizza.delivery.Infrastructure.Data.Mappings
{
    public class ClientMap : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            // Primary Key
            builder.HasKey(x => x.ClientId);

            // Properties
            builder.Property(x => x.ClientId)
                   .ValueGeneratedOnAdd()
                   .IsRequired();

            builder.Property(x => x.Name)
                   .IsRequired()
                   .HasMaxLength(250);

            builder.Property(x => x.Email)
                   .IsRequired()
                   .HasMaxLength(250);

            builder.Property(x => x.Phone)
                   .IsRequired()
                   .HasMaxLength(50);

            // Table & Column Mappings
            builder.ToTable("Clientes");
            builder.Property(x => x.ClientId).HasColumnName("Id");
            builder.Property(x => x.Name).HasColumnName("Name");
            builder.Property(x => x.Email).HasColumnName("Email");
            builder.Property(x => x.Phone).HasColumnName("Phone");

            // Relationships

            // Ignores

            // Indexes
        }
    }
}