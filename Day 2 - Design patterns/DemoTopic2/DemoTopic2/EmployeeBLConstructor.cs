using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoTopic2
{
    public class EmployeeBLConstructor
    {

        public IEmployeeDAL employeeDAL;
        //Injecting the Dependency Object using Constructor means it is a Loose Coupling
        public EmployeeBLConstructor(IEmployeeDAL employeeDAL)
        {
            this.employeeDAL = employeeDAL;
        }
        public List<Employee> GetAllEmployees()
        {
            return employeeDAL.SelectAllEmployees();
        }
    }
}
