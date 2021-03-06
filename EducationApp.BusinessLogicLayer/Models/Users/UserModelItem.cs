using EducationApp.BusinessLogicLayer.Models.Base;

namespace EducationApp.BusinessLogicLayer.Models.Users
{
    public class UserModelItem : BaseModel
    {
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public long Id { get; set; }
        public string Role { get; set; }
        public bool LockoutEnabled { get; set; }
        public string Password { get; set; }

    }
}
