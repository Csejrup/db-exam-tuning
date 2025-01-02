using DbTuning.Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DbTuning.Api.Data.EntityConfigurations;

public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.HasKey(c => c.CustomerID);
        builder.Property(c => c.CustomerID).HasColumnName("customerid");
        builder.Property(c => c.Name).IsRequired().HasMaxLength(100).HasColumnName("name");
        builder.Property(c => c.Email).IsRequired().HasMaxLength(100).HasColumnName("email");
        builder.Property(c => c.Phone).HasMaxLength(8).HasColumnName("phone");
    }
}