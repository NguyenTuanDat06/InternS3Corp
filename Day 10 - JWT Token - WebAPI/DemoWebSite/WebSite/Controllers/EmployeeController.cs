using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using WebSite.Models;

namespace WebSite.Controllers
{
    public class EmployeeController : Controller
    {
        string local = "http://localhost:8080/";
        public async Task<IActionResult> ListOfEmployee()
        {
            using (HttpClient client = new HttpClient())
            {
                string ulr = local + "Employee/ListEmployee";

                var res = await client.GetAsync(ulr);

                if (res.IsSuccessStatusCode)
                {
                    //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                    var data = await res.Content.ReadAsStringAsync();
                    var employees = JsonConvert.DeserializeObject<List<DtoEmployee>>(data);
                    return View(employees);
                }
                else
                {
                    return BadRequest("Not Find");
                }
            }
        }

        public async Task<IActionResult> AddEmployee(DtoEmployee db)
        {
            if (ModelState.IsValid)
            {
                using (HttpClient client = new HttpClient())
                {
                    string ulr = local + "Employee/AddEmployee";
                    string data = JsonConvert.SerializeObject(db);
                    var jsondata = new StringContent(data, Encoding.UTF8, "application/json");

                    var response = await client.PostAsync(ulr, jsondata);
                    if (response.IsSuccessStatusCode)
                    {
                        return RedirectToAction("ListOfEmployee");
                    }
                    else
                    {
                        return View(db);
                    }
                }
            }
            return View(db);
        }
    }
}
