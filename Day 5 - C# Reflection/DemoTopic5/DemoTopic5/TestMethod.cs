using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoTopic5
{
    public class TestMethod
    {
        public void Run()
        {
            var reflectionInfo = new ReflectionInfo();
            var type = reflectionInfo.GetType();

            var methods = type.GetMethods();
            foreach (var item in methods) Console.WriteLine(item);
        }
    }
}
