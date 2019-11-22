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

            var authorPrintingEdition = AuthorInPrintingEditionMapper.Map(printingEditionId,model.Authors.Items.ToList()); //todo use mapper
            var result = await _authorInPrintingEditionRepository.CreateRangeAsync(authorPrintingEdition); //todo see to AddRangeAsync
            if (!result)
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
            await _authorInPrintingEditionRepository.RemoveAuthorInPrintingEditionAsync(id);
            return errorsModel;
        }

        public async Task<BaseModel> UpdateAsync(PrintingEditionModelItem printingEditionModelItem)
        {
            var errorsModel = new BaseModel();
            //var printingEdition = await _printingEditionRepository.FindByIdAsync(printingEditionModelItem.Id);
            //if (printingEdition == null || printingEdition.IsRemoved)
            //{
            //    errorsModel.Errors.Add(errors.PINotFound);
            //}
            //printingEdition = PrintingEditionMaping.Map(printingEdition, printingEditionModelItem);
            //var result = await _printingEditionRepository.UpdateAsync(printingEdition);
            //if (!result)
            //{
            //    errorsModel.Errors.Add(errors.PIUpdate);
            //    return errorsModel;
            //}
            //var oldAuthorInPE = AuthorInPrintingEditionMapper.Map(printingEdition.Id, printingEditionModelItem.Authors);
            //var removeAuthorPE = await _authorInPrintingEditionRepository.RemoveRange(oldAuthorInPE);
            //if (!removeAuthorPE)
            //{
            //    errorsModel.Errors.Add(errors.AuthorInPERemove);
            //}
            //var newAuthorInPE = AuthorInPrintingEditionMapper.Map(printingEdition.Id, printingEditionModelItem.Authors);
            //var CreateAuthorPE = await _authorInPrintingEditionRepository.CreateRangeAsync(newAuthorInPE);
            //if (!CreateAuthorPE)
            //{
            //    errorsModel.Errors.Add(errors.AuthorInPECreate);
            //}
                //todo if if
                    //todo mapper, change this logic
            
            return errorsModel;
        }

        public async Task<PrintingEditionModel> GetPrintingEditionAsync(PrintingEditionFilterState state)
        {
            var filterModel = PrintingEditionFilterStateMapping.Map(state);
            var printingEdition = await _printingEditionRepository.GetPrintingEditionAsync(filterModel);
            var modelItems = new PrintingEditionModel();
            for (int i = 0; i < printingEdition.Count(); i++)
            {
                modelItems.Items.Add(PrintingEditionFilterMapping.Map(printingEdition[i]));
            }
            return modelItems;
        }
    }
}




