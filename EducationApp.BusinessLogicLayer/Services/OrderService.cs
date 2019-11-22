using EducationApp.BusinessLogicLayer.Helpers.Mapper;
using EducationApp.BusinessLogicLayer.Helpers.Mapper.OrderMapper;
using EducationApp.BusinessLogicLayer.Helpers.Mapper.PaymentMapper;
using EducationApp.BusinessLogicLayer.Models.Base;
using EducationApp.BusinessLogicLayer.Models.Orders;
using EducationApp.BusinessLogicLayer.Models.Payments;
using EducationApp.BusinessLogicLayer.Services.Interfaces;
using EducationApp.DataAccessLayer.Entities;
using EducationApp.DataAccessLayer.Models;
using EducationApp.DataAccessLayer.Repositories.Interfaces;
using EducationApp.DataAccessLayer.Ropositories.Interfaces;
using System.Threading.Tasks;
using errors = EducationApp.BusinessLogicLayer.Common.Consts.Consts.Errors;

namespace EducationApp.BusinessLogicLayer.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IPaymentRepository _paymentRepository;
        private readonly IOrderItemRepository _orderItemRepository;
        public OrderService(IOrderRepository orderRepository, IOrderItemRepository orderItemRepository, IPaymentRepository paymentRepository)
        {
            _orderItemRepository = orderItemRepository;
            _orderRepository = orderRepository;
            _paymentRepository = paymentRepository;
        }
        public async Task<BaseModel> CreateAsync(OrdersItemModel ordersItemModel)
        {
            var resultModel = new BaseModel();
            if (ordersItemModel == null)
            {
                resultModel.Errors.Add(errors.OrderItem);
                return resultModel;
            }
            var order = OrderMapper.Map(ordersItemModel, createResult);
            var createOrder = await _orderRepository.CreateAsync();
            if (createOrder < 1)
            {
                resultModel.Errors.Add(errors.OrderItem);
                return resultModel;
            }
                
            var orderItem = OrderItemMapper.Map(ordersItemModel.OrderItemModel);
            var createResult = await _orderItemRepository.CreateRangeAsync(orderItem);
            if (!createResult)
            {
                resultModel.Errors.Add(errors.OrderItemCreate);
                return resultModel;
            }
                return resultModel;
        }
    }
}
//var payment = PaymentMapper.Map(ordersItemModel.TransactionId);
//var paymentId = await _paymentRepository.CreateAsync(payment);
//if (paymentId<1)
//{
//    resultModel.Errors.Add(errors.PaymentCreate);
//}
//var order = OrderMapper.Map(ordersItemModel, paymentId);
//var orderId = await _orderRepository.CreateAsync(order);
//if (orderId<1)
//{
//    resultModel.Errors.Add(errors.OrderCreate);
//}