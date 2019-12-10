using System.Threading.Tasks;
using EducationApp.BusinessLogicLayer.Models.Users;
using EducationApp.BusinessLogicLayer.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EducationApp.PresentationLayer.Helpers.Interfaces;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using System.Linq;
using error = EducationApp.BusinessLogicLayer.Common.Consts.Consts.Errors;
using EducationApp.BusinessLogicLayer.Models.Base;

namespace EducationApp.PresentationLayer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IJwtHelper _jwtHelper;

        private readonly IAccountService _accountService;

        public AccountController(IJwtHelper jwtHelper, IAccountService accountService)
        {
            _jwtHelper = jwtHelper;

            _accountService = accountService;
        }

        [HttpPost("register")]
        public async Task<ActionResult> Register(UserModelItem userItemModel,string password)
        {
            var result = await _accountService.CreateUserAsync(userItemModel, password);

            return Ok(result.Errors);
        }

        [HttpPost("confirmEmail")]
        public async Task<ActionResult> ConfirmEmail(UserModelItem email)
        {
            var resultConfirmEmail = await _accountService.ConfirmEmailAsync(email.Email);

            return Ok(resultConfirmEmail.Errors);
        }


        [HttpPost("signIn")]
        public async Task<ActionResult> SignIn(string email,string password)
        {
            var errors = await _accountService.SignIn(email, password);

            var user = await _accountService.GetByEmailAsync(email);

            if (errors.Errors.Count > 0)
            {
                return Ok(errors.Errors);
            }

            var tokens = _jwtHelper.GenerateTokenModel(user);

            SetCookies(tokens.AccessToken, tokens.RefreshToken);

            return Ok(errors);
        }
        [Authorize]
        [HttpPost("signOut")]
        public async Task<ActionResult> SignOutAsync()
        {
            await _accountService.SignOutAsync();

            return Ok();
        }

        private async Task<IActionResult> RefreshTokenAsync(string refreshToken)
        {
            var result = new BaseModel();
            var token = _jwtHelper.ValidateToken(refreshToken);

            if (token == null)
            {
                result.Errors.Add(error.InvalidToken);
                return Ok(result);
            }

            var userId = token.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value;

            long id;

              //todo use tryParse
            var resultParse = long.TryParse(userId, out id);
            if (!resultParse)
            {
                result.Errors.Add(error.IdNotValid);
                return Ok(result);
            }

            var user = await _accountService.GetByIdAsync(id);

            var tokens = _jwtHelper.GenerateTokenModel(user);

            SetCookies(tokens.AccessToken, tokens.RefreshToken);

            return Ok(result);
        }
       
        private void SetCookies(string accessToken,string refreshToken)
        {
            HttpContext.Response.Cookies.Append("RefereshToken", refreshToken);

            HttpContext.Response.Cookies.Append("AccessToken", accessToken);
        }
    }
}
