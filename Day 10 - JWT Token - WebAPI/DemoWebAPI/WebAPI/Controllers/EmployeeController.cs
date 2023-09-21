using BLL.IService;
using BLL.Models.DTOs;
using BLL.Models.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]

    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        private readonly HttpClient _httpClient;

        public EmployeeController(IEmployeeService employeeService, HttpClient httpClient)
        {
            _employeeService = employeeService;
            _httpClient = httpClient;
        }

        [HttpGet("TestCustomer")]
        public async Task<string> GetListCustomer()
        {
            string url = "https://localhost:7024/api/Customer/CustomerList";
            var response = await _httpClient.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();
            return content;
        }

        [HttpGet("ListEmployee")]
        [Authorize]
        public IEnumerable<EmployeeDto> GetListEmployee()
        {
            List<EmployeeDto> result = _employeeService.ListOfEmployee();
            return result;
        }

        [HttpGet("GetEmployee/{id}")]
        public ActionResult<EmployeeDto> GetEmployeeById(int id)
        {

            if (id == null)
            {
                return NotFound();
            }

            return _employeeService.GetEmployeeId(id);
        }

        [HttpPost("AddEmployee")]
        public ActionResult AddEmployee(EmployeeRequests employeeDto)
        {
            _employeeService.InsertEmployee(employeeDto);
            return Ok("Employee added successfully.");
        }
    }
}
