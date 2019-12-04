using BookStore.DataAccess.AppContext;
using EducationApp.DataAccessLayer.Entities;
using EducationApp.DataAccessLayer.Ropositories.Base;
using EducationApp.DataAccessLayer.Ropositories.Interfaces;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace EducationApp.DataAccessLayer.Ropositories.EFRepositories
{
    public class AuthorInPrintingEditionRepository : BaseEFRepository<AuthorInPrintingEdition>, IAuthorInPrintingEditionRepository
    {
        public AuthorInPrintingEditionRepository(ApplicationContext applicationContext) : base(applicationContext)
        {

        }

        public async Task<bool> RemoveRangeAsync(Expression<Func<AuthorInPrintingEdition, bool>> predicate)
        {
            var authorInPrintingEditions = _applicationContext.AuthorInPrintingEditions.Where(predicate);

            if (!authorInPrintingEditions.Any())
            {
                return false;
            }

            _applicationContext.RemoveRange(authorInPrintingEditions);

            var result = await _applicationContext.SaveChangesAsync();

            return result < 1 ? false : true;

        }

    }
}
