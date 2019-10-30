using EducationApp.DataAccessLayer.Entities.Base;
using static EducationApp.DataAccessLayer.Entities.Enums.Enums;

namespace EducationApp.DataAccessLayer.Entities
{
    public class OrderItems : BaseEntity
    {
        public int Amount { get; set; }
        public CurrencyType Currency { get; set; }
        public int PrintingEditionId { get; set; }
        public int OrderId { get; set; }
        public int Count { get; set; }
        public PrintingEdition PrintingEdition { get; set; }
        public Order Orders { get; set; }
    }
}
