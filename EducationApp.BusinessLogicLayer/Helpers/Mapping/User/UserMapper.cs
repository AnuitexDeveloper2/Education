﻿using EducationApp.BusinessLogicLayer.Extention.User;
using EducationApp.BusinessLogicLayer.Models.Users;
using EducationApp.DataAccessLayer.Entities;
using EducationApp.DataAccessLayer.Helpers;
using EducationApp.DataAccessLayer.Models;

namespace EducationApp.BusinessLogicLayer.Helpers.Mapping
{
    public static class UserMapper
    {
        public static ApplicationUser Map(this UserModelItem model)
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

        public static UserModelItem Map(this ApplicationUser user)
        {
            UserModelItem userItemModel = new UserModelItem
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
        public static DataAccessLayer.Helpers.UserFilterModel Map(this Extention.User.UserFilterModel filterUser)
        {
            var userFilter = new DataAccessLayer.Helpers.UserFilterModel
            {
                UsersSortType = (DataAccessLayer.Entities.Enums.Enums.UserSortType)filterUser.UserSortType,
                UsersFilterType = (DataAccessLayer.Entities.Enums.Enums.UserFilterType)filterUser.UsersFilterStatus,
                PageCount = filterUser.PageCount,
                PageSize = filterUser.PageSize,
                SearchString = filterUser.SearchString
                
            };
            return userFilter;
        }
        public static ApplicationUser Map(UserProfileEditModel editUserModel,ApplicationUser user)
        {
            user.FirstName = editUserModel.FirstName;
            user.LastName = editUserModel.LastName;
            user.UserName = user.UserName;
            return user;
        }
       
    }
}
