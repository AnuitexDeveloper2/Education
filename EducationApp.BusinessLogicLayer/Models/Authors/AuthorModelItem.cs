using EducationApp.BusinessLogicLayer.Models.PrintingEditions;
using System.Collections.Generic;

namespace EducationApp.BusinessLogicLayer.Models.Authors
{
    public class AuthorModelItem
    {
        public string Name { get; set; }
        public long Id { get; set; }
        public bool IsRemoved { get; set; }
        public PrintingEditionModel PrintingEditions { get; set; }
    }
}
