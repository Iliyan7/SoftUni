using Microsoft.EntityFrameworkCore;
using WebServer.ByTheCakeApplication.Models;

namespace WebServer.ByTheCakeApplication.Data
{
    public class ByTheCakeDbContext : DbContext
    {
        public ByTheCakeDbContext()
        {
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Order> Orders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=ASUS\\SQLEXPRESS;Database=ByTheCakeDb;Integrated Security=True;");
            }

            base.OnConfiguring(optionsBuilder);
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
               .Entity<User>()
               .HasMany(u => u.Orders)
               .WithOne(o => o.User)
               .HasForeignKey(o => o.UserId);

            modelBuilder
                .Entity<OrderProduct>()
                .HasOne(op => op.Order)
                .WithMany(p => p.Products)
                .HasForeignKey(op => op.OrderId);

            modelBuilder
                .Entity<OrderProduct>()
                .HasOne(op => op.Product)
                .WithMany(o => o.Orders)
                .HasForeignKey(op => op.ProductId);

            modelBuilder
                .Entity<OrderProduct>()
                .HasKey(op => new { op.OrderId, op.ProductId });
        }
    }
}
