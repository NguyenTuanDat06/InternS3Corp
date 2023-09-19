using DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext() : base()
        {

        }
        public DatabaseContext(DbContextOptions<DatabaseContext> opt) : base(opt)
        {

        }
        public DbSet<Employee> Employees { get; set; }

    }
}
