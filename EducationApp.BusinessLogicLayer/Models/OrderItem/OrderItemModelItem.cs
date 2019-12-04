using EducationApp.BusinessLogicLayer.Models.Base;
using static EducationApp.BusinessLogicLayer.Models.Enums.Enums;

namespace EducationApp.BusinessLogicLayer.Models.OrderItemModelItem
{
    public class OrderItemModelItem :BaseModel
    {
        public decimal Amount { get; set; }
        public CurrencyType Currency { get; set; }
        public long PrintingEditionId { get; set; }
        public int Count { get; set; }
        public string PrintingEditionType { get; set; }
        public string PrintingEditionName { get; set; } 
    }
}
