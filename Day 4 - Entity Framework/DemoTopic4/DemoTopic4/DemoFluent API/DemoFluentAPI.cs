using DemoTopic4.DemoDataAnnotation;
using DemoTopic4.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DemoTopic4.DemoFluent_API
{
    public class DemoFluentAPI :DbContext
    {
        public DemoFluentAPI() : base()
        {
        }
        public DbSet<Product> products { get; set; }

        public DbSet<Category> categories { get; set; }

        public DbSet<Department> department { get; set; }

        public DbSet<Employee> employee { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("Admin");
            modelBuilder.Entity<Category>().ToTable("CategoryInfo");
            modelBuilder.Entity<Product>().ToTable("ProductInfo", "dbo");
            
            //demo Entity
            modelBuilder.Entity<Department>().Map(m =>
            {
                m.Properties(p => new { p.DeparmentId, p.DeparmentName,p.RowVersion });
                m.ToTable("StudentInfo");
            });
            //demo Property
            modelBuilder.Entity<Employee>().HasKey<int>(s => s.EmployeeId);
        }
    }
}