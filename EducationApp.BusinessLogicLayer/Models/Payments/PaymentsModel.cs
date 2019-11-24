using EducationApp.BusinessLogicLayer.Models.Base;
using EducationApp.BusinessLogicLayer.Models.OrderItemModelItem;
using System;

namespace EducationApp.BusinessLogicLayer.Models.Payments
{
    public class PaymentsModel : BaseModel
    {
        public long TransactionId { get; set; }
        public DateTime Date { get; set; }
    }
}
