//Demo Coding Convention
//Nguyen Tuan Dat

using System;
using System.Collections.Generic;
using System.Runtime.ExceptionServices;
using System.Text;

namespace DemoTopic3
{
    class Program
    {

        class Student
        {
            public string Name { get; set; }
            public int ID { get; set; }
            public string Location { get; set; }
            public int Age { get; set; }
        }

        // String Data & "new" Operator
        public static void StringData()
        {
            var student = new Student();
            student.Name = "Dat";
            student.ID = 123456;
            student.Location = "DakLak";
            student.Age = 22;
            Console.WriteLine($"Name : {student.Name} , ID : {student.ID} , Location : {student.Location} , Age : {student.Age} ");
        }

        //Arrays
        public static void Arrays() 
        {
            Student[] listStudent = { new Student { Name = "Dat" ,ID = 1 , Location = "DakLak" , Age = 22 },
                                  new Student { Name = "S3Corp" ,ID = 2 , Location = "Tan Binh" , Age = 16 },
                                  };
            for (int i = 0;i<listStudent.Length;i++)
            {
                Console.WriteLine($"Name : {listStudent[i].Name} , ID : {listStudent[i].ID} , Location : {listStudent[i].Location} , Age : {listStudent[i].Age} ");

            }
        }
        
        //Delegates use Func<> and Action<>
        public static void Delegates()
        {
            Action<string> actionExample1 = x => Console.WriteLine($"x is: {x}");

            Action<string, string> actionExample2 = (x, y) =>Console.WriteLine($"x is: {x}, y is {y}");

            Func<string, int> funcExample1 = x => Convert.ToInt32(x);

            Func<int, int, int> funcExample2 = (x, y) => x + y;

            actionExample1("string for x");

            actionExample2("string for x", "string for y");

            Console.WriteLine($"The value is {funcExample1("1")}");

            Console.WriteLine($"The sum is {funcExample2(1, 2)}");
        }

        public delegate void Del(string message);

        public static void DelMethod(string str)
        {
            Console.WriteLine("DelMethod argument: {0}", str);
        }

        //try-catch
        public static int ComputeDistance(int x1, int x2)
        {
            try
            {
                return x1 + x2;
            }
            catch (System.ArithmeticException ex)
            {
                Console.WriteLine($"Arithmetic overflow or underflow: {ex}");
                throw;
            }
        }

        public static void Main()
        {
            Console.WriteLine("Test StringData and new Operator");
            StringData();
            Console.WriteLine("\nTest Arrays");
            Arrays();
            Console.WriteLine("\nTest Delegates");
            Delegates();
            Del exampleDel1 = new Del(DelMethod);
            exampleDel1("Hey");
            Console.WriteLine("\nTest Try-catch");
            Console.WriteLine(ComputeDistance(4, 3));

        }
    }
}