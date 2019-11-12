using System.Threading.Tasks;
using EducationApp.BusinessLogicLayer.Helpers;
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
using System.Security.Principal;
using System.Collections.Generic;

namespace EducationApp.PresentationLayer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly ITokenFactory _tokenFactory;
        private readonly IAccountService _accountService;
        private readonly TokenValidationParameters _tokenValidationParameters;

        public AccountController(ITokenFactory tokenFactory, IAccountService accountService,TokenValidationParameters tokenValidationParameters)
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
            var user = await _accountService.GetByEmailAsync(model.Email);
            if (user == null)
            {
                return BadRequest();
            }
            var token = await _accountService.GeneratePasswordResetTokenAsync(user);
            await _accountService.RestorePasswordAsync(user, token, model.Password);
            return Ok();
        }
        [HttpPost("signIn")]
        public async Task<ActionResult> SignIn(UserItemModel model)
        {
            if (string.IsNullOrEmpty(model.Email) && string.IsNullOrEmpty(model.Password))
            {
                return Content(Invalid);
            }
            var user = await _accountService.GetByEmailAsync(model.Email);
            var passwordValid = await _accountService.ConfirmPasswordAsync(user, model.Password);
            if (!passwordValid)
            {
                return Content(Invalid);
            }
            model.Role = await _accountService.GetRoleAsync(user);
            model.UserName = user.UserName;
            model.Id = user.Id;
            model.SecurityStamp = user.SecurityStamp;
            if (user != null)
            {
                var tokens = _tokenFactory.GenerateTokenModel(model);
                HttpContext.Response.Cookies.Append("RefereshToken", tokens.RefreshToken);
                HttpContext.Response.Cookies.Append("AccessToken", tokens.AccessToken);
                CheckJwtToken(tokens.AccessToken, tokens.RefreshToken);
                await _accountService.SignInAsync(model.Email, model.Password);
               
               
            }
                    return Ok();
        }
        [Authorize]
        [HttpPost("signOut")]
        public async Task<ActionResult> SignOutAsync()
        {
            await _accountService.SignOutAsync();
            return Ok();
        }

        //public List<UserItemModel> Filter()
        //{
        //    return 
        //}
        public  ActionResult RefreshToken(string refreshToken)
        {
            var expires = new JwtSecurityTokenHandler().ReadToken(refreshToken).ValidTo;

            if (expires >= DateTime.Now)
            {
                try
                {

                var userId = this.HttpContext.User.Claims
               .FirstOrDefault(x => x.Type == ClaimTypes.Role).Value;
                }
                catch (Exception ex)
                {

                    throw;
                }
                
            }
            return Ok();
        }
        public bool CheckJwtToken(string accessToken, string refreshToken)
        {
            var expiresAccess = new JwtSecurityTokenHandler().ReadToken(accessToken).ValidTo;

            if (expiresAccess > DateTime.Now)
            {
                 RefreshToken(accessToken);
            }
            return true;
        }



       

        }
}
