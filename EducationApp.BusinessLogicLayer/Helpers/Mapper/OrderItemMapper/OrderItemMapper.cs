using EducationApp.BusinessLogicLayer.Models.OrderItemModelItem;
using EducationApp.DataAccessLayer.Entities;
using System.Collections.Generic;

namespace EducationApp.BusinessLogicLayer.Helpers.Mapper
{
    public static class OrderItemMapper
    {
        public static List<OrderItem> Map(OrderItemModel orderItemModel,long id)
        {
            var orderItem = new List<OrderItem>();
            foreach (var item in orderItemModel.Items)
            {
                var result = new OrderItem
                {
                    PrintingEditionId = item.PrintingEditionId,
                    Count = item.Count,
                    OrderId = id,
                    Amount = item.Amount,
                    Currency = (DataAccessLayer.Entities.Enums.Enums.CurrencyType)item.Currency
                };
                orderItem.Add(result);
            }
            return orderItem;
        }
    }
}
