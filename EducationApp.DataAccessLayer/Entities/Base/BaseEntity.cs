using System;

namespace EducationApp.DataAccessLayer.Entities.Base
{
    public class BaseEntity
    {
        public long Id { get; set; }
        public bool IsRemoved { get; set; }
        public DateTime Date { get; set; }
    }
}
