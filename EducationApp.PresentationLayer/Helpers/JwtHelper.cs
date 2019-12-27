using EducationApp.BusinessLogicLayer.Models.JWT;
using EducationApp.BusinessLogicLayer.Models.Token;
using EducationApp.BusinessLogicLayer.Models.Users;
using EducationApp.PresentationLayer.Helpers.Interfaces;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using static EducationApp.BusinessLogicLayer.Common.Consts.Constants.JWTConsts;

namespace EducationApp.PresentationLayer.Helpers
{
    public class JwtHelper : IJwtHelper
    {
        private readonly JWTOptions _jWTOptions;
        public JwtHelper(IOptions<JWTOptions> option)
        {
            _jWTOptions = option.Value;
        }
        public JwtSecurityToken securityToken;
        public static SymmetricSecurityKey GetSymmetricSecurityKey(string key)
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(key));
        }
        public TokenModel GenerateTokenModel(UserModelItem user)
        {

            if (user == null)
            {
                return null;
            }

            var claimsRefresh = new List<Claim>
                {
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                };
            var claimsAccess = new List<Claim>
                {
                    new Claim(ClaimTypes.Role, user.Role),
                    new Claim(ClaimTypes.Name, user.UserName)
                 };
            claimsRefresh.AddRange(claimsRefresh);

            var accessToken = GenerateToken(claimsAccess, 200.0);
            var refreshToken = GenerateToken(claimsRefresh, 450.0);
            securityToken = refreshToken;
            return new TokenModel
            {
                AccessToken = new JwtSecurityTokenHandler().WriteToken(accessToken),
                RefreshToken = new JwtSecurityTokenHandler().WriteToken(refreshToken)
            };
        }

        private JwtSecurityToken GenerateToken(List<Claim> claims, double expires)
        {
            var token = new JwtSecurityToken(
            issuer: Issuer,
            audience: Audience,
            claims: claims,
            expires: DateTime.Now.AddMinutes(expires),
            signingCredentials: new SigningCredentials(GetSymmetricSecurityKey(_jWTOptions.Key), SecurityAlgorithms.HmacSha256));
            return token;
        }

        public JwtSecurityToken ValidateToken(string token)
        {
            var refreshToken = new JwtSecurityTokenHandler().ReadJwtToken(token);
            if (refreshToken != null && refreshToken.ValidTo > DateTime.Now)
            {
                return refreshToken;
            }
            return null;
        }

    }
}
