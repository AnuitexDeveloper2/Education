using System.Threading.Tasks;
using EducationApp.BusinessLogicLayer.Models.Users;
using Microsoft.AspNetCore.Mvc;
using EducationApp.BusinessLogicLayer.Services;

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
        public async Task<ActionResult> ChangeEmail(UserItemModel model)
        {
            var user = await _userService.GetById(model.Id);
            await _userService.ChangeEmail(user, model.Email);
            return Ok("Ok");
        }

        [HttpPost("changePassword")]
        public async Task<ActionResult> ChangePassword(UserItemModel model)
        {
            var user = await _userService.GetById(model.Id);
            await _userService.ChangePassword(user, model.Password, "Education*2019");
            return Ok("Ok");
        }
    }
}