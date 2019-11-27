using EducationApp.BusinessLogicLayer.Models.OrderItemModelItem;
using EducationApp.BusinessLogicLayer.Models.Orders;
using EducationApp.DataAccessLayer.Entities;
using EducationApp.DataAccessLayer.Helpers.OrderFilterModel;
using EducationApp.DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using static EducationApp.DataAccessLayer.Entities.Enums.Enums;
//using statusType = EducationApp.DataAccessLayer.Entities.Enums.Enums;

namespace EducationApp.BusinessLogicLayer.Helpers.Mapper.OrderMapper
{
    public static class OrderMapper
    {
        public static Order Map(OrdersItemModel ordersItemModel,long id)
        {
            var order = new Order
            {
                PaymentId = id,
                Description = ordersItemModel.Description,
                UserId = ordersItemModel.UserId,
                OrderStatusType = (OrderStatusType)ordersItemModel.OrderStatus,
                Date = DateTime.Now
            };
            return order;
        }
        public static OrderFilterModel Map(Extention.Order.OrderFilterModel orderFilterModel)
        {
            var resultFilter = new OrderFilterModel
            {
                SortOrder = (SortOrder)orderFilterModel.SortOrder,
                StatusOrder = MapList(orderFilterModel),
                SortType = (SortType)orderFilterModel.SortType //todo check types
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

        public static OrdersItemModel Map(Order order)
        {
            var resultModel = new OrdersItemModel
            {
                Id = order.Id,
                DateTime = order.Date,
                UserName = order.UserName,
                UserEmail = order.UserEmail,
                OrderStatus = (Models.Enums.Enums.OrderStatusType)order.OrderStatusType,
                AmountOrder = order.Amount,
                OrderItemModel = MapList(order.OrderItems)
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
                TypeProduct = (Models.Enums.Enums.TypeProduct)item.TypeProduct,
                PrintingEditionName = item.PrintingEditionTitle
            };
          return result;
        }
    }
}



