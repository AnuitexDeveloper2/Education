using System.Threading.Tasks;
using EducationApp.BusinessLogicLayer.Models.Base;
using EducationApp.BusinessLogicLayer.Models.Payments;
using EducationApp.BusinessLogicLayer.Services.Interfaces;
using EducationApp.DataAccessLayer.Entities;
using EducationApp.DataAccessLayer.Repositories.Interfaces;
using EducationApp.DataAccessLayer.Ropositories.Interfaces;
using errors = EducationApp.BusinessLogicLayer.Common.Consts.Consts.Errors;

namespace EducationApp.BusinessLogicLayer.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IPaymentRepository _paymentRepository;
        private readonly IOrderItemRepository _orderItemRepository;
        public async Task<BaseModel> CreateAsync(PaymentsModel paymentsModel)
        {
            var resultModel = new BaseModel();
            if (paymentsModel == null)
            {
                resultModel.Errors.Add(errors.PaymentsNotFound);
                return resultModel;
            }
            var payment = new Payment()
            {
                TransactionId = paymentsModel.TransactionId
            };
            var paymentId = await _paymentRepository.CreateAsync(payment);
            var order = new Order()
            {
                Description = paymentsModel.Description,
                PaymentId = paymentId,
                UserId = paymentsModel.UserId
            };
            var orderId = await _orderRepository.CreateAsync(order);
            foreach (var orderItem in paymentsModel.OrderItemModel.Items)
            {
                //orderItem.OrderId = orderId;
                //var orderItemEntity = orderItem.Map();
                //await _orderItemRepository.CreateAsync(orderItemEntity);
            }
            return resultModel;
            return resultModel;
        }
    }
}
