using System;
using static EducationApp.DataAccessLayer.Entities.Enums.Enums;

namespace EducationApp.DataAccessLayer.Models
{
    public class OrderModel
    {
        public long Id { get; set; }
        public TypeProduct TypeProduct { get; set; }
        public decimal Amount { get; set; }
        public int Count { get; set; }
        public string Title { get; set; }
        public StatusType Status { get; set; }
        public DateTime DataTime { get; set; }
    }
}
