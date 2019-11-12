using EducationApp.BusinessLogicLayer.Models.Users;
using EducationApp.DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

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
                SecurityStamp = model.SecurityStamp
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
                SecurityStamp = user.SecurityStamp
            };
            return userItemModel;
        }
    }
}
