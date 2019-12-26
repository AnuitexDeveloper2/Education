using EducationApp.BusinessLogicLayer.Models.PrintingEditions;
using System;
using EducationApp.DataAccessLayer.Entities;
using static EducationApp.DataAccessLayer.Entities.Enums.Enums;

namespace EducationApp.BusinessLogicLayer.Helpers.Mapping
{
    public static partial class PrintingEditionMapper
    {
        public static PrintingEdition Map(this PrintingEditionModelItem model)
        {
            var printingEdition = new PrintingEdition
            {
                Date = DateTime.Now,
                Id = model.Id,
                Title = model.Title,
                Description = model.Description,
                Price = model.Price,
                ProductType = (TypeProduct)model.Type,
            };
            return printingEdition;
        }
    }
}
