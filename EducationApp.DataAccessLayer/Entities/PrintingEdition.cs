using EducationApp.DataAccessLayer.Entities.Base;
using System.Collections.Generic;
using static EducationApp.DataAccessLayer.Entities.Enums.Enum.EntityEnums;

namespace EducationApp.DataAccessLayer.Entities
{
    public class PrintingEdition : BaseEntity
    {
        public string Title { get; set; }
        public string Desccription { get; set; }
        public decimal Price { get; set; }
        public IList<OrderItem> OrderItems { get; set; }
        public string Currency { get; set; }
        public TypeEnum Type { get; set; }
        public string Status { get; set; }
    }
}
