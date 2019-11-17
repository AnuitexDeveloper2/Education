using EducationApp.BusinessLogicLayer.Models.Users;
using EducationApp.DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EducationApp.BusinessLogicLayer.Services.Interfaces
{
    public interface IAccountService
    {
        Task<bool> ConfirmEmailAsync(string email);
        Task<bool> RestorePasswordAsync(UserItemModel model);
        Task<ApplicationUser> GetUserAsync(string userName, string password);
        Task<bool> CreateUserAsync(UserItemModel userItemModel);
        Task<string> GenerateEmailConfirmationTokenAsync(UserItemModel user);
        Task<ApplicationUser> GetByIdAsync(long Id);
        Task<UserItemModel> GetByEmailAsync(string email);
        Task<bool> SignInAsync(string email, string password);
        Task SignOutAsync();
        Task<string> GetRoleAsync(ApplicationUser user);
        Task<bool> ConfirmPasswordAsync(ApplicationUser user,string password);
    }
}
