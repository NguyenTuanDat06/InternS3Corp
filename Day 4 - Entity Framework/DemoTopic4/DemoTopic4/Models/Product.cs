using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DemoTopic4.Models
{
    public class Product
    {
        public int productID { get; set; }
        public string productName { get; set; }
        public string description { get; set; }
        public Nullable<int> categoryID { get; set; }
        public virtual Category Category { get; set; }
    }
}