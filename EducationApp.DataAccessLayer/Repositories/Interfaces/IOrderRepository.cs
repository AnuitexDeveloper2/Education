using EducationApp.DataAccessLayer.Entities;
using EducationApp.DataAccessLayer.Helpers.OrderFilterModel;
using EducationApp.DataAccessLayer.Models;
using EducationApp.DataAccessLayer.Models.Base;
using EducationApp.DataAccessLayer.Repositories.Interfaces;
using System.Threading.Tasks;

namespace EducationApp.DataAccessLayer.Ropositories.Interfaces
{
    public interface IOrderRepository : IBaseEFRRepository<Order>
    {
        Task<ResponseModel<Order>> GetOrderAsync(OrderFilterModel orderFilterModel);
       
    }
}
