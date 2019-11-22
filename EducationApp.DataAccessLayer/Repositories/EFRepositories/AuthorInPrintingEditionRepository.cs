using BookStore.DataAccess.AppContext;
using EducationApp.DataAccessLayer.Entities;
using EducationApp.DataAccessLayer.Ropositories.Base;
using EducationApp.DataAccessLayer.Ropositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EducationApp.DataAccessLayer.Ropositories.EFRepositories
{
    public class AuthorInPrintingEditionRepository : BaseEFRepository<AuthorInPrintingEdition>, IAuthorInPrintingEditionRepository
    {
        public AuthorInPrintingEditionRepository(ApplicationContext applicationContext) : base(applicationContext)
        {

        }

        public async Task<bool> RemoveByAuthorId(long id)
        {
            var authorInPrintingEdition = await _applicationContext.AuthorInPrintingEditions.Where(k => k.AuthorId == id).ToListAsync();
            _applicationContext.RemoveRange(authorInPrintingEdition);
            var result = await _applicationContext.SaveChangesAsync();
            //todo remove from DB
            if (result<1)
            {
                return false;
            }
            return true;
        }

        public async Task<bool> RemoveByPrintingEditionId(long id)
        {
            var authorInPrintingEdition = await _applicationContext.AuthorInPrintingEditions.Where(k => k.PrintingEditionId == id).ToListAsync();
            _applicationContext.RemoveRange(authorInPrintingEdition);
            var result = await _applicationContext.SaveChangesAsync();
            if (result < 1)
            {
                return false;
            }
            return true;
        }
    }
}
