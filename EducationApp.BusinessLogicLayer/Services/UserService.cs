using System.Collections.Generic;
using System.Linq;
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
            var userModel = new UserItemModel();
            if (string.IsNullOrWhiteSpace(model.FirstName)||string.IsNullOrWhiteSpace(model.LastName) || string.IsNullOrWhiteSpace(model.Email)||string.IsNullOrWhiteSpace(model.Password))
            {
                userModel.Errors.Add(EmptyField);
                return userModel;
            }
            var user = await _userRepository.GetByIdAsync(model.Id); //todo check for null, rename method to async
            if (user == null)
            {
                userModel.Errors.Add(NotFound);
                return userModel;
            }
            var tokenEmail = await _userRepository.GenerateChangeEmailTokenAsync(user, model.Email);
            if (tokenEmail == null)
            {
                userModel.Errors.Add(Token);
                return userModel;
            }
            var resultChangeEmail = await _userRepository.ChangeEmailAsync(user,model.Email, tokenEmail);
            if (!resultChangeEmail)
            {
                userModel.Errors.Add(ChangeEmailFailure);
                return userModel;
            }
            var tokenPassword = await _userRepository.GeneratePasswordResetTokenAsync(user);
            if (tokenPassword == null)
            {
                userModel.Errors.Add(Token);
                return userModel;
            }
            var changePassword = await _userRepository.ResetPasswordAsync(user, tokenPassword, model.Password);
            user = UserMapper.Map(model,user); //todo rename UserMapper, add method for update UserEntity from UserModel
            if (!changePassword)
            {
                userModel.Errors.Add(ChangePasswordFailure);
                return userModel;
            }
            var result = await _userRepository.EditAsync(user);
            if (!result)
            {
                userModel.Errors.Add(EditUserFailure);
                return userModel;
            }
            return userModel; //todo return BaseModel

        }

        public async Task<UserItemModel> GetByIdAsync(long id)
        {
            var userModel = new UserItemModel();
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null)
            {
                userModel.Errors.Add(NotFound);
                return userModel; //todo return BaseModel with errors (UserNotFound)
            }
            var model = UserMapper.Map(user);
            return model;
        }

        public async Task<BaseModel> RemoveUserAsync(long id) //todo rename RemoveUserAsync, param = id or email
        {
            var resultModel = new UserItemModel();
            //todo get user from DB, check for null
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
                return resultModel;
            }
            return resultModel; //return BaseModel
        }

        public async Task<BaseModel> BlockUserAsync(long id)
        {
            var userModel = new UserItemModel();
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null)
            {
                //todo return baseModel with errors
                userModel.Errors.Add(NotFound);
                return userModel;
            }
            var result = await _userRepository.BlockUserAsync(user);
            if (!result)
            {
                userModel.Errors.Add(Blok);
            }
            return userModel; //todo return BaseModel
        }


        public async Task<UserItemModel> GetProfileAsync(long id) //todo rename GetProfileAsync
        {
            var usermodel = new UserItemModel();
            var user = await _userRepository.GetByIdAsync(id);//todo check for null
            if (user == null)
            {
                usermodel.Errors.Add(NotFound);
                return usermodel;
            }
            var userItemModel = UserMapper.Map(user);
            return userItemModel; 
        }

        public async Task<BaseModel> RestorePasswordAsync(UserItemModel model)
        {
            var userModel = new UserItemModel();
            var user = await _userRepository.GetByIdAsync(model.Id);
            if (user == null)
            {
                userModel.Errors.Add(NotFound);
                return userModel;
            }
            var token = await _userRepository.GeneratePasswordResetTokenAsync(user);
            if (token == null)
            {
                userModel.Errors.Add(Token);
                return userModel;
            }
            var result = await _userRepository.ResetPasswordAsync(user, token, GeneratePassword.CreateRandomPassword(8));
            if (!result)
            {
                userModel.Errors.Add(Token);
                return userModel;
            }
            //_emailSender.SendingEmailAsync(user.Email, "Restore Password", newPassword);
            return userModel;
        }


        public async Task <List<UserItemModel>> UserFilterModel(UserFilterModel filter) //todo rename model to UserFilterModel
        {
            var filterUsers = await _userRepository.FilterUsers(UserMapper.Map(filter));
            List<UserItemModel> model = new List<UserItemModel>();
            for (int i = 0; i < filterUsers.Count; i++)
            {
                model.Add(UserMapper.Map(filterUsers[i]));
            }
            return model;
        }


    }
}
