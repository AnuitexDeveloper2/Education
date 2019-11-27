using EducationApp.BusinessLogicLayer.Extention.Order;
using EducationApp.BusinessLogicLayer.Models.Base;
using EducationApp.BusinessLogicLayer.Models.Orders;
using System.Threading.Tasks;

namespace EducationApp.BusinessLogicLayer.Services.Interfaces
{
    public interface IOrderService
    {
        Task<BaseModel> CreateAsync(OrdersItemModel ordersItemModel);
        Task<OrdersModel> GetOrdersAsync(OrderFilterModel orderFilterModel);
        Task<BaseModel> UpdateOrderAsync(long TransactoinId, long orderId);
    }
}
