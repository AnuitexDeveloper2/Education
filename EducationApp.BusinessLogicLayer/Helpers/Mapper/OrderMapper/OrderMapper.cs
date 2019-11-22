using EducationApp.BusinessLogicLayer.Models.Orders;
using EducationApp.DataAccessLayer.Entities;

namespace EducationApp.BusinessLogicLayer.Helpers.Mapper.OrderMapper
{
    public static class OrderMapper
    {
        public static Order Map(OrdersItemModel ordersItemModel,long id)
        {
            var order = new Order
            {
                Description = ordersItemModel.Description,
                PaymentId = id,
                UserId = ordersItemModel.UserId,
                Status = (DataAccessLayer.Entities.Enums.Enums.StatusType)ordersItemModel.OrderStatus
            };
            return order;
        }
    }
}



