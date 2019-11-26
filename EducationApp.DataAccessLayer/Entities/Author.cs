using EducationApp.DataAccessLayer.Entities.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace EducationApp.DataAccessLayer.Entities
{
    public class Author : BaseEntity
    {
        public string Name { get; set; }
        [NotMapped]
        public IEnumerable<PrintingEdition> PrintingEditions { get; set; }
    }
}
