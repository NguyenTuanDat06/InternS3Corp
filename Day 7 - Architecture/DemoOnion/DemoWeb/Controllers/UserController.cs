using DAL;
using DemoWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Service.IServices;
using Service.Models.Requests;

namespace DemoWeb.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService userService;
        private readonly IUserProfileService userProfileService;

        public UserController(IUserService userService, IUserProfileService userProfileService)
        {
            userService = userService;
            userProfileService = userProfileService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<UserViewModel> model = new List<UserViewModel>();
            userService.GetUsers().ToList().ForEach(u =>
            {
                UserProfile userProfile = userProfileService.GetUserProfile(u.Id);
                UserViewModel user = new UserViewModel
                {
                    Id = u.Id,
                    Name = $"{userProfile.FirstName} {userProfile.LastName}",
                    Email = u.Email,
                    Address = userProfile.Address
                };
                model.Add(user);
            });
            //List<UserViewModel> listOfUsers = userService.GetListUsers();
            return View(model);
        }

        [HttpGet]
        [HttpPost]
        public ActionResult AddUser(CreateUserRequest model)
        {
            if (HttpContext.Request.Method == "POST")
            {
                if (ModelState.IsValid)
                {
                    User userEntity = new User
                    {
                        UserName = model.UserName,
                        Email = model.Email,
                        Password = model.Password,
                        AddedDate = DateTime.UtcNow,
                        ModifiedDate = DateTime.UtcNow,
                        IPAddress = Request.HttpContext.Connection.RemoteIpAddress.ToString(),
                        UserProfile = new UserProfile
                        {
                            FirstName = model.FirstName,
                            LastName = model.LastName,
                            Address = model.Address,
                            AddedDate = DateTime.UtcNow,
                            ModifiedDate = DateTime.UtcNow,
                            IPAddress = Request.HttpContext.Connection.RemoteIpAddress.ToString()
                        }
                    };
                    userService.InsertUser(userEntity);
                    if (userEntity.Id > 0)
                    {
                        return RedirectToAction("index");
                    }
                }
                return View(model);
            }
            else
            {
                return View();
            }
        }

        public ActionResult GetUser(int? id, bool isDetail = false)
        {
            UserViewModel model = new UserViewModel();
            if (id.HasValue && id != 0)
            {
                User userEntity = userService.GetUser(id.Value);
                UserProfile userProfileEntity = userProfileService.GetUserProfile(id.Value);
                model.FirstName = userProfileEntity.FirstName;
                model.LastName = userProfileEntity.LastName;
                model.Address = userProfileEntity.Address;
                model.Email = userEntity.Email;
            }

            if (isDetail)
            {
                return View("GetUserDetail", model); // Return the detail view
            }

            return View(model); // Return the standard view
        }

        [HttpPost]
        public ActionResult EditUser(UserViewModel model)
        {
            User userEntity = userService.GetUser(model.Id);
            userEntity.Email = model.Email;
            userEntity.ModifiedDate = DateTime.UtcNow;
            userEntity.IPAddress = Request.HttpContext.Connection.RemoteIpAddress.ToString();
            UserProfile userProfileEntity = userProfileService.GetUserProfile(model.Id);
            userProfileEntity.FirstName = model.FirstName;
            userProfileEntity.LastName = model.LastName;
            userProfileEntity.Address = model.Address;
            userProfileEntity.ModifiedDate = DateTime.UtcNow;
            userProfileEntity.IPAddress = Request.HttpContext.Connection.RemoteIpAddress.ToString();
            userEntity.UserProfile = userProfileEntity;
            userService.UpdateUser(userEntity);
            if (userEntity.Id > 0)
            {
                return RedirectToAction("index");
            }
            return View(model);
        }
    }
}
