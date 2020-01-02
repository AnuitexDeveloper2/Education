using EducationApp.BusinessLogicLayer.Models.MyOptions.Email;
using EducationApp.BusinessLogicLayer.Models.MyOptions.JWT;
using EducationApp.BusinessLogicLayer.Models.MyOptions.Password;

namespace EducationApp.BusinessLogicLayer.Models.MyOptions
{
    public class MyOptions
    {
        public EmailOptions EmailOptions { get; set; }
        public JWTOptions JWTOptions { get; set; }
        public PasswordOptions PasswordOptions { get; set; }
    }
}
