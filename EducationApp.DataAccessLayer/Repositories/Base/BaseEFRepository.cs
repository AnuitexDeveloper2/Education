using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using BookStore.DataAccess.AppContext;
using EducationApp.DataAccessLayer.Entities;
using EducationApp.DataAccessLayer.Entities.Base;
using EducationApp.DataAccessLayer.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using static EducationApp.DataAccessLayer.Entities.Enums.Enums;

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
            var save = await _applicationContext.SaveChangesAsync();
            if (save < 1)
            {
                return 0;
            }
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
        public async Task<bool> CreateRangeAsync(List<TEntity> entities)
        {

            await _applicationContext.AddRangeAsync(entities);
            var result = await _applicationContext.SaveChangesAsync();
            if (result < 1)
            {
                return false;
            }
            return true;
        }

        public async Task<IQueryable<TEntity>> SortEntityAsync(IQueryable<TEntity> entities,string sortProperty,string sortType)
        {
            var property = typeof(PrintingEdition).GetProperty(sortProperty);
            var parameterExpr = Expression.Parameter(typeof(PrintingEdition), "k");
            var propertyExpr = Expression.Property(parameterExpr, property);
            var selectorExpr = Expression.Lambda(propertyExpr, parameterExpr);
            Expression queryExpr = entities.Expression;
            queryExpr = Expression.Call(
          typeof(Queryable),
          sortType == SortType.Increase.ToString() ? "OrderBy" : "OrderByDescending",
          new Type[] {
                entities.ElementType,
                property.PropertyType },
          queryExpr,
          selectorExpr);
           return entities.Provider.CreateQuery<TEntity>(queryExpr);
        }
    }
}

