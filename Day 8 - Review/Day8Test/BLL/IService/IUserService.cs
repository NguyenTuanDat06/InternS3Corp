using BLL.Models.DTOs;
using BLL.Models.Requests;
using DAL.Entities;

namespace BLL.IService
{
    public interface IUserService
    {
        public List<DtoUser> ListOfUser();
    }
}
