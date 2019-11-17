using EducationApp.DataAccessLayer.Entities;
using System.Collections.Generic;
using static EducationApp.DataAccessLayer.Entities.Enums.Enums;

namespace EducationApp.DataAccessLayer.Helpers.PrintingEditionFilter
{
    public class PrintingEditionFilter
    {
        public Price Price { get; set; }
        public TypeProduct TypeProduct { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }

    }
}
