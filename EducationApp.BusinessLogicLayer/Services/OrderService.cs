using EducationApp.BusinessLogicLayer.Extention.Order;
using EducationApp.BusinessLogicLayer.Helpers.Mapper;
using EducationApp.BusinessLogicLayer.Helpers.Mapper.OrderMapper;
using EducationApp.BusinessLogicLayer.Helpers.Mapper.PaymentMapper;
using EducationApp.BusinessLogicLayer.Models.Base;
using EducationApp.BusinessLogicLayer.Models.Orders;
using EducationApp.BusinessLogicLayer.Models.Payments;
using EducationApp.BusinessLogicLayer.Services.Interfaces;
using EducationApp.DataAccessLayer.Repositories.Interfaces;
using EducationApp.DataAccessLayer.Ropositories.Interfaces;
using System.Collections.Generic;
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
            var payment = PaymentMapper.Map(ordersItemModel.PaymentModel); //todo create entity directly
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

            var orderItem = OrderItemMapper.Map(ordersItemModel.OrderItemModel, order.Id);
            var createResult = await _orderItemRepository.CreateRangeAsync(orderItem);
            if (!createResult)
            {
                resultModel.Errors.Add(errors.OrderItemCreate);
            }
            return resultModel;
        }

        public async Task<OrdersPresentationModel> GetOrder(OrderFilterModel orderFilterModel) //todo async
        {
            var filter = OrderMapper.Map(orderFilterModel);
            var filterdOrderModel = await _orderRepository.GetOrderAsync(filter);
            var resultModel = new OrdersPresentationModel(); //todo change model
            foreach (var item in filterdOrderModel.Data)
            {
                resultModel.Items.Add(OrderMapper.Map(item));
            }
            resultModel.Count = filterdOrderModel.Count;

            return resultModel;
        }

        public async Task<BaseModel> PaymentAsync(PaymentsModel paymentsModel) //todo rename to Update, why you use this method
        {
            var resultModel = new BaseModel();
            if (paymentsModel.TransactionId < 1)
            {
                resultModel.Errors.Add(errors.PaymentCreate);
                return resultModel;
            }
            var payment =  PaymentMapper.Map(paymentsModel);
            var resultPayment = await _paymentRepository.UpdateAsync(payment);
            if (!resultPayment)
            {
                resultModel.Errors.Add(errors.PaymentCreate);
                return resultModel;
            }
            var order = await _orderRepository.Payment(payment.Id);
            if (order == null)
            {
                resultModel.Errors.Add(errors.OrderIsNotFound);
                return resultModel;
            }
            var isUpdate = await _orderRepository.UpdateAsync(order);
            if (!isUpdate)
            {
                resultModel.Errors.Add(errors.NotPaid);
            }
            return resultModel;
        }

        
    }
}
