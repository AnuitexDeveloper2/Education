using EducationApp.BusinessLogicLayer.Models.Base;
using EducationApp.BusinessLogicLayer.Models.OrderItemModelItem;
using EducationApp.BusinessLogicLayer.Models.Payments;
using System;
using static EducationApp.BusinessLogicLayer.Models.Enums.Enums;

namespace EducationApp.BusinessLogicLayer.Models.Orders
{
    public class OrderModelItem : BaseModel //todo OrderModelItem
    {
        public long Id { get; set; }
        public string Description { get; set; }
        public long UserId { get; set; }
        public OrderItemModel OrderItems { get; set; } //todo rename prop OrderItems, 
        public OrderStatusType Status { get; set; } //todo rename prop to Staus
        public string TransactionId { get; set; }
        public DateTime Date { get; set; } //todo CreationDate od Date
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public decimal AmountOrder { get; set; }
    }
}
