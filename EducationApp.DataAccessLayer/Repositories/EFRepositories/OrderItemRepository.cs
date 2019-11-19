using BookStore.DataAccess.AppContext;
using EducationApp.DataAccessLayer.Entities;
using EducationApp.DataAccessLayer.Ropositories.Base;
using EducationApp.DataAccessLayer.Ropositories.Interfaces;

namespace EducationApp.DataAccessLayer.Ropositories.EFRepositories
{
    public class OrderItemRepository : BaseEFRepository<OrderItems>, IOrderItemRepository
    {
        public OrderItemRepository(ApplicationContext applicationContext) : base(applicationContext)
        {

        }
    }
}
