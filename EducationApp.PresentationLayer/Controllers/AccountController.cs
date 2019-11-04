using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using EducationApp.BusinessLogicLayer.Models.Users;
using EducationApp.BusinessLogicLayer.Services;
using EducationApp.BusinessLogicLayer.Services.Interfaces;
using EducationApp.PresentationLayer.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using static EducationApp.BusinessLogicLayer.Common.Consts.Consts.JWTConsts;

namespace EducationApp.PresentationLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly JWTHelpers _jWTHelpers;
        private readonly IAccountService _accountService;

        public AccountController(JWTHelpers jWTHelpers, IAccountService accountService)
        {
            _jWTHelpers = jWTHelpers;
            _accountService = accountService;
        }

        [HttpGet("token")]

        public void Token(string userName,string password)
        {
            userName = "Education";
            password = "123";
            var identity = GetUser(userName, password);
            var now = DateTime.UtcNow;
            var jwt = new JwtSecurityToken(
                    issuer: Issuer,
                    audience: Audience,
                    notBefore: now,
                    claims: identity.Claims,
                    expires: now.Add(TimeSpan.FromMinutes(Lifetimew)),
                    signingCredentials: new SigningCredentials(JWTHelpers.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);
        }


        private ClaimsIdentity GetUser(string username, string password)
        {
            UsersModel usersModel = new UsersModel { Email = "educationappgoncharuk2019@gmail.com",Password= "Education2019" };
            if (usersModel != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimsIdentity.DefaultNameClaimType, usersModel.Email),
                    new Claim(ClaimsIdentity.DefaultRoleClaimType, usersModel.Password)
                };
                ClaimsIdentity claimsIdentity =
                new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType,
                    ClaimsIdentity.DefaultRoleClaimType);
                return claimsIdentity;
            }

            
            return  null;
        }
    }
}