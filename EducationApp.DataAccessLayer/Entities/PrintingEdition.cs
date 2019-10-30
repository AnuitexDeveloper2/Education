using EducationApp.DataAccessLayer.Entities.Base;
using static EducationApp.DataAccessLayer.Entities.Enums.Enums;

namespace EducationApp.DataAccessLayer.Entities
{
    public class PrintingEdition : BaseEntity
    {
        public string Title { get; set; }
        public string Desccription { get; set; }
        public decimal Price { get; set; }
        public CurrencyType CurrencyType { get; set; }
        public TypeProduct Type { get; set; }
    }
}
