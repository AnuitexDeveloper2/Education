using System.Threading.Tasks;
using EducationApp.BusinessLogicLayer.Extention.User;
using EducationApp.BusinessLogicLayer.Helpers;
using EducationApp.BusinessLogicLayer.Helpers.Mapping;
using EducationApp.BusinessLogicLayer.Models.Base;
using EducationApp.BusinessLogicLayer.Models.Users;
using EducationApp.DataAccessLayer.Ropositories.Interfaces;
using errors = EducationApp.BusinessLogicLayer.Common.Consts.Constants.Errors;
using EducationApp.BusinessLogicLayer.Extention.Mapper.UserMapper;

namespace EducationApp.BusinessLogicLayer.Services
{
    class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<BaseModel> EditProfileAsync(UserProfileEditModel model)
        {
            var resultModel = new BaseModel();

            if (model.FirstName == null || model.LastName == null)
            {
                resultModel.Errors.Add(errors.EmptyField);
                return resultModel;
            }

            var user = await _userRepository.GetByIdAsync(model.Id);

            if (user == null)
            {
                resultModel.Errors.Add(errors.UserNotFound);
                return resultModel;
            }

           

            var result = await _userRepository.EditAsync(user.Map(model));

            if (!result)
            {
                resultModel.Errors.Add(errors.EditUserFailure);
                return resultModel;
            }

            return resultModel;
        }

        public async Task<BaseModel> RemoveUserAsync(long id)
        {
            var resultModel = new UserModelItem();
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null)
            {
                resultModel.Errors.Add(errors.UserNotFound);
                return resultModel;
            }

            var result = await _userRepository.RemoveAsync(user);
            
            if (!result)
            {
                resultModel.Errors.Add(errors.Remove);
            }

            return resultModel;
        }

        public async Task<BaseModel> BlockUserAsync(long id)
        {
            var resultModel = new BaseModel();

            var user = await _userRepository.GetByIdAsync(id);

            if (user == null)
            {
                resultModel.Errors.Add(errors.UserNotFound);
                return resultModel;
            }

            var result = await _userRepository.BlockAsync(user);

            if (!result)
            {
                resultModel.Errors.Add(errors.Blok);
            }

            return resultModel;
        }

        public async Task<BaseModel> ChangePassword(long id, string oldPassword,string newPassword)
        {
            var resultModel = new BaseModel();

            var user = await _userRepository.GetByIdAsync(id);

            if (user == null)
            {
                resultModel.Errors.Add(errors.UserNotFound);
                return resultModel;
            }

            var result = await _userRepository.ResetPasswordAsync(user, newPassword);

            if (!result)
            {
                resultModel.Errors.Add(errors.ChangePasswordFailure);
            }
            return resultModel;

        }


        public async Task<UserModelItem> GetProfileAsync(long id)
        {
            var resultModel = new UserModelItem();

            var user = await _userRepository.GetByIdAsync(id);

            if (user == null)
            {
                resultModel.Errors.Add(errors.UserNotFound);
                return resultModel;
            }

            resultModel = user.Map();

            return resultModel;
        }

        public async Task<UserModel> GetUsersAsync(UserFilterModel userFilter)
        {
            var filter = userFilter.Map();

            var users = await _userRepository.GetFilteredAsync(filter);

            var usersModel = new UserModel();

            if (users == null)
            {
                usersModel.Errors.Add(errors.UserNotFound);
                return usersModel;
            }

            for (int i = 0; i < users.Data.Count; i++)
            {
                usersModel.Items.Add(users.Data[i].Map());
            }

            usersModel.Count = users.Count;

            return usersModel;
        }


    }
}
