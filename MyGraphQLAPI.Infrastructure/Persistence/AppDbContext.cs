// src/MyGraphQLAPI.Infrastructure/Persistence/AppDbContext.cs
using Microsoft.EntityFrameworkCore;
using MyGraphQLAPI.Domain.Entities;

namespace MyGraphQLAPI.Infrastructure.Persistence
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }

        // Optional: Configure schema, relationships etc.
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Configure Product entity if needed (e.g., required fields, indexing)
            modelBuilder.Entity<Product>().HasKey(p => p.Id);
            modelBuilder.Entity<Product>().Property(p => p.Name).IsRequired().HasMaxLength(200);
            // modelBuilder.Entity<Product>().Property(p => p.Price).HasColumnType("decimal(18,2)");

            // Add some initial data for testing
            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Name = "Laptop", Description = "High performance laptop", Price = 1200.00m, Stock = 10 },
                new Product { Id = 2, Name = "Keyboard", Description = "Mechanical keyboard", Price = 75.00m, Stock = 50 },
                new Product { Id = 3, Name = "Mouse", Description = "Wireless mouse", Price = 25.50m, Stock = 100 }
            );
        }
    }
}