using EducationApp.BusinessLogicLayer.Models.OrderItemModelItem;
using EducationApp.BusinessLogicLayer.Models.Orders;
using EducationApp.DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
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
                
                OrderItems = Map(ordersItemModel.OrderItems.Items)
            };

            return order;
        }

        private static IEnumerable<OrderItem> Map(ICollection<OrderItemModelItem> model)
        {
            var result = new List<OrderItem>();

            foreach (var item in model)
            {
                var orderItemModel = new OrderItem
                {
                    Date = DateTime.Now,
                    PrintingEditionId = item.PrintingEditionId,
                    Count = item.Count
                };
                result.Add(orderItemModel);
            }
            return result;
        }

    }
}




