using EducationApp.BusinessLogicLayer.Helpers.Mapping.Authors;
using EducationApp.BusinessLogicLayer.Models.PrintingEditions;

namespace EducationApp.BusinessLogicLayer.Helpers.Mapping.PrintingEditions
{
    public class PrintingEditionFilterMapping
    {
        public static PrintingEditionModelItem Map(DataAccessLayer.Models.PrintingEditionModel model)
        {
           
                PrintingEditionModelItem printingEdition = new PrintingEditionModelItem
                {
                    //Id = model.Id,
                    //Title = model.Title,
                    //Desccription = model.Desccription,
                    //Price = model.Price,
                    //TypeProduct = (EducationApp.BusinessLogicLayer.Models.Enums.Enums.TypeProduct)model.ProductType,
                    //Authors = AuthorsMapping.Map(model.Authors)
                };
            return printingEdition;
        }
    }
}
