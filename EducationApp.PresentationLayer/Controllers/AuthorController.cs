using System.Threading.Tasks;
using EducationApp.BusinessLogicLayer.Models.Authors;
using EducationApp.BusinessLogicLayer.Services.Interfaces;
using EducationApp.DataAccessLayer.Helpers.Author;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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

        //todo authorize attrs
        [Authorize(Roles = "Admin")]
        [HttpPost("createAuthor")]
        public async Task<ActionResult> CreateAuthor(AuthorModelItem model)
        {
            var result = await _authorService.CreateAsync(model);
            return Ok(result);
        }
        //[Authorize(Roles = "Admin")]
        [HttpPost("removeAuthor")]
        public async Task<ActionResult> RemoveAuthor(AuthorModelItem authorModel)
        {
            var result =  await _authorService.RemoveAsync(authorModel.Id);
            return Ok(result);
        }
        [Authorize(Roles = "Admin")]
        [HttpPost("updateAuthor")]
        public async Task<ActionResult> UpdateAuthor(long id)
        {
            var result = await _authorService.UpdateAsync(id);
            return Ok(result);
        }

        [HttpGet("getAutors")]
        public async Task<ActionResult>  GetAuthors(AuthorFilterModel authorFilterModel)
        {
            var authors = await _authorService.GetAuthorsAsync(authorFilterModel);
            return Ok(authors);
        }
    }
}