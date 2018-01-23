using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Workshop.Models;

namespace Workshop.Data.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(u => u.Username)
                .IsRequired();

            builder.HasIndex(u => u.Username)
                  .IsUnique();

            builder.Property(u => u.Password)
                .IsRequired();

            builder.Property(u => u.FirstName)
                .HasMaxLength(25);

            builder.Property(u => u.LastName)
                .HasMaxLength(25);

            builder.Property(u => u.Password)
                .HasMaxLength(30);

        }
    }
}
