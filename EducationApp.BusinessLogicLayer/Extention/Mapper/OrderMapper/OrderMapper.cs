using EducationApp.BusinessLogicLayer.Models.OrderItemModelItem;
using EducationApp.BusinessLogicLayer.Models.Orders;
using EducationApp.DataAccessLayer.Entities;
using EducationApp.DataAccessLayer.Helpers.OrderFilterModel;
using System;
using System.Collections.Generic;
using static EducationApp.DataAccessLayer.Entities.Enums.Enums;
//using statusType = EducationApp.DataAccessLayer.Entities.Enums.Enums;

namespace EducationApp.BusinessLogicLayer.Helpers.Mapper.OrderMapper
{
    public static class OrderMapper
    {
        public static Order Map(OrderModelItem ordersItemModel,long id)
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
        public static OrderFilterModel Map(Extention.Order.OrderFilterModel orderFilterModel)
        {
            var resultFilter = new OrderFilterModel
            {
                Id = orderFilterModel.Id,
                SortOrder = (SortOrder)orderFilterModel.SortOrder,
                StatusOrder = MapList(orderFilterModel),
                SortType = (SortType)orderFilterModel.SortType,
                PageNumber = orderFilterModel.PageNumber,
                PageSize = orderFilterModel.PageSize
            };
            return resultFilter;
        }
        private static List<OrderStatusType> MapList(Extention.Order.OrderFilterModel orderFilterModel)
        {
            var statusOrder = new OrderStatusType();
            List<OrderStatusType> result = new List<OrderStatusType>();
            foreach (var item in orderFilterModel.StatusOrder)
            {
                statusOrder = (OrderStatusType)item;
                result.Add(statusOrder);
            }
            return result;
        }

        public static OrderModelItem Map(Order order)
        {
            var resultModel = new OrderModelItem
            {
                Id = order.Id,
                Date = order.Date,
                UserName = order.UserName,
                UserEmail = order.UserEmail,
                Status = (Models.Enums.Enums.OrderStatusType)order.Status,
                AmountOrder = order.Amount,
                OrderItems = MapList(order.OrderItems)
            };
            return resultModel;
        }

        private static OrderItemModel MapList(IEnumerable<OrderItem> orderItems)
        {
            var result = new OrderItemModel();
            foreach (var item in orderItems)
            {
                result.Items.Add(MapNecessary(item));
            };
            return result;
        }

        private static OrderItemModelItem MapNecessary(OrderItem item)
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



