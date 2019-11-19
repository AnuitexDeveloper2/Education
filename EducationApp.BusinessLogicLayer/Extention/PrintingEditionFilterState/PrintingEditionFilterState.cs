using EducationApp.BusinessLogicLayer.Extention.BaseFilter;
using static EducationApp.BusinessLogicLayer.Models.Enums.Enums;

namespace EducationApp.BusinessLogicLayer.Extention.PrintingEditionFilterState
{
    public class PrintingEditionFilterState : BaseFilterModel
    {
        public TypeProduct TypeProduct { get; set; }
        public Price Price { get; set; }
    }
}
