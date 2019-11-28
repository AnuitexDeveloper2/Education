using EducationApp.BusinessLogicLayer.Extention.BaseFilter;
using System.Collections.Generic;
using static EducationApp.BusinessLogicLayer.Models.Enums.Enums;

namespace EducationApp.BusinessLogicLayer.Extention.PrintingEditionFilterState
{
    public class PrintingEditionFilterState : BaseFilterModel
    {
        public List<TypeProduct> TypeProduct { get; set; }
        public PrintingEditionSortType PrintingEditionSortType { get; set; }
    }
}
