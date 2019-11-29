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
        public PrintingEditionRepository(ApplicationContext applicationContext) : base(applicationContext)
        {

        }

        public async Task<ResponseModel<PrintingEdition>> GetPrintingEditionsAsync(PrintingEditionFilterModel printingEditionFilter) //toso rename ...s
        {
            var printingEditions = (from printingEdition in _applicationContext.PrintingEditions
                                    select new PrintingEdition
                                    {
                                        Id = printingEdition.Id,
                                        Title = printingEdition.Title,
                                        ProductType = printingEdition.ProductType,
                                        Price = printingEdition.Price,
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
                var searchByName = await printingEditions.Where(k => k.Authors.Any(l => l.Name == printingEditionFilter.SearchString)).ToListAsync();
                var printingEditio = await printingEditions.Where(l => l.Title == printingEditionFilter.SearchString).ToListAsync();
                printingEditions = Enumerable.Concat(searchByName, printingEditio).AsQueryable();
            }

            if (printingEditions.Count() == 0)
            {
                return null;
            }

            List<TypeProduct> types = Enum.GetValues(typeof(TypeProduct))
                .OfType<TypeProduct>()
                .Except(printingEditionFilter.TypeProduct)
                .ToList();

            foreach (var item in types)
            {
                printingEditions = printingEditions.Where(k => k.ProductType != item);
            }

            var property = typeof(PrintingEdition).GetProperty(printingEditionFilter.PrintingEditionSortType.ToString()); //todo replace to extantion
            printingEditions = printingEditionFilter.SortType == SortType.Decrease ? printingEditions
                .OrderBy(property.Name, printingEditionFilter.PrintingEditionSortType.ToString()): printingEditions.OrderBy(property.Name + " descending"); 
            var count = printingEditions.Count();

            printingEditions = printingEditions.Skip((printingEditionFilter.PageNumber - 1) * printingEditionFilter.PageSize).Take(printingEditionFilter.PageSize);

            var result = new ResponseModel<PrintingEdition>()
            { 
                Data = await printingEditions.ToListAsync(),
                Count = count
            };
            return result;
        }
    }
}


