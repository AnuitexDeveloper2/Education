using EducationApp.BusinessLogicLayer.Extention.PrintingEditionFilterState;
using EducationApp.BusinessLogicLayer.Models.PrintingEditions;
using EducationApp.DataAccessLayer.Helpers.PrintingEditionFilter;
using System;
using System.Collections.Generic;
using System.Text;
using static EducationApp.DataAccessLayer.Entities.Enums.Enums;

namespace EducationApp.BusinessLogicLayer.Helpers.Mapping.PrintingEditions
{
    public  class PrintingEditionFilterStateMapping
    {
        public static PrintingEditionFilter Map(PrintingEditionFilterState printingEditionFilterState)
        {
            var printingEditionFilter = new PrintingEditionFilter
            {
                TypeProduct = (DataAccessLayer.Entities.Enums.Enums.TypeProduct)printingEditionFilterState.TypeProduct,
                PageNumber = printingEditionFilterState.PageNumber,
                PageSize = printingEditionFilterState.PageSize,
                Price = (DataAccessLayer.Entities.Enums.Enums.Price)printingEditionFilterState.Price
            };
            return printingEditionFilter;
        }
    }
}
