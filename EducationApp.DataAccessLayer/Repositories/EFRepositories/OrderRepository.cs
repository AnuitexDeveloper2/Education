using BookStore.DataAccess.AppContext;
using EducationApp.DataAccessLayer.Entities;
using EducationApp.DataAccessLayer.Helpers.OrderFilterModel;
using EducationApp.DataAccessLayer.Models.Base;
using EducationApp.DataAccessLayer.Ropositories.Base;
using EducationApp.DataAccessLayer.Ropositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static EducationApp.DataAccessLayer.Entities.Enums.Enums;
using System.Linq.Dynamic.Core;

namespace EducationApp.DataAccessLayer.Ropositories.EFRepositories
{
    public class OrderRepository : BaseEFRepository<Order>, IOrderRepository
    {

        public OrderRepository(ApplicationContext applicationContext) : base(applicationContext)
        {
        }
        public async Task<ResponseModel<Order>> GetOrdersAsync(OrderFilterModel orderFilterModel)
        {
            var orders = from order in _applicationContext.Orders
                         join user in _applicationContext.Users on order.UserId equals user.Id
                         where (user.Id == order.UserId)
                         select new Order
                         {
                             UserId = user.Id,
                             Id = order.Id,
                             Date = order.Date,
                             Status = order.Status,
                             UserName = user.UserName,
                             UserEmail = user.Email,
                             Amount = order.Amount,
                             OrderItems = from orderItem in _applicationContext.OrderItems
                                          join printingEdition in _applicationContext.PrintingEditions on orderItem.PrintingEditionId equals printingEdition.Id
                                          where (orderItem.OrderId == order.Id)
                                          select new OrderItem
                                          {
                                              Id = orderItem.Id,
                                              Count = orderItem.Count,
                                              PrintingEditionTitle = printingEdition.Title,
                                              TypeProduct = printingEdition.ProductType.ToString()
                                          }
                         };
            if (orderFilterModel.Id > 0)
            {
                orders = orders.Where(k => k.UserId == orderFilterModel.Id);
            }

            List<OrderStatusType> types = Enum.GetValues(typeof(OrderStatusType)).OfType<OrderStatusType>().Except(orderFilterModel.StatusOrder).ToList();

            foreach (var item in types)
            {
               orders = orders.Where(k => k.Status != item);
            }

            orders = SortByType(orders, orderFilterModel.SortOrder.ToString(), orderFilterModel.SortType);

            var count = orders.Count();

            orders = orders.Skip((orderFilterModel.PageNumber - 1) * orderFilterModel.PageSize).Take(orderFilterModel.PageSize);

            var result = new ResponseModel<Order> { Data = await orders.ToListAsync(), Count = count };

            return result;
        }

        public Order GetOrder(long id)
        {
            var result = _applicationContext.Orders.Where(p => p.PaymentId == id).FirstOrDefault();

            return result;
        }
    }
}