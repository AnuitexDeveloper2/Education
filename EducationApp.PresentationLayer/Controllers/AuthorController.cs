using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EducationApp.BusinessLogicLayer.Models.Authors;
using EducationApp.BusinessLogicLayer.Services.Interfaces;
using EducationApp.DataAccessLayer.Helpers.Author;
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
        public async Task<ActionResult> Create(AuthorModelItem model)
        {
            var result = await _authorService.CreateAsync(model);
            return Ok(result);
        }

        [HttpPost("remove")]
        public async Task<ActionResult> Remove(AuthorModelItem model)
        {
            var result =  await _authorService.RemoveAsync(model);
            return Ok(result);
        }

        [HttpPost("update")]
        public async Task<ActionResult> Update(AuthorModelItem model)
        {
            var result = await _authorService.UpdateAsync(model);
            return Ok(result);
        }

        [HttpGet("getAutors")]
        public async Task<ActionResult>  GetAuthors(AuthorFilterModel authorFilterModel)
        {
            var authors = await _authorService.GetAuthors(authorFilterModel);
            return Ok(authors);
        }
    }
}