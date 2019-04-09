using System;
using System.Linq;
using FlandersOpen.Domain.Entities;
using FlandersOpen.Domain.SeedWork;
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
        public DbSet<Timeslot> Timeslots { get; set; }
        public DbSet<Game> Events { get; set; }
        public DbSet<Referee> Referees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("fo");

            modelBuilder.Entity<User>(ConfigureUser);
            modelBuilder.Entity<Competition>(ConfigureCompetition);
            modelBuilder.Entity<Pitch>(ConfigurePitches);
            modelBuilder.Entity<Timeslot>(ConfigureTimeslots);
            modelBuilder.Entity<Game>(ConfigureEvents);
            modelBuilder.Entity<Referee>(ConfigureReferees);
        }

        private void ConfigureReferees(EntityTypeBuilder<Referee> builder)
        {
            builder.Property<DateTime>("ModificationDate");
            builder.OwnsOne(e => e.ShortName).Property(e => e.Value).HasColumnName("ShortName").IsRequired();
        }

        private void ConfigureEvents(EntityTypeBuilder<Game> builder)
        {
            builder.Property<DateTime>("ModificationDate");           
        }

        private void ConfigureTimeslots(EntityTypeBuilder<Timeslot> builder)
        {
            builder.Property<DateTime>("ModificationDate");
            builder.Property(e => e.PitchId).IsRequired();
            builder.OwnsOne(e => e.StartTime).Property(e => e.Value).HasColumnName("StartTime").IsRequired();
            builder.OwnsOne(e => e.EndTime).Property(e => e.Value).HasColumnName("EndTime").IsRequired();
        }

        private void ConfigurePitches(EntityTypeBuilder<Pitch> builder)
        {
            builder.Property<DateTime>("ModificationDate");
            builder.Property(e => e.Name).IsRequired();
            builder.Property(e => e.Number).IsRequired();
            builder.Property(e => e.OrderNumber).IsRequired();
            builder.HasMany<Timeslot>().WithOne(e => e.Pitch).HasForeignKey(e => e.PitchId);
        }

        private void ConfigureCompetition(EntityTypeBuilder<Competition> builder)
        {
            builder.Property<DateTime>("ModificationDate");
            builder.Property(e => e.Name).IsRequired();
            builder.OwnsOne(e => e.ShortName).Property(e => e.Value).HasColumnName("ShortName").IsRequired();
            builder.OwnsOne(e => e.Color).Property(e => e.Value).HasColumnName("Color").IsRequired();
        }

        private static void ConfigureUser(EntityTypeBuilder<User> builder)
        {
            builder.Property<DateTime>("ModificationDate");
            builder.Property(e => e.Username).IsRequired();
        }

        public override int SaveChanges()
        {
            var timestamp = DateTime.Now;

            foreach (var entry in ChangeTracker.Entries()
                .Where(e => e.Entity is Entity && (e.State == EntityState.Added || e.State == EntityState.Modified)))
            {
                entry.Property("ModificationDate").CurrentValue = timestamp;
            }

            return base.SaveChanges();
        }
    }
}
