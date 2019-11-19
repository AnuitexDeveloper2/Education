using EducationApp.BusinessLogicLayer.Extention.User;
using EducationApp.BusinessLogicLayer.Models;
using EducationApp.BusinessLogicLayer.Models.Base;
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
using static EducationApp.DataAccessLayer.Entities.Enums.Enums;

namespace EducationApp.BusinessLogicLayer.Services
{
    public interface IUserService
    {
        Task<BaseModel> RemoveUserAsync(long id);
        Task<BaseModel> BlockUserAsync(long id);
        Task<UserModelItem> GetProfileAsync(long id);
        Task<BaseModel> EditProfileAsync(UserProfileEditModel model);
        Task <UserModel> GetUsersAsync(UserFilterModel filter);
        Task<BaseModel> RestorePasswordAsync(UserModelItem model);



    }
}
