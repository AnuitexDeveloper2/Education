using EducationApp.BusinessLogicLayer.Models.OrderItemModelItem;
using EducationApp.BusinessLogicLayer.Models.Payments;
using static EducationApp.BusinessLogicLayer.Models.Enums.Enums;

namespace EducationApp.BusinessLogicLayer.Models.Orders
{
    public class OrdersItemModel
    {
        public long Id { get; set; }
        public string Description { get; set; }
        public long UserId { get; set; }
        public  PaymentsModel PaymentModel { get; set; }
        public OrderItemModel OrderItemModel{get;set;}
        public OrderStatus OrderStatus { get; set; }
       public long TransactionId { get; set; }
    }
}
