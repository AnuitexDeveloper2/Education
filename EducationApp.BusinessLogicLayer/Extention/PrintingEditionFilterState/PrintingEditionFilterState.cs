using System;
using System.Collections.Generic;
using System.Text;
using static EducationApp.BusinessLogicLayer.Models.Enums.Enums;

namespace EducationApp.BusinessLogicLayer.Extention.PrintingEditionFilterState
{
    public class PrintingEditionFilterState
    {
        public int PageNumber { get; set; } 
        public int PageSize { get; set; } 
        public TypeProduct TypeProduct { get; set; }
        public Price Price { get; set; }
    }
}
