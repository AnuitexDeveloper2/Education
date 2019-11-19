using EducationApp.DataAccessLayer.Entities;
using EducationApp.DataAccessLayer.Helpers.Author;
using EducationApp.DataAccessLayer.Models;
using EducationApp.DataAccessLayer.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationApp.DataAccessLayer.Ropositories.Interfaces
{
    public interface IAuthorRepository :IBaseEFRRepository<Author>
    {
        List<AuthorModelItem> GetAuthors(AuthorFilterModel authorFilterModel);
    }
}
