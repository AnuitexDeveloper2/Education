using EducationApp.DataAccessLayer.Helpers.Base;
using static EducationApp.DataAccessLayer.Entities.Enums.Enums;

namespace EducationApp.DataAccessLayer.Helpers
{
    public class UserFilterModel : BaseFilterModel
    {
        public UserSortType UsersSortType { get; set; }
        public UserFilterType UsersFilterType { get; set; }
    }
}
