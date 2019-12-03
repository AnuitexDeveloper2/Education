using EducationApp.BusinessLogicLayer.Extention.Order;
using EducationApp.BusinessLogicLayer.Models.Orders;
using EducationApp.BusinessLogicLayer.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using role = EducationApp.BusinessLogicLayer.Common.Consts.Consts.UserRoles;

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

        [Authorize(Roles = role.User)]
        [HttpPost("createOrder")]
        public async Task<ActionResult> CreateOrder(OrderModelItem ordersItemModel)
        {
            var result = await _orderService.CreateAsync(ordersItemModel);

            return Ok(result);
        }

        [Authorize(Roles = role.Admin)]
        [HttpPost("getOrders")]
        public async Task<OrderModel> GetOrders(OrderFilterModel orderFilterModel)
        {
            //todo orders for users
            var result = await _orderService.GetOrdersAsync(orderFilterModel);
           
            return result;
        }

        [Authorize(Roles = role.User)]
        [HttpPost("getUserOrders")]
        public async Task<OrderModel> GetUserOrders(OrderFilterModel orderFilterModel)
        {
            var result = await _orderService.GetOrdersAsync(orderFilterModel);

            return result;
        }

        [Authorize(Roles = role.User)]
        [HttpPost("updateOrder")]
        public async Task<ActionResult> UpdateOrder(string TransactoinId,long paymentId) //todo rename UpdateOrder
        {
            var result =await _orderService.UpdateOrderAsync(TransactoinId,paymentId);

            return Ok(result);
        }
    }
}