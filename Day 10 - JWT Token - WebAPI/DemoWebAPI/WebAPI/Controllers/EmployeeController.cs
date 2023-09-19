using BLL.IService;
using BLL.Models.DTOs;
using BLL.Models.Requests;
using DAL.Repository;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet("/ListEmployee")]
        public IEnumerable<EmployeeDto> GetListEmployee()
        {
            List<EmployeeDto> result = _employeeService.ListOfEmployee();
            return result;
        }

        [HttpGet("/Employee/{id}")]
        public ActionResult<EmployeeDto> GetEmployeeById(int id)
        {

            if (id == null)
            {
                return NotFound();
            }

            return _employeeService.GetEmployeeId(id);
        }

        [HttpPost("/AddEmployee")]
        public ActionResult AddEmployee(EmployeeRequests employeeDto)
        {
            _employeeService.InsertEmployee(employeeDto);
            return Ok("Employee added successfully.");
        }
    }
}
