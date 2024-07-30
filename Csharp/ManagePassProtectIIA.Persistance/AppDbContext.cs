using ManagePassProtectIIA.Models;
using ManagePassProtectIIA.Persistance.EntityTypeConfigurations;
using Microsoft.EntityFrameworkCore;

namespace ManagePassProtectIIA.Persistance
{
    public class AppDbContext : DbContext
    {
        public DbSet<Models.Type> Types { get; set; }
        public DbSet<Models.Product> Products { get; set; }
        public DbSet<User> Users { get; set; }

        public AppDbContext(DbContextOptions options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TypeConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
        }
    }
}
