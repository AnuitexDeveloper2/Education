using EducationApp.BusinessLogicLayer.Models.Users;
using EducationApp.DataAccessLayer.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EducationApp.BusinessLogicLayer.Services
{
    public interface IUserService
    {
        Task<bool> Remove(ApplicationUser user);
        Task<bool> ChangePassword(ApplicationUser user, string oldPassword, string newPassword);
        Task<bool> ChangeEmail(ApplicationUser user,string email);
        Task<ApplicationUser> GetById(long Id);
        Task<ApplicationUser> GetByName(string name);
        Task<ApplicationUser> GetByEmail(string email);
        void FilterUsers();
        Task<bool> BlockUserAsync(long id);
        Task<UserItemModel> Profile(long id);
        bool ExcistUser(ApplicationUser user);
        Task<bool> EditProfile(UserItemModel model);

    }
}
