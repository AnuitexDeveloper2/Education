using System.Collections.Generic;
using System.Threading.Tasks;
using EducationApp.BusinessLogicLayer.Extention.User;
using EducationApp.BusinessLogicLayer.Helpers.Mapping;
using EducationApp.BusinessLogicLayer.Helpers.Mapping.User;
using EducationApp.BusinessLogicLayer.Models.Base;
using EducationApp.BusinessLogicLayer.Models.Users;
using EducationApp.DataAccessLayer.Ropositories.Interfaces;
using static EducationApp.BusinessLogicLayer.Common.Consts.Consts.Errors;

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
                resultModel.Errors.Add(EmptyField);
                return resultModel;
            }
            var user = await _userRepository.GetByIdAsync(model.Id);
            if (user == null)
            {
                resultModel.Errors.Add(NotFound);
                return resultModel;
            }
            var resultChangeEmail = await _userRepository.ChangeEmailAsync(user,model.Email);
            if (!resultChangeEmail)
            {
                resultModel.Errors.Add(ChangeEmailFailure);
                return resultModel;
            }
           
            var changePassword = await _userRepository.ResetPasswordAsync(user, model.Password);
            user = UserMapper.Map(model,user);
            if (!changePassword)
            {
                resultModel.Errors.Add(ChangePasswordFailure);
                return resultModel;
            }
            var result = await _userRepository.EditAsync(user);
            if (!result)
            {
                resultModel.Errors.Add(EditUserFailure);
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
                resultModel.Errors.Add(NotFound);
                return resultModel; 
            }
           
            var result = await _userRepository.RemoveAsync(user);
            if (!result)
            {
                resultModel.Errors.Add(Remove);
            }
            return resultModel;
        }

        public async Task<BaseModel> BlockUserAsync(long id)
        {
            var resultModel = new BaseModel();
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null)
            {
                resultModel.Errors.Add(NotFound);
                return resultModel;
            }
            var result = await _userRepository.BlockUserAsync(user);
            if (!result)
            {
                resultModel.Errors.Add(Blok);
            }
            return resultModel;
        }


        public async Task<UserModelItem> GetProfileAsync(long id)
        {
            var resultModel = new UserModelItem();
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null)
            {
                resultModel.Errors.Add(NotFound);
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
                resultModel.Errors.Add(NotFound);
                return resultModel;
            }
            var result = await _userRepository.ResetPasswordAsync(user, GeneratePassword.CreateRandomPassword());
            if (!result)
            {
                resultModel.Errors.Add(Token);
            }
            //_emailSender.SendingEmailAsync(user.Email, "Restore Password", newPassword);
            return resultModel;
        }


        public async Task <UserModel> GetUsersAsync(UserFilterModel filter)
        {
            var getUsers = await _userRepository.GetUserAsync(UserMapper.Map(filter));
            var model = new UserModel();
            for (int i = 0; i < getUsers.Data.Count; i++)
            {
                model.Items.Add(UserMapper.Map(getUsers.Data[i]));
            }
            model.Count = getUsers.Count;
            return model;
        }


    }
}
