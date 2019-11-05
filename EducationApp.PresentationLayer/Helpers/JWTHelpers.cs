using EducationApp.BusinessLogicLayer.Models.Users;
using EducationApp.PresentationLayer.Helpers.Interfaces;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using static EducationApp.BusinessLogicLayer.Common.Consts.Consts;
using static EducationApp.BusinessLogicLayer.Common.Consts.Consts.JWTConsts;

namespace EducationApp.PresentationLayer.Helpers
{
    public class JWTHelpers : IJWTHelpers
    {
        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(JWTConsts.Key));
        }
        public async Task<TokenModel> GenerateTokenModel(UserItemModel user)
        {
            if (user == null)
            {
                return null;
            }

            var claimsAccess = new List<Claim>
                {
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Role, user.Role),
                    new Claim(ClaimTypes.Name, user.UserName),
                };

            var claimsRefresh = new List<Claim>
                {
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
                };

            var accessToken = await GenerateToken(claimsAccess, 5);
            var refreshToken = await GenerateToken(claimsRefresh, 30);

            return new TokenModel
            {
                AccessToken = new JwtSecurityTokenHandler().WriteToken(accessToken),
                RefreshToken = new JwtSecurityTokenHandler().WriteToken(refreshToken)
            };
        }

        public async  Task<JwtSecurityToken> GenerateToken(List<Claim> claims, long expires)
        {
            var token = new JwtSecurityToken(
            issuer:Issuer,
            audience: Audience,
            claims: claims,
            expires:  DateTime.Now.AddMinutes(expires),
            signingCredentials: new SigningCredentials(GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
            return token;
        }

        

        public class TokenModel
        {
            public string AccessToken { get; set; }
            public string RefreshToken { get; set; }
        }
    }
}
