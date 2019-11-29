using EducationApp.BusinessLogicLayer.Extention.Order;
using EducationApp.BusinessLogicLayer.Models.Base;
using EducationApp.BusinessLogicLayer.Models.Orders;
using System.Threading.Tasks;

namespace EducationApp.BusinessLogicLayer.Services.Interfaces
{
    public interface IOrderService
    {
        Task<BaseModel> CreateAsync(OrderModelItem ordersItemModel);
        Task<OrderModel> GetOrdersAsync(OrderFilterModel orderFilterModel);
        Task<BaseModel> UpdateOrderAsync(string TransactoinId);
    }
}
