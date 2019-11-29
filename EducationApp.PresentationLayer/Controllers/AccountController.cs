using System.Threading.Tasks;
using EducationApp.BusinessLogicLayer.Models.Users;
using EducationApp.BusinessLogicLayer.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EducationApp.PresentationLayer.Helpers.Interfaces;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using System;
using System.Linq;
using EducationApp.BusinessLogicLayer.Helpers.Mapping;

namespace EducationApp.PresentationLayer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IJwtHelper _tokenFactory; //todo JwtHelper
        private readonly IAccountService _accountService;

        public AccountController(IJwtHelper tokenFactory, IAccountService accountService)
        {
            _tokenFactory = tokenFactory;
            _accountService = accountService;
        }

        [HttpPost("register")]
        public async Task<ActionResult> Register(UserModelItem userItemModel,string password)
        {
            var result = await _accountService.CreateUserAsync(userItemModel,password);
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
            var errors = await _accountService.SignIn(email, password);

            var user = await _accountService.GetByEmailAsync(email);

            if (errors.Errors.Count > 0)
            {
                return Ok(errors.Errors);
            }

            var tokens = _tokenFactory.GenerateTokenModel(user);

            TokensInCookies(tokens.AccessToken, tokens.RefreshToken);

            return Ok(errors);
        }
        [Authorize]
        [HttpPost("signOut")]
        public async Task<ActionResult> SignOutAsync()
        {
            await _accountService.SignOutAsync();
            return Ok();
        }
        private async Task<ActionResult> RefreshTokenAsync(string refreshToken)
        {
            var token = new JwtSecurityTokenHandler().ReadJwtToken(refreshToken); //todo replace to jwt helper

            if (token.ValidTo < DateTime.Now)
            {
                //todo return unvalid error
                return Ok();
            }
            var userId = token.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value;
            long Id = long.Parse(userId);
            var user = await _accountService.GetByIdAsync(Id);
            //todo replace to BLL, returm mapped model
            var tokens = _tokenFactory.GenerateTokenModel(user);
            //add to cookie
            TokensInCookies(tokens.AccessToken,tokens.RefreshToken);
            return Ok();
        }
       
        private void TokensInCookies(string accessToken,string refreshToken)
        {
            HttpContext.Response.Cookies.Append("RefereshToken", refreshToken); //todo to private method
            HttpContext.Response.Cookies.Append("AccessToken", accessToken);
        }
    }
}
