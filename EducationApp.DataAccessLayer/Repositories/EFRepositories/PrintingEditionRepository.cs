using EducationApp.DataAccessLayer.Ropositories.Interfaces;
using EducationApp.DataAccessLayer.Entities;
using EducationApp.DataAccessLayer.Ropositories.Base;
using BookStore.DataAccess.AppContext;
using static EducationApp.DataAccessLayer.Entities.Enums.Enums;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using EducationApp.DataAccessLayer.Helpers.PrintingEditionFilter;
using EducationApp.DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace EducationApp.DataAccessLayer.Ropositories.EFRepositories
{
    public class PrintingEditionRepository : BaseEFRepository<PrintingEdition>, IPrintingEditionRepository
    {
        public PrintingEditionRepository(ApplicationContext applicationContext) : base(applicationContext)
        {
           
        }

        public async Task<PrintingEditionModel> GetPrintingEditionAsync(PrintingEditionFilterModel printingEditionFilter) //toso rename ...s
        {
            var printingEditions = from printingEdition in _applicationContext.PrintingEditions //todo use AuthorInPE table
                                   select new PrintingEditionModel
                                   {
                                       Id = printingEdition.Id,
                                       Title = printingEdition.Title,
                                       Price = printingEdition.Price,
                                       Desccription = printingEdition.Desccription,
                                       ProductType = printingEdition.ProductType,
                                       Authors = (from authorInPrintingEdition in _applicationContext.AuthorInPrintingEditions
                                                  join author in _applicationContext.Authors on authorInPrintingEdition.AuthorId equals author.Id
                                                  where (authorInPrintingEdition.PrintingEditionId == printingEdition.Id)
                                                  select new Author
                                                  {
                                                      Id = author.Id,
                                                      Name = author.Name
                                                  }).ToList()
                                   };

            if (!string.IsNullOrWhiteSpace(printingEditionFilter.SearchString))
            {

                var author = _applicationContext.Authors.Where(k => k.Name == printingEditionFilter.SearchString).FirstOrDefault();
                var AInPE = _applicationContext.AuthorInPrintingEditions.Where(a => a.AuthorId == author.Id);
                var printingEditionSearchByName = new List<PrintingEditionModel>();
                foreach (var item in AInPE)
                {
                    printingEditionSearchByName.Add(printingEditions.Where(j => j.Id == item.PrintingEditionId).FirstOrDefault());
                }
                printingEditions = printingEditions
                    .Where(k => k.Title == printingEditionFilter.SearchString)
                    .ToList()
                    .Concat(printingEditionSearchByName)
                    .AsQueryable();
            }

            List<TypeProduct> types = Enum.GetValues(typeof(TypeProduct))
                .OfType<TypeProduct>()
                .Except(printingEditionFilter.TypeProduct)
                .ToList();
            foreach (var item in types)
            {
                printingEditions = printingEditions.Where(k => k.ProductType != item);
            }
            //todo may be you can update sort logic withour If (use Reflection)?
            printingEditions = printingEditionFilter.Price == Price.PriceAsc ? printingEditions.OrderBy(k => k.Price) : printingEditions
                .OrderBy(k => k.Price);
            var count =  printingEditions.Count();
            printingEditions = printingEditions
                .Skip((printingEditionFilter.PageCount - 1) * printingEditionFilter.PageSize)
                .Take(printingEditionFilter.PageSize);
            var result = new PrintingEditionModel { Data = await printingEditions.ToListAsync(), Count = count};
            return  result;

            //return new ResponseModel<RpintingEditionModel>() { Data = }
        }
    }
}


