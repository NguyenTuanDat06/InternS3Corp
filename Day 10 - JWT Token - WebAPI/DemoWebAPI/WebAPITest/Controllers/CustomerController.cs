using BLL.Models.Authentication;
using BLL.Models.DTOs;
using BLL.Models.Requests;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace WebAPITest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly HttpClient _httpClient;

        string localhost = "https://localhost:7214/";
        public CustomerController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        [HttpGet("CustomerList")]
        public List<string> GetList()
        {
            var customerList = new List<string> { "customer1", "customer2", "customer3" };
            return customerList;
        }

        [HttpPost("AddEmployee")]
        public async Task<string> AddEmployee(EmployeeRequests otd)
        {
            var ulr = localhost + "Employee/AddEmployee";

            string jsonData = JsonConvert.SerializeObject(otd);
            var jsonContent = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(ulr, jsonContent);
            if (response.IsSuccessStatusCode)
            {
                return "Employee added successfully.";
            }
            else
                throw new HttpRequestException($"Failed to add employee. Status code: {response.StatusCode}");
        }

        [HttpPost("SignInEmployee")]
        public async Task<IActionResult> SignIn(SignInModel model)
        {
            var ulr = localhost + "Account/SignIn";
            string data = JsonConvert.SerializeObject(model);
            var content = new StringContent(data, Encoding.UTF8, "application/json");
            var req = await _httpClient.PostAsync(ulr, content);
            if (req.IsSuccessStatusCode)
            {
                return Ok(req.Content.ReadAsStringAsync().Result);
            }
            else
                return Unauthorized();
        }

        private async Task<string> GetToken()
        {
            var ulr = localhost + "Account/SignIn";
            string email = "abc@gmail.com";
            string pass = "Abc@123";

            var data = new SignInModel()
            {
                Email = email,
                Password = pass,
            };
            var content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");
            var req = await _httpClient.PostAsync(ulr, content);
            if (req.IsSuccessStatusCode)
            {
                var responseContent = await req.Content.ReadAsStringAsync();
                var requestData = JsonConvert.DeserializeObject<ViewTokenModel>(responseContent);
                return requestData.AccessToken;
            }
            else
            {
                return null;
            }
        }

        [HttpGet("ListEmployee")]
        public async Task<List<EmployeeDto>> ListEmployyee()
        {
            var token = await GetToken();

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var ulr = localhost + "Employee/ListEmployee";
            var data = await _httpClient.GetAsync(ulr);
            var content = await data.Content.ReadAsStringAsync();
            var list = JsonConvert.DeserializeObject<List<EmployeeDto>>(content);
            return list;
        }


        //Test nhập token

        [HttpGet("ListEmployeeTest")]
        public async Task<List<EmployeeDto>> ListEmployyeeTest()
        {
            //var token = await GetToken();

            //_httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var ulr = localhost + "Employee/ListEmployee";
            var data = await _httpClient.GetAsync(ulr);
            var content = await data.Content.ReadAsStringAsync();
            var list = JsonConvert.DeserializeObject<List<EmployeeDto>>(content);
            return list;
        }
    }
}
