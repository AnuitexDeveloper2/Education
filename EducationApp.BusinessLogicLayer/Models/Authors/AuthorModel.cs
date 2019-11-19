using System;
using System.Collections.Generic;
using System.Text;

namespace EducationApp.BusinessLogicLayer.Models.Authors
{
    public class AuthorModel
    {
        public ICollection<AuthorModelItem> Items = new List<AuthorModelItem>();
    }
}
