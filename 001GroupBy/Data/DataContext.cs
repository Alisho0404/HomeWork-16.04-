using Data;
using System.Net;
using _001GroupBy;
using Microsoft.EntityFrameworkCore;

namespace _005.DataAnnotation.Data;

public class DataContext : DbContext
{
    
    
    public DbSet<Customer> Customers  { get; set; }
    public DbSet<Order> Orders  { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }

    public DataContext()
    {
        Database.EnsureDeleted();
        Database.EnsureCreated();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var connectionString = @"server=localhost;
                                port=5432;          
                                database=Practice_db;
                                user id=postgres; 
                                password=909662643";
        optionsBuilder.UseNpgsql(connectionString);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>().HasData(DataProvider.Customer);
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Order>().HasData(DataProvider.Order);
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<OrderItem>().HasData(DataProvider.OrderItem);
        base.OnModelCreating(modelBuilder);
    }
}