using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.DataAccess.AppContext;
using EducationApp.DataAccessLayer.Entities.Base;
using EducationApp.DataAccessLayer.Helpers.Base;
using EducationApp.DataAccessLayer.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using static EducationApp.DataAccessLayer.Entities.Enums.Enums;
using System.Linq.Dynamic.Core;

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


        public async Task<bool> MarkRemoveAsync(TEntity entity)
        {
            entity.IsRemoved = true;
            var save = await _applicationContext.SaveChangesAsync();
            if (save > 0)
            {
                return true;
            }
            return false;
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

        public async Task<TEntity> GetByIdAsync(long id)
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
    }

    static class Extensions
    {
        public static IQueryable<TEntity> Sorting<TEntity>(this IBaseEFRRepository<TEntity> baseEFRRepository, IQueryable<TEntity> entities, string entitySortType, SortType sortType) where TEntity: BaseEntity 
        {
            var property = typeof(TEntity).GetProperty(entitySortType);
            entities = sortType == SortType.Increase ? entities.OrderBy(property.Name) : entities.OrderBy(property.Name + " descending");
            return entities;
        }
    }
   


}

