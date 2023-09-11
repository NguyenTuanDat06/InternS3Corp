using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DemoTopic4.DemoDataAnnotation
{
    [Table("EmployeeInfo")]
    public class Employee
    {
        public int EmployeeId { get; set; }
        [StringLength(50)]
        public string EmployeeName { get; set; }
        [NotMapped]
        public int EmployeeAge { get; set; }
        [Required]
        public string EmployeeAdress { get; set; }

        [ForeignKey("Department")]
        public int DeparmentId { get; set; }
        public virtual Department Department { get; set; }
    }
}