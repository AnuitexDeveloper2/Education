using EducationApp.BusinessLogicLayer.Models.Payments;
using EducationApp.BusinessLogicLayer.Services;
using EducationApp.BusinessLogicLayer.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EducationApp.PresentationLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost("createOrder")]
        public async Task<ActionResult> CreateOrder(PaymentsModel paymentsModel)
        {
            var result = await _orderService.CreateAsync(paymentsModel);
            return Ok(result);
        }
    }
}