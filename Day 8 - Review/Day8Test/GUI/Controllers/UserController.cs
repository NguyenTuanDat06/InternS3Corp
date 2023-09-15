using BLL.IService;
using BLL.Models.Requests;
using Microsoft.AspNetCore.Mvc;

namespace GUI.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        public IActionResult Index()
        {
            List<CreateUserRequest> requests = _userService.ListOfUser();

            return View();
        }
    }
}
