using EducationApp.BusinessLogicLayer.Models.Base;
using System.Collections.Generic;

namespace EducationApp.BusinessLogicLayer.Models.Authors
{
    public class AuthorModelItem : BaseModel
    {
        public string Name { get; set; }
        public long Id { get; set; }
        public List<string> BookTitles { get; set; }
    }
}
