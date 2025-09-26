using CrudApi.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Data.Common;

namespace CrudApi.Repositories;

public class AppDbContext : DbContext
{
    public DbSet<Customer> DbCustomer { get; set; }
    public DbSet<Product> DbProduct { get; set; }
    public DbSet<Order> DbOrder { get; set; }

    private readonly IDbConnection _dbConnection;

    public AppDbContext(IDbConnection dbConnection)
    {
        _dbConnection = dbConnection;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(_dbConnection as DbConnection);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>().ToTable("customer");
        modelBuilder.Entity<Customer>().HasKey(c => c.Id);
        modelBuilder.Entity<Customer>()
            .Property(c => c.Name).HasColumnType("VARCHAR").HasMaxLength(100).IsRequired();

        modelBuilder.Entity<Product>().ToTable("product");
        modelBuilder.Entity<Product>().HasKey(p => p.Id);
        modelBuilder.Entity<Product>()
            .Property(p => p.Name).HasColumnType("VARCHAR").HasMaxLength(100).IsRequired();
        modelBuilder.Entity<Product>()
            .Property(c => c.Price).HasColumnType("DECIMAL(16,2)").IsRequired();

        modelBuilder.Entity<Order>().ToTable("order");
        modelBuilder.Entity<Order>().HasKey(o => o.Id);
        modelBuilder.Entity<Order>()
            .Property(o => o.OrderDate).HasColumnType("DATETIME").IsRequired();
        modelBuilder.Entity<Order>()
            .Property(o => o.Total).HasColumnType("DECIMAL(16,2)").IsRequired();
        modelBuilder.Entity<Order>().Property(o => o.CustomerId);
    }
}
