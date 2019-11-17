using EducationApp.BusinessLogicLayer.Extention.PrintingEditionFilterState;
using EducationApp.BusinessLogicLayer.Models.PrintingEditions;
using EducationApp.DataAccessLayer.Entities;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EducationApp.BusinessLogicLayer.Services.Interfaces
{
    public interface IPrintingEditionService
    {
        Task<bool> CreateAsync(PrintingEditionModelItem model);
        Task<bool> RemoveAsync(PrintingEditionModelItem model);
        Task<bool> UpdateAsync(PrintingEditionModelItem model);
        Task< List<PrintingEditionModelItem>> GetPrintingEditionAsync(PrintingEditionFilterState state);
        IQueryable<PrintingEditionModelItem> FilterProductsByName(PrintingEditionModelItem model, string text);
    }
}
