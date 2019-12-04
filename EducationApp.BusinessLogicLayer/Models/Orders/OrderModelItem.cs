using EducationApp.BusinessLogicLayer.Models.Base;
using EducationApp.BusinessLogicLayer.Models.OrderItemModelItem;
using System;
using static EducationApp.BusinessLogicLayer.Models.Enums.Enums;

namespace EducationApp.BusinessLogicLayer.Models.Orders
{
    public class OrderModelItem : BaseModel
    {
        public long Id { get; set; }
        public string Description { get; set; }
        public long UserId { get; set; }
        public OrderItemModel OrderItems { get; set; }
        public OrderStatusType Status { get; set; }
        public string TransactionId { get; set; }
        public DateTime Date { get; set; }
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public decimal AmountOrder { get; set; }
    }
}
