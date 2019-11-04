using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.DataAccess.AppContext;
using EducationApp.DataAccessLayer.Entities.Base;
using EducationApp.DataAccessLayer.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EducationApp.DataAccessLayer.Ropositories.Base
{
    public class BaseEFRepository<TEntity> : IBaseEFRRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly ApplicationContext _applicationContext;
        private readonly DbSet<TEntity> _dbSet;
        public BaseEFRepository(ApplicationContext applicationContext, DbSet<TEntity> dbSet)
        {
            _applicationContext = applicationContext;
            _dbSet = dbSet;
        }

        async Task<bool> IBaseEFRRepository<TEntity>.CreateAsync(TEntity entity)
        {
            _dbSet.Add(entity);
            await _applicationContext.SaveChangesAsync();
            return _applicationContext.SaveChangesAsync().IsCompleted;
            
        }

        public IEnumerable<TEntity> GetAsync()
        {
            return _dbSet.AsNoTracking().ToList();
        }

        async Task<bool> IBaseEFRRepository<TEntity>.DeleteAsync(TEntity entity)
        {
            entity.IsRemoved = true;
            await _applicationContext.SaveChangesAsync();
            return _applicationContext.SaveChangesAsync().IsCompleted;
        }
        public async Task<TEntity> FindByIdAsync(long id)
        {
            return await _dbSet.FindAsync(id);
        }

        async Task<bool> IBaseEFRRepository<TEntity>.EditAsync(TEntity entity)
        {
            _dbSet.Update(entity);
            await _applicationContext.SaveChangesAsync();
            return _applicationContext.SaveChangesAsync().IsCompleted;
        }

        public Task<List<TEntity>> GetAsync(TEntity entity)
        {
            throw new System.NotImplementedException();
        }
    }
}
