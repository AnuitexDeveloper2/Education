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
        Task<bool> RestorePasswordAsync(ApplicationUser user,string token, string newPassword);
        Task<ApplicationUser> GetUserAsync(string userName, string password);
        Task<ApplicationUser> RegisterAsync(string email, string password,string firstName,string lastName);
        Task<string> GenerateEmailConfirmationTokenAsync(ApplicationUser user);
        Task<ApplicationUser> GetByIdAsync(long Id);
        Task<ApplicationUser> GetByEmailAsync(string email);
        Task<ApplicationUser> SignInAsync(string email, string password);
        Task SignOutAsync();
        Task<string> GeneratePasswordResetTokenAsync(ApplicationUser user);
    }
}
