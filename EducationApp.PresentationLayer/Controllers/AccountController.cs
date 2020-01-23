using System.Threading.Tasks;
using EducationApp.BusinessLogicLayer.Models.Users;
using EducationApp.BusinessLogicLayer.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EducationApp.PresentationLayer.Helpers.Interfaces;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using System.Linq;
using error = EducationApp.BusinessLogicLayer.Common.Consts.Constants.Errors;
using token = EducationApp.BusinessLogicLayer.Common.Consts.Constants.Token;
using EducationApp.BusinessLogicLayer.Models.Base;

namespace EducationApp.PresentationLayer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IJwtHelper _jwtHelper;

        private readonly IAccountService _accountService;

        private readonly IHttpContextAccessor _httpContextAccessor;



        public AccountController(IJwtHelper jwtHelper, IAccountService accountService, IHttpContextAccessor httpContextAccessor )
        {
            _httpContextAccessor = httpContextAccessor;

            _jwtHelper = jwtHelper;

            _accountService = accountService;
        }

        [HttpPost("register")]
        public async Task<ActionResult> Register(UserModelItem userItemModel)
        {
            var result = await _accountService.CreateUserAsync(userItemModel);

            return Ok(result);
        }

        [HttpPost("forgotPassword")]
        public async Task<ActionResult> ForgotPassword(string email)
        {
            var result = await _accountService.RestorePasswordAsync(email);

            return Ok(result);
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
            var result = await _accountService.SignInAsync(email, password);

            if (result.Errors.Any())
            {
                return Ok(result);
            }

            var user = await _accountService.GetByEmailAsync(email);

            var tokens = _jwtHelper.GenerateTokenModel(user);

            SetCookies(tokens.AccessToken, tokens.RefreshToken);

            return Ok(user);
        }
        [Authorize]
        [HttpGet("signOut")]
        public async Task<ActionResult> SignOutAsync()
        {
            await _accountService.SignOutAsync();

            return Ok();
        }

        [HttpGet("token")]
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
            HttpContext.Response.Cookies.Append(token.RefreshToken, refreshToken);

            HttpContext.Response.Cookies.Append(token.AccessToken, accessToken);

        }
    }
}
