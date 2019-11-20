using BookStore.DataAccess.AppContext;
using EducationApp.DataAccessLayer.Entities;
using EducationApp.DataAccessLayer.Helpers.Author;
using EducationApp.DataAccessLayer.Models;
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
        public async Task<List<AuthorModelItem>> GetAuthorsAsync(AuthorFilterModel authorFilterModel) //toao add async
        {
            var author = from authors in _applicationContext.Authors
                         select new AuthorModelItem
                         {
                             Id = authors.Id,
                             Name = authors.Name,
                             printingEditions = (from authorPrintingEdition in _applicationContext.AuthorInPrintingEditions
                                                 join printingEdition in _applicationContext.PrintingEditions on authorPrintingEdition.AuthorId equals authors.Id
                                                 where (authorPrintingEdition.PrintingEditionId == printingEdition.Id)
                                                 select new PrintingEdition
                                                 {
                                                     Title = printingEdition.Title
                                                 }) //todo check without .ToList()
                         };
            //todo sort by id
            if (!string.IsNullOrEmpty(authorFilterModel.SearchString))
            {
                author = author.Where(k => k.Name.Contains(authorFilterModel.SearchString));
            }
            author = authorFilterModel.SortById == AuthorSortById.IdAsc ? author.OrderBy(k => k.Id) : author.OrderByDescending(k => k.Id);
            //author = author.Skip((authorFilterModel.PageCount - 1) * authorFilterModel.PageSize).Take(authorFilterModel.PageSize); //todo where count
           
            return await author.ToListAsync();

        }

    }
}
