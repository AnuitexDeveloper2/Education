using EducationApp.DataAccessLayer.Entities;
using EducationApp.DataAccessLayer.Repositories.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EducationApp.DataAccessLayer.Ropositories.Interfaces
{
    public interface IAuthorInPrintingEditionRepository : IBaseEFRRepository<AuthorInPrintingEdition>
    {

        Task<bool> RemoveByAuthorId(long id);
       
        Task<bool> RemoveByPrintingEditionId(long id);
    }
}
