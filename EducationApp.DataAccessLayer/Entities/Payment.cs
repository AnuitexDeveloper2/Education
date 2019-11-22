using EducationApp.DataAccessLayer.Entities.Base;
using System;

namespace EducationApp.DataAccessLayer.Entities
{
    public class Payment : BaseEntity
    {
        public long TransactionId { get; set; }
        public DateTime Date { get; set; }
    }
}
