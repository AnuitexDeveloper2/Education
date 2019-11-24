using EducationApp.BusinessLogicLayer.Models.Base;
using static EducationApp.BusinessLogicLayer.Models.Enums.Enums;

namespace EducationApp.BusinessLogicLayer.Models.OrderItemModelItem
{
    public class OrderItemModelItem :BaseModel
    {
        public long Id { get; set; }
        public decimal Amount { get; set; }
        public CurrencyType Currency { get; set; }
        public long PrintingEditionId { get; set; }
        public long OrderId { get; set; }
        public int Count { get; set; }
        public OrderStatus Status { get; set; }
    }
}
