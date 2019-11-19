using EducationApp.BusinessLogicLayer.Models.Authors;
using EducationApp.BusinessLogicLayer.Models.Base;
using EducationApp.DataAccessLayer.Helpers.Author;
using EducationApp.DataAccessLayer.Repositories.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EducationApp.BusinessLogicLayer.Services.Interfaces
{
    public interface IAuthorService 
    {
        Task<BaseModel> CreateAsync(AuthorModelItem authorModelItem);
        Task<BaseModel> UpdateAsync(AuthorModelItem authorModelItem);
        Task<BaseModel> RemoveAsync(AuthorModelItem authorModelItem);
        Task<AuthorModel> GetAuthors(AuthorFilterModel authorFilterModel);
    }
}
