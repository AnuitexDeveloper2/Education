using EducationApp.BusinessLogicLayer.Models.PrintingEditions;
using EducationApp.DataAccessLayer.Entities;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EducationApp.BusinessLogicLayer.Services.Interfaces
{
    public interface IPrintingEditionService
    {
        Task<bool> CreateAsync(PrintingEditionModelItem model);
        Task<bool> RemoveAsync(PrintingEditionModelItem model);
        Task<bool> UpdateAsync(PrintingEditionModelItem model);
        List<PrintingEditionModelItem> PrintingEditionFilter(PrintingEditionModelItem model);
    }
}
