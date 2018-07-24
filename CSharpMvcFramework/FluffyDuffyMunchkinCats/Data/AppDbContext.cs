using Microsoft.EntityFrameworkCore;
using Models;

namespace Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Cat> Cats { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=ASUS\SQLEXPRESS;Database=FluffyDuffyMunckinCats;Integrated Security=True");
            }

            base.OnConfiguring(optionsBuilder);
        }
    }
}
