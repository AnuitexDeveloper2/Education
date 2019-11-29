using EducationApp.BusinessLogicLayer.Extention.Order;
using EducationApp.BusinessLogicLayer.Models.Orders;
using EducationApp.BusinessLogicLayer.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EducationApp.PresentationLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //todo authorize
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [Authorize(Roles = "User")]
        [HttpPost("createOrder")]
        public async Task<ActionResult> CreateOrder(OrderModelItem ordersItemModel)
        {
            var result = await _orderService.CreateAsync(ordersItemModel);
            return Ok(result);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("getOrders")]
        public async Task<ActionResult> GetOrders(OrderFilterModel orderFilterModel)
        {
            //todo orders for users
            var result = await _orderService.GetOrdersAsync(orderFilterModel);
           
            return Ok(result);
        }
        [HttpPost("updateOrder")]
        public async Task<ActionResult> UpdateOrder(string TransactoinId) //todo rename UpdateOrder
        {
            var result =await _orderService.UpdateOrderAsync(TransactoinId);

            return Ok(result);
        }
    }
}