using DbTuning.Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DbTuning.Api.Data.EntityConfigurations;

public class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        // Composite Key: OrderID, OrderDate
        builder.HasKey(o => new { o.OrderID, o.OrderDate });

        // Column Mappings
        builder.Property(o => o.OrderID).HasColumnName("orderid");
        builder.Property(o => o.OrderDate).HasColumnName("orderdate").IsRequired();
        builder.Property(o => o.CustomerID).HasColumnName("customerid").IsRequired();
        builder.Property(o => o.Total).HasColumnName("total").HasColumnType("decimal(10, 2)");

        // Relationships
        builder.HasOne(o => o.Customer)
            .WithMany(c => c.Orders)
            .HasForeignKey(o => o.CustomerID)
            .OnDelete(DeleteBehavior.Cascade);
    }
}