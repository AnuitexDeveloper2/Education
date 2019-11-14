using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EducationApp.BusinessLogicLayer.Models.Authors;
using EducationApp.BusinessLogicLayer.Services.Interfaces;
using Microsoft.AspNetCore.Http;
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

        [HttpPost("Create")]
        public async Task<ActionResult> Create(AuthorsModelItem model)
        {
            await _authorService.CreateAsync(model);
            return Ok();
        }

        [HttpPost("remove")]

        public async Task<ActionResult> Remove(AuthorsModelItem model)
        {
            await _authorService.RemoveAsync(model);
            return Ok();
        }

        [HttpPost("update")]
        public async Task<ActionResult> Update(AuthorsModelItem model)
        {
            await _authorService.UpdateAsync(model);
            return Ok();
        }

        [HttpGet("getById")]
        public async Task<AuthorsModelItem> GetbyId(long id)
        {
            var author = await _authorService.GetByIdAsync(id);
            return author;
        }

        //[HttpGet("GetAutors")]

        //public async Task<List<AuthorsModelItem>> GetAuthors()
        //{

        //}
    }
}