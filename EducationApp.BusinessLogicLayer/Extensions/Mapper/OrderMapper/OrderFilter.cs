using EducationApp.DataAccessLayer.Helpers.OrderFilterModel;
using System.Collections.Generic;
using static EducationApp.DataAccessLayer.Entities.Enums.Enums;

namespace EducationApp.BusinessLogicLayer.Extention.Mapper.OrderMapper
{
    public static partial class OrderMapper
    {
        public static OrderFilterModel Map(this Extention.Order.OrderFilterModel orderFilterModel)
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

            var result = new List<OrderStatusType>();

            foreach (var item in orderFilterModel.StatusOrder)
            {
                statusOrder = (OrderStatusType)item;
                result.Add(statusOrder);
            }

            return result;
        }
    }
}
