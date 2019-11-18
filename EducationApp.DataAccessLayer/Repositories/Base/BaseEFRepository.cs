using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using BookStore.DataAccess.AppContext;
using EducationApp.DataAccessLayer.Entities;
using EducationApp.DataAccessLayer.Entities.Base;
using EducationApp.DataAccessLayer.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EducationApp.DataAccessLayer.Ropositories.Base
{
    public class BaseEFRepository<TEntity> : IBaseEFRRepository<TEntity> where TEntity : BaseEntity
    {
        protected readonly ApplicationContext _applicationContext;
        protected readonly DbSet<TEntity> _dbSet;

        public BaseEFRepository(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
            _dbSet = _applicationContext.Set<TEntity>();
        }

        public async Task<bool> CreateAsync(TEntity entity)
        {
            if (entity == null)
            {
                return false;
            }
            await _applicationContext.AddAsync(entity);
            var save = await _applicationContext.SaveChangesAsync();
            if (save > 0)
            {
                return true;
            }
            return false;
        }


        public async Task<bool> RemoveAsync(TEntity entity)
        {
            entity.IsRemoved = true;
            var save = await _applicationContext.SaveChangesAsync();
            if (save > 0)
            {
                return true;
            }
            return false;
        }

        public List<TEntity> GetAll()
        {
            var getAll = _dbSet.ToList<TEntity>();
            return getAll;
        }

        public async Task<bool> UpdateAsync(TEntity entity)
        {
            
            if (entity.Id == 0)
            {
                return false;
            }
            _applicationContext.Attach(entity).State = EntityState.Modified;
            var result = await _applicationContext.SaveChangesAsync();
            if (result > 0)
            {
                return true;
            }
            return false;
        }

        public async Task<TEntity> FindByIdAsync(long id)
        {
            var result = await _dbSet.FindAsync(id);

            if (result == null)
            {
                return null;
            }
            return result;
        }


        public IQueryable<TEntity> Get()
        {
            var deleted = _dbSet.Where(k =>k.IsRemoved == true);
            return deleted;
        }

        public IQueryable<TEntity> FilterContainsText<TEntity>(IQueryable<TEntity> entities, Expression<Func<TEntity, string>> getProperty, string text)
        {
            return entities.Where(Expression.Lambda<Func<TEntity, bool>>
            (
                body: Expression.Call
                (
                    getProperty.Body,
                    nameof(string.Contains),
                    Type.EmptyTypes,
                    Expression.Constant(text)
                ),
                parameters: getProperty.Parameters.FirstOrDefault()
            )) ;
        }

    }
}
