using EducationApp.BusinessLogicLayer.Helpers.Mapping;
using EducationApp.BusinessLogicLayer.Models.PrintingEditions;
using EducationApp.BusinessLogicLayer.Services.Interfaces;
using EducationApp.DataAccessLayer.Entities;
using EducationApp.DataAccessLayer.Entities.Enums;
using EducationApp.DataAccessLayer.Ropositories.Base;
using EducationApp.DataAccessLayer.Ropositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static EducationApp.DataAccessLayer.Entities.Enums.Enums;

namespace EducationApp.BusinessLogicLayer.Services
{
    class PrintingEditionService : IPrintingEditionService
    {
        private readonly IPrintingEditionRepository _printingEditionRepository;

        public PrintingEditionService(IPrintingEditionRepository printingEditionRepository)
        {
            _printingEditionRepository = printingEditionRepository;
        }

        public async Task<bool> CreateAsync(PrintingEditionModelItem model)
        {
            var printingEdition = PrintingEditionMaping.Map(model);
            var result = await _printingEditionRepository.CreateAsync(printingEdition);
            return result;
        }

        public Task<IEnumerable<PrintingEdition>> Filter()
        {
            throw new NotImplementedException();
        }

        public async Task<bool> RemoveAsync(PrintingEditionModelItem model)
        {
            var printingEdition = PrintingEditionMaping.Map(model);
            var excist = _printingEditionRepository.FindById(printingEdition.Id);
            if (excist == null)
            {
                return false;
            }
            var result = await _printingEditionRepository.RemoveAsync(excist);
            return result;
        }

        public async Task<bool> UpdateAsync(PrintingEditionModelItem model)
        {
            var printingEdition = PrintingEditionMaping.Map(model);
            var current = _printingEditionRepository.FindById(printingEdition.Id);
            var result = await _printingEditionRepository.UpdateAsync(current);
            return result;
        }

        public List<PrintingEditionModelItem> PrintingEditionFilter(PrintingEditionModelItem model)
        {
            var printingEdition = PrintingEditionMaping.Map(model);
            List<PrintingEdition> list = _printingEditionRepository.FilterPrintingEditionFilter(model.Price);
            List<PrintingEditionModelItem> List = new List<PrintingEditionModelItem>();
                for (int i = 0; i < list.Count; i++)
                {
                    List.Add(PrintingEditionMaping.Map(list[i]));
                }
            return List;
        }


}


}
