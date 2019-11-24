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
using System.Linq.Expressions;
using System;

namespace EducationApp.DataAccessLayer.Ropositories.EFRepositories
{
    public class PrintingEditionRepository : BaseEFRepository<PrintingEdition>, IPrintingEditionRepository
    {
        private readonly IAuthorInPrintingEditionRepository _authorInPrintingEditionRepository;
        public PrintingEditionRepository(ApplicationContext applicationContext, IAuthorInPrintingEditionRepository authorInPrintingEditionRepository) : base(applicationContext)
        {
            _authorInPrintingEditionRepository = authorInPrintingEditionRepository;
        }

        public async Task<PrintingEditionModel> GetPrintingEditionAsync(PrintingEditionFilterModel printingEditionFilter)
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

            if (!string.IsNullOrWhiteSpace(printingEditionFilter.SearchString)) //todo add search by author
            {

                var author = _applicationContext.Authors.Where(k => k.Name == printingEditionFilter.SearchString).FirstOrDefault();
                var AInPE = _applicationContext.AuthorInPrintingEditions.Where(a => a.AuthorId == author.Id);
                var List = new List<PrintingEditionModel>();
                foreach (var item in AInPE)
                {
                    List.Add(printingEditions.Where(j => j.Id == item.PrintingEditionId).FirstOrDefault());
                }
                printingEditions = printingEditions
                    .Where(k => k.Title == printingEditionFilter.SearchString)
                    .ToList()
                    .Concat(List)
                    .AsQueryable();
            }

            //todo use collection of types
            //todo change
            List<TypeProduct> types = Enum.GetValues(typeof(TypeProduct))
                .OfType<TypeProduct>()
                .Except(printingEditionFilter.TypeProduct)
                .ToList();
            foreach (var item in types)
            {
                printingEditions = printingEditions.Where(k => k.ProductType != item);
            }
            //todo may be you can update sort logic withour If?
            printingEditions = printingEditionFilter.Price == Price.PriceAsc ? printingEditions.OrderBy(k => k.Price) : printingEditions
                .OrderBy(k => k.Price);
            var count =  printingEditions.Count();
            //printingEditions = printingEditions
            //    .Skip((printingEditionFilter.PageCount - 1) * printingEditionFilter.PageSize)
            //    .Take(printingEditionFilter.PageSize); //todo where is count?
            var result = new PrintingEditionModel { Data = printingEditions.ToList(), Count = count };
            return  result;
        }
    }
}


