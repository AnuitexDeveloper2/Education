using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using BookStore.DataAccess.AppContext;
using EducationApp.DataAccessLayer.Entities;

namespace EducationApp.DataAccessLayer.Repositories.Interfaces
{
    public interface IBaseEFRRepository<TEntity> where TEntity : class
    {
        Task<long> CreateAsync(TEntity entity);
        Task<bool> UpdateAsync(TEntity entity);
        Task<TEntity> FindByIdAsync(long id);
        Task<bool> RemoveAsync(TEntity entity);
        IQueryable<TEntity> FilterContainsText<TEntity>(IQueryable<TEntity> entities, Expression<Func<TEntity, string>> getProperty, string text);
        List<TEntity> GetAll();
       
    }
}
