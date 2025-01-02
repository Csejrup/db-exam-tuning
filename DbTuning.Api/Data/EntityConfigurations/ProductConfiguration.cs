using DbTuning.Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DbTuning.Api.Data.EntityConfigurations;
public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasKey(p => p.ProductID);
        builder.Property(p => p.ProductID).HasColumnName("productid");
        builder.Property(p => p.Name).IsRequired().HasMaxLength(100).HasColumnName("name");
        builder.Property(p => p.Category).IsRequired().HasMaxLength(50).HasColumnName("category");
        builder.Property(p => p.Price).HasColumnType("decimal(10, 2)").HasColumnName("price");
        builder.Property(p => p.Stock).IsRequired().HasColumnName("stock");
    }
}
