using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoTemplateMethod
{
    public class Number1to10 : CalculatorTemplate
    {
        protected override void ImportNumber()
        {
            Console.WriteLine(" 1 2 3 4 5 6 7 8 9 10");
        }
        protected override void PerformMath()
        {
            Console.WriteLine(" 1+2+3+4+5+6+7+8+9+10");

        }
        protected override void ShowResults()
        {
            int s = 0;
            for (int i = 0; i <= 10; i++) {
                    s += i; 
            }
            Console.WriteLine($" results = {s}");

        }
    }
}
