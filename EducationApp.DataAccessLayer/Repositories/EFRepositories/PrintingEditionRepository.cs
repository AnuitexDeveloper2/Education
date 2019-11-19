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

namespace EducationApp.DataAccessLayer.Ropositories.EFRepositories
{
    public class PrintingEditionRepository : BaseEFRepository<PrintingEdition>, IPrintingEditionRepository
    {
        public PrintingEditionRepository(ApplicationContext applicationContext) : base(applicationContext)
        {

        }

        public async Task<List<PrintingEditionModel>> GetPrintingEditionAsync(PrintingEditionFilterModel printingEditionFilter)
        {
            var printingEditions = from printingEdition in _applicationContext.PrintingEditions
                                   select new Models.PrintingEditionModel
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
                printingEditions = printingEditions.Where(k => k.Title.Contains(printingEditionFilter.SearchString));
            }
            if (printingEditionFilter.TypeProduct == TypeProduct.Book)
            {
                printingEditions = printingEditions.Where(k => k.ProductType == 0);
            }
            if (printingEditionFilter.TypeProduct == TypeProduct.Journal)
            {
                printingEditions = printingEditions.Where(k => k.ProductType == TypeProduct.Journal);
            }
            if (printingEditionFilter.TypeProduct == TypeProduct.Journal)
            {
                printingEditions = printingEditions.Where(k => k.ProductType == TypeProduct.Newspaper);
            }
            if (printingEditionFilter.Price == Price.PriceAsc)
            {
                printingEditions = printingEditions.OrderBy(k => k.Price);
            }
            if (printingEditionFilter.Price == Price.PriceDesc)
            {
                printingEditions = printingEditions.OrderByDescending(k => k.Price);
            }

            printingEditions = printingEditions.Skip((printingEditionFilter.PageCount - 1) * printingEditionFilter.PageSize).Take(printingEditionFilter.PageSize);

            return printingEditions.ToList();
        }



    }
}
