using EducationApp.DataAccessLayer.Entities.Base;

namespace EducationApp.DataAccessLayer.Entities
{
    public class AuthorInPrintingEdition : BaseEntity
    {
        public long AuthorId { get; set; }
        public long PrintingEditionId { get; set; }
        public Author Author { get; set; }
        public PrintingEdition PrintingEdition { get; set; }
    }
}
