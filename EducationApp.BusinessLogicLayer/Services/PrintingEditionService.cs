using EducationApp.BusinessLogicLayer.Helpers.Mapping;
using EducationApp.BusinessLogicLayer.Helpers.Mapping.Authors;
using EducationApp.BusinessLogicLayer.Models.Authors;
using EducationApp.BusinessLogicLayer.Models.PrintingEditions;
using EducationApp.BusinessLogicLayer.Services.Interfaces;
using EducationApp.DataAccessLayer.Entities;
using EducationApp.DataAccessLayer.Ropositories.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EducationApp.BusinessLogicLayer.Services
{
    class PrintingEditionService : IPrintingEditionService
    {
        private readonly IPrintingEditionRepository _printingEditionRepository;
        private readonly IAuthorInPrintingEditionRepository _authorInPrintingEdition;
        private readonly IAuthorRepository _authorRepository;

        public PrintingEditionService(IPrintingEditionRepository printingEditionRepository, IAuthorInPrintingEditionRepository authorInPrintingEditionRepository, IAuthorRepository authorRepository)
        {
            _authorInPrintingEdition = authorInPrintingEditionRepository;
            _printingEditionRepository = printingEditionRepository;
            _authorRepository = authorRepository;
        }

        public async Task<bool> CreateAsync(PrintingEditionModelItem model)
        {
            var printingEdition = PrintingEditionMaping.Map(model);
            var authorModel = new AuthorsModelItem { Name = model.Author };
            foreach (var item in model.Authors)
            {
                var author = AuthorsMapping.Map(item);
                if (await _authorRepository.GetId(author.Name) == null)
                {
                    await _authorRepository.CreateAsync(author);
                }
            }
            var result = await _printingEditionRepository.CreateAsync(printingEdition);
            var printingEditionId = _printingEditionRepository.GetId(printingEdition.Title).Result.Id;
            //var authors = await _authorRepository.GetId(model.Author);
            //foreach (var item in authors)
            //{
            //    var authorPrintingEdition = new AuthorInPrintingEdition { AuthorId = item.Id, PrintingEditionId = printingEditionId };
            //    await _authorInPrintingEdition.CreateAsync(authorPrintingEdition);
            //}
            await _authorInPrintingEdition.GetAsync(printingEdition.Title);
            return result;
        }



        public async Task<bool> RemoveAsync(PrintingEditionModelItem model)
        {
            var printingEdition = PrintingEditionMaping.Map(model);
            var excist = await _printingEditionRepository.FindByIdAsync(printingEdition.Id);
            if (excist == null)
            {
                return false;
            }
            var result = await _printingEditionRepository.RemoveAsync(excist);
            return result;
        }

        public async Task<bool> UpdateAsync(PrintingEditionModelItem model)
        {
            var author = PrintingEditionMaping.Map(model);
            var result = await _printingEditionRepository.UpdateAsync(author);
            return result;
        }

        public List<PrintingEditionModelItem> PrintingEditionFilter(PrintingEditionModelItem model)
        {
            var printingEdition = PrintingEditionMaping.Map(model);
            var GetAll = _printingEditionRepository.GetAll();
            List<PrintingEdition> list = _printingEditionRepository.FilterPrintingEditionFilter(model.Price);
            List<PrintingEditionModelItem> List = new List<PrintingEditionModelItem>();
            for (int i = 0; i < list.Count; i++)
            {
                List.Add(PrintingEditionMaping.Map(list[i]));
            }
            return List;
        }

        public IQueryable<PrintingEditionModelItem> FilterProductsByName(PrintingEditionModelItem model, string text)
        {
            var printingEdition = PrintingEditionMaping.Map(model);
            var GetAll = _printingEditionRepository.GetAll();
            var all = GetAll.AsQueryable();
            var result = _printingEditionRepository.FilterContainsText(all, printingEditions => printingEditions.Title, text);
            List<PrintingEdition> list = result.ToList<PrintingEdition>();
            List<PrintingEditionModelItem> List = new List<PrintingEditionModelItem>();
            for (int i = 0; i < result.Count(); i++)
            {
                List.Add(PrintingEditionMaping.Map(list[i]));
            }
            return List.AsQueryable();
        }


    }


}
