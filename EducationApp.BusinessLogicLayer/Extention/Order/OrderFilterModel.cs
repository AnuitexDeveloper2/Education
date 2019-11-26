using EducationApp.BusinessLogicLayer.Extention.BaseFilter;
using System.Collections.Generic;
using static EducationApp.BusinessLogicLayer.Models.Enums.Enums;

namespace EducationApp.BusinessLogicLayer.Extention.Order
{
    public class OrderFilterModel : BaseFilterModel
    {
        public SortOrder SortOrder { get; set; }
        public List<OrderStatusType> StatusOrder  { get; set; }
        public long Id { get; set; }
    }
}
