using EducationApp.BusinessLogicLayer.Helpers.Mapping.Authors;
using EducationApp.BusinessLogicLayer.Models.PrintingEditions;
using EducationApp.DataAccessLayer.Helpers.PrintingEditionFilter;
using EducationApp.DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;
using static EducationApp.BusinessLogicLayer.Models.Enums.Enums;

namespace EducationApp.BusinessLogicLayer.Helpers.Mapping.PrintingEditions
{
    public class PrintingEditionFilterMapping
    {
        public static PrintingEditionModelItem Map(PrintingEditionFilterModel model)
        {
           
                PrintingEditionModelItem printingEdition = new PrintingEditionModelItem
                {
                    Id = model.Id,
                    Title = model.Title,
                    Desccription = model.Desccription,
                    Price = model.Price,
                    TypeProduct = (EducationApp.BusinessLogicLayer.Models.Enums.Enums.TypeProduct)model.ProductType,
                    Authors = AuthorsMapping.Map(model.Authors)
                };
           
            return printingEdition;
        }
    }
}
