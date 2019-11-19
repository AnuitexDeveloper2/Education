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
        public static PrintingEditionFilterModel Map(PrintingEditionFilterState printingEditionFilterState)
        {
            var printingEditionFilter = new PrintingEditionFilterModel
            {
                TypeProduct = (DataAccessLayer.Entities.Enums.Enums.TypeProduct)printingEditionFilterState.TypeProduct,
                PageCount = printingEditionFilterState.PageCount,
                PageSize = printingEditionFilterState.PageSize,
                SearchString = printingEditionFilterState.SearchString,
                Price = (DataAccessLayer.Entities.Enums.Enums.Price)printingEditionFilterState.Price
            };
            return printingEditionFilter;
        }
    }
}
