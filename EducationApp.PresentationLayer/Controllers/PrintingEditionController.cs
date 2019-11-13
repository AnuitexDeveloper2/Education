using System.Threading.Tasks;
using EducationApp.BusinessLogicLayer.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using EducationApp.BusinessLogicLayer.Models.PrintingEditions;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

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


        [HttpPost("Create")]
        public async Task<ActionResult> Create(PrintingEditionModelItem printingEditonModelItem)
        {
            await _printingEditionService.CreateAsync(printingEditonModelItem);
            return Ok();
        }

        [HttpPost("remove")]

        public async Task<ActionResult> Remove(PrintingEditionModelItem printingEditonModelItem)
        {
            await _printingEditionService.RemoveAsync(printingEditonModelItem);
            return Ok();
        }

        [HttpPost("update")]

        public async Task<ActionResult> Update(PrintingEditionModelItem printingEditionModelItem)
        {
            await _printingEditionService.UpdateAsync(printingEditionModelItem);
            return Ok();
        }
        [HttpGet("Filter")]
        public async Task<IQueryable<PrintingEditionModelItem>> Filter(PrintingEditionModelItem printingEditionModelItem)
        {
           
            var result = _printingEditionService.FilterProductsByName(printingEditionModelItem, "Algoritm");
            return result;

        }


    }
}