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
                Desccription = model.Desccription,
                Price = model.Price,
                ProductType = (TypeProduct)model.TypeProduct,
                
            };
            return printingEdition;
        }

        public static PrintingEditionModelItem Map(this PrintingEdition printingEditions)
        {
            PrintingEditionModelItem printingEdition = new PrintingEditionModelItem
            {
                Date = DateTime.Now,
                Id = printingEditions.Id,
                IsRemoved = printingEditions.IsRemoved,
                Title = printingEditions.Title,
                Desccription = printingEditions.Desccription,
                Price = printingEditions.Price,
                TypeProduct = (Models.Enums.Enums.TypeProduct)printingEditions.ProductType
                
            };
            return printingEdition;
        }

        public static PrintingEdition Map(this PrintingEdition printingEdition,PrintingEditionModelItem printingEditionModelItem)
        {
            printingEdition.Title = printingEditionModelItem.Title;
            printingEdition.Desccription = printingEditionModelItem.Desccription;
            printingEdition.Price = printingEditionModelItem.Price;
            printingEdition.ProductType = (TypeProduct)printingEditionModelItem.TypeProduct;
            return printingEdition;
        }


    }
}
