using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace DemoTopic4.Models
{
    public class CodeDBContext : DbContext
    {
        public CodeDBContext() : base("MyConnection") { }
        public DbSet<Category> categories { get; set; }
        public DbSet<Product> products { get; set; }
    }
}