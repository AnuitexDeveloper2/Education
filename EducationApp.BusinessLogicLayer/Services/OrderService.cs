using EducationApp.BusinessLogicLayer.Extention.Order;
using EducationApp.BusinessLogicLayer.Helpers.Mapper;
using EducationApp.BusinessLogicLayer.Helpers.Mapper.OrderMapper;
using EducationApp.BusinessLogicLayer.Models.Base;
using EducationApp.BusinessLogicLayer.Models.Orders;
using EducationApp.BusinessLogicLayer.Services.Interfaces;
using EducationApp.DataAccessLayer.Entities;
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
        public async Task<OrderModel> CreateAsync(OrderModelItem ordersItemModel)
        {
            var resultModel = new OrderModel();

            if (ordersItemModel == null)
            {
                resultModel.Errors.Add(errors.OrderItem);
                return resultModel;
            }

            var payment = new Payment
            { 
                TransactionId = ordersItemModel.TransactionId
            };

            var paymentId = await _paymentRepository.CreateAsync(payment);

            if (paymentId < 1)
            {
                resultModel.Errors.Add(errors.PaymentCreate);
                return resultModel;
            }

            var order = OrderMapper.Map(ordersItemModel, payment.Id);

            var orderId = await _orderRepository.CreateAsync(order);

            if (orderId < 1)
            {
                resultModel.Errors.Add(errors.OrderCreate);
                return resultModel;
            }

            var orderItem = OrderItemMapper.Map(ordersItemModel.OrderItems, order.Id);

            var wasCreate = await _orderItemRepository.CreateRangeAsync(orderItem);

            if (!wasCreate)
            {
                resultModel.Errors.Add(errors.OrderItemCreate);
            }
            resultModel.PaymentId = paymentId;
            return resultModel;
        }

        public async Task<OrderModel> GetOrdersAsync(OrderFilterModel orderFilterModel)
        {
            var filter = OrderMapper.Map(orderFilterModel);

            var getOrders = await _orderRepository.GetOrdersAsync(filter);

            var resultModel = new OrderModel();

            if (getOrders == null)
            {
                resultModel.Errors.Add(errors.OrderIsNotFound);
                return resultModel;
            }

            foreach (var item in getOrders.Data)
            {
                resultModel.Items.Add(OrderMapper.Map(item));
            }

            resultModel.ItemsCount = getOrders.Count;

            return resultModel;
        }

        public async Task<BaseModel> UpdateOrderAsync(string transactoinId,long paymentId)
        {
            var resultModel = new BaseModel();

            var payment = await _paymentRepository.GetByIdAsync(paymentId);
            if (payment == null)
            {
                resultModel.Errors.Add(errors.PaymentNotFound);
                return resultModel;
            }

            payment.TransactionId = transactoinId;

            var wasUpdate = await _paymentRepository.UpdateAsync(payment);

            if (!wasUpdate)
            {
                resultModel.Errors.Add(errors.PaymentCreate);
                return resultModel;
            }

            var order =  _orderRepository.GetOrder(paymentId);

            if (order == null)
            {
                resultModel.Errors.Add(errors.OrderIsNotFound);
                return resultModel;
            }

            order.Status = DataAccessLayer.Entities.Enums.Enums.OrderStatusType.Paid;

            wasUpdate = await _orderRepository.UpdateAsync(order);

            if (!wasUpdate)
            {
                resultModel.Errors.Add(errors.OrderIsNotFound);
            }

            return resultModel;
        }
    }
}
