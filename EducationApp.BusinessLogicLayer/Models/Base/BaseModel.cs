using System.Collections.Generic;

namespace EducationApp.BusinessLogicLayer.Models.Base
{
    public class BaseModel
    {
        public ICollection<string> Errors { get; set; } = new List<string>();
    }
}
