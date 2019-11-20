using EducationApp.DataAccessLayer.Helpers.Base;
using System.Collections.Generic;
using static EducationApp.DataAccessLayer.Entities.Enums.Enums;

namespace EducationApp.DataAccessLayer.Helpers.PrintingEditionFilter
{
    public class PrintingEditionFilterModel :BaseFilterStatus
    {
        public Price Price { get; set; }
        public List<TypeProduct> TypeProduct { get; set; }
       

    }
}
