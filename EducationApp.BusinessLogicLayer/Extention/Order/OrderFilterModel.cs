using EducationApp.DataAccessLayer.Helpers.Base;
using System.Collections.Generic;
using static EducationApp.BusinessLogicLayer.Models.Enums.Enums;

namespace EducationApp.BusinessLogicLayer.Extention.Order
{
    public class OrderFilterModel : BaseFilterStatus
    {
        public SortOrder SortOrder { get; set; }
        public List<OrderStatus> StatusOrder  { get; set; }
        public long Id { get; set; }
    }
}
