using EducationApp.BusinessLogicLayer.Extention.PrintingEditionFilterState;
using EducationApp.BusinessLogicLayer.Helpers.Mapping;
using EducationApp.BusinessLogicLayer.Helpers.Mapping.AuthorInPrintingEditionMapper;
using EducationApp.BusinessLogicLayer.Helpers.Mapping.PrintingEditions;
using EducationApp.BusinessLogicLayer.Models.Base;
using EducationApp.BusinessLogicLayer.Models.PrintingEditions;
using EducationApp.BusinessLogicLayer.Services.Interfaces;
using EducationApp.DataAccessLayer.Entities;
using EducationApp.DataAccessLayer.Ropositories.Interfaces;
using System.Linq;
using System.Threading.Tasks;
using errors = EducationApp.BusinessLogicLayer.Common.Consts.Consts.Errors;

namespace EducationApp.BusinessLogicLayer.Services
{
    public class PrintingEditionService : IPrintingEditionService
    {
        private readonly IPrintingEditionRepository _printingEditionRepository;
        private readonly IAuthorInPrintingEditionRepository _authorInPrintingEditionRepository;

        public PrintingEditionService(IPrintingEditionRepository printingEditionRepository, IAuthorInPrintingEditionRepository authorInPrintingEditionRepository)
        {
            _authorInPrintingEditionRepository = authorInPrintingEditionRepository;
            _printingEditionRepository = printingEditionRepository;
        }

        public async Task<BaseModel> CreateAsync(PrintingEditionModelItem model)
        {
            var resultModel = new BaseModel();
            var printingEdition = PrintingEditionMaping.Map(model);

            var printingEditionId = await _printingEditionRepository.CreateAsync(printingEdition);
            if (printingEditionId < 1)
            {
                resultModel.Errors.Add(errors.Create);
                return resultModel;
            }

            var authorPrintingEdition = AuthorInPrintingEditionMapper.Map(printingEditionId, model.Authors.Items.ToList()); //todo rename ...s
            var hasCreated = await _authorInPrintingEditionRepository.CreateRangeAsync(authorPrintingEdition);
            if (!hasCreated)
            {
                resultModel.Errors.Add(errors.Create);
            }
            return resultModel;
        }

        public async Task<BaseModel> RemoveAsync(long id)
        {
            var errorsModel = new BaseModel();
            var excist = await _printingEditionRepository.FindByIdAsync(id);
            if (excist == null)
            {
                errorsModel.Errors.Add(errors.PINotFound);
                return errorsModel;
            }
            var result = await _printingEditionRepository.RemoveAsync(excist);
            if (!result)
            {
                errorsModel.Errors.Add(errors.PIRemove);
                return errorsModel;
            }
            await _authorInPrintingEditionRepository.RemoveByAuthorId(id);
            return errorsModel;
        }

        public async Task<BaseModel> UpdateAsync(PrintingEditionModelItem printingEditionModelItem)
        {
            var resultModel = new BaseModel();
            var printingEdition = await _printingEditionRepository.FindByIdAsync(printingEditionModelItem.Id);
            if (printingEdition == null || printingEdition.IsRemoved)
            {
                resultModel.Errors.Add(errors.PINotFound);
                return resultModel;
            }
            printingEdition = PrintingEditionMaping.Map(printingEdition, printingEditionModelItem);
            var removeAuthorInPE = await _authorInPrintingEditionRepository.RemoveByPrintingEditionId(printingEdition.Id);
            if (!removeAuthorInPE)
            {
                resultModel.Errors.Add(errors.AuthorInPERemove);
                return resultModel;
            }
            var result = await _printingEditionRepository.UpdateAsync(printingEdition);
            if (!result)
            {
                resultModel.Errors.Add(errors.PIUpdate);
                return resultModel;
            }
            var newAuthorInPE = AuthorInPrintingEditionMapper.Map(printingEdition.Id, printingEditionModelItem.Authors.Items);
            var createAuthorPE = await _authorInPrintingEditionRepository.CreateRangeAsync(newAuthorInPE);
            if (!createAuthorPE)
            {
                resultModel.Errors.Add(errors.AuthorInPECreate);
            }
            return resultModel;
        }

        public async Task<PrintingEditionModel> GetPrintingEditionAsync(PrintingEditionFilterState state)
        {
            var filterModel = PrintingEditionFilterStateMapping.Map(state);
            var printingEdition = await _printingEditionRepository.GetPrintingEditionAsync(filterModel);
            var modelItems = new PrintingEditionModel();
            for (int i = 0; i < printingEdition.Data.Count(); i++)
            {
                modelItems.Items.Add(PrintingEditionFilterMapping.Map(printingEdition.Data[i]));
            }
            modelItems.Count = printingEdition.Count;


            return modelItems;
        }
    }
}




