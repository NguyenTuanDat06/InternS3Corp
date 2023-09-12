using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoTopic5
{
    public class TestProperty
    {
        public void Run()
        {
            var reflectionInfo = new ReflectionInfo();
            var type = reflectionInfo.GetType();

            var props = type.GetProperties();
            foreach (var item in props) Console.WriteLine(item);
        }
    }
}
