using EducationApp.DataAccessLayer.Entities;
using EducationApp.DataAccessLayer.Helpers;
using EducationApp.DataAccessLayer.Models;
using System.Threading.Tasks;

namespace EducationApp.DataAccessLayer.Ropositories.Interfaces
{
    public interface IUserRepository
    {
        Task<bool> CreateUserAsync(ApplicationUser user,string password);
        Task<bool> EditAsync(ApplicationUser user);
        Task<bool> RemoveAsync(ApplicationUser user);
        Task<string> CheckRoleAsync(string email);
        Task<ApplicationUser> GetByIdAsync(long id);
        Task<ApplicationUser> GetByNameAsync(string userName);
        Task<bool> ChangePasswordAsync(ApplicationUser user, string oldPasswor, string newPassword);
        Task<bool> ChangeEmailAsync(ApplicationUser user ,string newEmail);
        Task<ApplicationUser> GetByEmailAsync(string email);
        Task<bool> ConfirmEmailAsync(ApplicationUser user,string token);
        Task<string> GenerateEmailConfirmationTokenAsync(ApplicationUser user);
        Task<bool> ConfirmPasswordAsync(ApplicationUser user, string password);
        Task<string> GeneratePasswordResetTokenAsync(ApplicationUser user);
        Task<ApplicationUser> FindByEmailAsync(string email);
        Task<bool> ResetPasswordAsync(ApplicationUser user, string newPassword);
        Task<string> GetRoleAsync(ApplicationUser user);
        Task<bool> BlockUserAsync(ApplicationUser user);
        Task SignOut();
        Task<UserPresentationModel> GetUserAsync(UserFilterModel state);


    }
}
