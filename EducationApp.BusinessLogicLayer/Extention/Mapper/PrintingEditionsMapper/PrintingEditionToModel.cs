using EducationApp.BusinessLogicLayer.Extention.Mapper.AuthorMapper;
using EducationApp.BusinessLogicLayer.Models.PrintingEditions;
using EducationApp.DataAccessLayer.Entities;

namespace EducationApp.BusinessLogicLayer.Helpers.Mapping.PrintingEditions
{
    public static partial class PrintingEditionMapper
    {
        public static PrintingEditionModelItem Map(this PrintingEdition printingEdition)
        {
            PrintingEditionModelItem printingEditionModel = new PrintingEditionModelItem
            {
                Id = printingEdition.Id,
                Title = printingEdition.Title,
                Description = printingEdition.Description,
                Price = printingEdition.Price,
                Type = (Models.Enums.Enums.ProductType)printingEdition.ProductType,
                Authors = AuthorMaper.Map(printingEdition.Authors)
            };
            return printingEditionModel;

        }

    }
}
