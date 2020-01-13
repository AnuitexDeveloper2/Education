using EducationApp.DataAccessLayer.Helpers.Base;
using System.Collections.Generic;
using static EducationApp.DataAccessLayer.Entities.Enums.Enums;

namespace EducationApp.DataAccessLayer.Helpers.PrintingEditionFilter
{
    public class PrintingEditionFilterModel : BaseFilterModel
    {
        public PrintingEditionSortType PrintingEditionSortType { get; set; }
        public List<TypeProduct> TypeProduct { get; set; }
        public CurrencyType CurrencyType { get; set; }
        public decimal MinPrice { get; set; }
        public decimal MaxPrice { get; set; }
    }
}
