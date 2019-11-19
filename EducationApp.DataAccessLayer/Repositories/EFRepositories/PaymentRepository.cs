using BookStore.DataAccess.AppContext;
using EducationApp.DataAccessLayer.Entities;
using EducationApp.DataAccessLayer.Repositories.Interfaces;
using EducationApp.DataAccessLayer.Ropositories.Base;

namespace EducationApp.DataAccessLayer.Repositories.EFRepositories
{
    public class PaymentRepository : BaseEFRepository<Payment>, IPaymentRepository
    {
        public PaymentRepository(ApplicationContext applicationContext) : base(applicationContext)
        {

        }
    }
}
