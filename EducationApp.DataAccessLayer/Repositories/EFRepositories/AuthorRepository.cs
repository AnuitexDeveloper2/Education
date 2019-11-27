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
        public async Task <ResponseModel<Author>> GetAuthorsAsync(AuthorFilterModel authorFilterModel)
        {
            var author = from authors in _applicationContext.Authors
                         select new Author
                         {
                             Id = authors.Id,
                             Name = authors.Name,
                             PrintingEditions = (from authorPrintingEdition in _applicationContext.AuthorInPrintingEditions
                                                 join printingEdition in _applicationContext.PrintingEditions on authorPrintingEdition.AuthorId equals authors.Id
                                                 where (authorPrintingEdition.PrintingEditionId == printingEdition.Id)
                                                 select new PrintingEdition
                                                 {
                                                     Title = printingEdition.Title,
                                                     Id = printingEdition.Id
                                                 })
                         };
            if (!string.IsNullOrEmpty(authorFilterModel.SearchString))
            {
                author = author.Where(k => k.Name.Contains(authorFilterModel.SearchString));
            }
          
            author = authorFilterModel.SortById == AuthorSortById.IdAsc ? author.OrderBy(k => k.Id) : author.OrderByDescending(k => k.Id);
            var count = await author.CountAsync();
            author = author.Skip((authorFilterModel.PageNumber - 1) * authorFilterModel.PageSize).Take(authorFilterModel.PageSize);
            var resultModel = new ResponseModel<Author>
            { 
                Data = author.ToList(),
                Count = count 
            };
            return resultModel;

        }

    }
}
