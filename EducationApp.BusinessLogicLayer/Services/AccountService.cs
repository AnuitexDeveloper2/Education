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

        public async Task<bool> CreateUserAsync(string email, string password, string firstName, string lastName)
        {

            var userCreate = await _userRepository.AddAsync(email, password, firstName, lastName);
            return userCreate;
        }
        public async Task<ApplicationUser> RegisterAsync(string email, string password, string firstName, string lastName)
        {
            var user = new ApplicationUser { FirstName = firstName, LastName = lastName, Email = email, UserName = lastName + " " + firstName };
            var userCreate = await _userRepository.AddAsync(email, password, firstName, lastName);
            if (userCreate)
            {
                _emailSender.SendingEmailAsync(UserEmail, MailSubject, $"Confirm registration by clicking on the link: <a href='{callbackUrl}'>link</a>");
                return user;
            }
            return null;
        }

        public async Task<ApplicationUser> GetUserAsync(string userName, string password)
        {
            return await _userRepository.GetByNameAsync(userName);
        }

        public async Task<string> GenerateEmailConfirmationTokenAsync(ApplicationUser user)
        {
            return await _userRepository.GenerateEmailConfirmationTokenAsync(user);
        }


        public async Task<bool> RestorePasswordAsync(ApplicationUser user, string token, string newPassword)
        {
            var result = await _userRepository.ResetPassword(user, token, "Education2019");
            //_emailSender.SendingEmailAsync(user.Email, "Restore Password", newPassword);
            return result.Succeeded;
        }

        public async Task<bool> ConfirmEmailAsync(string email)
        {
            var user = await _userRepository.FindByEmailAsync(email);
            if (user == null)
            {
                return false;
            }
            string token = await _userRepository.GenerateEmailConfirmationTokenAsync(user);
            return await _userRepository.ConfirmEmailAsync(user, token);
        }

        public async Task<ApplicationUser> GetByIdAsync(long id)
        {
            return await _userRepository.GetByIdAsync(id);
        }

        public async Task<ApplicationUser> GetByEmailAsync(string email)
        {
            return await _userRepository.FindByEmailAsync(email);
        }

        public async Task<bool> SignInAsync(string email, string password)
        {
            var result = await _userRepository.SignInAsync(email, password);
            return result;
        }

        public async Task SignOutAsync()
        {
            await _userRepository.SignOut();
        }

        public async Task<string> GeneratePasswordResetTokenAsync(ApplicationUser user)
        {
            return await _userRepository.GeneratePasswordResetTokenAsync(user);
        }

        public async Task<bool> CheckByPassword(string email, string password)
        {
            var result = await _userRepository.SignInAsync(email, password);
            return result;
        }

        public async Task<string> GetRoleAsync(ApplicationUser user)
        {
            if (ExcistUser(user)) { return null; }
            var role = await _userRepository.GetRoleAsync(user);
            return role;
        }

        public async Task<bool> ConfirmPasswordAsync(ApplicationUser user, string password)
        {
            return await _userRepository.ConfirmPasswordAsync(user, password);
        }
        public bool ExcistUser(ApplicationUser user)
        {
            if (user == null || user.IsRemoved == true)
            {
                return true;
            }
            return false;
        }
    }
}
