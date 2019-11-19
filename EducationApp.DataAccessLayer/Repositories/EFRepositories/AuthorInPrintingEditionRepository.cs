using BookStore.DataAccess.AppContext;
using EducationApp.DataAccessLayer.Entities;
using EducationApp.DataAccessLayer.Ropositories.Base;
using EducationApp.DataAccessLayer.Ropositories.Interfaces;
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

        public async Task<bool> ConfirmAuthorInPrintingEdition(long printingEditionId, long authorId)
        {
            var authorInPrtintingEdition = _applicationContext.AuthorInPrintingEditions.Where(k=>k.AuthorId ==authorId).Where(l=>l.PrintingEditionId ==printingEditionId);
            var count = authorInPrtintingEdition.Count();
            if (authorInPrtintingEdition.Count() == 0)
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
                item.IsRemoved = true;
                var result = await _applicationContext.SaveChangesAsync();
                if (result < 1)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
