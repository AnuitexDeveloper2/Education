using EducationApp.BusinessLogicLayer.Models.Users;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using static EducationApp.PresentationLayer.Helpers.JWTHelpers;

namespace EducationApp.PresentationLayer.Helpers.Interfaces
{
    public interface IJWTHelpers
    {
        Task<TokenModel> GenerateTokenModel(UserItemModel user);
        Task<JwtSecurityToken> GenerateToken(List<Claim> claims, long expires);

    }
}
