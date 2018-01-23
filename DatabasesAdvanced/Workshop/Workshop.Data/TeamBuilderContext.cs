using Microsoft.EntityFrameworkCore;
using Workshop.Data.Configuration;
using Workshop.Models;

namespace Workshop.Data
{
    public class TeamBuilderContext : DbContext
    {
        public TeamBuilderContext()
        {
        }

        public TeamBuilderContext(DbContextOptions options)
            : base(options)
        {  
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=ASUS\SQLEXPRESS;Database=TeamBuilder;Integrated Security=True");
            }
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Event> Events { get; set; }

        public DbSet<Team> Teams { get; set; }

        public DbSet<Invitation> Invitations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());

            modelBuilder.ApplyConfiguration(new TeamConfiguration());

            modelBuilder.ApplyConfiguration(new EventConfiguration());

            modelBuilder.ApplyConfiguration(new EventTeamConfiguration());

            modelBuilder.ApplyConfiguration(new UserTeamConfiguration());
        }
    }
}
