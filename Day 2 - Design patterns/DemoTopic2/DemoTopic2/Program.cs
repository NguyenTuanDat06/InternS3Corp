using DemoTopic2;
using System;
using System.Collections.Generic;
using System.Data.Common;

namespace DemoTopic2
{
    class Program
    {
        static void Main(string[] args)
        {
            ////constructor
            //EmployeeBL employeeBL = new EmployeeBL(new EmployeeDAL());
            //List<Employee> ListEmployee = employeeBL.GetAllEmployees();

            //property
            EmployeeBL employeeBL = new EmployeeBL();
            employeeBL.EmployeeDataObject = new EmployeeDAL();
            List<Employee> ListEmployee = employeeBL.GetAllEmployees();

            ////Method
            //EmployeeBL employeeBL = new EmployeeBL();
            //List<Employee> ListEmployee = employeeBL.GetAllEmployees(new EmployeeDAL());


            foreach (Employee emp in ListEmployee)
            {
                Console.WriteLine($"ID = {emp.ID}, Name = {emp.Name}, Age = {emp.Age}");
            }
            Console.ReadKey();
        }
    }
    
}