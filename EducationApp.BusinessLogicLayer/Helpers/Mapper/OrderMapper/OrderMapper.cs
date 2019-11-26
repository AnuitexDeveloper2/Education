using EducationApp.BusinessLogicLayer.Models.Orders;
using EducationApp.DataAccessLayer.Entities;
using EducationApp.DataAccessLayer.Helpers.OrderFilterModel;
using EducationApp.DataAccessLayer.Models;
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
                Status = (OrderStatusType)ordersItemModel.OrderStatus
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

        public static OrdersPresentationModelItem Map(Order orderModel)
        {
            var result = new OrdersPresentationModelItem
            {
                Amount = orderModel.Amount,
                CountOrdersModel = orderModel.CountOrdersModel,
                DateTime = orderModel.Date,
                Id = orderModel.Id,
                //Title = orderModel.Title,
                //TypeProduct = orderModel.TypeProduct,
                UserName = orderModel.UserName,
                UserEmail = orderModel.UserEmail,
                OrderStatusType = (Models.Enums.Enums.OrderStatusType) orderModel.OrderStatusType,
                
            };
            return result;
        }
    }
}



