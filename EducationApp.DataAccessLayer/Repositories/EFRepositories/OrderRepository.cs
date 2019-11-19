using EducationApp.DataAccessLayer.Ropositories.Interfaces;

namespace EducationApp.DataAccessLayer.Ropositories.EFRepositories
{
    using BookStore.DataAccess.AppContext;
    using EducationApp.DataAccessLayer.Entities;
    using EducationApp.DataAccessLayer.Entities.Base;
    using EducationApp.DataAccessLayer.Ropositories.Base;

    public class OrderRepository : BaseEFRepository<Order> ,IOrderRepository
    {
        public OrderRepository(ApplicationContext applicationContext) : base(applicationContext)
        {

        }
    }
}
