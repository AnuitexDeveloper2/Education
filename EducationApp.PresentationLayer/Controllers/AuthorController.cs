using System.Threading.Tasks;
using EducationApp.BusinessLogicLayer.Extention.Author;
using EducationApp.BusinessLogicLayer.Models.Authors;
using EducationApp.BusinessLogicLayer.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using role = EducationApp.BusinessLogicLayer.Common.Consts.Consts.UserRoles;

namespace EducationApp.PresentationLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        public readonly IAuthorService _authorService;

        public AuthorController(IAuthorService authorService)
        {
            _authorService = authorService;
        }


        [Authorize(Roles = role.Admin)]
        [HttpPost("create")]
        public async Task<ActionResult> Create(string name)
        {

            var result = await _authorService.CreateAsync(name);

            return Ok(result);
        }

        [Authorize(Roles = role.User)]
        [HttpGet("remove")]
        public async Task<ActionResult> Remove(long id)
        {
            var result = await _authorService.RemoveAsync(id);

            return Ok(result);
        }

        [Authorize(Roles = role.Admin)]
        [HttpGet("update")]
        public async Task<ActionResult> Update(long id, string name)
        {
            var result = await _authorService.UpdateAsync(id, name);

            return Ok(result);
        }

        [Authorize(Roles = role.Admin)]
        [HttpGet("getAll")]
        public async Task<ActionResult> GetAll()
        {
            var result = await _authorService.GetAll();

            return Ok(result);
        }


        [AllowAnonymous]
        [HttpPost("get")]
        public async Task<ActionResult> Get(AuthorFilterModel authorFilterModel)
        {
            
            var authors = await _authorService.GetAuthorsAsync(authorFilterModel);

            return Ok(authors);
        }


    }
}