
using BeSpokedBikesSalesTracker.Entities;
using Microsoft.EntityFrameworkCore;

public class SalesTrackingContext : DbContext
{
    public SalesTrackingContext(DbContextOptions<SalesTrackingContext> options) : base(options) { }

    public DbSet<Product> Products { get; set; }
    public DbSet<Salesperson> Salespersons { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Sale> Sales { get; set; }
    public DbSet<Discount> Discounts { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>().HasIndex(p => p.Name).IsUnique();
        modelBuilder.Entity<Salesperson>().HasIndex(s => new { s.FirstName, s.LastName }).IsUnique();
        DataSeeder.SeedData(this);
    }
}