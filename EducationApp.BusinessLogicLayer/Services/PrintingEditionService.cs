using EducationApp.BusinessLogicLayer.Extention.PrintingEditionFilterState;
using EducationApp.BusinessLogicLayer.Helpers.Mapping;
using EducationApp.BusinessLogicLayer.Helpers.Mapping.Authors;
using EducationApp.BusinessLogicLayer.Helpers.Mapping.PrintingEditions;
using EducationApp.BusinessLogicLayer.Models.Base;
using EducationApp.BusinessLogicLayer.Models.PrintingEditions;
using EducationApp.BusinessLogicLayer.Services.Interfaces;
using EducationApp.DataAccessLayer.Entities;
using EducationApp.DataAccessLayer.Ropositories.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static EducationApp.BusinessLogicLayer.Common.Consts.Consts.Errors;

namespace EducationApp.BusinessLogicLayer.Services
{
    public class PrintingEditionService : IPrintingEditionService
    {
        private readonly IPrintingEditionRepository _printingEditionRepository;
        private readonly IAuthorInPrintingEditionRepository _authorInPrintingEditionRepository;
        private readonly IAuthorRepository _authorRepository;

        public PrintingEditionService(IPrintingEditionRepository printingEditionRepository, IAuthorInPrintingEditionRepository authorInPrintingEditionRepository, IAuthorRepository authorRepository)
        {
            _authorInPrintingEditionRepository = authorInPrintingEditionRepository;
            _printingEditionRepository = printingEditionRepository;
            _authorRepository = authorRepository;
        }

        public async Task<BaseModel> CreateAsync(PrintingEditionModelItem model) //todo get list with authorId from client
        {
            var resultModel = new BaseModel();
            var printingEdition = PrintingEditionMaping.Map(model);

            var printingEditionId = await _printingEditionRepository.CreateAsync(printingEdition);
            if (printingEditionId < 1)
            {
                resultModel.Errors.Add(Create);
                return resultModel;
            }
            foreach (var item in model.Authors.Items)
            {
                var authorPrintingEdition = new AuthorInPrintingEdition { AuthorId = item.Id, PrintingEditionId = printingEditionId };
                var result = await _authorInPrintingEditionRepository.CreateAsync(authorPrintingEdition);
                if (result < 1)
                {
                    resultModel.Errors.Add(Create);
                }
            }

            return resultModel;
        }

        public async Task<BaseModel> RemoveAsync(long id)
        {
            var errorsModel = new BaseModel();
            var excist = await _printingEditionRepository.FindByIdAsync(id);
            if (excist == null)
            {
                errorsModel.Errors.Add(PINotFound);
                return errorsModel;
            }

            var result = await _printingEditionRepository.RemoveAsync(excist);
            if (!result)
            {
                errorsModel.Errors.Add(PIRemove);
                return errorsModel;
            }
            await _authorInPrintingEditionRepository.RemoveAuthorInPrintingEditionAsync(id);

            return errorsModel;
        }

        public async Task<BaseModel> UpdateAsync(PrintingEditionModelItem printingEditionModelItem)
        {
            var errorsModel = new BaseModel();
            var printingEdition = await _printingEditionRepository.FindByIdAsync(printingEditionModelItem.Id);
            if (printingEdition == null || printingEdition.IsRemoved)
            {
                errorsModel.Errors.Add(PINotFound);
            }
            printingEdition = PrintingEditionMaping.Map(printingEdition, printingEditionModelItem);
            var result = await _printingEditionRepository.UpdateAsync(printingEdition);
            if (!result)
            {
                errorsModel.Errors.Add(PIUpdate);
                return errorsModel;
            }
            foreach (var item in printingEditionModelItem.Authors.Items)
            {
                result = await _authorInPrintingEditionRepository.ConfirmAuthorInPrintingEdition(printingEdition.Id, item.Id);
                if (!result)
                {
                    var authorPrintingEdition = new AuthorInPrintingEdition { AuthorId = item.Id, PrintingEditionId = printingEdition.Id };
                    var create = await _authorInPrintingEditionRepository.CreateAsync(authorPrintingEdition);
                    if (create < 1)
                    {
                        errorsModel.Errors.Add(APICreate);
                    }
                }
            }
            return errorsModel;
        }



        public async Task<PrintingEditionModel> GetPrintingEditionAsync(PrintingEditionFilterState state)
        {
            var printingEdition = await _printingEditionRepository.GetPrintingEditionAsync(PrintingEditionFilterStateMapping.Map(state));
            PrintingEditionModel modelItems = new PrintingEditionModel();
            for (int i = 0; i < printingEdition.Count(); i++)
            {
                modelItems.Items.Add(PrintingEditionFilterMapping.Map(printingEdition[i]));
            }
            return modelItems;
        }
    }


}
