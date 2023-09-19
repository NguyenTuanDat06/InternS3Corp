using BLL.IService;
using BLL.Models.DTOs;
using DAL.Repository;

namespace BLL.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepo;

        public UserService(IUserRepository userRepo)
        {
            _userRepo = userRepo;
        }

        public List<DtoUser> ListOfUser()
        {
            var req = new List<DtoUser>();
            var dbUsers = _userRepo.GetAll();
            foreach (var dbUser in dbUsers)
            {
                req.Add(new DtoUser
                {
                    Name = dbUser.Name,
                    Phone = dbUser.phone,
                    Address = dbUser.address
                });
            }
            return req;
        }
    }
}
