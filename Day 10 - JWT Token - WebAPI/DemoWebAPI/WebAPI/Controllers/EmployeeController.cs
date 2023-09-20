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

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
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
