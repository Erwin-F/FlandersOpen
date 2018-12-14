using System;
using System.Linq;
using FlandersOpen.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FlandersOpen.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(ConfigureUser);
        }

        public override int SaveChanges()
        {
            AddTimeStamp();
            return base.SaveChanges();
        }

        private static void ConfigureUser(EntityTypeBuilder<User> builder)
        {
            builder.Property(e => e.Username).IsRequired();
        }

        private void AddTimeStamp()
        {
            var entries = ChangeTracker.Entries()
                .Where(e => e.State == EntityState.Added || e.State == EntityState.Modified);

            foreach (var entry in entries)
            {
                if (entry.Entity is IEntity entity) entity.ModificationDate = DateTime.UtcNow;
            }
        }
    }
}
