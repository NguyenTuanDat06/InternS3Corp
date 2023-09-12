using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoTopic5
{
    public class TestConstructor
    {
        public void Run()
        {
            var reflectionInfo = new ReflectionInfo();
            var type = reflectionInfo.GetType();

            var constructors = type.GetConstructors();
            foreach (var item in constructors) Console.WriteLine(item);
        }
    }
}
