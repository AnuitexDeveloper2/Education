using EducationApp.DataAccessLayer.Entities.Base;
using System.Collections.Generic;
using static EducationApp.DataAccessLayer.Entities.Enums.Enum.EntityEnums;

namespace EducationApp.DataAccessLayer.Entities
{
    public class Order : BaseEntity
    {
        public string Description { get; set; }
        public long UserId { get; set; }
        public long PaymentId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public List<OrderItem> OrderItems { get; set; }
        public StatusEnum Status { get; set; }
        public Payment Payments { get; set; }
    }
}
