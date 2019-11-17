using EducationApp.DataAccessLayer.Helpers.Base;
using static EducationApp.DataAccessLayer.Entities.Enums.Enums;

namespace EducationApp.DataAccessLayer.Helpers
{
    public class UsersFilter : BaseFilterModel//todo rename, add BaseFilterModel (SortType, pageNumber and pageSize for paginator, searchString)
    {
        public UsersSortType UsersSortType { get; set; }
        public UsersFilterType UsersFilterType { get; set; }
        //UserStatus prop (enum)
    }
}
