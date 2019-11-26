using EducationApp.DataAccessLayer.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace EducationApp.DataAccessLayer.Entities
{
    public class AuthorInPrintingEdition : BaseEntity
    {
        [ForeignKey("Author")]
        public long AuthorId { get; set; } //todo Add ForeignKey attrs
        [ForeignKey("PrintingEdition")]
        public long PrintingEditionId { get; set; }
        public Author Author { get; set; }
        public PrintingEdition PrintingEdition { get; set; }
    }
}
