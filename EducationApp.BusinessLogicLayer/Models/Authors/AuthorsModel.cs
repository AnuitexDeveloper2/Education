using System;
using System.Collections.Generic;
using System.Text;

namespace EducationApp.BusinessLogicLayer.Models.Authors
{
    public class AuthorsModel
    {
        public ICollection<AuthorsModelItem> Items = new List<AuthorsModelItem>();
    }
}
