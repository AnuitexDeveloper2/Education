using EducationApp.DataAccessLayer.Entities;
using EducationApp.DataAccessLayer.Helpers.Base;
using System.Collections.Generic;
using static EducationApp.DataAccessLayer.Entities.Enums.Enums;

namespace EducationApp.DataAccessLayer.Helpers.PrintingEditionFilter
{
    public class PrintingEditionFilter :BaseFilterModel
    {
        public Price Price { get; set; }
        public TypeProduct TypeProduct { get; set; }
       

    }
}
