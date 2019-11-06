using System.Threading.Tasks;
using EducationApp.BusinessLogicLayer.Helpers;
using EducationApp.BusinessLogicLayer.Models.Users;
using EducationApp.BusinessLogicLayer.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static EducationApp.BusinessLogicLayer.Common.Consts.Consts.EmailConsts;
using EducationApp.BusinessLogicLayer.Models.Account;
using EducationApp.PresentationLayer.Helpers.Interfaces;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

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
            await _accountService.RegisterAsync( model.Email, model.Password, model.FirstName,model.LastName);

           
            return Ok();
        }

        [HttpPost("confirmEmail")]
        public async Task<ActionResult> ConfirmEmail( UserItemModel model,string token)
        {
            var confirmUser = await _accountService.ConfirmEmailAsync(model.Email);
            if (!confirmUser)
            {
                return Content(Error);
            }
            var tokens = _jWTHelpers.GenerateTokenModel(model) ;
            HttpContext.Response.Cookies.Append("AccessToken", tokens.Result.AccessToken);
            HttpContext.Response.Cookies.Append("RefereshToken", tokens.Result.RefreshToken);
            return Ok();
        }

        [HttpPost("forgotPassword")]
        public async Task<ActionResult> ForgotPassword(UserItemModel model)
        {
            var user = await _accountService.GetByEmailAsync(model.Email);
            if (user == null )
            {
                return Content("ForgotPasswordConfirmation");
            }
            var token = await _accountService.GeneratePasswordResetTokenAsync(user);
            await _accountService.RestorePasswordAsync(user,token, model.Password);
            return Ok();
        }
        [HttpPost("signIn")]
        public async Task<ActionResult> SignIn(UserItemModel model)
        {
            var user = await _accountService.GetByEmailAsync(model.Email);
            var tokens = _jWTHelpers.GenerateTokenModel(model);
            //HttpContext.Response.Cookies.Append("AccessToken", tokens.Result.AccessToken);
            //HttpContext.Response.Cookies.Append("RefereshToken", tokens.Result.RefreshToken);
            await _accountService.SignInAsync(model.Email, model.Password);
            return Ok();
        }

        [HttpGet("signOut")]
        public async Task<ActionResult> SignOut()
        {
            await _accountService.SignOutAsync();
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
