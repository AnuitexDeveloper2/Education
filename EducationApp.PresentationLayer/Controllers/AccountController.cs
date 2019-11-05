using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using EducationApp.BusinessLogicLayer.Helpers;
using EducationApp.BusinessLogicLayer.Models.Users;
using EducationApp.BusinessLogicLayer.Services;
using EducationApp.BusinessLogicLayer.Services.Interfaces;
using EducationApp.PresentationLayer.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using static EducationApp.BusinessLogicLayer.Common.Consts.Consts.JWTConsts;
using static EducationApp.BusinessLogicLayer.Common.Consts.Consts.EmailConsts;
using EducationApp.BusinessLogicLayer.Models.Account;
using EducationApp.PresentationLayer.Helpers.Interfaces;

namespace EducationApp.PresentationLayer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IJWTHelpers _jWTHelpers;
        private readonly IAccountService _accountService;

        public AccountController(IJWTHelpers jWTHelpers, IAccountService accountService)
        {
            _jWTHelpers = jWTHelpers;
            _accountService = accountService;
        }



        [HttpPost("register")]
        public async Task<ActionResult> Register(RegistrationModel model)
        {
            var user = await _accountService.RegisterAsync(model.FirstName, model.Email, model.Password);

            if (user != null)
            {

                EmailSender email = new EmailSender();
                email.SendingEmailAsync(UserEmail, MailSubject, MailBody);
            }

            return Content("Для завершения регистрации проверьте электронную почту и перейдите по ссылке, указанной в письме");
        }

        [HttpGet("confirmEmail")]
        public async Task<ActionResult> ConfirmEmail(UserItemModel model)
        {
            var user = await _accountService.GetByEmail(model.Email);
            var encodedJwt = await _jWTHelpers.GenerateTokenModel(model);
            await _accountService.ConfirmEmailAsync(UserEmail);
            HttpContext.Response.Cookies.Append("AccessToken",encodedJwt.AccessToken);
            HttpContext.Response.Cookies.Append("RefereshToken",encodedJwt.RefreshToken);
            return Ok();
        }

        [HttpPost("forgotPassword")]
        public async Task<ActionResult> ForgotPassword(RegistrationModel model)
        {
            var user = await _accountService.GetById(model.Id);
            await _accountService.RestorePassword(user, "234");
            return Ok();
        }
        [HttpPost("signIn")]
        public async Task<ActionResult> SignIn(string email,string password)
        {
            HttpContext.Response.Cookies.Append(access)
            return Ok();
        }

        [HttpPost("signOut")]
        public async Task<ActionResult> Signout()
        {
            await +_accountService.
            return Ok();
        }
    }
}




















//[HttpGet("token")]

//public void Token(string userName,string password)
//{
//    userName = "Education";
//    password = "123";
//    var identity = GetUser(userName, password);
//    var now = DateTime.UtcNow;
//    var jwt = new JwtSecurityToken(
//            issuer: Issuer,
//            audience: Audience,
//            notBefore: now,
//            claims: identity.Claims,
//            expires: now.Add(TimeSpan.FromMinutes(Lifetimew)),
//            signingCredentials: new SigningCredentials(JWTHelpers.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
//    var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);
//}


//private ClaimsIdentity GetUser(string username, string password)
//{
//    UsersModel usersModel = new UsersModel { Email = "educationappgoncharuk2019@gmail.com", Password = "Education2019" };
//    if (usersModel != null)
//    {
//        var claims = new List<Claim>
//                {
//                    new Claim(ClaimsIdentity.DefaultNameClaimType, usersModel.Email),
//                    new Claim(ClaimsIdentity.DefaultRoleClaimType, usersModel.Password)
//                };
//        ClaimsIdentity claimsIdentity =
//        new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType,
//            ClaimsIdentity.DefaultRoleClaimType);
//        return claimsIdentity;
//    }
//    return null;
//}
