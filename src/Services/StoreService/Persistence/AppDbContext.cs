using StoreService.Domain.Users;
using Microsoft.EntityFrameworkCore;
using StoreService.Domain.Orders;
using StoreService.Domain.Products;

namespace StoreService.Persistence
{
    public sealed class AppDbContext : DbContext
    {
        #region DbSets

        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }

        #endregion

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Apply Configurations
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);

            // Creating Model
            base.OnModelCreating(modelBuilder);
        }
    }
}