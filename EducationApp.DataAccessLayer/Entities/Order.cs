using EducationApp.DataAccessLayer.Entities.Base;
using System;
using System.Collections.Generic;
using static EducationApp.DataAccessLayer.Entities.Enums.Enums;

namespace EducationApp.DataAccessLayer.Entities
{
    public class Order : BaseEntity
    {
        public string Description { get; set; }
        public long UserId { get; set; }
        public long PaymentId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public List<OrderItem> OrderItems { get; set; }
        public StatusType Status { get; set; }
        public Payment Payment { get; set; }
    }
}
