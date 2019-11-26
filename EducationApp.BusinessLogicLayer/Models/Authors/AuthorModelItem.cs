using EducationApp.BusinessLogicLayer.Models.Base;
using EducationApp.BusinessLogicLayer.Models.PrintingEditions;
using System.Collections.Generic;

namespace EducationApp.BusinessLogicLayer.Models.Authors
{
    public class AuthorModelItem : BaseModel
    {
        public string Name { get; set; }
        public long Id { get; set; }
        public List<string> BooksTitle { get; set; }
    }
}
