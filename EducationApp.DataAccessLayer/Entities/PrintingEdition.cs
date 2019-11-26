using EducationApp.DataAccessLayer.Entities.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using static EducationApp.DataAccessLayer.Entities.Enums.Enums;

namespace EducationApp.DataAccessLayer.Entities
{
    public class PrintingEdition : BaseEntity
    {
        public string Title { get; set; }
        public string Desccription { get; set; }
        public decimal Price { get; set; }
        public CurrencyType CurrencyType { get; set; }
        public TypeProduct ProductType { get; set; }
        [NotMapped]
        public IEnumerable<Author> Authors { get; set; }

    }
}
