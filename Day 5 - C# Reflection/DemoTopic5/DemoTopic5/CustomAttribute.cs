using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoTopic5
{
    public class CustomAttribute : Attribute
    {
        public string Name { get; set; }

        public void Write()
        {
            Console.WriteLine("Hello CustomAttribute.");
        }
    }
}
