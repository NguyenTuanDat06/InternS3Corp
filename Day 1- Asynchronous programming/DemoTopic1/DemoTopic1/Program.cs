using System;
using System.Threading.Tasks;

class Program
{
    public static void GetNumber1to10()
    {
        for (int i = 1; i <= 10; i++)
        {
            Console.WriteLine(i);
        }
    }

    public static void GetNumber11to20()
    {
        for (int i = 11; i <= 20; i++)
        {
            Console.WriteLine(i);
        }
    }

    static async Task Main(string[] args)
    {
        Task task1 = Task.Run(() => GetNumber1to10());
        Task task2 = Task.Run(() => GetNumber11to20());
        ////Not Async
        //GetNumber1to10();
        //GetNumber11to20();

        //Async
        await Task.WhenAll(task1, task2);

    }
}