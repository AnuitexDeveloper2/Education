﻿using System.Collections.Generic;
using System.Threading.Tasks;

namespace EducationApp.DataAccessLayer.Repositories.Interfaces
{
    public interface IBaseEFRRepository<TEntity> where TEntity : class
    {
        Task<long> CreateAsync(TEntity entity);
        Task<bool> UpdateAsync(TEntity entity);
        Task<TEntity> FindByIdAsync(long id);
        Task<bool> MarkRemoveAsync(TEntity entity);
        Task<bool> CreateRangeAsync(List<TEntity> entity);
    }
}
