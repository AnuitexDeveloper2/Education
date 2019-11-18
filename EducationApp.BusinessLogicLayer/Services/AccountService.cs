using EducationApp.BusinessLogicLayer.Helpers;
using EducationApp.BusinessLogicLayer.Helpers.Mapping;
using EducationApp.BusinessLogicLayer.Helpers.Mapping.User;
using EducationApp.BusinessLogicLayer.Models.Base;
using EducationApp.BusinessLogicLayer.Models.Users;
using EducationApp.BusinessLogicLayer.Services.Interfaces;
using EducationApp.DataAccessLayer.Entities;
using EducationApp.DataAccessLayer.Ropositories.Interfaces;
using System;
using System.Threading.Tasks;
using static EducationApp.BusinessLogicLayer.Common.Consts.Consts.EmailConsts;
using static EducationApp.BusinessLogicLayer.Common.Consts.Consts.Errors;


namespace EducationApp.BusinessLogicLayer.Services
{
    public class AccountService : IAccountService
    {
        private readonly IUserRepository _userRepository;
        public AccountService(IUserRepository userRepository, IEmailSender emailSender)
        {
            _userRepository = userRepository;
        }

        public async Task<bool> ConfirmAccountAsync(string email)
        {
            var excistUser = await _userRepository.GetByEmailAsync(email);
            if (excistUser == null)
            {
                return false;
            }
            string token = await _userRepository.GenerateEmailConfirmationTokenAsync(excistUser);
            if (token == null)
            {
                return false;
            }
            return true;
        }

        public async Task<BaseModel> CreateUserAsync(UserItemModel userItemModel)
        {
            var userModel = new BaseModel();
            if (string.IsNullOrWhiteSpace(userItemModel.FirstName) || string.IsNullOrWhiteSpace(userItemModel.LastName) || string.IsNullOrWhiteSpace(userItemModel.Email) || string.IsNullOrWhiteSpace(userItemModel.Password))
            {
                userModel.Errors.Add(EmptyField);
                return userModel;
            }
            var user = UserMapper.Map(userItemModel);
            var userCreate = await _userRepository.CreateUserAsync(user, userItemModel.Password);
            if (!userCreate)
            {
                userModel.Errors.Add(UserCreate);
                return userModel;
            }
            // _emailSender.SendingEmailAsync(UserEmail, MailSubject, $"Confirm registration by clicking on the link: <a href='{callbackUrl}'>link</a>");
            return userModel;
        }



        public async Task<BaseModel> ConfirmEmailAsync(string email)
        {
            var userModel = new BaseModel();
            var user = await _userRepository.FindByEmailAsync(email);
            if (user == null)
            {
                userModel.Errors.Add(NotFound);
                return userModel;
            }
            string token = await _userRepository.GenerateEmailConfirmationTokenAsync(user);
            var result = await _userRepository.ConfirmEmailAsync(user, token);
            if (!result)
            {
                userModel.Errors.Add(ConfirmEmail);
            }
            return userModel;
        }

        public async Task<ApplicationUser> GetByIdAsync(long id)
        {
            return await _userRepository.GetByIdAsync(id);
        }

        public async Task<UserItemModel> GetByEmailAsync(string email)
        {
            if (email == null)
            {
                return null;
            }
            var user = await _userRepository.FindByEmailAsync(email);
            var model = UserMapper.Map(user);
            model.Role = await _userRepository.GetRoleAsync(user);
            return model;
        }

        public async Task<BaseModel> SignIn(string email, string password)
        {
             var usersModel = new BaseModel();
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                usersModel.Errors.Add(EmptyField);
                return usersModel;
            }
            var user = await _userRepository.GetByEmailAsync(email);
            if (user == null)
            {
                usersModel.Errors.Add(NotFound);
                return usersModel;
            }
            var checkPassword = await _userRepository.ConfirmPasswordAsync(user, password);
            if (!checkPassword)
            {
                usersModel.Errors.Add(NotValidPassword);
                return usersModel;
            }
            return usersModel;
        }

        public async Task SignOutAsync()
        {
            await _userRepository.SignOut();
        }
    }
}
