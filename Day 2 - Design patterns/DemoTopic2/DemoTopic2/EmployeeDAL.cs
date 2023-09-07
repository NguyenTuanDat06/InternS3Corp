using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoTopic2
{
    public interface IEmployeeDAL
    {
        List<Employee> SelectAllEmployees();
    }
    public class EmployeeDAL : IEmployeeDAL
    {
        public List<Employee> SelectAllEmployees()
        {
            List<Employee> ListEmployees = new List<Employee>
            {
                new Employee() { ID = 1, Name = "dat", Age = 21 },
                new Employee() { ID = 2, Name = "quyen", Age = 21 },
                new Employee() { ID = 3, Name = "thuan", Age = 20 }
            };
            return ListEmployees;
        }
    }
}
