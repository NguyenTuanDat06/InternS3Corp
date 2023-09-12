using DemoTopic5;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("------Test Type------");
        var testType = new TestType();
        testType.Run();
        Console.WriteLine("\n------Test Attribute------");
        var testAttribute = new TestAttribute();
        testAttribute.Run();
        Console.WriteLine("\n------Test Constructor------");
        var testConstructor = new TestConstructor();
        testConstructor.Run();
        Console.WriteLine("\n------Test Method------");
        var testMethod = new TestMethod();
        testMethod.Run();
        Console.WriteLine("\n------Test Property------");
        var testProperty = new TestProperty();
        testProperty.Run();
        Console.WriteLine("\n------Test Field------");
        var testField = new TestField();
        testField.Run();
        Console.ReadKey();
    }
}