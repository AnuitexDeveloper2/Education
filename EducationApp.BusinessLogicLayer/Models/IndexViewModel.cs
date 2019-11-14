using EducationApp.BusinessLogicLayer.Models.PrintingEditions;
using System;
using System.Collections.Generic;
using System.Text;

namespace EducationApp.BusinessLogicLayer.Models
{
    public class IndexViewModel
    {
        public IEnumerable<PrintingEditionModelItem> PrintingEditionModelItems  { get; set; }
        public PageViewModel PageViewModel { get; set; }
    }
}
