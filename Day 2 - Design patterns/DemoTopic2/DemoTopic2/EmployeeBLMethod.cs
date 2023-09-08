using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoTopic2
{
    public class EmployeeBLMethod
    {
        public List<Employee> GetAllEmployees(IEmployeeDAL employeeDAL)
        {
            return employeeDAL.SelectAllEmployees();
        }
    }
}
