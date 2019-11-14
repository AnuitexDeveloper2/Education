using EducationApp.BusinessLogicLayer.Models.Authors;
using EducationApp.DataAccessLayer.Repositories.Interfaces;
using System.Threading.Tasks;

namespace EducationApp.BusinessLogicLayer.Services.Interfaces
{
    public interface IAuthorService 
    {
        Task<bool> CreateAsync(AuthorsModelItem authorModelItem);
        Task<bool> UpdateAsync(AuthorsModelItem authorModelItem);
        Task<bool> RemoveAsync(AuthorsModelItem authorModelItem);
        Task<AuthorsModelItem> GetByIdAsync(long id);
    }
}
