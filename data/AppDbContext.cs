using Microsoft.EntityFrameworkCore;
using DBase.Models;

namespace DBase.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Products> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Products>().HasData(
                new Products {  ProductName = "холодильник", UnitPrice = 100 },
                new Products {  ProductName = "рыба", UnitPrice = 40 }
            );
        }
    }
}