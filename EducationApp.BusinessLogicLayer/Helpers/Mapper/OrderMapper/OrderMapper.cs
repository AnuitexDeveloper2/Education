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
                Status = (StatusType)ordersItemModel.OrderStatus
            };
            return order;
        }
        public static OrderFilterModel Map(EducationApp.BusinessLogicLayer.Extention.Order.OrderFilterModel orderFilterModel)
        {
            var resultFilter = new OrderFilterModel
            {
                SortOrder = (SortOrder)orderFilterModel.SortOrder,
                StatusOrder = MapList(orderFilterModel),
                SortType = (SortType)orderFilterModel.SortType //todo check types
            };
            return resultFilter;
        }
        private static List<StatusType> MapList(EducationApp.BusinessLogicLayer.Extention.Order.OrderFilterModel orderFilterModel)
        {
            var statusOrder = new StatusType();
            List<StatusType> result = new List<StatusType>();
            foreach (var item in orderFilterModel.StatusOrder)
            {
                statusOrder = (DataAccessLayer.Entities.Enums.Enums.StatusType)item;
                result.Add(statusOrder);
            }
            return result;
        }

        public static OrdersPresentationModelItem Map(OrderModel orderModel)
        {
            var result = new OrdersPresentationModelItem
            {
                Amount = orderModel.Amount,
                CountOrdersModel = orderModel.CountOrdersModel,
                DateTime = orderModel.DateTime,
                Id = orderModel.Id,
                //Title = orderModel.Title,
                //TypeProduct = orderModel.TypeProduct,
                UserName = orderModel.UserName,
                UserEmail = orderModel.UserEmail,
                Status = (StatusType) orderModel.Status
            };
            return result;
        }
    }
}



