using System.ComponentModel.DataAnnotations;

namespace DAL.Entities
{
    public class User
        {
            [Key]
            public int Id { get; set; }

            public string Name { get; set; }

            public int phone { get; set; }

            public string address { get; set; }
        }
}
