using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DemoTopic4.DemoDataAnnotation
{
    public class Department
    {
        [Column("ID")]
        [Key]
        public int DeparmentId { get; set; }
        [Column("Name")]
        public string DeparmentName { get; set; }
        [Timestamp]
        public byte[] RowVersion { get; set; }
        public ICollection<Employee> Students { get; set; }
    }
}