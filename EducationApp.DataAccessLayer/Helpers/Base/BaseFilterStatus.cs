using static EducationApp.DataAccessLayer.Entities.Enums.Enums;

namespace EducationApp.DataAccessLayer.Helpers.Base
{
    public class BaseFilterStatus
    {
        public string SearchString { get; set; }
        public int PageCount { get; set; }
        public int PageSize { get; set; }
        public SortType SortType { get; set; }
    }
}
