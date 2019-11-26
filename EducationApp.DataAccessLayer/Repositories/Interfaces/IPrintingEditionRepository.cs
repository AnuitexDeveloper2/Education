using EducationApp.DataAccessLayer.Entities;
using EducationApp.DataAccessLayer.Helpers.PrintingEditionFilter;
using EducationApp.DataAccessLayer.Models;
using EducationApp.DataAccessLayer.Models.Base;
using EducationApp.DataAccessLayer.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static EducationApp.DataAccessLayer.Entities.Enums.Enums;

namespace EducationApp.DataAccessLayer.Ropositories.Interfaces
{
    public interface IPrintingEditionRepository : IBaseEFRRepository<PrintingEdition>
    {
        Task<ResponseModel<PrintingEdition>> GetPrintingEditionsAsync(PrintingEditionFilterModel printingEditionFilterModel);
    }
}
