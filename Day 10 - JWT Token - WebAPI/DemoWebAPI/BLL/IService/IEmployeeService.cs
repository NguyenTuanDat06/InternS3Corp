using BLL.Models.DTOs;
using BLL.Models.Requests;

namespace BLL.IService
{
    public interface IEmployeeService
    {
        public List<EmployeeDto> ListOfEmployee();

        public EmployeeDto GetEmployeeId(int id);

        public void InsertEmployee(EmployeeRequests employee);

        public Task<List<string>> GetCustomer();
    }
}
