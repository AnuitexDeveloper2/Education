using EducationApp.BusinessLogicLayer.Models.PrintingEditions;
using EducationApp.DataAccessLayer.Entities;
using static EducationApp.DataAccessLayer.Entities.Enums.Enums;

namespace EducationApp.BusinessLogicLayer.Extention.Mapper.PrintingEditionsMapper
{
   public static partial class PrintingEditionMapper
    {
        public static PrintingEdition Map(this PrintingEditionModelItem printingEditionModelItem, PrintingEdition printingEdition)
        {
            printingEdition.Title = printingEditionModelItem.Title;
            printingEdition.Description = printingEditionModelItem.Description;
            printingEdition.Price = printingEditionModelItem.Price;
            printingEdition.ProductType = (TypeProduct)printingEditionModelItem.Type;
            return printingEdition;
        }
    }
}
