using EducationApp.BusinessLogicLayer.Extention.User;
using EducationApp.BusinessLogicLayer.Models.Base;
using EducationApp.BusinessLogicLayer.Models.Users;
using System.Threading.Tasks;

namespace EducationApp.BusinessLogicLayer.Services
{
    public interface IUserService
    {
        Task<BaseModel> RemoveUserAsync(long id);
        Task<BaseModel> BlockUserAsync(long id);
        Task<UserModelItem> GetProfileAsync(long id);
        Task<BaseModel> EditProfileAsync(UserProfileEditModel model);
        Task <UserModel> GetUsersAsync(UserFilterModel filter);
        Task<BaseModel> RestorePasswordAsync(string email);
        Task<BaseModel> ChangePassword( long id, string oldPassword, string newPassword);



    }
}
