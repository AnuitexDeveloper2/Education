using EducationApp.DataAccessLayer.Entities;
using EducationApp.DataAccessLayer.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static EducationApp.DataAccessLayer.Entities.Enums.Enums;

namespace EducationApp.DataAccessLayer.Ropositories.Interfaces
{
    public interface IPrintingEditionRepository : IBaseEFRRepository<PrintingEdition>
    {
        List<PrintingEdition> FilterPrintingEditionFilter(TypeProduct typeProduct);
        List<PrintingEdition> FilterPrintingEditionFilter(decimal price);
    }
}
