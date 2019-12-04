using EducationApp.BusinessLogicLayer.Models.Orders;
using EducationApp.DataAccessLayer.Entities;
using System;
using static EducationApp.DataAccessLayer.Entities.Enums.Enums;

namespace EducationApp.BusinessLogicLayer.Helpers.Mapper.OrderMapper
{
    public static partial class OrderMapper
    {
        public static Order Map(this OrderModelItem ordersItemModel, long id)
        {
            var order = new Order
            {
                PaymentId = id,
                Description = ordersItemModel.Description,
                UserId = ordersItemModel.UserId,
                Status = (OrderStatusType)ordersItemModel.Status,
                Date = DateTime.Now,
            };

            return order;
        }
    }
}




