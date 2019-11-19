using BookStore.DataAccess.AppContext;
using EducationApp.DataAccessLayer.Entities;
using EducationApp.DataAccessLayer.Helpers.Author;
using EducationApp.DataAccessLayer.Models;
using EducationApp.DataAccessLayer.Ropositories.Base;
using EducationApp.DataAccessLayer.Ropositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace EducationApp.DataAccessLayer.Ropositories.EFRepositories
{
    public class AuthorRepository : BaseEFRepository<Author>, IAuthorRepository
    {

        public AuthorRepository(ApplicationContext applicationContext) : base(applicationContext)
        {
        }
        public List<AuthorModelItem> GetAuthors(AuthorFilterModel authorFilterModel)
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
                                                 }).ToList()



                         };

            //author = author.Skip((authorFilterModel.PageCount - 1) * authorFilterModel.PageSize).Take(authorFilterModel.PageSize);
            return author.ToList();

        }

    }
}
