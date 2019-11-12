using EducationApp.BusinessLogicLayer.Models.Users;
using EducationApp.BusinessLogicLayer.Services;
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
    public class TokenFactory : ITokenFactory
    {
       public JwtSecurityToken  securityToken;
        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(JWTConsts.Key));
        }
        public TokenModel GenerateTokenModel(UserItemModel user)
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
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Email,user.Email)
                };

            var accessToken =  GenerateToken(claimsAccess, 200.0);
            var refreshToken =  GenerateToken(claimsRefresh, 450.0);
            securityToken = refreshToken;
            return new TokenModel
            {
                AccessToken = new JwtSecurityTokenHandler().WriteToken(accessToken),
                RefreshToken = new JwtSecurityTokenHandler().WriteToken(refreshToken)
            };
        }

        public JwtSecurityToken GenerateToken(List<Claim> claims, double expires)
        {
            var token = new JwtSecurityToken(
            issuer: Issuer,
            audience: Audience,
            claims: claims,
            expires: DateTime.Now.AddMinutes(expires),
            signingCredentials: new SigningCredentials(GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256)) ;
            return token;
        }
    


        public class TokenModel
        {
            public string AccessToken { get; set; }
            public string RefreshToken { get; set; }
        }

        public JwtSecurityToken ValidateToken(string token)
        {
            string refreshToken = new JwtSecurityTokenHandler().WriteToken(securityToken);
            
            return securityToken;
        }

        private static ClaimsPrincipal GetPrincipal(string token)
        {
            throw new NotImplementedException();
        }
    }
}
