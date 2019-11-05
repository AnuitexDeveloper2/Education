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
        Task<bool> RestorePassword(ApplicationUser user, string newPassword);
        Task<ApplicationUser> GetUserAsync(string userName, string password);
        Task<ApplicationUser> RegisterAsync(string name, string email, string password);
        Task<string> GenerateEmailConfirmationTokenAsync(ApplicationUser user);
        Task<ApplicationUser> GetById(long Id);
        Task<ApplicationUser> GetByEmail(string email);
        Task<ApplicationUser> SignIn(string email, string password);
        Task SignOut();
    }
}
