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

namespace EducationApp.PresentationLayer.Helpers
{
    public class JWTHelpers : IJWTHelpers
    {
        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(JWTConsts.Key));
        }


    }
}
