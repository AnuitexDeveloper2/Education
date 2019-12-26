using EducationApp.BusinessLogicLayer.Models.Users;
using EducationApp.DataAccessLayer.Entities;

namespace EducationApp.BusinessLogicLayer.Extention.Mapper.UserMapper
{
    public static partial class UserMapper
    {
        public static UserModelItem Map(this ApplicationUser user)
        {
            var userItemModel = new UserModelItem
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Id = user.Id,
                UserName = user.UserName,
                LockoutEnabled = user.LockoutEnabled
            };
            return userItemModel;
        }
    }
}
