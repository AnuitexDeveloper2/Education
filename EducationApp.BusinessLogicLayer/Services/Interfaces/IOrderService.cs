using EducationApp.BusinessLogicLayer.Extention.Order;
using EducationApp.BusinessLogicLayer.Models.Base;
using EducationApp.BusinessLogicLayer.Models.Orders;
using EducationApp.BusinessLogicLayer.Models.Payments;
using System.Threading.Tasks;

namespace EducationApp.BusinessLogicLayer.Services.Interfaces
{
    public interface IOrderService
    {
        Task<PaymentModel> CreateAsync(OrderModelItem ordersItemModel);
        Task<OrderModel> GetOrdersAsync(OrderFilterModel orderFilterModel);
        Task<BaseModel> UpdateOrderAsync(string TransactoinId,long paymentId);
    }
}
