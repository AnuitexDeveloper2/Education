using System.Collections.Generic;

namespace EducationApp.BusinessLogicLayer.Models.Authors
{
    public class AuthorsModelItem
    {
        public string Name { get; set; }
        public long Id { get; set; }
        public bool IsRemoved { get; set; }
        public List<AuthorsModelItem> AuthorsModelItems { get; set; }
    }
}
