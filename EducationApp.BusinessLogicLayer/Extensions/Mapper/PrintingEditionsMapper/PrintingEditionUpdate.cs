using EducationApp.BusinessLogicLayer.Models.Authors;
using EducationApp.BusinessLogicLayer.Models.PrintingEditions;
using EducationApp.DataAccessLayer.Entities;
using System.Collections.Generic;
using static EducationApp.DataAccessLayer.Entities.Enums.Enums;
using EducationApp.BusinessLogicLayer.Helpers.Mapping.Authors;

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
            printingEdition.Authors = Map(printingEditionModelItem.Authors);
            return printingEdition;
        }

        public static List<DataAccessLayer.Entities.Author> Map(AuthorModel authorModel)
        {
            var result = new List<DataAccessLayer.Entities.Author>();

            foreach (var item in authorModel.Items)
            {
                result.Add(item.Map());
            }
            return result;
        }
    }
}
