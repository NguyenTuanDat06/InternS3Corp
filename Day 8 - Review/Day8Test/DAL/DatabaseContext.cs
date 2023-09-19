using DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext()
            : base()
        {
        }
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<User> Users { get; set; }
    }
}
