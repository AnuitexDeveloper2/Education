using System.Threading.Tasks;
using EducationApp.BusinessLogicLayer.Models.Users;
using EducationApp.BusinessLogicLayer.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static EducationApp.BusinessLogicLayer.Common.Consts.Consts.EmailConsts;
using EducationApp.PresentationLayer.Helpers.Interfaces;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using System;
using System.Linq;
using Microsoft.IdentityModel.Tokens;
using EducationApp.BusinessLogicLayer.Helpers.Mapping;

namespace EducationApp.PresentationLayer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly ITokenFactory _tokenFactory;
        private readonly IAccountService _accountService;
        private readonly TokenValidationParameters _tokenValidationParameters;

        public AccountController(ITokenFactory tokenFactory, IAccountService accountService, TokenValidationParameters tokenValidationParameters)
        {
            _tokenFactory = tokenFactory;
            _accountService = accountService;
            _tokenValidationParameters = tokenValidationParameters;
        }

        [HttpPost("register")]
        public async Task<ActionResult> Register(UserItemModel model)
        {
            var user = await _accountService.RegisterAsync(model.Email, model.Password, model.FirstName, model.LastName);
            if (user == null)
            {
                return BadRequest(ModelState);
            }
            return Ok();
        }

        [HttpPost("confirmEmail")]
        public async Task<ActionResult> ConfirmEmail(UserItemModel model)
        {
            var confirmUser = await _accountService.ConfirmEmailAsync(model.Email);
            if (!confirmUser)
            {
                return Content(Error);
            }
            return Ok();
        }

        [HttpPost("forgotPassword")]
        public async Task<ActionResult> ForgotPassword(UserItemModel model)
        {
            await _accountService.RestorePasswordAsync(model);
            return Ok();
        }
        [HttpPost("signIn")]
        public async Task<ActionResult> SignIn(UserItemModel model)
        {
            var user = await _accountService.GetByEmailAsync(model.Email);
            if (user == null)
            {
                return Content(Invalid);
            }
            var tokens = _tokenFactory.GenerateTokenModel(user);
            HttpContext.Response.Cookies.Append("RefereshToken", tokens.RefreshToken);
            HttpContext.Response.Cookies.Append("AccessToken", tokens.AccessToken);
            await _accountService.SignInAsync(model.Email, model.Password);
            return Ok();
        }
        [Authorize]
        [HttpPost("signOut")]
        public async Task<ActionResult> SignOutAsync()
        {
            await _accountService.SignOutAsync();
            return Ok();
        }

        public async Task<ActionResult> RefreshTokenAsync(string refreshToken)
        {
            var token = new JwtSecurityTokenHandler().ReadJwtToken(refreshToken);

            if (token.ValidTo >= DateTime.Now)
            {
                var UserId = token.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value;
                long Id = long.Parse(UserId);
                var user = await _accountService.GetByIdAsync(Id);
                var model = UserMaping.Map(user);
                var encodedJwt = _tokenFactory.GenerateTokenModel(model);

            }
            return Ok();
        }
        public async Task<bool> CheckJwtTokenAsync(string accessToken, string refreshToken)
        {
            var expiresAccess = new JwtSecurityTokenHandler().ReadToken(accessToken).ValidTo;

            if (expiresAccess > DateTime.Now)
            {
                await RefreshTokenAsync(refreshToken);
            }
            return true;
        }





    }
}
