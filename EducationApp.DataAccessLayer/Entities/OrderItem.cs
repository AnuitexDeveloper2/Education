using EducationApp.DataAccessLayer.Entities.Base;
using static EducationApp.DataAccessLayer.Entities.Enums.Enum.EntityEnums;

namespace EducationApp.DataAccessLayer.Entities
{
    public class OrderItem : BaseEntity
    {
        public int Amount { get; set; }
        public CurrencyEnum Currency { get; set; }
        public int PrintingEditionId { get; set; }
        public int OrderId { get; set; }
        public int Count { get; set; }
        public PrintingEdition PrintingEdition { get; set; }
        public Order Orders { get; set; }
    }
}
