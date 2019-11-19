using EducationApp.BusinessLogicLayer.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EducationApp.PresentationLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly OrderService _orderService ;

        public OrderController(OrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost("createOrder")]
         public async Task<ActionResult> CreateOrder()
        {
            return Ok();
        }
    }
}