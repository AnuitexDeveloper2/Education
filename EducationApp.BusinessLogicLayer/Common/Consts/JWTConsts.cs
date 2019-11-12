using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace EducationApp.BusinessLogicLayer.Common.Consts
{
    partial class Consts
    {

        public class JWTConsts
        {
            public const string Issuer = "MyAuthServer"; 
            public const string Audience = "https://localhost:49945/"; 
            public const string Key = "mysupersecret_secretkey!123";   
            public const int Lifetimew = 10;
            
            public static SymmetricSecurityKey GetSymmetricSecurityKey()
            {
                return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(JWTConsts.Key));
            }
        }
    }
}
