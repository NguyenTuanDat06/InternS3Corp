using System.ComponentModel.DataAnnotations;

namespace DAL.Entities
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public int Phone { get; set; }

        public string Address { get; set; }

    }
}
