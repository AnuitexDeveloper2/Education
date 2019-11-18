using System.Threading.Tasks;
using EducationApp.BusinessLogicLayer.Models.Users;
using Microsoft.AspNetCore.Mvc;
using EducationApp.BusinessLogicLayer.Services;
using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;
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
        public async Task<IActionResult> BlockUser(long id) //todo get UserId from client
        {
           var result = await _userService.BlockUserAsync(id);
            return Ok(result.Errors); //todo return result with errorsCollection
        }

        [HttpGet("getProfile")]
        public async Task<IActionResult> GetProfile(long id) //todo rename, param = id or email
        {
            var profile = await _userService.GetProfileAsync(id); //rename
            return Ok(profile);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("removeUser")] //todo equal names for url and method
        public async Task<ActionResult> RemoveUser(long id)
        {
            var user = await _userService.RemoveUserAsync(id);
            return Ok(user);
        }
        [Authorize(Roles = "User")]
        [HttpPost("EditProfile")]
        public async Task<ActionResult> EditProfile(UserProfileEditModel model)
        {
            var result = await _userService.EditProfileAsync(model);
           
            return Ok(result.Errors);
        }


        [HttpPost("forgotPassword")]
        public async Task<ActionResult> ForgotPassword(UserItemModel model)
        {
            await _userService.RestorePasswordAsync(model);
            return Ok();
        }

        [HttpGet("filter")]
        public async Task<IEnumerable<UserItemModel>> FilterUser(UserFilterModel filterUser)
        {
            return await _userService.UserFilterModel(filterUser);
        }


    }
}