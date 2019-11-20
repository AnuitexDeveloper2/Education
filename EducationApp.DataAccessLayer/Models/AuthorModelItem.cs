using EducationApp.DataAccessLayer.Entities;
using System.Collections.Generic;

namespace EducationApp.DataAccessLayer.Models
{
    public class AuthorModelItem
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<PrintingEdition> printingEditions { get; set; }
    }
}
