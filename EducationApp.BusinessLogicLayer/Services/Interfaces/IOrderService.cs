using EducationApp.BusinessLogicLayer.Extention.Order;
using EducationApp.BusinessLogicLayer.Models.Base;
using EducationApp.BusinessLogicLayer.Models.Orders;
using EducationApp.BusinessLogicLayer.Models.Payments;
using System.Threading.Tasks;

namespace EducationApp.BusinessLogicLayer.Services.Interfaces
{
    public interface IOrderService
    {
        Task<BaseModel> CreateAsync(OrdersItemModel ordersItemModel);
        Task<OrdersPresentationModel> GetOrder(OrderFilterModel orderFilterModel);
        Task<BaseModel> PaymentAsync(PaymentsModel paymentsModel);
    }
}
