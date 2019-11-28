using System.Threading.Tasks;
using EducationApp.BusinessLogicLayer.Models.Users;
using Microsoft.AspNetCore.Mvc;
using EducationApp.BusinessLogicLayer.Services;
using Microsoft.AspNetCore.Authorization;
using EducationApp.BusinessLogicLayer.Extention.User;

namespace EducationApp.PresentationLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("blockUser")]
        public async Task<IActionResult> BlockUser(long id)
        {
           var result = await _userService.BlockUserAsync(id);
            return Ok(result);
        }

        [HttpGet("getProfile")]
        public async Task<UserModelItem> GetProfile(long id)
        {
            var profile = await _userService.GetProfileAsync(id);
            return profile;
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("removeUser")]
        public async Task<ActionResult> RemoveUser(long id)
        {
            var result = await _userService.RemoveUserAsync(id);
            return Ok(result);
        }

        [Authorize(Roles = "User")]
        [HttpPost("EditProfile")]
        public async Task<ActionResult> EditProfile(UserProfileEditModel model)
        {
            var result = await _userService.EditProfileAsync(model);       
            return Ok(result);
        }


        [HttpPost("forgotPassword")]
        public async Task<ActionResult> ForgotPassword(UserModelItem model)
        {
            var result = await _userService.RestorePasswordAsync(model);
            return Ok(result);
        }

        [HttpPost("GetUsers")]
        public async Task<UserModel> GetUsers(UserFilterModel filterUser)
        {
            var users = await _userService.GetUsersAsync(filterUser);
            return users;
        }


    }
}