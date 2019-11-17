using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EducationApp.BusinessLogicLayer.Extention.User;
using EducationApp.BusinessLogicLayer.Helpers.Mapping;
using EducationApp.BusinessLogicLayer.Models.Base;
using EducationApp.BusinessLogicLayer.Models.Users;
using EducationApp.DataAccessLayer.Entities;
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
        public async Task<BaseModel> ChangeEmail(string newEmail) //todo use one param email
        {
            var returnModel = new UserItemModel();
            var user = await _userRepository.GetByEmailAsync(newEmail);
            if (user == null)
            {
                returnModel.Errors.Add(NotFound);
                return returnModel;
            }
            //todo get user from DB by id or email and check for null
            var token = await _userRepository.GenerateChangeEmailTokenAsync(user, newEmail);
            if (token == null)
            {
                returnModel.Errors.Add(NotFound);
                return returnModel;
            }
            //todo check token for null
            var result = await _userRepository.ChangeEmailAsync(newEmail, token);
            if (!result)
            {
                returnModel.Errors.Add(Token);
            }
            return returnModel;
        }


        public async Task<BaseModel> EditProfileAsync(UserItemModel model)
        {
            var user = await _userRepository.GetByEmailAsync(model.Email); //todo check for null, rename method to async
            model = UserMapper.Map(user);
            user = UserMapper.Map(model); //todo rename UserMapper, add method for update UserEntity from UserModel
            var result = await _userRepository.EditAsync(user);
            return result; //todo return BaseModel

        }

        public async Task<UserItemModel> GetByEmailAsync(string email)
        {
            var user = await _userRepository.GetByEmailAsync(email);
            if (user == null)
            {
                return null;
            }
            var model = UserMapper.Map(user);
            return model;
        }

        public async Task<UserItemModel> GetByIdAsync(long id)
        {
            var resultModel = new UserItemModel();
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null)
            {
                resultModel.Errors.Add(NotFound);
                return resultModel; //todo return BaseModel with errors (UserNotFound)
            }
            var model = UserMapper.Map(user);
            return model;
        }

        public async Task<ApplicationUser> GetByNameAsync(string name)
        {
            var user = await _userRepository.GetByNameAsync(name);
           
            return null;
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
            var result = new UserItemModel();
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null)
            {
                //todo return baseModel with errors
                result.Errors.Add(NotFound);
            }
            user.LockoutEnabled = !user.LockoutEnabled;
            return result; //todo return BaseModel
        }



        public async Task<UserItemModel> GetProfileAsync(long id) //todo rename GetProfileAsync
        {
            var resultModel = new UserItemModel();
            var user = await _userRepository.GetByIdAsync(id);//todo check for null
            if (user == null)
            {
               resultModel.Errors.Add("User Not Found");
                return resultModel;
            }
            var userItemModel = UserMapper.Map(user);
            return userItemModel; 
        }


        public List<UserItemModel> UserFilterModel(UserFilterModel filter) //todo rename model to UserFilterModel
        {
            var filterUsers = _userRepository.FilterUsers(UserMapper.Map(filter));
            List<UserItemModel> model = new List<UserItemModel>();
            for (int i = 0; i < filterUsers.Count(); i++)
            {
                model.Add(UserMapper.Map(filterUsers[i]));
            }
            return model;
        }


    }
}
