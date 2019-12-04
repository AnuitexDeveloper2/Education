using EducationApp.BusinessLogicLayer.Models.Users;
using EducationApp.DataAccessLayer.Entities;

namespace EducationApp.BusinessLogicLayer.Helpers.Mapping
{
    public static partial class UserMapper
    {
        public static ApplicationUser Map(this UserModelItem model)
        {
            ApplicationUser user = new ApplicationUser
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                Id = model.Id,
                UserName = model.UserName
            };
            return user;
        }
    }
}


