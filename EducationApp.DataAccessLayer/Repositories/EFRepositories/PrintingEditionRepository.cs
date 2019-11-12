using EducationApp.DataAccessLayer.Ropositories.Interfaces;
using EducationApp.DataAccessLayer.Entities;
using EducationApp.DataAccessLayer.Ropositories.Base;
using BookStore.DataAccess.AppContext;
using Microsoft.AspNetCore.Identity;
using System;
using static EducationApp.DataAccessLayer.Entities.Enums.Enums;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.Generic;

namespace EducationApp.DataAccessLayer.Ropositories.EFRepositories
{
    public class PrintingEditionRepository : BaseEFRepository<PrintingEdition>, IPrintingEditionRepository
    {
        private static DbSet<PrintingEdition> dbSet;

        public PrintingEditionRepository(ApplicationContext applicationContext) : base(applicationContext,dbSet)
        {

        }

        public List<PrintingEdition> FilterPrintingEditionFilter( TypeProduct typeProduct)
        {
            var result = _applicationContext.PrintingEditions.Where(k => k.ProductType == typeProduct);
            return result.ToList();
        }

        public List<PrintingEdition> FilterPrintingEditionFilter( decimal price)
        {
            var result = _applicationContext.PrintingEditions.Where(k => k.Price > price);
            return result.ToList();
        }

    }
}
