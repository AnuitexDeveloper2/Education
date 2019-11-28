using System.Collections.Generic;
using System.Threading.Tasks;
using EducationApp.BusinessLogicLayer.Extention.User;
using EducationApp.BusinessLogicLayer.Helpers.Mapping;
using EducationApp.BusinessLogicLayer.Helpers.Mapping.User;
using EducationApp.BusinessLogicLayer.Models.Base;
using EducationApp.BusinessLogicLayer.Models.Users;
using EducationApp.DataAccessLayer.Ropositories.Interfaces;
using errors = EducationApp.BusinessLogicLayer.Common.Consts.Consts.Errors;

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
            if (model == null)
            {
                resultModel.Errors.Add(errors.EmptyField);
                return resultModel;
            }
            var user = await _userRepository.GetByIdAsync(model.Id);
            if (user == null)
            {
                resultModel.Errors.Add(errors.NotFound);
                return resultModel;
            }
            var resultChangeEmail = await _userRepository.ChangeEmailAsync(user,model.Email);
            if (!resultChangeEmail)
            {
                resultModel.Errors.Add(errors.ChangeEmailFailure);
                return resultModel;
            }
           
            var changePassword = await _userRepository.ResetPasswordAsync(user, model.Password);
            user = UserMapper.Map(model,user);
            if (!changePassword)
            {
                resultModel.Errors.Add(errors.ChangePasswordFailure);
                return resultModel;
            }
            var result = await _userRepository.EditAsync(user);
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
                resultModel.Errors.Add(errors.NotFound);
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
                resultModel.Errors.Add(errors.NotFound);
                return resultModel;
            }
            var result = await _userRepository.BlockUserAsync(user);
            if (!result)
            {
                resultModel.Errors.Add(errors.Blok);
            }
            return resultModel;
        }


        public async Task<UserModelItem> GetProfileAsync(long id)
        {
            var resultModel = new UserModelItem();
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null)
            {
                resultModel.Errors.Add(errors.NotFound);
                return resultModel;
            }
            resultModel = UserMapper.Map(user);
            return resultModel; 
        }

        public async Task<BaseModel> RestorePasswordAsync(UserModelItem model)
        {
            var resultModel = new BaseModel();
            var user = await _userRepository.GetByIdAsync(model.Id);
            if (user == null)
            {
                resultModel.Errors.Add(errors.NotFound);
                return resultModel;
            }
            var result = await _userRepository.ResetPasswordAsync(user, GeneratePassword.CreateRandomPassword());
            if (!result)
            {
                resultModel.Errors.Add(errors.Token);
            }
            //_emailSender.SendingEmailAsync(user.Email, "Restore Password", newPassword);
            return resultModel;
        }


        public async Task <UserModel> GetUsersAsync(UserFilterModel userFilter)
        {
            var filter = UserMapper.Map(userFilter);
            var users = await _userRepository.GetUsersAsync(filter);
            var usersModel = new UserModel();
            if (users == null)
            {
                usersModel.Errors.Add(errors.NotFound);
                return usersModel;
            }
            for (int i = 0; i < users.Data.Count; i++)
            {
                usersModel.Items.Add(UserMapper.Map(users.Data[i]));
            }
            usersModel.Count = users.Count;
            return usersModel;
        }


    }
}
