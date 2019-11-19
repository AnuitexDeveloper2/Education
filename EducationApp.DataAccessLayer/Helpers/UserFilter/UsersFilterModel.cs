using EducationApp.DataAccessLayer.Helpers.Base;
using static EducationApp.DataAccessLayer.Entities.Enums.Enums;

namespace EducationApp.DataAccessLayer.Helpers
{
    public class UsersFilterModel : BaseFilterModel//todo rename to UserFilterModel
    {
        public UsersSortType UsersSortType { get; set; }
        public UsersFilterType UsersFilterType { get; set; }
    }
}
