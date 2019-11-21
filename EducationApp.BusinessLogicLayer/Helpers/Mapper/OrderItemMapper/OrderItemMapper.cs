using EducationApp.BusinessLogicLayer.Models.OrderItemModelItem;
using EducationApp.DataAccessLayer.Entities;
using System.Collections.Generic;

namespace EducationApp.BusinessLogicLayer.Helpers.Mapper
{
    public static class OrderItemMapper
    {
        public static List<OrderItem> Map(OrderItemModel orderItemModel)
        {
            var orderItem = new List<OrderItem>();
            foreach (var item in orderItemModel.Items)
            {
                var result = new OrderItem
                {
                    PrintingEditionId = item.printingEditionId,
                    Count = item.Count,
                };
                orderItem.Add(result);
            }
            return orderItem;
        }
    }
}
