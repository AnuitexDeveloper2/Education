using System.Collections.Generic;
using System.Threading.Tasks;
using BookStore.DataAccess.AppContext;


namespace EducationApp.DataAccessLayer.Repositories.Interfaces
{
    interface IBaseEFRRepository<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> GetAsync();
        Task<bool> CreateAsync(TEntity entity);
        Task<bool> DeleteAsync(TEntity entity);
        Task<bool> EditAsync(TEntity entity);
    }
}
