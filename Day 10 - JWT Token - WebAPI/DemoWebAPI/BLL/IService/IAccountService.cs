using BLL.Models.Authentication;
using Microsoft.AspNetCore.Identity;

namespace BLL.IService
{
    public interface IAccountService
    {
        public Task<(int,string)> SignUpAsync(SignUpModel model);

        public Task<ViewTokenModel> SignInAsync(SignInModel model);

        public Task<ViewTokenModel> GetRefreshToken(GetRefeshTokenViewModel model);
    }
}
