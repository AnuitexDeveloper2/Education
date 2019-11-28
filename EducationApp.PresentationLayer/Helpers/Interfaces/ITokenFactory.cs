using EducationApp.BusinessLogicLayer.Models.Users;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using static EducationApp.PresentationLayer.Helpers.TokenFactory;

namespace EducationApp.PresentationLayer.Helpers.Interfaces
{
    public interface ITokenFactory
    {
        TokenModel GenerateTokenModel(UserModelItem user);
        JwtSecurityToken GenerateToken(List<Claim> claims, double expires);
        JwtSecurityToken ValidateToken(string token);
    }
}
