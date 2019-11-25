using EducationApp.DataAccessLayer.Entities.Base;
using System.Collections.Generic;
using static EducationApp.DataAccessLayer.Entities.Enums.Enums;

namespace EducationApp.DataAccessLayer.Entities
{
    public class Order : BaseEntity
    {
        public string Description { get; set; }
        public long UserId { get; set; }
        public long PaymentId { get; set; }
        public List<OrderItem> OrderItems { get; set; } //todo add NoptMapped, Add User
        public StatusType Status { get; set; } //todo OrderStatusType
        public Payment Payment { get; set; }
    }
}
