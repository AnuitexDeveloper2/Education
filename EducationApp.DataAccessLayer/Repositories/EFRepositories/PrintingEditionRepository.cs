using BookStore.DataAccess.AppContext;
using EducationApp.DataAccessLayer.Entities;
using EducationApp.DataAccessLayer.Helpers.PrintingEditionFilter;
using EducationApp.DataAccessLayer.Models.Base;
using EducationApp.DataAccessLayer.Ropositories.Base;
using EducationApp.DataAccessLayer.Ropositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using static EducationApp.DataAccessLayer.Entities.Enums.Enums;
namespace EducationApp.DataAccessLayer.Ropositories.EFRepositories
{
    public class PrintingEditionRepository : BaseEFRepository<PrintingEdition>, IPrintingEditionRepository
    {
        private List<TypeProduct> types = new List<TypeProduct>();
        public PrintingEditionRepository(ApplicationContext applicationContext) : base(applicationContext)
        {

        }

        public async Task<ResponseModel<PrintingEdition>> GetFiltredAsync(PrintingEditionFilterModel printingEditionFilter)
        {
            var printingEditions = (from printingEdition in _applicationContext.PrintingEditions
                                    where printingEdition.IsRemoved == false
                                    select new PrintingEdition
                                    {
                                        Id = printingEdition.Id,
                                        Title = printingEdition.Title,
                                        ProductType = printingEdition.ProductType,
                                        Price = printingEdition.Price,
                                        Description = printingEdition.Description,
                                        Date = printingEdition.Date,
                                        Authors = (from authorPrintingEdition in _applicationContext.AuthorInPrintingEditions
                                                   join author in _applicationContext.Authors on authorPrintingEdition.AuthorId equals author.Id
                                                   where (authorPrintingEdition.PrintingEditionId == printingEdition.Id)
                                                   select new Author
                                                   {
                                                       Name = author.Name,
                                                       Id = author.Id
                                                   })
                                    });
            if (!string.IsNullOrWhiteSpace(printingEditionFilter.SearchString))
            {
                var searchByName = await printingEditions.Where(k => k.Authors.Any(l => l.Name.Contains(printingEditionFilter.SearchString))).ToListAsync();
                var searchByTitle = await printingEditions.Where(l => l.Title.Contains(printingEditionFilter.SearchString)).ToListAsync();
                printingEditions = Enumerable.Concat(searchByName, searchByTitle).AsQueryable();
            }

            if (!printingEditions.Any())
            {
                return null;
            }

            types = Enum.GetValues(typeof(TypeProduct))
                .OfType<TypeProduct>()
                .Except(printingEditionFilter.TypeProduct)
                .ToList();
            if (!printingEditionFilter.TypeProduct.Any())
            {
                types = new List<TypeProduct>();
            }

            foreach (var item in types)
            {
                printingEditions = printingEditions.Where(k => k.ProductType != item);
            }

            printingEditions = SortByType(printingEditions, printingEditionFilter.PrintingEditionSortType.ToString(), printingEditionFilter.SortType);

            printingEditions = printingEditions.Where(k => k.Price > printingEditionFilter.MinPrice && k.Price < printingEditionFilter.MaxPrice);

            var count = printingEditions.Count();

            printingEditions = printingEditions.Skip((printingEditionFilter.PageNumber - 1) * printingEditionFilter.PageSize).Take(printingEditionFilter.PageSize);

            var result = new ResponseModel<PrintingEdition>()
            {
                Data = printingEditions.ToList(),
                Count = count
            };

            return result;
        }

    }
}


