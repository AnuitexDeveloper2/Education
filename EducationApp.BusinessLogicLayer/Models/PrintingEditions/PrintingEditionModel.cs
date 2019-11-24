using EducationApp.BusinessLogicLayer.Models.Base;
using System.Collections.Generic;

namespace EducationApp.BusinessLogicLayer.Models.PrintingEditions
{
    public class PrintingEditionModel : BaseModel
    {
        public ICollection<PrintingEditionModelItem> Items = new List<PrintingEditionModelItem>();
        public int Count { get; set; } 
    }
}
