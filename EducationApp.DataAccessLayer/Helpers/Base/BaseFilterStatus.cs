using static EducationApp.DataAccessLayer.Entities.Enums.Enums;

namespace EducationApp.DataAccessLayer.Helpers.Base
{
    public class BaseFilterStatus
    {
        public string SearchString { get; set; }
        public int PageNumber { get; set; } //todo update: use PageSize(count of items on one page) and PageNumber (for exumple page number 3) 
        public int PageSize { get; set; }
        public SortType SortType { get; set; }
    }
}
