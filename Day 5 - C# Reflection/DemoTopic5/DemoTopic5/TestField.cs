using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoTopic5
{
    public class TestField
    {
        public void Run()
        {
            var reflectionInfo = new ReflectionInfo();
            var type = reflectionInfo.GetType();

            var fields = type.GetFields();
            foreach (var item in fields) Console.WriteLine(item);
        }
    }
}
