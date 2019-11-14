using EducationApp.DataAccessLayer.Ropositories.Interfaces;
using EducationApp.DataAccessLayer.Entities;
using EducationApp.DataAccessLayer.Ropositories.Base;
using BookStore.DataAccess.AppContext;
using static EducationApp.DataAccessLayer.Entities.Enums.Enums;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

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

        public async Task<PrintingEdition> GetId(string Name)
        {
            var printingEdition = _applicationContext.PrintingEditions.Where(k => k.Title == Name).FirstOrDefault();
            return printingEdition;
        }

    }
}
