﻿using EducationApp.BusinessLogicLayer.Extention.Order;
using EducationApp.BusinessLogicLayer.Models.Orders;
using EducationApp.BusinessLogicLayer.Models.Payments;
using EducationApp.BusinessLogicLayer.Services.Interfaces;
using EducationApp.DataAccessLayer.Models;
using Microsoft.AspNetCore.Authorization;
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

        [Authorize(Roles = "Admin")]
        [HttpPost("createOrder")]
        public async Task<ActionResult> CreateOrder(OrdersItemModel ordersItemModel)
        {
            var result = await _orderService.CreateAsync(ordersItemModel);
            return Ok(result);
        }

        [HttpPost("getOrders")]
        public async Task<ActionResult> GetOrder(/*OrderFilterModel orderFilterModel*/)
        {
            //var result = await _orderService.GetOrder(orderFilterModel);
            var result = await _orderService.GetOrder(new OrderFilterModel 
            { 
                PageCount = 1, 
                PageSize = 5, 
                SearchString = "", 
                SortOrder = BusinessLogicLayer.Models.Enums.Enums.SortOrder.Id, 
                SortType = DataAccessLayer.Entities.Enums.Enums.SortType.Increase, 
                StatusOrder = new System.Collections.Generic.List<BusinessLogicLayer.Models.Enums.Enums.OrderStatus> { BusinessLogicLayer.Models.Enums.Enums.OrderStatus.Paid }
            });
            return Ok(result);
        }
        [HttpPost("payment")]
        public async Task<ActionResult> Payment(PaymentsModel paymentsModel)
        {
            var result = _orderService.PaymentAsync(paymentsModel);
            return Ok(result);
        }
    }
}