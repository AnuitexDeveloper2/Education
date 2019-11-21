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
                                       Data = (from authorInPrintingEdition in _applicationContext.AuthorInPrintingEditions
                                                  join author in _applicationContext.Authors on authorInPrintingEdition.AuthorId equals author.Id
                                                  where (authorInPrintingEdition.PrintingEditionId == printingEdition.Id)
                                                  select new Author
                                                  {
                                                      Id = author.Id,
                                                      Name = author.Name
                                                  }).ToList()
                                   };

            if (!string.IsNullOrWhiteSpace(printingEditionFilter.SearchString)) //todo add search by author
            {
                printingEditions = printingEditions.Where(k => k.Title.Contains(printingEditionFilter.SearchString));
            }
            //var allCategories = (Enum.GetValues(typeof(TypePrintingEdition))).OfType<TypePrintingEdition>().ToList();
            //allCategories = allCategories.Where(x => !printingEditionsFilterModel.Categories.Contains(x)).ToList();
          
            //todo use collection of types
            //todo change
            var category = printingEditionFilter.TypeProduct;
            foreach (var item in printingEditionFilter.TypeProduct)
            {
                printingEditions = printingEditions.Where(k => k.ProductType == item);
                printingEditions.Union(printingEditions);
            }
           

            printingEditions = printingEditionFilter.Price == Price.PriceAsc? printingEditions.OrderBy(k => k.Price): printingEditions.OrderBy(k => k.Price);
            //todo may be you can update sort logic withour If?
            printingEditions = printingEditions.Skip((printingEditionFilter.PageCount - 1) * printingEditionFilter.PageSize).Take(printingEditionFilter.PageSize); //todo where is count?
            return await printingEditions.ToListAsync();
        }



    }
}
