using System.Threading.Tasks;
using EducationApp.BusinessLogicLayer.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using EducationApp.BusinessLogicLayer.Models.PrintingEditions;
using EducationApp.BusinessLogicLayer.Extention.PrintingEditionFilterState;
using Microsoft.AspNetCore.Authorization;
using role = EducationApp.BusinessLogicLayer.Common.Consts.Constants.UserRoles;

namespace EducationApp.PresentationLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   
    public class PrintingEditionController : ControllerBase
    {
        private readonly IPrintingEditionService _printingEditionService;
        public PrintingEditionController(IPrintingEditionService printingEditionService)
        {
            _printingEditionService = printingEditionService;
        }

        [Authorize(Roles = role.Admin)]
        [HttpPost("create")]
        public async Task<ActionResult> Create(PrintingEditionModelItem printingEditonModelItem)
        {
            var result = await _printingEditionService.CreateAsync(printingEditonModelItem);

            return Ok(result);
        }

        [Authorize(Roles = role.Admin)]
        [HttpGet("remove")]
        public async Task<ActionResult> Remove(long id)
        {
            var result = await _printingEditionService.RemoveAsync(id);

            return Ok(result);
        }

        [Authorize(Roles = role.Admin)]
        [HttpPost("update")]
        public async Task<ActionResult> Update(PrintingEditionModelItem printingEditionModelItem)
        {
            var result = await _printingEditionService.UpdateAsync(printingEditionModelItem);

            return Ok(result);
        }

        [AllowAnonymous]
        [HttpPost("get")]
        public async Task<ActionResult> Get(PrintingEditionFilterState printingEditionFilterState)
        {
            var printingEdition = await _printingEditionService.GetPrintingEditionsAsync(printingEditionFilterState);

            return Ok(printingEdition);
        }
    }
}
