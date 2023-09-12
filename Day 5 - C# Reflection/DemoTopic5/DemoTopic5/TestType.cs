using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoTopic5
{
    public class TestType
    {
        public void Run()
        {
            var fullName = string.Empty;
            var assemblyName = string.Empty;
            var constructors = new List<string>();

            //typeof
            var type = typeof(int);
            fullName = type.FullName;
            assemblyName = type.Assembly.FullName;
            var listConstructors = type.GetConstructors().ToList();
            foreach (var item in listConstructors) constructors.Add(item.Name);

            Console.WriteLine("Type.FullName: " + fullName);
            Console.WriteLine("Type.Assembly.FullName: " + assemblyName);
            Console.WriteLine("Type.GetConstructors: " + string.Join(", ", constructors));
            Console.WriteLine("==============================");

            //gettype
            double i = 100d;
            type = i.GetType();
            fullName = type.FullName;
            assemblyName = type.Assembly.FullName;
            listConstructors = type.GetConstructors().ToList();
            foreach (var item in listConstructors) constructors.Add(item.Name);

            Console.WriteLine("Type.FullName: " + fullName);
            Console.WriteLine("Type.Assembly.FullName: " + assemblyName);
            Console.WriteLine("Type.GetConstructors: " + string.Join(", ", constructors));
            Console.WriteLine("==============================");


            var reflectionInfo = new ReflectionInfo(1, "Name") ;
            type = reflectionInfo.GetType();
            fullName = type.FullName;
            assemblyName = type.Assembly.FullName;
            listConstructors = type.GetConstructors().ToList();
            foreach (var item in listConstructors) constructors.Add(item.ToString());

            Console.WriteLine("Type.FullName: " + fullName);
            Console.WriteLine("Type.Assembly.FullName: " + assemblyName);
            Console.WriteLine("Type.GetConstructors: " + string.Join(", ", constructors));
        }
    }
}
