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
        public async Task<ActionResult> ChangeEmailAsync(UserItemModel model)
        {
           
            var user = await _userService.GetById(model.Id);
            await _userService.ChangeEmail(model, model.Email);
            return Ok("Ok");
        }
        [Authorize(Roles = "User")]
        [HttpPost("changePassword")]
        public async Task<ActionResult> ChangePasswordAsync(UserItemModel model)
        {
            var user = await _userService.GetById(model.Id);
            await _userService.ChangePassword(model, model.Password, "Education/2019");
            return Ok("Ok");
        }
        [Authorize(Roles = "Admin")]
        [HttpPost("blockUser")]
        public async Task<ActionResult> BlockUserAsync(UserItemModel model)
        {
           await _userService.BlockUserAsync(model.Id);
            return Ok();
        }
        
        [HttpPost("profile")]
        public async Task<UserItemModel> Profile( UserItemModel model)
        {
            var profile = await _userService.Profile(model.Id);
                return profile;
        }
        
        [HttpPost("Remove")]
        public async Task<bool> RemoveUser(UserItemModel model)
        {
            var user = await _userService.GetById(model.Id);
            var isRemoved = await _userService.Remove(model);
            return isRemoved;
        }
        [Authorize(Roles= "User")]
        [HttpPost ("EditProfile")]
        public async Task<ActionResult> EditProfile(UserItemModel model)
        {
            var result = await _userService.EditProfile(model);
            if (!result)
            {
                return BadRequest();
            }
            return Ok();

        }

        [HttpGet("sort")]
        public async Task< IEnumerable<UserItemModel>> SortUsers(UserActionModel sortUser )
        {
            return _userService.SortUsers(sortUser);
        }

        [HttpGet("filter")]
        public async Task<IEnumerable<UserItemModel>> FilterUser(UserActionModel filterUser)
        {
           return  _userService.FilterModel(filterUser);
        }


    }
}