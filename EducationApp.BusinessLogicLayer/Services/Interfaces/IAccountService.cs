using EducationApp.BusinessLogicLayer.Models.Base;
using EducationApp.BusinessLogicLayer.Models.Users;
using System.Threading.Tasks;

namespace EducationApp.BusinessLogicLayer.Services.Interfaces
{
    public interface IAccountService
    {
        Task<BaseModel> ConfirmEmailAsync(string email);
        Task<BaseModel> CreateUserAsync(UserModelItem userItemModel);
        Task<UserModelItem> GetByIdAsync(long Id);
        Task<UserModelItem> GetByEmailAsync(string email);
        Task<UserModelItem> SignInAsync(string email, string password);
        Task<BaseModel> RestorePasswordAsync(string email);
        Task SignOutAsync();
    }
}
