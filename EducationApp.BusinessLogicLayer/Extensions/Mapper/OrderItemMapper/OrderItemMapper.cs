using EducationApp.BusinessLogicLayer.Models.OrderItemModelItem;
using EducationApp.DataAccessLayer.Entities;
using System.Collections.Generic;

namespace EducationApp.BusinessLogicLayer.Helpers.Mapper
{
    public static class OrderItemMapper
    {
        public static List<OrderItem> Map(this OrderItemModel orderItemModel,long id)
        {
            var orderItem = new List<OrderItem>();
            foreach (var item in orderItemModel.Items)
            {
                orderItem.Add(Map(item, id));
            }
            return orderItem;
        }

        private static OrderItem Map(OrderItemModelItem orderItemModelItem,long id)
        {
            var result = new OrderItem
            {
                PrintingEditionId = orderItemModelItem.PrintingEditionId,
                Count = orderItemModelItem.Count,
                OrderId = id,
                Amount = orderItemModelItem.Amount,
                Currency = (DataAccessLayer.Entities.Enums.Enums.CurrencyType)orderItemModelItem.Currency,
            };
            return result;
        }
    }
}
