using DbTuning.Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DbTuning.Api.Data.EntityConfigurations;

public class OrderDetailConfiguration : IEntityTypeConfiguration<OrderDetail>
{
    public void Configure(EntityTypeBuilder<OrderDetail> builder)
    {
        // Composite Key: OrderID, OrderDate, ProductID
        builder.HasKey(od => new { od.OrderID, od.OrderDate, od.ProductID });

        // Column Mappings
        builder.Property(od => od.OrderID).HasColumnName("orderid");
        builder.Property(od => od.OrderDate).HasColumnName("orderdate").IsRequired();
        builder.Property(od => od.ProductID).HasColumnName("productid");
        builder.Property(od => od.Quantity).IsRequired().HasColumnName("quantity");
        builder.Property(od => od.Price).HasColumnType("decimal(10, 2)").HasColumnName("price");

        // Relationships
        builder.HasOne(od => od.Order)
            .WithMany(o => o.OrderDetails)
            .HasForeignKey(od => new { od.OrderID, od.OrderDate });

        builder.HasOne(od => od.Product)
            .WithMany()
            .HasForeignKey(od => od.ProductID);
    }
}