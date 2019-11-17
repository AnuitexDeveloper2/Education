using System.Threading.Tasks;
using EducationApp.BusinessLogicLayer.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using EducationApp.BusinessLogicLayer.Models.PrintingEditions;
using System.Linq;
using EducationApp.BusinessLogicLayer.Extention.PrintingEditionFilterState;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;

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

        [Authorize(Roles = "Admin")]
        [HttpPost("Create")]
        public async Task<ActionResult> Create(PrintingEditionModelItem printingEditonModelItem)
        {
            await _printingEditionService.CreateAsync(printingEditonModelItem);
            return Ok();
        }
        [Authorize(Roles = "Admin")]
        [HttpPost("remove")]

        public async Task<ActionResult> Remove(PrintingEditionModelItem printingEditonModelItem)
        {
            await _printingEditionService.RemoveAsync(printingEditonModelItem);
            return Ok();
        }
        [Authorize(Roles = "Admin")]
        [HttpPost("update")]

        public async Task<ActionResult> Update(PrintingEditionModelItem printingEditionModelItem)
        {
            await _printingEditionService.UpdateAsync(printingEditionModelItem);
            return Ok();
        }

        [HttpGet("Filter")]
        public async Task<List<PrintingEditionModelItem>> Filter(PrintingEditionFilterState printingEditionFilterState)
        {
            var printingEdition = await _printingEditionService.GetPrintingEditionAsync(printingEditionFilterState);
            return printingEdition;
        }


        [HttpGet("buy")]
        public async Task<ActionResult> Buy()
        {
            return Ok();
        }


    }
}