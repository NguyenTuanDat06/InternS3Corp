using System;
namespace DemoTemplateMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Calculator\n");
            Console.WriteLine("Calculator 1 to 10");
            Number1to10 task1 = new Number1to10();
            task1.BuildCalulator();

            Console.WriteLine();

            Console.WriteLine("Calculator 11 to 20");
            Number11to20 task2 = new Number11to20();
            task2.BuildCalulator();

            Console.Read();
        }
    }
}