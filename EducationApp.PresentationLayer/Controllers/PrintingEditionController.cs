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
    [Authorize(Roles = "Admin")]
    public class PrintingEditionController : ControllerBase
    {
        private readonly IPrintingEditionService _printingEditionService;
        public PrintingEditionController(IPrintingEditionService printingEditionService)
        {
            _printingEditionService = printingEditionService;
        }

       /* [Authorize(Roles = "Admin")]*/ //todo check
        [HttpPost("createPrintingEdition")]
        public async Task<ActionResult> CreatePrintingEdition(PrintingEditionModelItem printingEditonModelItem)
        {
           var result = await _printingEditionService.CreateAsync(printingEditonModelItem);
            return Ok(result);
        }

        [HttpPost("removePrintingEdition")]
        public async Task<ActionResult> RemovePrintingEdition(long id) //todo param is Id
        {
            var result = await _printingEditionService.RemoveAsync(id);
            return Ok(result);
        }

        [HttpPost("updatePrintingEdition")]
        public async Task<ActionResult> UpdatePrintingEdition(PrintingEditionModelItem printingEditionModelItem)
        {
            var result = await _printingEditionService.UpdateAsync(printingEditionModelItem);
            return Ok(result);
        }

        [AllowAnonymous]
        [HttpPost("getPrintingEditons")]
        public async Task<ActionResult> GetPrintingEditions(PrintingEditionFilterState printingEditionFilterState)
        {
            var printingEdition = await _printingEditionService.GetPrintingEditionsAsync(printingEditionFilterState);
            return Ok(printingEdition);
        }





    }
}