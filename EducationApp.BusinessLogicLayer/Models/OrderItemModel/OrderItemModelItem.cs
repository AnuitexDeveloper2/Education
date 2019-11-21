using static EducationApp.BusinessLogicLayer.Models.Enums.Enums;

namespace EducationApp.BusinessLogicLayer.Models.OrderItemModelItem
{
    public class OrderItemModelItem
    {
        public long Id { get; set; }
        public decimal Amount { get; set; }
        public CurrencyType Currency { get; set; }
        public long printingEditionId { get; set; }
        public long OrderId { get; set; }
        public int Count { get; set; }
        public long PrintingEditionId { get; set; }
    }
}
