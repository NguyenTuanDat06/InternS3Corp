using Microsoft.AspNetCore.Mvc;

namespace WebSite.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Login()
        {

            return View();
        }

        public IActionResult Register()
        {
            return View();
        }
    }
}
