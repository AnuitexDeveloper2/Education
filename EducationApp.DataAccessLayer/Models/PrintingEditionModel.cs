using EducationApp.DataAccessLayer.Entities;
using EducationApp.DataAccessLayer.Models.Base;
using System.Collections.Generic;
using static EducationApp.DataAccessLayer.Entities.Enums.Enums;

namespace EducationApp.DataAccessLayer.Models
{
    public class PrintingEditionModel : BaseFilterModel<Author>
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Desccription { get; set; }
        public decimal Price { get; set; }
        public CurrencyType CurrencyType { get; set; }
        public TypeProduct ProductType { get; set; }
    }
}
