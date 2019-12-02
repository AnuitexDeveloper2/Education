using BookStore.DataAccess.AppContext;
using EducationApp.DataAccessLayer.Entities;
using EducationApp.DataAccessLayer.Helpers.Author;
using EducationApp.DataAccessLayer.Models;
using EducationApp.DataAccessLayer.Models.Base;
using EducationApp.DataAccessLayer.Ropositories.Base;
using EducationApp.DataAccessLayer.Ropositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static EducationApp.DataAccessLayer.Entities.Enums.Enums;

namespace EducationApp.DataAccessLayer.Ropositories.EFRepositories
{
    public class AuthorRepository : BaseEFRepository<Author>, IAuthorRepository
    {

        public AuthorRepository(ApplicationContext applicationContext) : base(applicationContext)
        {
        }
        public async Task<ResponseModel<Author>> GetAuthorsAsync(AuthorFilterModel authorFilterModel)
        {
            var authors = from author in _applicationContext.Authors
                         select new Author
                         {
                             Id = author.Id,
                             Name = author.Name,
                             PrintingEditions = (from authorPrintingEdition in _applicationContext.AuthorInPrintingEditions
                                                 join printingEdition in _applicationContext.PrintingEditions on authorPrintingEdition.AuthorId equals author.Id
                                                 where (authorPrintingEdition.PrintingEditionId == printingEdition.Id)
                                                 select new PrintingEdition
                                                 {
                                                     Title = printingEdition.Title,
                                                     Id = printingEdition.Id
                                                 })
                         };
            if (!string.IsNullOrEmpty(authorFilterModel.SearchString))
            {
                authors = authors.Where(k => k.Name.Contains(authorFilterModel.SearchString));
            }

            if (!authors.Any())
            {
                return null;
            }

            authors = authorFilterModel.SortType == SortType.Increase ? authors.OrderBy(k => k.Id) : authors.OrderByDescending(k => k.Id);

            var count = await authors.CountAsync();

            authors = authors.Skip((authorFilterModel.PageNumber - 1) * authorFilterModel.PageSize).Take(authorFilterModel.PageSize);

            var resultModel = new ResponseModel<Author> { Data = authors.ToList(), Count = count };

            return resultModel;

        }

    }
}
