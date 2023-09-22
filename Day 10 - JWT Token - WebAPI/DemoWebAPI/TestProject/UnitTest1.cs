using BLL.IService;
using Microsoft.Extensions.Logging;
using WebAPI.Controllers;

namespace TestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        [DynamicData(nameof(createSource))]
        public void TestMethod1(IEmployeeService employeeService, HttpClient httpClient, ILogger<EmployeeController> logger)
        {
            var list = new List<string> { "customer1", "customer2", "customer3" };

            EmployeeController controller = new EmployeeController(employeeService, httpClient, logger);

            var result = controller.GetListCustomer();
            
            Assert.AreEqual(result, list);

        }

        private static IEnumerable<object[]> createSource
        {
            get
            {
                return new[]
                {
                    new object[] {"customer1", "customer2", "customer3" }
                };
            }
        }
    }
}