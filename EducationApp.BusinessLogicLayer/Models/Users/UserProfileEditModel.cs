using EducationApp.BusinessLogicLayer.Models.Base;

namespace EducationApp.BusinessLogicLayer.Models.Users
{
    public class UserProfileEditModel : BaseModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public long Id { get; set; }
    }
}
