using EducationApp.BusinessLogicLayer.Extention.User;
using EducationApp.BusinessLogicLayer.Models;
using EducationApp.BusinessLogicLayer.Models.Users;
using EducationApp.DataAccessLayer.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using static EducationApp.BusinessLogicLayer.Extention.Enums.Enums;

namespace EducationApp.BusinessLogicLayer.Services
{
    public interface IUserService
    {
        Task<bool> Remove(UserItemModel model);
        Task<bool> ChangePassword(UserItemModel model, string oldPassword, string newPassword);
        Task<bool> ChangeEmail(UserItemModel model,string email);
        Task<UserItemModel> GetById(long Id);
        Task<ApplicationUser> GetByName(string name);
        Task<UserItemModel> GetByEmail(string email);
        Task<bool> BlockUserAsync(long id);
        Task<UserItemModel> Profile(long id);
        bool ExcistUser(ApplicationUser user);
        Task<bool> EditProfile(UserItemModel model);
        List<UserItemModel> SortUsers(UserActionModel state);
        List<UserItemModel> FilterModel(UserActionModel filterUser);



    }
}
