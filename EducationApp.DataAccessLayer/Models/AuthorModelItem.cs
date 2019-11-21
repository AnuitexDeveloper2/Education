using EducationApp.DataAccessLayer.Entities;
using EducationApp.DataAccessLayer.Models.Base;
using System.Collections.Generic;

namespace EducationApp.DataAccessLayer.Models
{
    public class AuthorModelItem : BaseFilterModel<AuthorModelItem>
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<PrintingEdition> printingEditions { get; set; }
    }
}
