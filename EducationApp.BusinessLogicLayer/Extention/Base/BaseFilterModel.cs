using static EducationApp.BusinessLogicLayer.Models.Enums.Enums;

namespace EducationApp.BusinessLogicLayer.Extention.BaseFilter
{

    public class BaseFilterModel
    {
        public string SearchString { get; set; }
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public SortType SortType { get; set; }
    }
}
