using EducationApp.DataAccessLayer.Entities;
using EducationApp.DataAccessLayer.Helpers;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using static EducationApp.DataAccessLayer.Entities.Enums.Enums;

namespace EducationApp.DataAccessLayer.Ropositories.Interfaces
{
    public interface IUserRepository
    {
        Task<bool> CreateUserAsync(ApplicationUser user);
        Task<bool> EditAsync(ApplicationUser user);
        Task<bool> RemoveAsync(ApplicationUser user);
        Task<string> CheckRoleAsync(string email);
        Task<ApplicationUser> GetByIdAsync(long id);
        Task<ApplicationUser> GetByNameAsync(string userName);
        Task<bool> ChangePasswordAsync(ApplicationUser user, string oldPasswor, string newPassword);
        Task<bool> ChangeEmailAsync( string newEmail, string token);
        Task<ApplicationUser> GetByEmailAsync(string email);
        Task<bool> ConfirmEmailAsync(ApplicationUser user,string token);
        Task<bool> ConfirmPasswordAsync(ApplicationUser user, string password);
        Task<string> GenerateEmailConfirmationTokenAsync(ApplicationUser user);
        Task<string> GeneratePasswordResetTokenAsync(ApplicationUser user);
        Task<ApplicationUser> FindByEmailAsync(string email);
        Task<bool> SignInAsync(string email, string password);
        Task SignOut();
        Task<IdentityResult> ResetPassword(ApplicationUser user, string token, string newPassword);
        Task<string> GenerateChangeEmailTokenAsync(ApplicationUser user, string newEmail);
        Task<string> GetRoleAsync(ApplicationUser user);
        List<ApplicationUser> FilterUsers(UsersFilter state);


    }
}
