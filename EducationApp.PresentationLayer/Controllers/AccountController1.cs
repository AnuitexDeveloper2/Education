using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using EducationApp.BusinessLogicLayer.Services;
using EducationApp.PresentationLayer.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using static EducationApp.BusinessLogicLayer.Common.Consts.Consts.JWTConsts;
using EducationApp.BusinessLogicLayer.Models.Users;
using EducationApp.DataAccessLayer.Entities;
using System.Security.Claims;
using EducationApp.BusinessLogicLayer.Services.Interfaces;

namespace EducationApp.PresentationLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController1 : ControllerBase
    {

        private readonly IAccountService _accountService;
        private readonly UserManager<ApplicationUser> _userManager;
        public AccountController1(IAccountService accountService, UserManager<ApplicationUser> userManager)
        {
            _accountService = accountService;
            _userManager = userManager;
        }


        private List<UsersModel> people = new List<UsersModel>
        {
            new UsersModel {Email ="educationappgoncharuk2019@gmail.com",Password ="Education2019" },
        };

        [HttpPost("/token")]
        public async Task Token()
        {
            var email = Request.Form["username"];
            var password = Request.Form["password"];

            var identity = GetIdentity(email, password);
            if (identity == null)
            {
                Response.StatusCode = 400;
                await Response.WriteAsync("Invalid username or password.");
                return;
            }

            var now = DateTime.UtcNow;
            // создаем JWT-токен
            var jwt = new JwtSecurityToken(
                    issuer: Issuer,
                    audience: Audience,
                    notBefore: now,
                    claims: identity.Claims,
                    expires: now.Add(TimeSpan.FromMinutes(Lifetimew)),
                    signingCredentials: new SigningCredentials(JWTHelpers.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            var response = new
            {
                access_token = encodedJwt,
                username = identity.Name
            };

            // сериализация ответа
            Response.ContentType = "application/json";
            await Response.WriteAsync(JsonConvert.SerializeObject(response, new JsonSerializerSettings { Formatting = Formatting.Indented }));
        }

        private ClaimsIdentity GetIdentity(string email, string password)
        {
            UsersModel person = people.FirstOrDefault(x => x.Email == email && x.Password == password);
            if (person != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimsIdentity.DefaultNameClaimType, person.Email),
                    new Claim(ClaimsIdentity.DefaultRoleClaimType, person.Password)
                };
                ClaimsIdentity claimsIdentity =
                new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType,
                    ClaimsIdentity.DefaultRoleClaimType);
                return claimsIdentity;
            }

            return null;
        }

    }
}
[ApiController]
[Route("api/[controller]")]
public class AccountController : ControllerBase
{
    private readonly IAccountServise _accountService;
    private readonly IJwtHelper _jwtHelper;

    public AccountController(IAccountServise accountService, IJwtHelper jwtHelper)
    {
        _accountService = accountService;
        _jwtHelper = jwtHelper;
    }

    [HttpGet("login")]
    public async Task<IActionResult> Login(string userName, string password)
    {
        var resultModel = new BaseModel();
        var user = await _accountService.FindByNameAsync(userName);

        var encodedJwt = await _jwtHelper.GenerateTokenModel(user);

        if (encodedJwt == null)
        {
            resultModel.Errors.Add("some error");
            return Ok(resultModel);
        }

        HttpContext.Response.Cookies.Append("accessToken", encodedJwt.AccessToken);
        HttpContext.Response.Cookies.Append("refreshToken", encodedJwt.RefreshToken);
        return Ok(resultModel);
    }

    [HttpGet("register")]
    public async Task<IActionResult> Register()
    {
        await _accountService.Register();
        return Ok(new BaseModel());
    }

    [HttpGet("confirmEmail")]
    public async Task<IActionResult> ConfirmEmail(string userId, string token)
    {
        return Ok(await _accountService.ConfirmEmail(userId, token));
    }

    [HttpGet("forgotPassword")]
    public async Task<IActionResult> ForgotPassword()
    {
        return Ok(await _accountService.ForgotPassword(""));
    }


    //public async Task<IActionResult> CheckJwtToken(string accessToken, string refreshToken)
    //{
    //    var expiresAccess = new JwtSecurityTokenHandler().ReadToken(accessToken).ValidTo;

    //    if (expiresAccess < DateTime.Now)
    //    {
    //        await RefreshToken(refreshToken);
    //    }
    //    return Ok();
    //}

    public async Task<IActionResult> RefreshToken(string refreshToken)
    {
        var expires = new JwtSecurityTokenHandler().ReadToken(refreshToken).ValidTo; //check token from jwtHelper

        if (expires >= DateTime.Now)
        {
            var userId = this.HttpContext.User.Claims
           .FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value;
            var user = await _accountService.FindByNameAsync(userId);
            var encodedJwt = await _jwtHelper.GenerateTokenModel(user);
        }
        return Ok(new BaseModel());
    }
}