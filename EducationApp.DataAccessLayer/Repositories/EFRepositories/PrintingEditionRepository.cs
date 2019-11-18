using EducationApp.DataAccessLayer.Ropositories.Interfaces;
using EducationApp.DataAccessLayer.Entities;
using EducationApp.DataAccessLayer.Ropositories.Base;
using BookStore.DataAccess.AppContext;
using static EducationApp.DataAccessLayer.Entities.Enums.Enums;
using Microsoft.EntityFrameworkCore;
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

        public List<PrintingEdition> FilterPrintingEditionFilter(TypeProduct typeProduct)
        {
            var result = _applicationContext.PrintingEditions.Where(k => k.ProductType == typeProduct);
            return result.ToList();
        }

        public List<PrintingEdition> FilterPrintingEditionFilter(decimal price)
        {
            var result = _applicationContext.PrintingEditions.Where(k => k.Price > price);
            return result.ToList();
        }

        public async Task<PrintingEdition> GetId(string title)
        {
            var printingEdition =  _applicationContext.PrintingEditions.Where(k => k.Title == title).FirstOrDefault();
            return printingEdition;
        }

        public async Task<List<PrintingEditionFilterModel>> GetPrintingEdition(PrintingEditionFilter printingEditionFilter)
        {
            var printingEditions = from printingEdition in _applicationContext.PrintingEditions
                                   select new PrintingEditionFilterModel
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

            if (printingEditionFilter.Price == printingEditionFilter.Price )
            {
                printingEditions.Where(k => k.Title == printingEditionFilter.ToString());
            }

            return printingEditions.ToList();
        }



    }
}
