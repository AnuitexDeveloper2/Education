using EducationApp.BusinessLogicLayer.Helpers.Mapper;
using EducationApp.BusinessLogicLayer.Helpers.Mapper.OrderMapper;
using EducationApp.BusinessLogicLayer.Helpers.Mapper.PaymentMapper;
using EducationApp.BusinessLogicLayer.Models.Base;
using EducationApp.BusinessLogicLayer.Models.Payments;
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
        public OrderService(IOrderRepository orderRepository,IOrderItemRepository orderItemRepository,IPaymentRepository paymentRepository)
        {
            _orderItemRepository = orderItemRepository;
            _orderRepository = orderRepository;
            _paymentRepository = paymentRepository;
        }
        public async Task<BaseModel> CreateAsync(PaymentsModel paymentsModel)
        {
            var resultModel = new BaseModel();
            if (paymentsModel == null)
            {
                resultModel.Errors.Add(errors.PaymentNotFound);
                return resultModel;
            }
            var payment = PaymentMapper.Map(paymentsModel.TransactionId);
            var paymentId = await _paymentRepository.CreateAsync(payment);
            if (paymentId<1)
            {
                resultModel.Errors.Add(errors.PaymentCreate);
            }
            var order = OrderMapper.Map(paymentsModel, paymentId);
            var orderId = await _orderRepository.CreateAsync(order);
            if (orderId<1)
            {
                resultModel.Errors.Add(errors.OrderCreate);
            }
            var orderItem = OrderItemMapper.Map(paymentsModel.OrderItemModel);
            var createResult = await _orderItemRepository.CreateRangeAsync(orderItem);
            if (!createResult)
            {
                resultModel.Errors.Add(errors.OrderItemCreate);
            }
            return resultModel;
        }
    }
}
