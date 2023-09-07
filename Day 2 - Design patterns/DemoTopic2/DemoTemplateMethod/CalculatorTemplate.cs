using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoTemplateMethod
{
    public abstract class CalculatorTemplate
    {
        public void BuildCalulator()
        {
            ImportNumber();
            PerformMath();
            ShowResults();
            Console.WriteLine("success");
        }

        protected abstract void ImportNumber();
        protected abstract void PerformMath();
        protected abstract void ShowResults();
    }
}
