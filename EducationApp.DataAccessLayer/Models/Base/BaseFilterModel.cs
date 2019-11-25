using System;
using System.Collections.Generic;
using System.Text;

namespace EducationApp.DataAccessLayer.Models.Base
{
    public class BaseFilterModel<T> where T : class //todo ResponseModel
    {
        public List<T> Data { get; set; }
        public int Count { get; set; }
    }
}
