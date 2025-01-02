using DbTuning.Api.Data.EntityConfigurations;
using DbTuning.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace DbTuning.Api.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Product> Products { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<OrderDetail> OrderDetails { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>().ToTable("products");
        modelBuilder.Entity<Customer>().ToTable("customers");
        modelBuilder.Entity<Order>().ToTable("orders");
        modelBuilder.Entity<OrderDetail>().ToTable("orderdetails");
        modelBuilder.ApplyConfiguration(new ProductConfiguration());
        modelBuilder.ApplyConfiguration(new OrderConfiguration());
        modelBuilder.ApplyConfiguration(new CustomerConfiguration());
        modelBuilder.ApplyConfiguration(new OrderDetailConfiguration());
    }
}