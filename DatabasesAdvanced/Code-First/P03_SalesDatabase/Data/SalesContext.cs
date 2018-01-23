using Microsoft.EntityFrameworkCore;
using P03_SalesDatabase.Data.Configuration;
using P03_SalesDatabase.Data.Models;

namespace P03_SalesDatabase
{
    public class SalesContext : DbContext
    {
        public SalesContext()
        {
        }

        public SalesContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Product> Prodcuts { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<Sale> Sales { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=ASUS\SQLEXPRESS;Database=Sales;Integrated Security=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration<Product>(new ProductConfiguration());
            modelBuilder.ApplyConfiguration<Customer>(new CustomerConfiguration());
            modelBuilder.ApplyConfiguration<Store>(new StoreConfiguration());
            modelBuilder.ApplyConfiguration<Sale>(new SaleConfiguration());
        }
    }
}