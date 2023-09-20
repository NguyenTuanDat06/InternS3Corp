using BLL.IService;
using BLL.Models.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Win32;

namespace WebAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AccountController : Controller
    {
        private readonly IAccountService _accountRepo;

        public AccountController(IAccountService accountRepo)
        {
            _accountRepo = accountRepo;
        }

        [HttpPost("SignUp")]
        public async Task<IActionResult> SignUp(SignUpModel model)
        {
            var (status, message) = await _accountRepo.SignUpAsync(model);
            if(status==0)
            {
                return BadRequest(message);
            }

            return CreatedAtAction(nameof(SignUp), model);
        }

        [HttpPost("SignIn")]
        public async Task<IActionResult> SignIn(SignInModel model)
        {
            var reslut = await _accountRepo.SignInAsync(model);
            if (reslut ==null)
            {
                return Unauthorized();
            }

            return Ok(reslut);
        }
    }
}
