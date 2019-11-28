using System.Collections.Generic;

namespace EducationApp.DataAccessLayer.Models.Base
{
    public class ResponseModel<T> where T : class //todo ResponseModel
    {
        public List<T> Data { get; set; }
        public int Count { get; set; }
    }
}
