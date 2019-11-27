using EducationApp.BusinessLogicLayer.Models.Base;
using EducationApp.BusinessLogicLayer.Models.OrderItemModelItem;
using EducationApp.BusinessLogicLayer.Models.Payments;
using System;
using static EducationApp.BusinessLogicLayer.Models.Enums.Enums;

namespace EducationApp.BusinessLogicLayer.Models.Orders
{
    public class OrdersItemModel : BaseModel
    {
        public long Id { get; set; }
        public string Description { get; set; }
        public long UserId { get; set; }
        public PaymentsModel PaymentModel { get; set; }
        public OrderItemModel OrderItemModel { get; set; }
        public OrderStatusType OrderStatus { get; set; }
        public long TransactionId { get; set; }
        public DateTime DateTime { get; set; }
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public decimal AmountOrder { get; set; }
    }
}
