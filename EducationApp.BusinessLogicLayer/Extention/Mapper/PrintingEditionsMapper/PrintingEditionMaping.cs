using EducationApp.BusinessLogicLayer.Models.PrintingEditions;
using System;
using EducationApp.DataAccessLayer.Entities;
using static EducationApp.DataAccessLayer.Entities.Enums.Enums;

namespace EducationApp.BusinessLogicLayer.Helpers.Mapping
{
    public static class PrintingEditionMaping
    {
        public static PrintingEdition Map(this PrintingEditionModelItem model)
        {
            PrintingEdition printingEdition = new PrintingEdition
            {
                Date = DateTime.Now,
                Id = model.Id,
                IsRemoved = model.IsRemoved,
                Title = model.Title,
                Desccription = model.Description,
                Price = model.Price,
                ProductType = (TypeProduct)model.Type,
                
            };
            return printingEdition;
        }

              public static PrintingEdition Map(this PrintingEdition printingEdition,PrintingEditionModelItem printingEditionModelItem)
        {
            printingEdition.Title = printingEditionModelItem.Title;
            printingEdition.Desccription = printingEditionModelItem.Description;
            printingEdition.Price = printingEditionModelItem.Price;
            printingEdition.ProductType = (TypeProduct)printingEditionModelItem.Type;
            return printingEdition;
        }


    }
}
