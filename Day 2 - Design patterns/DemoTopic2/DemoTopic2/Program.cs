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
            //constructor
            EmployeeBLConstructor employeeBLConstructor = new EmployeeBLConstructor(new EmployeeDAL());
            List<Employee> ListEmployeeConstructor = employeeBLConstructor.GetAllEmployees();

            //property
            EmployeeBL employeeBL = new EmployeeBL();
            employeeBL.EmployeeDataObject = new EmployeeDAL();
            List<Employee> ListEmployee = employeeBL.GetAllEmployees();

            //Method
            EmployeeBLMethod employeeBLMethod = new EmployeeBLMethod();
            List<Employee> ListEmployeeMethod = employeeBLMethod.GetAllEmployees(new EmployeeDAL());

            Console.WriteLine("Constructor DI");
            foreach (Employee emp in ListEmployeeConstructor)
            {
                Console.WriteLine($"ID = {emp.ID}, Name = {emp.Name}, Department = {emp.Age}");
            }

            Console.WriteLine("Property DI");

            foreach (Employee emp in ListEmployee)
            {
                Console.WriteLine($"ID = {emp.ID}, Name = {emp.Name}, Age = {emp.Age}");
            }

            Console.WriteLine("Method DI");

            foreach (Employee emp in ListEmployeeMethod)
            {
                Console.WriteLine($"ID = {emp.ID}, Name = {emp.Name}, Department = {emp.Age}");
            }
            Console.ReadKey();

        }
    }
    
}