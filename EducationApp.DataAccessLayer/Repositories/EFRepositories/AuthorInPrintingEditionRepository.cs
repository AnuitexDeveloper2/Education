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

        public async Task<bool> RemoveRange(List<AuthorInPrintingEdition> authorInPrintingEditions )
        {
            _applicationContext.RemoveRange(authorInPrintingEditions);
            var result = await _applicationContext.SaveChangesAsync();
            if (result<1)
            {
                return false;
            }
            return true;

        }

        public async Task<bool> RemoveAuthorInPrintingEditionAsync(long id)
        {
            var authorInPrintingEdition = _applicationContext.AuthorInPrintingEditions.Where(k => k.PrintingEditionId == id).ToList();
            foreach (var item in authorInPrintingEdition)
            {

                var resultRemove = _applicationContext.Remove(item); //todo remove from DB
                if (resultRemove.State != EntityState.Deleted)
                {
                    return true;
                }

            }
            return true;
        }
    }
}
