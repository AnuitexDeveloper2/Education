using EducationApp.DataAccessLayer.Entities;
using EducationApp.DataAccessLayer.Helpers.Author;
using EducationApp.DataAccessLayer.Models;
using EducationApp.DataAccessLayer.Repositories.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EducationApp.DataAccessLayer.Ropositories.Interfaces
{
    public interface IAuthorRepository :IBaseEFRRepository<Author>
    {
       Task <List<AuthorModelItem>> GetAuthorsAsync(AuthorFilterModel authorFilterModel);
    }
}
