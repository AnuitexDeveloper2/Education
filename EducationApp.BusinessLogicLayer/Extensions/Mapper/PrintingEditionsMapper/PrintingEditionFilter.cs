using EducationApp.BusinessLogicLayer.Extention.PrintingEditionFilterState;
using EducationApp.DataAccessLayer.Helpers.PrintingEditionFilter;
using System.Collections.Generic;
using static EducationApp.DataAccessLayer.Entities.Enums.Enums;

namespace EducationApp.BusinessLogicLayer.Helpers.Mapping.PrintingEditions
{
    public static partial class PrintingEditionMapper
    {
        public static PrintingEditionFilterModel Map(this PrintingEditionFilterState printingEditionFilterState)
        {
            var printingEditionFilter = new PrintingEditionFilterModel
            {
                PageNumber = printingEditionFilterState.PageNumber,
                PageSize = printingEditionFilterState.PageSize,
                SearchString = printingEditionFilterState.SearchString,
                PrintingEditionSortType = (PrintingEditionSortType)printingEditionFilterState.PrintingEditionSortType,
                SortType = (SortType)printingEditionFilterState.SortType,
                CurrencyType = (CurrencyType)printingEditionFilterState.CurrencyType,
                MinPrice = printingEditionFilterState.MinPrice,
                MaxPrice = printingEditionFilterState.MaxPrice
            };
            if (printingEditionFilterState.TypeProduct != null)
            {
                printingEditionFilter.TypeProduct = MapList(printingEditionFilterState);
            }
            return printingEditionFilter;
        }

        private static List<TypeProduct> MapList(PrintingEditionFilterState printingEditionFilterState)
        {
            var typeProduct = new TypeProduct();
            var result = new List<TypeProduct>();
            foreach (var item in printingEditionFilterState.TypeProduct)
            {
                typeProduct = (TypeProduct)item;
                result.Add(typeProduct);
            }
            return result;
        }
    }
}
