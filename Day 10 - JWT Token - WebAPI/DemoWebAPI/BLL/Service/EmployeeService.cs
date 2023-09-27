using BLL.IService;
using BLL.Models.DTOs;
using BLL.Models.Requests;
using DAL.Entities;
using DAL.Repository;

namespace BLL.Service
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IRepository<Employee> _repository;

        private readonly HttpClient _httpClient;
        //private readonly IMapper _mapper;

        public EmployeeService(IRepository<Employee> repository/* , IMapper mapper*/, HttpClient httpClient)
        {
            _repository = repository;
            _httpClient = httpClient;
            //_mapper = mapper;
        }

        string localhost = "https://localhost:7024/api/";

        public List<EmployeeDto> ListOfEmployee()
        {
            var req = new List<EmployeeDto>();
            var dbEmployees = _repository.GetAll();
            foreach (var employee in dbEmployees)
            {
                req.Add(new EmployeeDto
                {
                    Id = employee.Id,
                    Name = employee.Name,
                    Phone = employee.Phone,
                    Address = employee.Address
                });
            }
            return req;
        }

        public EmployeeDto GetEmployeeId(int id)
        {
            var dbEmployees = _repository.GetById(id);
            if (dbEmployees == null)
            {
                return null;
            }
            else
            {
                var req = new EmployeeDto
                {
                    Id = dbEmployees.Id,
                    Name = dbEmployees.Name,
                    Phone = dbEmployees.Phone,
                    Address = dbEmployees.Address
                };
                return req;

            }

        }

        public void InsertEmployee(EmployeeRequests employee)
        {
            if (employee == null)
            {
                throw new ArgumentNullException(nameof(employee), "Employee object cannot be null.");
            }
            else
            {
                var req = new Employee();

                req.Name = employee.Name;
                req.Phone = employee.Phone;
                req.Address = employee.Address;

                _repository.Insert(req);
                _repository.Save();
            }
        }

        public async Task<List<string>> GetCustomer()
        {
            string url = localhost + "Customer/CustomerList";
            var response = await _httpClient.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();
            var customerList = Newtonsoft.Json.JsonConvert.DeserializeObject<List<string>>(content);
            return customerList;
        }
    }
}
