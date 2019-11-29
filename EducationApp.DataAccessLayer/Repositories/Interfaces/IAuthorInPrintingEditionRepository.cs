using EducationApp.DataAccessLayer.Entities;
using EducationApp.DataAccessLayer.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace EducationApp.DataAccessLayer.Ropositories.Interfaces
{
    public interface IAuthorInPrintingEditionRepository : IBaseEFRRepository<AuthorInPrintingEdition>
    {

        Task<bool> RemoveRangeAsync(Expression<Func<AuthorInPrintingEdition, bool>> predicate);
    }
}
