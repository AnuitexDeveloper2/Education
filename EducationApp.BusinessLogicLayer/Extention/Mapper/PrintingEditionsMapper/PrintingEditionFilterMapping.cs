using EducationApp.BusinessLogicLayer.Helpers.Mapping.Authors;
using EducationApp.BusinessLogicLayer.Models.PrintingEditions;
using EducationApp.DataAccessLayer.Entities;

namespace EducationApp.BusinessLogicLayer.Helpers.Mapping.PrintingEditions
{
    public class PrintingEditionFilterMapping
    {
        public static PrintingEditionModelItem Map(PrintingEdition printingEdition)
        {
            PrintingEditionModelItem printingEditionModel = new PrintingEditionModelItem
            {
                Id = printingEdition.Id,
                Title = printingEdition.Title,
                Description = printingEdition.Description,
                Price = printingEdition.Price,
                Type = (EducationApp.BusinessLogicLayer.Models.Enums.Enums.ProductType)printingEdition.ProductType,
                Authors = AuthorsMapper.Map(printingEdition.Authors)
            };
            return printingEditionModel;

        }

    }
}
