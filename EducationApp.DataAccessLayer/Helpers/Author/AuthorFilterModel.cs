using EducationApp.DataAccessLayer.Helpers.Base;
using static EducationApp.DataAccessLayer.Entities.Enums.Enums;

namespace EducationApp.DataAccessLayer.Helpers.Author
{
    public class AuthorFilterModel : BaseFilterStatus
    {
        public AuthorSortById SortById { get; set; }
    }
}
