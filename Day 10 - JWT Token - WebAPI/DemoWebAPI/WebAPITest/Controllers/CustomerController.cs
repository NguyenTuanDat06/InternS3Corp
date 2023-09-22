using Microsoft.AspNetCore.Mvc;

namespace WebAPITest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        [HttpGet("CustomerList")]
        public List<string> GetList()
        {
            var customerList = new List<string> { "customer1", "customer2" ,"customer3" };
            return customerList;
        }

        [HttpPost("AddCustomer")]
        public ActionResult AddCustomer(string a)
        {
            var customerList = new List<string>();

                customerList.Add(a);

            return Ok(customerList);

        }
    }
}
