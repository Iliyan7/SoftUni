using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using Workshop.Models;

namespace Workshop.Data.Configuration
{
    public class TeamConfiguration : IEntityTypeConfiguration<Team>
    {
        public void Configure(EntityTypeBuilder<Team> builder)
        {
            builder.Property(t => t.Name)
                .IsRequired();

            builder.HasIndex(t => t.Name)
                .IsUnique();

            builder.Property(t => t.Acronym)
                .IsRequired();

        }
    }
}
