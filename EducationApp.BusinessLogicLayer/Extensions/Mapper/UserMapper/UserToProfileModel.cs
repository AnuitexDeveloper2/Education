using EducationApp.BusinessLogicLayer.Models.Users;
using EducationApp.DataAccessLayer.Entities;

namespace EducationApp.BusinessLogicLayer.Extention.Mapper.UserMapper
{
    public static partial class UserMapper
    {
        public static ApplicationUser Map(this ApplicationUser user, UserProfileEditModel editUserModel)
        {
            user.FirstName = editUserModel.FirstName;
            user.LastName = editUserModel.LastName;
            user.UserName = user.UserName;
            return user;
        }
    }
}
