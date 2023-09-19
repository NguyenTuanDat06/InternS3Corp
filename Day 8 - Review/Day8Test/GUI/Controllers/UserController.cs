using BLL.IService;
using BLL.Models.DTOs;
using BLL.Models.Requests;
using Microsoft.AspNetCore.Mvc;

namespace GUI.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        public IActionResult Index()
        {
            List<DtoUser> requests = _userService.ListOfUser();

            return View(requests);
        }
    }
}
