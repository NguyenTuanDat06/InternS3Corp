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
        private readonly ILogger<EmployeeController> _logger;

        string localhost = "https://localhost:7024/api/";
        public EmployeeController(IEmployeeService employeeService, HttpClient httpClient, ILogger<EmployeeController> logger)
        {
            _employeeService = employeeService;
            _httpClient = httpClient;
            _logger = logger;
            _logger.LogDebug("Nlog in employeeController");
        }

        [HttpGet("TestCustomer")]
        public async Task<string> GetListCustomer()
        {
            string url = localhost+"Customer/CustomerList";
            var response = await _httpClient.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();
            return content;
        }

        [HttpGet("ListEmployee")]
        [Authorize]
        public IEnumerable<EmployeeDto> GetListEmployee()
        {
            _logger.LogInformation("abc");
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
