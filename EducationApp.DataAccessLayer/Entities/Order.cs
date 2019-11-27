using EducationApp.DataAccessLayer.Entities.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using static EducationApp.DataAccessLayer.Entities.Enums.Enums;

namespace EducationApp.DataAccessLayer.Entities
{
    public class Order : BaseEntity
    {
        public string Description { get; set; }
        [ForeignKey("User")]
        public long UserId { get; set; }
        [ForeignKey("Payment")]
        public long PaymentId { get; set; }
        [NotMapped]
        public IEnumerable<OrderItem> OrderItems { get; set; } //todo add NoptMapped, Add User
        public OrderStatusType OrderStatusType { get; set; } //todo OrderStatusType
        public Payment Payment { get; set; }
        [NotMapped]
        public decimal Amount { get; set; }
        [NotMapped]
        public int CountOrdersModel { get; set; }
        [NotMapped]
        public string UserName { get; set; }
        [NotMapped]
        public string UserEmail { get; set; }

    }
}
