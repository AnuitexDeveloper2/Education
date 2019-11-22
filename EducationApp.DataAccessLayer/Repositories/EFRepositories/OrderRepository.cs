using BookStore.DataAccess.AppContext;
using EducationApp.DataAccessLayer.Entities;
using EducationApp.DataAccessLayer.Helpers.Author;
using EducationApp.DataAccessLayer.Models;
using EducationApp.DataAccessLayer.Ropositories.Base;
using EducationApp.DataAccessLayer.Ropositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static EducationApp.DataAccessLayer.Entities.Enums.Enums;

namespace EducationApp.DataAccessLayer.Ropositories.EFRepositories
{
    public class OrderRepository : BaseEFRepository<Order>, IOrderRepository
    {

        public OrderRepository(ApplicationContext applicationContext) : base(applicationContext)
        {
        }
        public async Task<List<OrderModel>> GetOrderAsync(AuthorFilterModel authorFilterModel)
        {
            var orders = from order in _applicationContext.Orders
                         join printingEdition in _applicationContext.PrintingEditions on order.Id equals printingEdition.Id
                         join user in _applicationContext.Users on order.Id equals user.Id
                         select new OrderModel
                         {
                             Id = order.Id,
                             Title = printingEdition.Title,
                             TypeProduct = printingEdition.ProductType,
                             Status = order.Status,
                         };
            return orders.ToList();
        }
    }
}