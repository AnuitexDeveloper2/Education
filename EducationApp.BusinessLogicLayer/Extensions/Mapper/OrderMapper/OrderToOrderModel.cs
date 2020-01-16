using EducationApp.BusinessLogicLayer.Models.OrderItemModelItem;
using EducationApp.BusinessLogicLayer.Models.Orders;
using EducationApp.DataAccessLayer.Entities;
using System.Collections.Generic;
using System.Globalization;

namespace EducationApp.BusinessLogicLayer.Extention.Mapper.OrderMapper
{
    public static partial class OrderMapper 
    {
        public static OrderModelItem Map(this EducationApp.DataAccessLayer.Entities.Order order)
        {
            var resultModel = new OrderModelItem
            {
                Id = order.Id,
                Date = order.Date.ToString("G",CultureInfo.CreateSpecificCulture("en-us")),
                UserName = order.UserName,
                UserEmail = order.UserEmail,
                Status = (Models.Enums.Enums.OrderStatusType)order.Status,
                AmountOrder = order.Amount,
                OrderItems = Map(order.OrderItems)
            };
            return resultModel;
        }

        private static OrderItemModel Map(IEnumerable<OrderItem> orderItems)
        {
            var result = new OrderItemModel();

            foreach (var item in orderItems)
            {
                result.Items.Add(Map(item));
            };

            return result;
        }

        private static OrderItemModelItem Map(OrderItem item)
        {
            var result = new OrderItemModelItem
            {
                PrintingEditionType = item.TypeProduct,
                PrintingEditionName = item.PrintingEditionTitle
            };
            return result;
        }

    }
}
