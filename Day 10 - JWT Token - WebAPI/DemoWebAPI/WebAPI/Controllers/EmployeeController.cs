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
        private readonly ILogger<EmployeeController> _logger;

        public EmployeeController(IEmployeeService employeeService, ILogger<EmployeeController> logger)
        {
            _employeeService = employeeService;
            _logger = logger;
            _logger.LogDebug("Nlog in employeeController");
        }

        [HttpGet("TestCustomer")]
        public async Task<List<string>> GetListCustomer()
        {
            var content = await _employeeService.GetCustomer();
            return content;
        }

        [HttpGet("ListEmployee")]
        //[Authorize]
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
