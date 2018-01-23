using FastFood.Data.Configs;
using FastFood.Models;
using Microsoft.EntityFrameworkCore;

namespace FastFood.Data
{
    public class FastFoodDbContext : DbContext
	{
		public FastFoodDbContext()
		{
		}

		public FastFoodDbContext(DbContextOptions options)
			: base(options)
		{
		}

        public DbSet<Employee> Employees { get; set; }

        public DbSet<Position> Positions { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Item> Items { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderItem> OrderItems { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
		{
			if (!builder.IsConfigured)
			{
				builder.UseSqlServer(Configuration.ConnectionString);
			}
		}

		protected override void OnModelCreating(ModelBuilder builder)
		{
            builder.ApplyConfiguration(new PositionConfiguration());

            builder.ApplyConfiguration(new ItemConfiguration());

            builder.ApplyConfiguration(new OrderItemConfiguration());
		}
	}
}