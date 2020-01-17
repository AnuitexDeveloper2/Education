using EducationApp.BusinessLogicLayer.Extention.Mapper.AuthorMapper;
using EducationApp.BusinessLogicLayer.Models.PrintingEditions;
using EducationApp.DataAccessLayer.Entities;
using static EducationApp.BusinessLogicLayer.Models.Enums.Enums;

namespace EducationApp.BusinessLogicLayer.Helpers.Mapping.PrintingEditions
{
    public static partial class PrintingEditionMapper
    {
        public static PrintingEditionModelItem Map(this PrintingEdition printingEdition, CurrencyType currencyType)
        {
            var printingEditionModel = new PrintingEditionModelItem
            {
                Id = printingEdition.Id,
                Title = printingEdition.Title,
                Description = printingEdition.Description,
                Type = (ProductType)printingEdition.ProductType,
                Authors = AuthorMapper.Map(printingEdition.Authors)
            };
              printingEditionModel.Price = CurrencyConvertor.Convertor(CurrencyType.USD, currencyType, printingEdition.Price);
            return printingEditionModel;

        }

    }
}
