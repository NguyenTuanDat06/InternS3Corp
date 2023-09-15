using BLL.IService;
using BLL.Models.DTOs;
using BLL.Models.Requests;
using DAL.Entities;
using DAL.Repository;

namespace BLL.Service
{
    public class UserService : IUserService
    {
        private readonly IRepository<User> _userService;
        
        public UserService(IRepository<User> userService)
        {
            _userService = userService;
        }
        public List<CreateUserRequest> ListOfUser()
        {
            List<CreateUserRequest> req = new List<CreateUserRequest>();
            //req = _userService.GetAll();
            return req;
        }
    }
}
