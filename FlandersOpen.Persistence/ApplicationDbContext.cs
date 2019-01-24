using System;
using System.Linq;
using FlandersOpen.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.DependencyInjection;

namespace FlandersOpen.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Competition> Competitions { get; set; }
        public DbSet<Pitch> Pitches { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("fo");

            modelBuilder.Entity<User>(ConfigureUser);
            modelBuilder.Entity<Competition>(ConfigureCompetition);
            modelBuilder.Entity<Pitch>(ConfigurePitches);
        }

        private void ConfigurePitches(EntityTypeBuilder<Pitch> builder)
        {
            builder.Property(e => e.Name).IsRequired();
            builder.Property(e => e.Number).IsRequired();
            builder.HasMany<Timeslot>();
        }

        private void ConfigureCompetition(EntityTypeBuilder<Competition> builder)
        {
            builder.Property(e => e.Name).IsRequired();
            builder.OwnsOne(e => e.ShortName).Property(e => e.Value).HasColumnName("ShortName").IsRequired();
            builder.OwnsOne(e => e.Color).Property(e => e.Value).HasColumnName("Color").IsRequired();
        }

        private static void ConfigureUser(EntityTypeBuilder<User> builder)
        {            
            builder.Property(e => e.Username).IsRequired();
        }
    }
}
