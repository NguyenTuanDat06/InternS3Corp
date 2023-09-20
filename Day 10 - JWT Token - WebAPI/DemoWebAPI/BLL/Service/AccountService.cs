using BLL.IService;
using BLL.Models.Authentication;
using DAL.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace BLL.Service
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IConfiguration _configuration;
        public AccountService(UserManager<ApplicationUser> userManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _configuration = configuration;
        }

        public async Task<(int,string)> SignUpAsync(SignUpModel model)
        {
            var user = new ApplicationUser
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                UserName = model.Email,
            };
            var createUser = await _userManager.CreateAsync(user, model.Password);

            if (!createUser.Succeeded)
                return (0, "User creation failed! Please check user details and try again.");


            return (1, "User created successfully!");

        }
        public async Task<ViewTokenModel> SignInAsync(SignInModel model)
        {
            ViewTokenModel viewTokenModel = new();
            var result = await _userManager.FindByNameAsync(model.Email);

            if (result == null)
            {
                viewTokenModel.StatusCode = 0;
                viewTokenModel.StatusMessage = "Invalid username";
                return viewTokenModel;
            }

            if (!await _userManager.CheckPasswordAsync(result, model.Password))
            {
                viewTokenModel.StatusCode = 0;
                viewTokenModel.StatusMessage = "Invalid password";
                return viewTokenModel;
            }

            var authClaims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, model.Email),
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString())
            };

            var accesstoken = GenerateToken(authClaims);
            var refentoken = GenerateRefreshToken();

            viewTokenModel.StatusCode = 1;
            viewTokenModel.StatusMessage = "Success";
            viewTokenModel.AccessToken = accesstoken;
            viewTokenModel.RefreshToken = refentoken;

            var _RefreshTokenValidityInDays = Convert.ToInt64(_configuration["JWT:RefreshTokenValidityInDays"]);
            result.RefreshToken = viewTokenModel.RefreshToken;
            result.RefreshTokenExpiryTime = DateTime.Now.AddDays(_RefreshTokenValidityInDays);
            await _userManager.UpdateAsync(result);

            return viewTokenModel;
        }

        public async Task<ViewTokenModel> GetRefreshToken(GetRefeshTokenViewModel model)
        {
            ViewTokenModel _ViewTokenModel = new();
            var principal = GetPrincipalFromExpiredToken(model.AccessToken);
            string username = principal.Identity.Name;
            var user = await _userManager.FindByNameAsync(username);

            if (user == null || user.RefreshToken != model.RefreshToken || user.RefreshTokenExpiryTime <= DateTime.Now)
            {
                _ViewTokenModel.StatusCode = 0;
                _ViewTokenModel.StatusMessage = "Invalid access token or refresh token";
                return _ViewTokenModel;
            }

            var authClaims = new List<Claim>
            {
               new Claim(ClaimTypes.Name, user.UserName),
               new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };
            var newAccessToken = GenerateToken(authClaims);
            var newRefreshToken = GenerateRefreshToken();

            user.RefreshToken = newRefreshToken;
            await _userManager.UpdateAsync(user);

            _ViewTokenModel.StatusCode = 1;
            _ViewTokenModel.StatusMessage = "Success";
            _ViewTokenModel.AccessToken = newAccessToken;
            _ViewTokenModel.RefreshToken = newRefreshToken;
            return _ViewTokenModel;
        }

        private ClaimsPrincipal GetPrincipalFromExpiredToken(string? token)
        {
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateAudience = false,
                ValidateIssuer = false,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"])),
                ValidateLifetime = false
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out SecurityToken securityToken);
            if (securityToken is not JwtSecurityToken jwtSecurityToken || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
                throw new SecurityTokenException("Invalid token");

            return principal;
        }

        private string GenerateToken(IEnumerable<Claim> claims)
        {
            var authenKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

            var tokenDes = new JwtSecurityToken(
                               issuer: _configuration["JWT : ValidIssuer"],
                               audience: _configuration["JWT : ValidAudience"],
                               expires: DateTime.Now.AddMinutes(20),
                               claims: claims,
                               signingCredentials: new SigningCredentials(authenKey, SecurityAlgorithms.HmacSha512Signature)
                           );

            var tokenHandler = new JwtSecurityTokenHandler();
            var accessToken = tokenHandler.WriteToken(tokenDes);
            return accessToken;

        }

        private string GenerateRefreshToken()
        {
            var random = new Byte[64];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(random);
                return Convert.ToBase64String(random);
            }
        }
    }
}
