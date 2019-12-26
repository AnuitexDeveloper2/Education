using EducationApp.DataAccessLayer.Helpers.Base;
using static EducationApp.DataAccessLayer.Entities.Enums.Enums;

namespace EducationApp.DataAccessLayer.Helpers
{
    public class UserFilterModel : BaseFilterModel
    {
        public UsersSortType ColumnType { get; set; }
        public UserFilterType FilterType { get; set; }
    }
}
