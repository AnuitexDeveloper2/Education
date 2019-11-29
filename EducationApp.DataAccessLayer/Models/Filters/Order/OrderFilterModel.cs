using EducationApp.DataAccessLayer.Helpers.Base;
using EducationApp.DataAccessLayer.Models.Base;
using System.Collections.Generic;
using static EducationApp.DataAccessLayer.Entities.Enums.Enums;

namespace EducationApp.DataAccessLayer.Helpers.OrderFilterModel
{
    public class OrderFilterModel : BaseFilterModel
    {
        public SortOrder SortOrder { get; set; }
        public List< OrderStatusType> StatusOrder { get; set; }
        public long Id { get; set; }
    }
}
