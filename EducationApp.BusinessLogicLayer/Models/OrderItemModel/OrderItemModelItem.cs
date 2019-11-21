using EducationApp.BusinessLogicLayer.Models.Base;
using static EducationApp.BusinessLogicLayer.Models.Enums.Enums;

namespace EducationApp.BusinessLogicLayer.Models.OrderItemModelItem
{
    public class OrderItemModelItem : BaseModel
    {
        public long Amount { get; set; }
        public Currency Currency { get; set; }
        public long Count { get; set; }
        public long OrderId { get; set; }
        public long PrintingEditionId { get; set; }
    }
}
