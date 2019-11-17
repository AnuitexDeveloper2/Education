using System.Threading.Tasks;
using EducationApp.BusinessLogicLayer.Models.Users;
using Microsoft.AspNetCore.Mvc;
using EducationApp.BusinessLogicLayer.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;
using System.Linq;
using EducationApp.DataAccessLayer.Entities;
using static EducationApp.BusinessLogicLayer.Extention.Enums.Enums;
using EducationApp.BusinessLogicLayer.Models;
using EducationApp.BusinessLogicLayer.Extention.User;
using static EducationApp.DataAccessLayer.Entities.Enums.Enums;
using EducationApp.BusinessLogicLayer.Models.Base;

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

        [HttpPost("changeEmail")]
        public async Task<ActionResult> ChangeEmail(string email)
        {
            var result = await _userService.ChangeEmailAsync(email);
            return Ok( result); //todo return basemodel with errors
        }

        //[Authorize(Roles = "User")]
        //[HttpPost("changePassword")]
        //public async Task<ActionResult> ChangePasswordAsync(UserItemModel model) //todo remove, merge UpdatePassword with UpdateProfile
        //{
        //    var user = await _userService.GetByIdAsync(model.Id);
        //    await _userService.ChangePasswordAsync(model, model.Password, "Education/2019"); //todo set one param
        //    return Ok("Ok");
        //}

        [Authorize(Roles = "Admin")]
        [HttpPost("blockUser")]
        public async Task<IActionResult> BlockUserAsync(long id) //todo get UserId from client
        {
           var result = await _userService.BlockUserAsync(id);
            return Ok(result); //todo return result with errorsCollection
        }

        [HttpGet("GetProfile")]
        public async Task<IActionResult> GetProfile(long id) //todo rename, param = id or email
        {
            var profile = await _userService.GetProfileAsync(id); //rename
            return Ok(profile);
        }

        [HttpPost("removeUser")] //todo equal names for url and method
        public async Task<ActionResult> RemoveUser(long id)
        {
            var user = await _userService.RemoveUserAsync(id);
            return Ok(user);
        }
        [Authorize(Roles = "User")]
        [HttpPost("EditProfile")]
        public async Task<ActionResult> EditProfile(UserItemModel model)
        {
            var result = await _userService.EditProfileAsync(model);
            if (!result)
            {
                return BadRequest();
            }
            return Ok();

        }



        [HttpGet("filter")]
        public async Task<IEnumerable<UserItemModel>> FilterUser(UserFilterModel filterUser)
        {
            return _userService.UserFilterModel(filterUser);
        }


    }
}