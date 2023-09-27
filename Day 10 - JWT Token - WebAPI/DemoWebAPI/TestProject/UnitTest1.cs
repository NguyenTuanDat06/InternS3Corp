using BLL.IService;
using BLL.Models.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using WebAPI.Controllers;

namespace TestProject
{
    [TestClass]
    public class UnitTest1
    {
        private readonly Mock<IEmployeeService> _employeeService = new();
        private readonly Mock<ILogger<EmployeeController>> _logger = new();

        [TestMethod]
        public async Task TestMethod1()
        {
            var list = new List<string>() { "customer1", "customer2", "customer3" };

            _employeeService.Setup(e => e.GetCustomer()).ReturnsAsync(list);

            var controller = new EmployeeController(_employeeService.Object, _logger.Object);

            var result = await controller.GetListCustomer();

            Assert.AreEqual(list, result);

        }

        [TestMethod]
        public void TestListEmployee()
        {
            var listOfEmployees = new List<EmployeeDto>();
            _employeeService.Setup(e => e.ListOfEmployee()).Returns(listOfEmployees);

            var controller = new EmployeeController(_employeeService.Object, _logger.Object);

            var result = controller.GetListEmployee();

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void TestGetEmployeeID()
        {
            EmployeeDto employee = new EmployeeDto{
                Id = 1,
                Name = "Dat",
                Phone = 0917355550,
                Address = "Daklak"
            };

            _employeeService.Setup(e => e.GetEmployeeId(It.IsAny<int>())).Returns(employee);

            var controller = new EmployeeController(_employeeService.Object, _logger.Object);

            var result = controller.GetEmployeeById(1);

            Assert.AreEqual(employee,result.Value);
        }

        [TestMethod]
        public void TestAdd()
        {
            var res = (1 + 2);
            Assert.AreEqual(3, res);
        }
    }
}