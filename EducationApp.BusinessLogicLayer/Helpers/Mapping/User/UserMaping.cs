using EducationApp.BusinessLogicLayer.Extention.User;
using EducationApp.BusinessLogicLayer.Models.Users;
using EducationApp.DataAccessLayer.Entities;
using EducationApp.DataAccessLayer.Helpers;

namespace EducationApp.BusinessLogicLayer.Helpers.Mapping
{
    public static class UserMaping
    {
        public static ApplicationUser Map(this UserItemModel model)
        {
            ApplicationUser user = new ApplicationUser
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                Id = model.Id,
                SecurityStamp = model.SecurityStamp,
                AccessFailedCount = model.AccessFailedCount,
                ConcurrencyStamp = model.ConcurrencyStamp,
                IsRemoved = model.IsRemoved,
                LockoutEnabled = model.LockoutEnabled,
                UserName = model.UserName
            };
            return user;
        }

        public static UserItemModel Map(this ApplicationUser user)
        {
            UserItemModel userItemModel = new UserItemModel
            {

                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Id = user.Id,
                SecurityStamp = user.SecurityStamp,
                AccessFailedCount = user.AccessFailedCount,
                ConcurrencyStamp = user.ConcurrencyStamp,
                IsRemoved = user.IsRemoved,
                LockoutEnabled = user.LockoutEnabled,
                UserName = user.UserName
            };
            return userItemModel;
        }
        public static UserAction Map(this UserActionModel sortUser)
        {
            var userAction = new UserAction
            {
                SortState = (EducationApp.DataAccessLayer.Entities.Enums.Enums.SortState)sortUser.SortState,
                FilterUser = (DataAccessLayer.Entities.Enums.Enums.FilterState)sortUser.FilterState
            };
            return userAction;
            
        }
    }
}
