namespace EducationApp.BusinessLogicLayer.Common.Consts
{
  partial class Constants
    {
        public class JWTConsts
        {
            public const string Issuer = "MyAuthServer"; 
            public const string Audience = "https://localhost:44309/"; 
            public const string Key = "mysupersecret_secretkey!123";   
            public const int Lifetimew = 10;
            
        }
    }
}
