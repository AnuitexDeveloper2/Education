using static EducationApp.BusinessLogicLayer.Models.Enums.Enums;

namespace EducationApp.BusinessLogicLayer.Extention.BaseFilter
{

    public class BaseFilterModel
    {
        public string SearchString { get; set; }
        public int PageCount { get; set; }
        public int PageSize { get; set; }
        public SortType SortType { get; set; }
    }
}
