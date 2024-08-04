using Microsoft.EntityFrameworkCore;
using SecureAPIContainer.Models;

namespace SecureAPIContainer.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed data
            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, Username = "user1", Email = "user1@example.com", Password = "password" },
                new User { Id = 2, Username = "user2", Email = "user2@example.com", Password = "password" },
                new User { Id = 3, Username = "user3", Email = "user3@example.com", Password = "password" },
                new User { Id = 4, Username = "user4", Email = "user4@example.com", Password = "password" },
                new User { Id = 5, Username = "user5", Email = "user5@example.com", Password = "password" },
                new User { Id = 6, Username = "user6", Email = "user6@example.com", Password = "password" },
                new User { Id = 7, Username = "user7", Email = "user7@example.com", Password = "password" },
                new User { Id = 8, Username = "user8", Email = "user8@example.com", Password = "password" },
                new User { Id = 9, Username = "user9", Email = "user9@example.com", Password = "password" },
                new User { Id = 10, Username = "user10", Email = "user10@example.com", Password = "password" }
            );

            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Name = "Product1", Description = "Description1", Price = 10.00M, Stock = 100 },
                new Product { Id = 2, Name = "Product2", Description = "Description2", Price = 20.00M, Stock = 200 },
                new Product { Id = 3, Name = "Product3", Description = "Description3", Price = 30.00M, Stock = 300 },
                new Product { Id = 4, Name = "Product4", Description = "Description4", Price = 40.00M, Stock = 400 },
                new Product { Id = 5, Name = "Product5", Description = "Description5", Price = 50.00M, Stock = 500 },
                new Product { Id = 6, Name = "Product6", Description = "Description6", Price = 60.00M, Stock = 600 },
                new Product { Id = 7, Name = "Product7", Description = "Description7", Price = 70.00M, Stock = 700 },
                new Product { Id = 8, Name = "Product8", Description = "Description8", Price = 80.00M, Stock = 800 },
                new Product { Id = 9, Name = "Product9", Description = "Description9", Price = 90.00M, Stock = 900 },
                new Product { Id = 10, Name = "Product10", Description = "Description10", Price = 100.00M, Stock = 1000 }
            );
        }
    }
}