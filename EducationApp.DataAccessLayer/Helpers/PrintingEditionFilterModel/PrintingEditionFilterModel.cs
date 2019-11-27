using EducationApp.DataAccessLayer.Helpers.Base;
using System.Collections.Generic;
using static EducationApp.DataAccessLayer.Entities.Enums.Enums;

namespace EducationApp.DataAccessLayer.Helpers.PrintingEditionFilter
{
    public class PrintingEditionFilterModel : BaseFilterStatus
    {
        public PrintingEditionSortType PrintingEditionSortType { get; set; }
        public List<TypeProduct> TypeProduct { get; set; }
    }
}
