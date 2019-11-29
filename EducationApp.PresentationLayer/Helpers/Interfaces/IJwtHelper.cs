using EducationApp.BusinessLogicLayer.Models.Token;
using EducationApp.BusinessLogicLayer.Models.Users;
using System.IdentityModel.Tokens.Jwt;

namespace EducationApp.PresentationLayer.Helpers.Interfaces
{
    public interface IJwtHelper
    {
        TokenModel GenerateTokenModel(UserModelItem user);
        JwtSecurityToken ValidateToken(string token);
    }
}
