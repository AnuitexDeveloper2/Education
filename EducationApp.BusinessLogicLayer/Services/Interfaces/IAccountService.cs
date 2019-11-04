using EducationApp.DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EducationApp.BusinessLogicLayer.Services.Interfaces
{
    public interface IAccountService
    {
        Task ConfirmEmailAsync(string email);
        Task RestorePassword(string newPassword);
        Task<ApplicationUser> GetUserAsync(string userName, string password);
        Task<ApplicationUser> RegisterAsync();
    }
}
