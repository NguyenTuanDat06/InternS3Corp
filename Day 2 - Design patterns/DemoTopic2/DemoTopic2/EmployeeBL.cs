using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoTopic2
{
    public class EmployeeBL
    {

        //// constructor
        //public IEmployeeDAL employeeDAL;
        //public EmployeeBL(IEmployeeDAL employeeDAL)
        //{
        //    this.employeeDAL = employeeDAL;
        //}

        //property
        public IEmployeeDAL employeeDAL;
        public IEmployeeDAL EmployeeDataObject
        {
            set
            {
                this.employeeDAL = value;
            }
        }

        public List<Employee> GetAllEmployees()
        {
            return employeeDAL.SelectAllEmployees();
        }

        ////Method
        //public List<Employee> GetAllEmployees(IEmployeeDAL employeeDAL)
        //{
        //    return employeeDAL.SelectAllEmployees();
        //}
    }
}

