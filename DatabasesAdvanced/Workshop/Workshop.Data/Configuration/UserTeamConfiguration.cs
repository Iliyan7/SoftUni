using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Workshop.Models;

namespace Workshop.Data.Configuration
{
    class UserTeamConfiguration : IEntityTypeConfiguration<UserTeam>
    {
        public void Configure(EntityTypeBuilder<UserTeam> builder)
        {
            builder.HasKey(et => new { et.UserId, et.TeamId });

            builder.HasOne(et => et.User)
                .WithMany(e => e.UserTeams)
                .HasForeignKey(et => et.TeamId);

            builder.HasOne(et => et.Team)
                .WithMany(t => t.UserTeams)
                .HasForeignKey(et => et.TeamId);
        }
    }
}
