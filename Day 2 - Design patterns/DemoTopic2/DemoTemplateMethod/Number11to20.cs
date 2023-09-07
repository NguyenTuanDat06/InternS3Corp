using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoTemplateMethod
{
        public class Number11to20 : CalculatorTemplate
        {
            protected override void ImportNumber()
            {
                Console.WriteLine(" 11 12 13 14 15 16 17 18 19 20");
            }
            protected override void PerformMath()
            {
                Console.WriteLine(" 11+12+13+14+15+16+17+18+19+20");

            }
            protected override void ShowResults()
            {
                int s = 0;
                for (int i = 11; i <= 20; i++)
                {
                    s += i;
                }
                Console.WriteLine($" results = {s}");

            }
        }
}
