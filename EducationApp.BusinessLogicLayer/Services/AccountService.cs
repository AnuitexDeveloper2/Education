using EducationApp.BusinessLogicLayer.Helpers;
using EducationApp.BusinessLogicLayer.Services.Interfaces;
using EducationApp.DataAccessLayer.Entities;
using EducationApp.DataAccessLayer.Ropositories.Interfaces;
using System;
using System.Threading.Tasks;
using static EducationApp.BusinessLogicLayer.Common.Consts.Consts.EmailConsts;


namespace EducationApp.BusinessLogicLayer.Services
{
    public class AccountService : IAccountService
    {
        private readonly IUserRepository _userRepository;
        private readonly IEmailSender _emailSender;
        public AccountService(IUserRepository userRepository, IEmailSender emailSender)
        {
            _userRepository = userRepository;
            _emailSender = emailSender;
        }

        public async Task<bool> ConfirmAccountAsync(string email)
        {
            var excistUser = await _userRepository.GetByEmailAsync(email);
            if (excistUser == null)
            {
                return false;
            }
            string token = await _userRepository.GenerateEmailConfirmationTokenAsync(excistUser);


            return true;
        }

        public async Task<bool> CreateUser(string email, string password)
        {

            var userCreate = await _userRepository.AddAsync(email, password);
            return userCreate;
        }
        public async Task<ApplicationUser> RegisterAsync(string name, string email, string password)
        {
            var user = new ApplicationUser { UserName = name, Email = email, Password = password };

            var userCreate = await _userRepository.AddAsync(email, password);
            if (userCreate)
            {
                _emailSender.SendingEmailAsync(UserEmail, MailSubject, $"Подтвердите регистрацию, перейдя по ссылке: <a href='{callbackUrl}'>link</a>");
            }
            return user;
        }

        public async Task<ApplicationUser> GetUserAsync(string userName, string password)
        {
            return await _userRepository.GetByNameAsync(userName);
        }

        public async Task<string> GenerateEmailConfirmationTokenAsync(ApplicationUser user)
        {
            return await _userRepository.GenerateEmailConfirmationTokenAsync(user);
        }


        public async Task<bool> RestorePassword(ApplicationUser user, string newPassword)
        {
                await _userRepository.ChangePasswordAsync(user, user.Password, newPassword);
            return await _userRepository.ConfirmPasswordAsync(user, newPassword);
        }

        public async Task<bool> ConfirmEmailAsync(string email)
        {
            var user = await _userRepository.FindByEmailAsync(email);
            if (user == null )
            {
                return  false;
            }
          string token = await _userRepository.GenerateEmailConfirmationTokenAsync(user);
              return await _userRepository.ConfirmEmailAsync(user,token);
        }

        public async Task<ApplicationUser> GetById(long id)
        {
            return await _userRepository.GetByIdAsync(id);
        }

        public async Task<ApplicationUser> GetByEmail(string email)
        {
           return await _userRepository.FindByEmailAsync(email);
        }

        public Task<ApplicationUser> SignInAsync(string email, string password)
        {
            var user = _userRepository.FindByEmailAsync(email);
            _userRepository.SignInAsync(user,);
        }

        public Task SignOut()
        {
            _userRepository.
        }
    }
}
