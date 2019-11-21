using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using BookStore.DataAccess.AppContext;
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

        public async Task<long> CreateAsync(TEntity entity)
        {
           
            if (entity == null)
            {
                return 0;
            }
            var resultId = await _applicationContext.AddAsync(entity);
            try
            {
            var save = await _applicationContext.SaveChangesAsync();

            }
            catch (Exception ex)
            {

                throw;
            }
            //if (save < 1)
            //{
            //    return 0;
            //}

            return resultId.Entity.Id;
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
        public async Task<bool> CreateRangeAsync(List<TEntity> entity)
        {
            await _applicationContext.AddRangeAsync(entity);
            var result = await _applicationContext.SaveChangesAsync();
            if (result < 1)
            {
                return false;
            }
            return true;
        }

        //public List<TEntity> GetEntity<TEntity>(TEntity entity, Expression<Func<TEntity, string>> getPropety)
        //{
        //    _applicationContext
        //}

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
            ));
        }

    }
}
