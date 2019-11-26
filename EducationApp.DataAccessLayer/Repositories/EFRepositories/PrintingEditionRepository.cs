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
                                    join authorInPrintingEdition in _applicationContext.AuthorInPrintingEditions on printingEdition.Id equals authorInPrintingEdition.PrintingEditionId
                                    where printingEdition.Id == authorInPrintingEdition.PrintingEditionId
                                    select new PrintingEdition
                                    {
                                        Id = printingEdition.Id,
                                        Title = printingEdition.Title,
                                        //Authors = from author in _applicationContext.Authors join authorInPrintingEdition in _applicationContext.AuthorInPrintingEditions
                                        //          on author.Id equals authorInPrintingEdition.AuthorId where printingEdition.Id == authorInPrintingEdition.PrintingEditionId
                                        //          select author
                                        
                                    }).Distinct();

            //var printingEditions = (from authorInPrintingEdition in _applicationContext.AuthorInPrintingEditions
            //                        join printingEdition in _applicationContext.PrintingEditions on authorInPrintingEdition.PrintingEditionId equals printingEdition.Id
            //                        join author in _applicationContext.Authors on authorInPrintingEdition.AuthorId equals author.Id
            //                        select new PrintingEdition
            //                        {
            //                            Id = printingEdition.Id,
            //                            Title = printingEdition.Title,
            //                            Authors = _applicationContext.Authors.Where(k => k.Id == authorInPrintingEdition.AuthorId)
            //                        }).Distinct();

            //var printingEditions = (from authorInPrintingEdition in _applicationContext.AuthorInPrintingEditions
            //                        join printingEdition in _applicationContext.PrintingEditions on authorInPrintingEdition.PrintingEditionId equals printingEdition.Id
            //                        select new PrintingEdition
            //                        {
            //                            Id = printingEdition.Id,
            //                            Title = printingEdition.Title,
            //                            Authors = (from author in _applicationContext.Authors
            //                                       join aip in _applicationContext.AuthorInPrintingEditions on author.Id equals aip.AuthorId
            //                                       where(authorInPrintingEdition.PrintingEditionId == printingEdition.Id)
            //                                       select new Author
            //                                       {
            //                                           Id = author.Id,
            //                                           Name = author.Name
            //                                       }
            //                                       )
            //                        }
            //                       ).Distinct().AsQueryable();

            if (!string.IsNullOrWhiteSpace(printingEditionFilter.SearchString))
            {
                printingEditions = printingEditions.Where(l => l.Title == printingEditionFilter.SearchString);
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
            var count = printingEditions.Count();
            printingEditions = printingEditions
                .Skip((printingEditionFilter.PageNumber - 1) * printingEditionFilter.PageSize)
                .Take(printingEditionFilter.PageSize);
            var result = new ResponseModel<PrintingEdition>() { Data = await printingEditions.ToListAsync(), Count = count };
            return result;

            //return new ResponseModel<RpintingEditionModel>() { Data = }
        }
    }
}


