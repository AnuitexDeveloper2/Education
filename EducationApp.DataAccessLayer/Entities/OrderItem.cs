using EducationApp.DataAccessLayer.Entities.Base;
using static EducationApp.DataAccessLayer.Entities.Enums.Enums;

namespace EducationApp.DataAccessLayer.Entities
{
    public class OrderItem : BaseEntity
    {
        public decimal Amount { get; set; }
        public CurrencyType Currency { get; set; }
        public long PrintingEditionId { get; set; }
        public int OrderId { get; set; }
        public int Count { get; set; }
        public PrintingEdition PrintingEdition { get; set; }
        public Order Orders { get; set; }
        public string UserName { get; set; }
    }
}
