using System;
using System.Linq;
using FlandersOpen.Domain.Entities;
using FlandersOpen.Domain.SeedWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FlandersOpen.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Competition> Competitions { get; set; }
        public DbSet<Pitch> Pitches { get; set; }        
        public DbSet<Game> Games { get; set; }        
        public DbSet<Referee> Referees { get; set; }
        public DbSet<Team> Teams { get; set; }

        //public DbSet<Gameslot> Gameslots { get; set; }
        //public DbSet<Timeslot> Timeslots { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("fo");

            modelBuilder.Entity<User>(ConfigureUser);
            modelBuilder.Entity<Country>(ConfigureCountry);
            modelBuilder.Entity<Competition>(ConfigureCompetition);
            modelBuilder.Entity<Pitch>(ConfigurePitches);
            modelBuilder.Entity<Timeslot>(ConfigureTimeslots);
            modelBuilder.Entity<Game>(ConfigureGame);
            modelBuilder.Entity<Gameslot>(ConfigureGameslot);
            modelBuilder.Entity<Team>(ConfigureTeam);
            modelBuilder.Entity<Referee>(ConfigureReferees);
        }

        private void ConfigureTeam(EntityTypeBuilder<Team> builder)
        {
            builder.Property<DateTime>("ModificationDate");

        }

        private void ConfigureGameslot(EntityTypeBuilder<Gameslot> builder)
        {
            builder.Property<DateTime>("ModificationDate");
            builder.HasOne(e => e.Team); //TODO withmany?
            builder.OwnsOne(e => e.Score).Property(e => e.FairplayPoints).HasColumnName("FairplayPoints");
            builder.OwnsOne(e => e.Score).Property(e => e.Scored).HasColumnName("Scored");
            builder.OwnsOne(e => e.Score).Property(e => e.Against).HasColumnName("Against");
            builder.OwnsOne(e => e.Score).Property(e => e.Forfeited).HasColumnName("Forfeited");
            builder.OwnsOne(e => e.Score).Property(e => e.YellowCards).HasColumnName("YellowCards");
            builder.OwnsOne(e => e.Score).Property(e => e.RedCards).HasColumnName("RedCards");
        }

        private void ConfigureCountry(EntityTypeBuilder<Country> builder)
        {
            builder.Property<DateTime>("ModificationDate");
        }

        private void ConfigureReferees(EntityTypeBuilder<Referee> builder)
        {
            builder.Property<DateTime>("ModificationDate");
            builder.OwnsOne(e => e.ShortName).Property(e => e.Value).HasColumnName("ShortName").IsRequired();
        }

        private void ConfigureGame(EntityTypeBuilder<Game> builder)
        {
            builder.Property<DateTime>("ModificationDate");
            builder.Property(e => e.Number).IsRequired();
            builder.HasOne(e => e.Referee).WithMany(e => e.Games);
            builder.HasOne(e => e.Competition).WithMany(e => e.Games);
            builder.HasMany(e => e.Gameslots).WithOne(e => e.Game);
        }

        private void ConfigureTimeslots(EntityTypeBuilder<Timeslot> builder)
        {
            builder.Property<DateTime>("ModificationDate");
            builder.Property(e => e.PitchId).IsRequired();
            builder.OwnsOne(e => e.StartTime).Property(e => e.Value).HasColumnName("StartTime").IsRequired();
            builder.OwnsOne(e => e.EndTime).Property(e => e.Value).HasColumnName("EndTime").IsRequired();
            builder.OwnsOne(e => e.Color).Property(e => e.Value).HasColumnName("Color").IsRequired();
        }

        private void ConfigurePitches(EntityTypeBuilder<Pitch> builder)
        {
            builder.Property<DateTime>("ModificationDate");
            builder.Property(e => e.Name).IsRequired();
            builder.Property(e => e.Number).IsRequired();
            builder.Property(e => e.OrderNumber).IsRequired();
            builder.HasMany<Timeslot>().WithOne(e => e.Pitch).HasForeignKey(e => e.PitchId); //TODO Remove Pitch
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
