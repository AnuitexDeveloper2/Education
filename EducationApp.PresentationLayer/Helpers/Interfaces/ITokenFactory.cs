using EducationApp.BusinessLogicLayer.Models.Users;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
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
