using EducationApp.BusinessLogicLayer.Extention.BaseFilter;
using System.Collections.Generic;
using static EducationApp.BusinessLogicLayer.Models.Enums.Enums;

namespace EducationApp.BusinessLogicLayer.Extention.PrintingEditionFilterState
{
    public class PrintingEditionFilterState : BaseFilterModel
    {
        public List<ProductType> TypeProduct { get; set; }
        public PrintingEditionSortType PrintingEditionSortType { get; set; }
        public decimal MinPrice { get; set; }
        public decimal MaxPrice { get; set; }
        public CurrencyType CurrencyType { get; set; }
    }
}
