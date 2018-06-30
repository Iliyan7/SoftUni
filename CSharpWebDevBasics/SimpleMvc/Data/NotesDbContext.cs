using Microsoft.EntityFrameworkCore;
using Models;

namespace Data
{
    public class NotesDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Note> Notes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=ASUS\SQLEXPRESS;Database=Notes;Integrated Security=True");
            }

            base.OnConfiguring(optionsBuilder);
        }
    }
}
