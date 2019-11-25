using System.Threading.Tasks;
using EducationApp.BusinessLogicLayer.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using EducationApp.BusinessLogicLayer.Models.PrintingEditions;
using EducationApp.BusinessLogicLayer.Extention.PrintingEditionFilterState;
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
        [HttpPost("createPrintingEdition")]
        public async Task<ActionResult> CreatePrintingEdition(PrintingEditionModelItem printingEditonModelItem)
        {
           var result = await _printingEditionService.CreateAsync(printingEditonModelItem);
            return Ok(result);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("removePrintingEdition")]
        public async Task<ActionResult> RemovePrintingEdition(PrintingEditionModelItem printingEditonModelItem)
        {
            var result = await _printingEditionService.RemoveAsync(printingEditonModelItem.Id);
            return Ok(result);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("updatePrintingEdition")]
        public async Task<ActionResult> UpdatePrintingEdition(PrintingEditionModelItem printingEditionModelItem)
        {
            var result = await _printingEditionService.UpdateAsync(printingEditionModelItem);
            return Ok(result);
        }

        [HttpGet("getPrintingEditon")]
        public async Task<ActionResult> GetPrintingEdition(PrintingEditionFilterState printingEditionFilterState)
        {
            var printingEdition = await _printingEditionService.GetPrintingEditionAsync(printingEditionFilterState);
            return Ok(printingEdition);
        }





    }
}