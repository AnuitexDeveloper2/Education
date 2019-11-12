using EducationApp.BusinessLogicLayer.Models.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace EducationApp.BusinessLogicLayer.Models.PrintingEditions
{
    public class PrintingEditionModel : BaseModel
    {
        public ICollection<PrintingEditionModelItem> Items = new List<PrintingEditionModelItem>();
    }
}
