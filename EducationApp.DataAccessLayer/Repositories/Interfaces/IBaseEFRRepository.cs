using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using BookStore.DataAccess.AppContext;
using EducationApp.DataAccessLayer.Entities;

namespace EducationApp.DataAccessLayer.Repositories.Interfaces
{
    public interface IBaseEFRRepository<TEntity> where TEntity : class
    {
        Task<bool> CreateAsync(TEntity entity);
        Task<bool> UpdateAsync(TEntity entity);
        TEntity FindById(long id);
        Task<bool> RemoveAsync(TEntity entity);
        Task<TEntity> GetAsync(TEntity entity);
    }
}
