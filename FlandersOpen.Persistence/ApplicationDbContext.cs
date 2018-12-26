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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.HasDefaultSchema("fo"); RelationalModelBuilderExtensions
            modelBuilder.Entity<User>(ConfigureUser);
        }

        private static void ConfigureUser(EntityTypeBuilder<User> builder)
        {            
            builder.Property(e => e.Username).IsRequired();
        }
    }
}
