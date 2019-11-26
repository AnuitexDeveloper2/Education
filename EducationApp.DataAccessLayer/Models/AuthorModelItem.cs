using EducationApp.DataAccessLayer.Entities;
using EducationApp.DataAccessLayer.Models.Base;
using System.Collections.Generic;

namespace EducationApp.DataAccessLayer.Models
{
    public class AuthorModelItem : ResponseModel<Author>
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public List<PrintingEdition> printingEditions { get; set; }
    }
}
