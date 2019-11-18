using EducationApp.DataAccessLayer.Entities;
using EducationApp.DataAccessLayer.Repositories.Interfaces;
using System.Threading.Tasks;

namespace EducationApp.DataAccessLayer.Ropositories.Interfaces
{
    public interface IAuthorInPrintingEditionRepository : IBaseEFRRepository<AuthorInPrintingEdition>
    {

        Task GetAsync(string name);
        Task<bool> RemoveAuthorInPrintingEditionAsync(long id);
    }
}
