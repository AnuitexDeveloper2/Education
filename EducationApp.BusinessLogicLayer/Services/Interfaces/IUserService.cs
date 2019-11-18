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
        Task<UserItemModel> GetByIdAsync(long Id);
        Task<BaseModel> BlockUserAsync(long id);
        Task<UserItemModel> GetProfileAsync(long id);
        Task<BaseModel> EditProfileAsync(UserProfileEditModel model);
        Task <List<UserItemModel>> UserFilterModel(UserFilterModel filter);
        Task<BaseModel> RestorePasswordAsync(UserItemModel model);



    }
}
