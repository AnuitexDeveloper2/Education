using EducationApp.DataAccessLayer.Entities;
using EducationApp.DataAccessLayer.Repositories.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EducationApp.DataAccessLayer.Ropositories.Interfaces
{
    public interface IAuthorInPrintingEditionRepository : IBaseEFRRepository<AuthorInPrintingEdition>
    {

        Task<bool> RemoveAuthorInPrintingEditionAsync(long id);
        Task<bool> RemoveRange(List<AuthorInPrintingEdition> authorInPrintingEditions);
    }
}
