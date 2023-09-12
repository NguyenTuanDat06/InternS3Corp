using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoTopic5
{
    public class TestAttribute
    {
        public void Run()
        {
            var testAttribute = new ReflectionInfo();
            var type = testAttribute.GetType();

            var attrs = type.Attributes;
            Console.WriteLine("Class.Attribute: " + attrs);

            var customAttrs = type.CustomAttributes;
            Console.WriteLine("Class.Custom.Attribute: " + customAttrs);
        }
    }
}
