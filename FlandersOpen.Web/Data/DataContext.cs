using FlandersOpen.Web.Entities;
using Microsoft.EntityFrameworkCore;

namespace FlandersOpen.Web.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
    }
}
